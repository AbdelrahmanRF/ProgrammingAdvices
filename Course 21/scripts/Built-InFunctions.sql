USE C21_DB1;
SELECT * FROM Employees2;

--Common String Functions...

-- Using the LEN function to get the length of each employee's name
SELECT LEN(Name) AS NameLength FROM Employees2
GO

-- Converting employee names to uppercase using the UPPER function
SELECT UPPER(Name) AS UpperCaseName FROM Employees2
GO

-- Converting employee names to lowercase using the LOWER function
SELECT LOWER(Name) AS UpperCaseName FROM Employees2
GO

-- Extracting the first three characters of each name using SUBSTRING
SELECT SUBSTRING(Name, 1, 3) AS NameSubstring FROM Employees2
GO

-- Finding the position of '0' in each name using CHARINDEX
SELECT CHARINDEX('o', Name) AS CharPosition FROM Employees2
GO

-- Replacing 'Sales' with 'Marketing' in department names using REPLACE
SELECT REPLACE(Department, 'Sales', 'Marketing') AS NewDepartment FROM Employees2
GO

-- Concatenating the name and department with a hyphen in between using CONCAT
SELECT CONCAT(Name, ' - ', Department) AS ConcatenatedString FROM Employees2
GO

-- Concatenating the name and department with a hyphen in between using CONCAT_WS
SELECT CONCAT_WS(' - ', Name, Department) AS ConcatenatedString FROM Employees2
GO

-- Practice Exercise: Format Name and Department in a specific format using CONCAT, UPPER, and LOWER
-- Objective: Format the Name and Department columns as a single string, where names are in uppercase, and department names are in lowercase, separated by a colon (:)
SELECT CONCAT(UPPER(Name), ' : ', LOWER(Department)) AS FormattedOutput FROM Employees2
GO

-- Extracting the first 3 characters from the left side of the employee's name using LEFT
SELECT LEFT(Name, 3) AS LeftSubstring FROM Employees2
GO

-- Extracting the last 3 characters from the right side of the employee's name using RIGHT
SELECT RIGHT(Name, 3) AS RightSubstring FROM Employees2
GO

-- Removing leading spaces from the employee's name using LTRIM
SELECT LTRIM(Name) AS NameWithNoLeadingSpaces FROM Employees2
GO

-- Removing trailing spaces from the employee's name using RTRIM
SELECT RTRIM(Name) AS NameWithNoTrailingSpaces FROM Employees2
GO

-- Removing spaces from the start and end of each name using LTRIM and RTRIM
SELECT LTRIM(RTRIM(Name)) AS TrimmedName FROM Employees2
GO

-- Removing both leading and trailing spaces from the employee's name using TRIM
SELECT TRIM(Name) AS NameWithNoSpaces FROM Employees2
GO

-- Excersise
DECLARE @FullName NVARCHAR(100) = '   John Doe   ';

SELECT 
    LEN(@FullName) AS LengthBeforeTrim,
    LTRIM(@FullName) AS LeftTrimmed,
    RTRIM(@FullName) AS RightTrimmed,
    TRIM(@FullName) AS FullyTrimmed,
    UPPER(@FullName) AS UpperCase,
    LOWER(@FullName) AS LowerCase,
    SUBSTRING(@FullName, 4, 3) AS SubStr,
    CHARINDEX('Doe', @FullName) AS PositionOfDoe,
    REPLACE(@FullName, 'John', 'Jane') AS ReplacedName,
    CONCAT('Hello ', TRIM(@FullName)) AS Greeting;

-- Common Date funcitons:

-- Getting the current system date and time
SELECT GETDATE() AS CurrentDateTime
GO

-- Getting the system date and time with fractional seconds and time zone offset
SELECT SYSDATETIME() AS SystemDateTime
GO

-- Adding 10 days to the current date
SELECT DATEADD(DAY, 10, GETDATE()) AS DatePlus10Days
GO

-- Calculating the difference in days between two dates
SELECT DATEDIFF(DAY, GETDATE(), '2026-01-01') AS DaysSinceStartOfYear
GO

-- Extracting the year part from the current date
SELECT DATEPART(YEAR, GETDATE()) AS CurrentYear
GO

-- Getting the name of the current month
SELECT DATENAME(MONTH, GETDATE()) AS CurrentMonthName
GO

-- Extracting the day from the current date
SELECT DAY(GETDATE()) AS CurrentDay
GO

-- Extracting the month from the current date
SELECT MONTH(GETDATE()) AS CurrentMonth
GO

-- Extracting the year from the current date
SELECT YEAR(GETDATE()) AS CurrentYear
GO

-- Converting a datetime to a different format,The third argument, 103, specifies the style code for the conversion. 
--In SQL Server, style code 103 represents the date format as DD/MM/YYYY. 
--This means that the resulting string will have the day, then the month, and finally the year, separated by forward slashes.
SELECT CONVERT(VARCHAR, GETDATE(), 103) AS DateInDDMMYYYY
GO

-- Casting a datetime to a different data type
SELECT CAST(GETDATE() AS DATE) AS DateOnly
GO

-- Getting the last day of the current month
SELECT DAY(EOMONTH(GETDATE())) AS LastDayOfCurrentMonth
GO

-- Excersise
DECLARE @Today DATETIME = GETDATE();

SELECT
    @Today AS CurrentDateTime,
    DATEADD(DAY, 7, @Today) AS NextWeek,
    DATEDIFF(DAY, '2025-01-01', @Today) AS DaysSince2025,
    DATEPART(YEAR, @Today) AS YearPart,
    DATENAME(MONTH, @Today) AS MonthName,
    EOMONTH(@Today) AS EndOfMonth;

--Aggregate functions

-- Description: Count the number of employees in each department
SELECT Department, COUNT(*) AS EmployeeCount
FROM Employees2
GROUP BY Department;

-- Description: Calculate the total salary for each department
SELECT Department, SUM(Salary) AS TotalSalary
FROM Employees2
GROUP BY Department;

-- Description: Calculate the average performance rating for each department
SELECT Department, AVG(PerformanceRating) AS AvgPerformanceRating
FROM Employees2
GROUP BY Department;

-- Description: Find the lowest salary in the company
SELECT MIN(Salary) AS LowestSalary
FROM Employees2;

-- Description: Find the highest salary in the company
SELECT MAX(Salary) AS HighestSalary
FROM Employees2;