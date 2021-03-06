﻿using Payroll.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Service.Interfaces
{
    public interface IEmployeePayrollAllowanceService
    {
        decimal ComputeEmployeeAllowance(int totalDays, int totalWorkHoursPerDay,
            EmployeeInfo employee, DateTime payrollStartDate, DateTime payrollEndDate);

        bool proceedAllowance(DateTime payrollStartDate, DateTime payrollEndDate);
    }
}
