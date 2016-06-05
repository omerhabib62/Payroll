﻿using Payroll.Common.Extension;
using Payroll.Entities;
using Payroll.Entities.Enums;
using Payroll.Entities.Payroll;
using Payroll.Infrastructure.Implementations;
using Payroll.Infrastructure.Interfaces;
using Payroll.Repository.Interface;
using Payroll.Repository.Repositories;
using Payroll.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Service.Implementations
{
    public class EmployeeDailyPayrollService : IEmployeeDailyPayrollService
    {
        private IUnitOfWork _unitOfWork;
        private ITotalEmployeeHoursService _totalEmployeeHoursService;
        private IEmployeeWorkScheduleService _employeeWorkScheduleService;
        private IHolidayService _holidayService;
        private ISettingService _settingService;
        private IEmployeeInfoService _employeeInfoService;
        private IEmployeeSalaryService _employeeSalaryService;

        private IEmployeeDailyPayrollRepository _employeeDailyPayrollRepository;

        private readonly String RATE_REST_DAY = "RATE_REST_DAY";
        private readonly String RATE_OT = "RATE_OT";
        private readonly String RATE_NIGHTDIF = "RATE_NIGHTDIF";
        private readonly String RATE_HOLIDAY_SPECIAL = "RATE_HOLIDAY_SPECIAL";
        private readonly String RATE_HOLIDAY_REGULAR = "RATE_HOLIDAY_REGULAR";
        private readonly String PAYROLL_REGULAR_HOURS = "PAYROLL_REGULAR_HOURS";

        public EmployeeDailyPayrollService(IUnitOfWork unitOfWork, ITotalEmployeeHoursService totalEmployeeHoursService, 
            IEmployeeWorkScheduleService employeeWorkScheduleService, IHolidayService holidayService, ISettingService settingService, 
            IEmployeeDailyPayrollRepository employeeDailyPayrollRepository, IEmployeeInfoService employeeInfoService, IEmployeeSalaryService employeeSalaryService)
        {
            _unitOfWork = unitOfWork;
            _totalEmployeeHoursService = totalEmployeeHoursService;
            _employeeWorkScheduleService = employeeWorkScheduleService;
            _holidayService = holidayService;
            _settingService = settingService;
            _employeeInfoService = employeeInfoService;
            _employeeDailyPayrollRepository = employeeDailyPayrollRepository;
            _employeeSalaryService = employeeSalaryService;
        } 

        /*Note that this method is applicable to employees with hourly rate*/
        public void GenerateEmployeeDailySalaryByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            IList<TotalEmployeeHours> totalEmployeeHours = 
                _totalEmployeeHoursService.GetByDateRange(dateFrom, dateTo);

            Double restDayRate = Double.Parse(_settingService.GetByKey(RATE_REST_DAY));
            Double OTRate = Double.Parse(_settingService.GetByKey(RATE_OT));
            Double nightDiffRate = Double.Parse(_settingService.GetByKey(RATE_NIGHTDIF));
            Double holidayRegularRate = Double.Parse(_settingService.GetByKey(RATE_HOLIDAY_REGULAR));
            Double holidateSpecialRate = Double.Parse(_settingService.GetByKey(RATE_HOLIDAY_SPECIAL));

            foreach (TotalEmployeeHours totalHours in totalEmployeeHours)
            {
                EmployeeInfo employeeInfo = _employeeInfoService.GetByEmployeeId(totalHours.EmployeeId);

                var hourlyRate = _employeeSalaryService.GetEmployeeHourlyRate(employeeInfo);

                var employeeWorkSchedule =
                   _employeeWorkScheduleService.GetByEmployeeId(totalHours.EmployeeId);
                //No work schedule, no computation
                if (employeeWorkSchedule != null)
                {
                    var workSchedule = employeeWorkSchedule.WorkSchedule;

                    DateTime date = totalHours.Date;

                    Double rateMultiplier = 1;

                    //Check if rest day
                    if (date.IsRestDay(workSchedule.WeekStart, workSchedule.WeekEnd))
                    {
                        rateMultiplier += restDayRate;
                    }

                    Holiday holiday = _holidayService.GetHoliday(date);
                    //Check if holiday 
                    if (holiday != null)
                    {
                        if (holiday.IsRegularHoliday)
                        {
                            rateMultiplier += holidayRegularRate;
                        }
                        else
                        {
                            rateMultiplier += holidateSpecialRate;
                        }
                    }
                    //if OT
                    if (totalHours.Type == RateType.OverTime)
                    {
                        rateMultiplier += OTRate;
                    }

                    decimal totalPayment = 0;

                    //if NightDif
                    if (totalHours.Type == RateType.NightDifferential)
                    {
                        //rateMultiplier += nightDiffRate;
                        if (rateMultiplier > 1)
                        {
                            totalPayment = (((decimal)(totalHours.Hours * (rateMultiplier - 1))) * hourlyRate);
                        }
                        totalPayment += (decimal)(nightDiffRate * totalHours.Hours);
                    }
                    else
                    {
                        totalPayment = ((decimal)(totalHours.Hours * rateMultiplier)) * hourlyRate;
                    }

                    var employeeDailySalary = new EmployeeDailyPayroll
                    {
                        EmployeeId = totalHours.EmployeeId,
                        Date = totalHours.Date,
                        TotalPay = totalPayment,
                        TotalEmployeeHoursId = totalHours.TotalEmployeeHoursId,
                        RateType = totalHours.Type
                    };

                    //Save
                    _employeeDailyPayrollRepository.Add(employeeDailySalary);
                    // _unitOfWork.Commit();
                }

                _unitOfWork.Commit();

                //Generate holiday pays
                GenerateEmployeeHolidayPay(dateFrom, dateTo);
                _unitOfWork.Commit();
            }
        }

        public IList<EmployeeDailyPayroll> GetByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            dateTo = dateTo.AddDays(1);
            return _employeeDailyPayrollRepository.GetByDateRange(dateFrom, dateTo);
        }

        public void GenerateEmployeeHolidayPay(DateTime payrollStartDate, DateTime payrollEndDate)
        {
            //Get all active employees
            IList<EmployeeInfo> employees = _employeeInfoService.GetAllActive();

            foreach (DateTime day in DatetimeExtension.EachDay(payrollStartDate, payrollEndDate))
            {
                //Check if holiday
                var holiday = _holidayService.GetHoliday(day);

                if (holiday != null)
                {
                    foreach (EmployeeInfo employee in employees)
                    {
                        WorkSchedule workSchedule =_employeeWorkScheduleService.GetByEmployeeId(employee.EmployeeId).WorkSchedule;

                        if (workSchedule != null)
                        {
                            //Check if within schedule
                            if (day.IsRestDay(workSchedule.WeekStart, workSchedule.WeekEnd))
                            {
                                //Don't proceed
                                return;
                            }
                        }

                        //If with schedule on this date, generate holiday pay

                        //Check if already have daily entry
                        EmployeeDailyPayroll dailyPayroll = _employeeDailyPayrollRepository.GetByDate(employee.EmployeeId, day);

                        int workHours = Convert.ToInt32(_settingService.GetByKey(PAYROLL_REGULAR_HOURS));

                        //If null create a holiday pay
                        if (dailyPayroll == null)
                        {
                            var hourlyRate = _employeeSalaryService.GetEmployeeHourlyRate(employee);

                            EmployeeDailyPayroll newDailyPayroll = new EmployeeDailyPayroll
                            {
                                EmployeeId = employee.EmployeeId,
                                Date = day,
                                TotalPay = hourlyRate * workHours,
                                RateType = RateType.Regular
                            };

                            _employeeDailyPayrollRepository.Add(newDailyPayroll);
                        }
                    }
                }             
            }
        }

        public IList<EmployeeDailyPayroll> GetByTypeAndDateRange(RateType rateType, DateTime dateFrom, DateTime dateTo)
        {
            dateTo = dateTo.AddDays(1);
            return _employeeDailyPayrollRepository.GetByTypeAndDateRange(rateType, dateFrom, dateTo);
        }
    }
}
