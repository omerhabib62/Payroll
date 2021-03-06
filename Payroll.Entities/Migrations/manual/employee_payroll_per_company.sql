CREATE TABLE `employee_payroll_per_company` (
  `EmployeePayrollPerCompanyId` int(11) NOT NULL,
  `CompanyId` int(11) DEFAULT NULL,
  `PayrollId` int(11) DEFAULT NULL,
  `EmployeeId` int(11) DEFAULT NULL,
  `TotalNet` decimal(18,2) DEFAULT NULL,
  `TotalGross` decimal(18,2) DEFAULT NULL,
  `TotalDeduction` decimal(18,2) DEFAULT NULL,
  `TaxableIncome` decimal(18,2) DEFAULT NULL,
  `TotalAdjustment` decimal(18,2) DEFAULT NULL,
  `TotalAllowance` decimal(18,2) DEFAULT NULL,
  `PayrollDate` datetime DEFAULT NULL,
  `CutOffStartDate` datetime DEFAULT NULL,
  `CutOffEndDate` datetime DEFAULT NULL,
  `PayrollGeneratedDate` datetime DEFAULT NULL,
  `IsTaxed` tinyint(1) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `UpdateDate` datetime DEFAULT NULL,
  PRIMARY KEY (`EmployeePayrollPerCompanyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
