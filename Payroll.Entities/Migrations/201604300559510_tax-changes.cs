namespace Payroll.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taxchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "attendance_log",
                c => new
                    {
                        AttendanceLogId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ClockInOut = c.DateTime(nullable: false, precision: 0),
                        Type = c.Int(nullable: false),
                        IsRecorded = c.Boolean(nullable: false),
                        IsConsidered = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.AttendanceLogId);
            
            CreateTable(
                "attendance",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ClockIn = c.DateTime(nullable: false, precision: 0),
                        ClockOut = c.DateTime(precision: 0),
                        IsManuallyEdited = c.Boolean(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "employee",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeCode = c.String(maxLength: 250, storeType: "nvarchar"),
                        FirstName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        LastName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        MiddleName = c.String(maxLength: 50, storeType: "nvarchar"),
                        NickName = c.String(maxLength: 100, storeType: "nvarchar"),
                        BirthDate = c.DateTime(nullable: false, precision: 0),
                        Picture = c.String(maxLength: 500, storeType: "nvarchar"),
                        Gender = c.Int(nullable: false),
                        Privilege = c.Int(nullable: false),
                        EnrolledToRfid = c.Boolean(nullable: false),
                        EnrolledToBiometrics = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "deduction_amount",
                c => new
                    {
                        DeductionAmountId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50, storeType: "nvarchar"),
                        DeductionId = c.Int(nullable: false),
                        Frequency = c.Int(nullable: false),
                        MinBaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaxBaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPercentage = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.DeductionAmountId);
            
            CreateTable(
                "deduction",
                c => new
                    {
                        DeductionId = c.Int(nullable: false, identity: true),
                        DeductionName = c.String(maxLength: 50, storeType: "nvarchar"),
                        Remarks = c.String(maxLength: 2500, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.DeductionId);
            
            CreateTable(
                "department_manager",
                c => new
                    {
                        DepartmentManagerId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.DepartmentManagerId);
            
            CreateTable(
                "department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 250, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "employee_adjustment",
                c => new
                    {
                        AdjustmentId = c.Int(nullable: false, identity: true),
                        AdjustmentTypeId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(maxLength: 5000, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.AdjustmentId);
            
            CreateTable(
                "employee_daily_payroll",
                c => new
                    {
                        EmployeeDailySalaryId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TotalEmployeeHoursId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        TotalPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeDailySalaryId);
            
            CreateTable(
                "employee_deduction",
                c => new
                    {
                        EmployeeDeductionId = c.Int(nullable: false, identity: true),
                        DeductionId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeDeductionId);
            
            CreateTable(
                "employee_department",
                c => new
                    {
                        EmployeeDepartmentId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeDepartmentId);
            
            CreateTable(
                "employee_files",
                c => new
                    {
                        EmployeeFileId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeFileId);
            
            CreateTable(
                "employee_hours",
                c => new
                    {
                        EmployeeHoursId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Hours = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        OriginAttendanceId = c.Int(nullable: false),
                        IsIncludedInTotal = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeHoursId)
                .ForeignKey("employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "employee_info",
                c => new
                    {
                        EmploymentInfoId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PaymentFrequencyId = c.Int(),
                        PositionId = c.Int(),
                        EmployeeSalaryId = c.Int(),
                        Allowance = c.Decimal(precision: 18, scale: 2),
                        TIN = c.String(maxLength: 50, storeType: "nvarchar"),
                        SSS = c.String(maxLength: 50, storeType: "nvarchar"),
                        GSIS = c.String(maxLength: 50, storeType: "nvarchar"),
                        PAGIBIG = c.String(maxLength: 50, storeType: "nvarchar"),
                        PhilHealth = c.String(maxLength: 50, storeType: "nvarchar"),
                        Dependents = c.Int(nullable: false),
                        Married = c.Boolean(nullable: false),
                        DateHired = c.DateTime(nullable: false, precision: 0),
                        EmploymentStatus = c.Int(nullable: false),
                        CustomDate1 = c.DateTime(precision: 0),
                        CustomDate2 = c.DateTime(precision: 0),
                        CustomString1 = c.String(maxLength: 250, storeType: "nvarchar"),
                        CustomString2 = c.String(maxLength: 250, storeType: "nvarchar"),
                        CustomDecimal1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomDecimal2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmploymentInfoId)
                .ForeignKey("employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("employee_salary", t => t.EmployeeSalaryId)
                .ForeignKey("payment_frequency", t => t.PaymentFrequencyId)
                .Index(t => t.EmployeeId)
                .Index(t => t.PaymentFrequencyId)
                .Index(t => t.EmployeeSalaryId);
            
            CreateTable(
                "employee_salary",
                c => new
                    {
                        EmploymentSalaryId = c.Int(nullable: false, identity: true),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalaryFrequency = c.Int(nullable: false),
                        EmployeeInfoId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmploymentSalaryId);
            
            CreateTable(
                "payment_frequency",
                c => new
                    {
                        PaymentFrequencyId = c.Int(nullable: false, identity: true),
                        FrequencyId = c.Int(nullable: false),
                        FrequencyType = c.Int(nullable: false),
                        WeeklyStartDayOfWeek = c.Int(),
                        MonthlyStartDay = c.Int(),
                        MonthlyEndDay = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.PaymentFrequencyId)
                .ForeignKey("frequency", t => t.FrequencyId, cascadeDelete: true)
                .Index(t => t.FrequencyId);
            
            CreateTable(
                "frequency",
                c => new
                    {
                        FrequencyId = c.Int(nullable: false, identity: true),
                        FrequencyName = c.String(maxLength: 50, storeType: "nvarchar"),
                        FrequencyType = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.FrequencyId);
            
            CreateTable(
                "employee_leave",
                c => new
                    {
                        EmployeeLeaveId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeaveId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Reason = c.String(maxLength: 5000, storeType: "nvarchar"),
                        IsApproved = c.Boolean(nullable: false),
                        Id = c.String(maxLength: 128, storeType: "nvarchar"),
                        Hours = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeLeaveId)
                .ForeignKey("leave", t => t.LeaveId, cascadeDelete: true)
                .ForeignKey("AspNetUsers", t => t.Id)
                .Index(t => t.LeaveId)
                .Index(t => t.Id);
            
            CreateTable(
                "leave",
                c => new
                    {
                        LeaveId = c.Int(nullable: false, identity: true),
                        LeaveName = c.String(maxLength: 250, storeType: "nvarchar"),
                        IsRefundable = c.Boolean(nullable: false),
                        Count = c.Int(nullable: false),
                        Description = c.String(maxLength: 2500, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.LeaveId);
            
            CreateTable(
                "AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserName = c.String(maxLength: 250, storeType: "nvarchar"),
                        PasswordHash = c.String(maxLength: 500, storeType: "nvarchar"),
                        SecurityStamp = c.String(maxLength: 500, storeType: "nvarchar"),
                        Discriminator = c.String(maxLength: 500, storeType: "nvarchar"),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "employee_loan",
                c => new
                    {
                        EmployeeLoanId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LoanId = c.Int(nullable: false),
                        FrequencyId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanDate = c.DateTime(nullable: false, precision: 0),
                        StartDate = c.DateTime(nullable: false, precision: 0),
                        EndDate = c.DateTime(nullable: false, precision: 0),
                        PaymentStartDate = c.DateTime(nullable: false, precision: 0),
                        WeeklyPaymentDayOfWeek = c.Int(nullable: false),
                        BiMonthlyPaymentFirstDate = c.Int(nullable: false),
                        BiMonthlyPaymentSecondDate = c.Int(nullable: false),
                        MonthlyPaymentDate = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeLoanId)
                .ForeignKey("employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("loan", t => t.LoanId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.LoanId);
            
            CreateTable(
                "loan",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        LoanName = c.String(maxLength: 50, storeType: "nvarchar"),
                        Min = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Interest = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanPeriod = c.Int(nullable: false),
                        LoanPeriodNumber = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.LoanId);
            
            CreateTable(
                "payroll",
                c => new
                    {
                        PayrollId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TotalNet = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalGross = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAdjustment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayrollDate = c.DateTime(nullable: false, precision: 0),
                        CutOffStartDate = c.DateTime(nullable: false, precision: 0),
                        CutOffEndDate = c.DateTime(nullable: false, precision: 0),
                        PayrollGeneratedDate = c.DateTime(nullable: false, precision: 0),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.PayrollId);
            
            CreateTable(
                "employee_payroll_deduction",
                c => new
                    {
                        EmployeePayrollDeductionId = c.Int(nullable: false, identity: true),
                        DeductionId = c.Int(nullable: false),
                        PayrollDate = c.DateTime(nullable: false, precision: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeePayrollDeductionId);
            
            CreateTable(
                "employee_workschedule",
                c => new
                    {
                        EmployeeWorkScheduleId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        WorkScheduleId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.EmployeeWorkScheduleId)
                .ForeignKey("employee", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("work_schedule", t => t.WorkScheduleId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.WorkScheduleId);
            
            CreateTable(
                "work_schedule",
                c => new
                    {
                        WorkScheduleId = c.Int(nullable: false, identity: true),
                        WorkScheduleName = c.String(maxLength: 250, storeType: "nvarchar"),
                        TimeStart = c.Time(nullable: false, precision: 0),
                        TimeEnd = c.Time(nullable: false, precision: 0),
                        WeekStart = c.Int(nullable: false),
                        WeekEnd = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.WorkScheduleId);
            
            CreateTable(
                "files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 250, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "holiday",
                c => new
                    {
                        HolidayId = c.Int(nullable: false, identity: true),
                        HolidayName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        IsRegularHoliday = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Year = c.Int(nullable: false),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.HolidayId);
            
            CreateTable(
                "loan_payment",
                c => new
                    {
                        LoanPaymentId = c.Int(nullable: false, identity: true),
                        EmployeeLoanId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false, precision: 0),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.LoanPaymentId);
            
            CreateTable(
                "positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionName = c.String(maxLength: 150, storeType: "nvarchar"),
                        Description = c.String(maxLength: 1000, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "AspNetRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Id = c.String(maxLength: 250, storeType: "nvarchar"),
                        Name = c.String(maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "schedule",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        StartDay = c.Int(nullable: false),
                        EndDay = c.Int(nullable: false),
                        Timeperiod = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false, precision: 0),
                        EndTime = c.DateTime(nullable: false, precision: 0),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
            CreateTable(
                "settings",
                c => new
                    {
                        SettingId = c.Int(nullable: false, identity: true),
                        SettingKey = c.String(maxLength: 250, storeType: "nvarchar"),
                        Value = c.String(maxLength: 5000, storeType: "nvarchar"),
                        Description = c.String(maxLength: 500, storeType: "nvarchar"),
                        Category = c.String(maxLength: 250, storeType: "nvarchar"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.SettingId);
            
            CreateTable(
                "tax",
                c => new
                    {
                        TaxId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50, storeType: "nvarchar"),
                        Frequency = c.Int(nullable: false),
                        NoOfDependents = c.Int(nullable: false),
                        BaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseTaxAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OverPercentage = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.TaxId);
            
            CreateTable(
                "employee_hours_total",
                c => new
                    {
                        TotalEmployeeHoursId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Hours = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, precision: 0),
                        UpdateDate = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.TotalEmployeeHoursId);
            
            CreateTable(
                "AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(maxLength: 500, storeType: "nvarchar"),
                        ClaimValue = c.String(maxLength: 500, storeType: "nvarchar"),
                        User_Id = c.String(maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "AspNetUserLogins",
                c => new
                    {
                        UserLoginId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(maxLength: 250, storeType: "nvarchar"),
                        LoginProvider = c.String(maxLength: 500, storeType: "nvarchar"),
                        ProviderKey = c.String(maxLength: 500, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserLoginId);
            
            CreateTable(
                "AspNetUserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 250, storeType: "nvarchar"),
                        RoleId = c.String(maxLength: 250, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UserRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("employee_workschedule", "WorkScheduleId", "work_schedule");
            DropForeignKey("employee_workschedule", "EmployeeId", "employee");
            DropForeignKey("employee_loan", "LoanId", "loan");
            DropForeignKey("employee_loan", "EmployeeId", "employee");
            DropForeignKey("employee_leave", "Id", "AspNetUsers");
            DropForeignKey("employee_leave", "LeaveId", "leave");
            DropForeignKey("employee_info", "PaymentFrequencyId", "payment_frequency");
            DropForeignKey("payment_frequency", "FrequencyId", "frequency");
            DropForeignKey("employee_info", "EmployeeSalaryId", "employee_salary");
            DropForeignKey("employee_info", "EmployeeId", "employee");
            DropForeignKey("employee_hours", "EmployeeId", "employee");
            DropForeignKey("attendance", "EmployeeId", "employee");
            DropIndex("employee_workschedule", new[] { "WorkScheduleId" });
            DropIndex("employee_workschedule", new[] { "EmployeeId" });
            DropIndex("employee_loan", new[] { "LoanId" });
            DropIndex("employee_loan", new[] { "EmployeeId" });
            DropIndex("employee_leave", new[] { "Id" });
            DropIndex("employee_leave", new[] { "LeaveId" });
            DropIndex("payment_frequency", new[] { "FrequencyId" });
            DropIndex("employee_info", new[] { "EmployeeSalaryId" });
            DropIndex("employee_info", new[] { "PaymentFrequencyId" });
            DropIndex("employee_info", new[] { "EmployeeId" });
            DropIndex("employee_hours", new[] { "EmployeeId" });
            DropIndex("attendance", new[] { "EmployeeId" });
            DropTable("AspNetUserRoles");
            DropTable("AspNetUserLogins");
            DropTable("AspNetUserClaims");
            DropTable("employee_hours_total");
            DropTable("tax");
            DropTable("settings");
            DropTable("schedule");
            DropTable("AspNetRoles");
            DropTable("positions");
            DropTable("loan_payment");
            DropTable("holiday");
            DropTable("files");
            DropTable("work_schedule");
            DropTable("employee_workschedule");
            DropTable("employee_payroll_deduction");
            DropTable("payroll");
            DropTable("loan");
            DropTable("employee_loan");
            DropTable("AspNetUsers");
            DropTable("leave");
            DropTable("employee_leave");
            DropTable("frequency");
            DropTable("payment_frequency");
            DropTable("employee_salary");
            DropTable("employee_info");
            DropTable("employee_hours");
            DropTable("employee_files");
            DropTable("employee_department");
            DropTable("employee_deduction");
            DropTable("employee_daily_payroll");
            DropTable("employee_adjustment");
            DropTable("department");
            DropTable("department_manager");
            DropTable("deduction");
            DropTable("deduction_amount");
            DropTable("employee");
            DropTable("attendance");
            DropTable("attendance_log");
        }
    }
}