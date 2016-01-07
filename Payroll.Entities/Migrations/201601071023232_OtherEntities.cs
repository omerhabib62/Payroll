namespace Payroll.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtherEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_deduction",
                c => new
                    {
                        DeductionId = c.Int(nullable: false, identity: true),
                        DeductionName = c.String(maxLength: 50),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.DeductionId);
            
            CreateTable(
                "dbo.tbl_department_manager",
                c => new
                    {
                        DepartmentManagerId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        ManagerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentManagerId);
            
            CreateTable(
                "dbo.tbl_department",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.tbl_employee_adjustment",
                c => new
                    {
                        AdjustmentId = c.Int(nullable: false, identity: true),
                        AdjustmentTypeId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.AdjustmentId);
            
            CreateTable(
                "dbo.tbl_employee_department",
                c => new
                    {
                        EmployeeDepartmentId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeDepartmentId);
            
            CreateTable(
                "dbo.tbl_employee_files",
                c => new
                    {
                        EmployeeFileId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        FileId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeFileId);
            
            CreateTable(
                "dbo.tbl_employee_info",
                c => new
                    {
                        EmploymentInfoId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        PaymentFrequencyId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Allowance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TIN = c.String(maxLength: 50),
                        SSS = c.String(maxLength: 50),
                        GSIS = c.String(maxLength: 50),
                        PAGIBIG = c.String(maxLength: 50),
                        PhilHealth = c.String(maxLength: 50),
                        Dependents = c.Int(nullable: false),
                        Married = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EmploymentInfoId);
            
            CreateTable(
                "dbo.tbl_employee_leave",
                c => new
                    {
                        EmployeeLeaveId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LeaveId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Reason = c.String(),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovedBy = c.Int(nullable: false),
                        Hours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeLeaveId);
            
            CreateTable(
                "dbo.tbl_employee_loan",
                c => new
                    {
                        EmployeeLoanId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        LoanId = c.Int(nullable: false),
                        FrequencyId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanDate = c.DateTime(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        PaymentStartDate = c.DateTime(nullable: false),
                        WeeklyPaymentDayOfWeek = c.DateTime(nullable: false),
                        BiMonthlyPaymentFirstDate = c.DateTime(nullable: false),
                        BiMonthlyPaymentSecondDate = c.DateTime(nullable: false),
                        MonthlyPaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeLoanId);
            
            CreateTable(
                "dbo.tbl_employee_workschedule",
                c => new
                    {
                        EmployeeWorkScheduleId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        WorkScheduleId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeWorkScheduleId);
            
            CreateTable(
                "dbo.tbl_files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.tbl_frequency",
                c => new
                    {
                        FrequencyId = c.Int(nullable: false, identity: true),
                        FrequencyName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.FrequencyId);
            
            CreateTable(
                "dbo.tbl_holiday",
                c => new
                    {
                        HolidayId = c.Int(nullable: false, identity: true),
                        HolidayName = c.String(maxLength: 50),
                        IsRegularHoliday = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HolidayId);
            
            CreateTable(
                "dbo.tbl_leave",
                c => new
                    {
                        LeaveId = c.Int(nullable: false, identity: true),
                        LeaveName = c.String(maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        IsRefundable = c.Boolean(nullable: false),
                        Count = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LeaveId);
            
            CreateTable(
                "dbo.tbl_loan_payment",
                c => new
                    {
                        LoanPaymentId = c.Int(nullable: false, identity: true),
                        EmployeeLoanId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LoanPaymentId);
            
            CreateTable(
                "dbo.tbl_loan",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        LoanName = c.String(maxLength: 50),
                        Min = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Interest = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.LoanId);
            
            CreateTable(
                "dbo.tbl_payment_frequency",
                c => new
                    {
                        PaymentFrequencyId = c.Int(nullable: false, identity: true),
                        FrequencyId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        WeeklyStartDayOfWeek = c.Int(nullable: false),
                        MonthlyStartDay = c.Int(nullable: false),
                        MonthlyEndDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentFrequencyId);
            
            CreateTable(
                "dbo.tbl_payroll",
                c => new
                    {
                        PayrollId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAdjustment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PayrollDate = c.DateTime(nullable: false),
                        CutOffStartDate = c.DateTime(nullable: false),
                        CutOffEndDate = c.DateTime(nullable: false),
                        PayrollGeneratedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PayrollId);
            
            CreateTable(
                "dbo.tbl_positions",
                c => new
                    {
                        PositionId = c.Int(nullable: false, identity: true),
                        PositionName = c.String(maxLength: 150),
                        Description = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PositionId);
            
            CreateTable(
                "dbo.tbl_schedule",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        StartDay = c.Int(nullable: false),
                        EndDay = c.Int(nullable: false),
                        Timeperiod = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId);
            
            CreateTable(
                "dbo.tbl_settings",
                c => new
                    {
                        SettingKey = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.String(),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.SettingKey);
            
            CreateTable(
                "dbo.tbl_tax",
                c => new
                    {
                        TaxId = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 50),
                        Frequency = c.Int(nullable: false),
                        NoOfDependents = c.Int(nullable: false),
                        BaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OverPercentage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaxId);
            
            CreateTable(
                "dbo.tbl_work_schedule",
                c => new
                    {
                        WorkScheduleId = c.Int(nullable: false, identity: true),
                        WorkScheduleName = c.String(maxLength: 250),
                        TimeStart = c.Int(nullable: false),
                        TimeEnd = c.Int(nullable: false),
                        WeekStart = c.Int(nullable: false),
                        WeekEnd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkScheduleId);
            
            DropTable("dbo.tbl_users");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbl_users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            DropTable("dbo.tbl_work_schedule");
            DropTable("dbo.tbl_tax");
            DropTable("dbo.tbl_settings");
            DropTable("dbo.tbl_schedule");
            DropTable("dbo.tbl_positions");
            DropTable("dbo.tbl_payroll");
            DropTable("dbo.tbl_payment_frequency");
            DropTable("dbo.tbl_loan");
            DropTable("dbo.tbl_loan_payment");
            DropTable("dbo.tbl_leave");
            DropTable("dbo.tbl_holiday");
            DropTable("dbo.tbl_frequency");
            DropTable("dbo.tbl_files");
            DropTable("dbo.tbl_employee_workschedule");
            DropTable("dbo.tbl_employee_loan");
            DropTable("dbo.tbl_employee_leave");
            DropTable("dbo.tbl_employee_info");
            DropTable("dbo.tbl_employee_files");
            DropTable("dbo.tbl_employee_department");
            DropTable("dbo.tbl_employee_adjustment");
            DropTable("dbo.tbl_department");
            DropTable("dbo.tbl_department_manager");
            DropTable("dbo.tbl_deduction");
        }
    }
}
