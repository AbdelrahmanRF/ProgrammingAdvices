USE HR_Database;

SELECT * FROM Employees;
-- Declaring Variables
DECLARE @EmployeeFullName NVARCHAR(100);

SELECT @EmployeeFullName = FirstName + ' ' + LastName
FROM Employees
WHERE ID = 285;

SELECT @EmployeeFullName;

DECLARE @Name NVARCHAR(50) = 'Abdelrahman';
-- Or 
--SET @Name = 'Abdelrahman';

SELECT * FROM Employees
WHERE FirstName = @Name;

UPDATE Employees
SET BonusPerc = 0.1
WHERE MonthlySalary < 600;
SELECT @@ROWCOUNT;

-- Example 1
Use C21_DB1;
SELECT * FROM Employees;


DECLARE @DepartmentID INT;
DECLARE @StartDate DATE;
DECLARE @EndDate DATE;
DECLARE @TotalEmployees INT;
DECLARE @DepartmentName VARCHAR(50);

SET @DepartmentID = 3;
SET @StartDate = '2023-01-01';
SET @EndDate = '2023-12-31';

SELECT @DepartmentName = Name FROM Departments WHERE DepartmentID = @DepartmentID;

SELECT @TotalEmployees = COUNT(*)
FROM Employees
WHERE DepartmentID = @DepartmentID
AND HireDate BETWEEN @StartDate AND @EndDate;

-- Print the report
PRINT 'Department Report';
PRINT 'Department Name: ' + @DepartmentName;
PRINT 'Reporting Period: ' + CAST(@StartDate AS VARCHAR) + ' to ' + CAST(@EndDate AS VARCHAR);
PRINT 'Total Employees Hired in ' + CAST(YEAR(@StartDate) AS VARCHAR) + ': ' + CAST(@TotalEmployees AS VARCHAR);


-- Example 2
SELECT * FROM Sales;

DECLARE @Year INT;
DECLARE @Month INT;
DECLARE @TotalSales DECIMAL(10,2);
DECLARE @TotalTransactions INT;
DECLARE @AverageSales DECIMAL(10,2);

SET @Year = 2023;
SET @Month = 6;

SELECT @TotalSales = ISNULL(SUM(SaleAmount), 0.00) FROM Sales
WHERE YEAR(SaleDate) = @Year AND MONTH(SaleDate) = @Month;


SELECT @TotalTransactions = ISNULL(COUNT(*), 0) FROM Sales
WHERE YEAR(SaleDate) = @Year AND MONTH(SaleDate) = @Month;


SET @AverageSales = @TotalSales / @TotalTransactions;

-- Print the report
PRINT 'Monthly Sales Summary Report';
PRINT 'Year: ' + CAST(@Year AS VARCHAR) + ', Month: ' + CAST(@Month AS VARCHAR);
PRINT 'Total Sales: ' + CAST(@TotalSales AS VARCHAR);
PRINT 'Total Transactions: ' + CAST(@TotalTransactions AS VARCHAR);
PRINT 'Average Sale Value: ' + CAST(@AverageSaleS AS VARCHAR);

-- Example 3
SELECT * FROM EmployeeAttendance;

DECLARE @ReportMonth INT;
DECLARE @ReportYear INT;
DECLARE @TotalDays INT;
DECLARE @EmployeeID INT;
DECLARE @PresentDays INT;
DECLARE @AbsentDays INT;
DECLARE @LeaveDays INT;


SET @ReportYear = 2023;
SET @ReportMonth = 7;
SET @EmployeeID = 101;

SET @TotalDays = DAY(EOMONTH(DATEFROMPARTS(@ReportYear, @ReportMonth, 1)));

SELECT 
	@PresentDays = SUM(CASE WHEN Status = 'Present' THEN 1 ELSE 0 END),
	@AbsentDays = SUM(CASE WHEN Status = 'Absent' THEN 1 ELSE 0 END),
	@LeaveDays = SUM(CASE WHEN Status = 'Absent' THEN 1 ELSE 0 END)

FROM EmployeeAttendance
WHERE EmployeeID = @EmployeeID 
AND AttendanceDate >= DATEFROMPARTS(@ReportYear, @ReportMonth, 1)
AND AttendanceDate < DATEADD(MONTH, 1, DATEFROMPARTS(@ReportYear, @ReportMonth, 1))

-- Print the report
PRINT 'Employee Attendance Report for Employee ID: ' + CAST(@EmployeeID AS VARCHAR);
PRINT 'Report Month: ' + CAST(@ReportMonth AS VARCHAR) + '/' + CAST(@ReportYear AS VARCHAR);
PRINT 'Total Working Days: ' + CAST(@TotalDays AS VARCHAR);
PRINT 'Days Present: ' + CAST(@PresentDays AS VARCHAR);
PRINT 'Days Absent: ' + CAST(@AbsentDays AS VARCHAR);
PRINT 'Days on Leave: ' + CAST(@LeaveDays AS VARCHAR);

-- Example 4
SELECT * FROM Customers;
SELECT * FROM Purchases;


DECLARE @CustomerID INT = 1;
DECLARE @TotalSpent DECIMAL(10,2);
DECLARE @PointsEarned INT;
DECLARE @CurrentYear INT = YEAR(GETDATE());

SELECT @TotalSpent = SUM(Amount)
FROM Purchases
WHERE CustomerID = @CustomerID 
AND YEAR(PurchaseDate) = @CurrentYear;

SET @PointsEarned = CAST(@TotalSpent / 10 AS INT);

UPDATE Customers
SET LoyaltyPoints = LoyaltyPoints + @PointsEarned
WHERE CustomerID = @CustomerID;


-- Print the results
PRINT 'Loyalty Points Update for Customer ID: ' + CAST(@CustomerID AS VARCHAR);
PRINT 'Total Amount Spent in ' + CAST(@CurrentYear AS VARCHAR) + ': $' + CAST(@TotalSpent AS VARCHAR);
PRINT 'Loyalty Points Earned: ' + CAST(@PointsEarned AS VARCHAR);

