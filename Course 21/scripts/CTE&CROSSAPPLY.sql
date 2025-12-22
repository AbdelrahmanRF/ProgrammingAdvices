Use HR_Database;

SELECT * FROM Employees
ORDER BY HireDate DESC;
SELECT * FROM Countries;
SELECT * FROM Departments;

-- CTE
-- Task 1: Simple CTE (Filtering)
WITH ActiveEmployeesCTE AS (
	SELECT 
		ID,
		CONCAT(FirstName, ' ', LastName) AS FullName,
		MonthlySalary
	FROM Employees
	WHERE ExitDate IS NULL
)
SELECT
	ID,
	FullName,
	MonthlySalary
FROM ActiveEmployeesCTE;

-- Task 2: CTE with Calculated Column
WITH SalaryCTE AS (
	    SELECT
			ID,
			CONCAT(FirstName, ' ', LastName) AS FullName,
			BonusPerc,
			ISNULL(MonthlySalary, 0) * 12 AS AnnualSalary
        FROM Employees
)
SELECT
	ID,
	FullName,
	AnnualSalary * BonusPerc AS BonusAmount
FROM SalaryCTE;

-- Task 3: CTE with JOINs
WITH HRTablesCTE AS (
	    SELECT
			CONCAT(E.FirstName, ' ', E.LastName) AS FullName,
			E.MonthlySalary,
			D.Name AS DepartmentName,
			C.Name AS CountryName,
			E.DepartmentID
        FROM Employees E
		JOIN Departments D ON E.DepartmentID = D.ID
		JOIN Countries C ON E.CountryID = C.ID
)
SELECT
	FullName,
	MonthlySalary,
	DepartmentName,
	CountryName
FROM HRTablesCTE
WHERE DepartmentID = 4; -- IT

-- Task 4: Aggregation with CTE
WITH DepartmentsAvgSalaryCTE AS (
	    SELECT
			AVG(ISNULL(E.MonthlySalary, 0)) AS AverageSalary,
			D.Name AS DepartmentName,
			E.DepartmentID
        FROM Employees E
		JOIN Departments D ON E.DepartmentID = D.ID
		GROUP BY E.DepartmentID, D.Name
)
SELECT
	AverageSalary,
	DepartmentName
FROM DepartmentsAvgSalaryCTE
ORDER BY AverageSalary DESC;

-- Task 5: CTE + Business Logic
WITH SalaryLevelCTE AS
(
    SELECT
			CASE 
            WHEN ISNULL(MonthlySalary, 0) * 12 < 15000 THEN 'Entry'
            WHEN ISNULL(MonthlySalary, 0) * 12 BETWEEN 15000 AND 30000 THEN 'Mid'
            WHEN ISNULL(MonthlySalary, 0) * 12 > 30000 THEN 'Senior'
            ELSE 'Not Specified'
        END AS SalaryLevel,
		MonthlySalary
    FROM Employees
)
SELECT 
	SalaryLevel,
	COUNT(*) AS NumberOfEmployees
FROM SalaryLevelCTE
GROUP BY (SalaryLevel)
ORDER BY 
    CASE 
        WHEN SalaryLevel = 'Entry' THEN 1
        WHEN SalaryLevel = 'Mid' THEN 2
        ELSE 3
    END;

-- CROSS APPLY
-- Task 1: Highest Paid Employee per Country
SELECT
    C.Name AS CountryName,
    E.FullName,
    E.MonthlySalary
FROM Countries C
CROSS APPLY
(
    SELECT TOP 1 
        CONCAT(FirstName, ' ', LastName) AS FullName,
        MonthlySalary
	FROM Employees
	WHERE CountryID = C.ID
	ORDER BY MonthlySalary DESC
) E;

-- Task 2: Most Recent Hire per Department
SELECT
    D.Name AS DepartmentName,
    E.FullName,
    E.HireDate
FROM Departments D
CROSS APPLY
(
	SELECT TOP 1
		CONCAT(FirstName, ' ', LastName) AS FullName,
		HireDate
	FROM Employees
	WHERE DepartmentID = D.ID
	ORDER BY HireDate DESC
) E;

-- Task 3: Top 2 Bonuses per Department
SELECT
    D.Name AS DepartmentName,
    E.FullName,
    E.BonusPerc
FROM Departments D
CROSS APPLY
(
	SELECT TOP 2
		CONCAT(FirstName, ' ', LastName) AS FullName,
		BonusPerc
	FROM Employees
	WHERE DepartmentID = D.ID
	ORDER BY BonusPerc DESC, HireDate ASC  -- Tie-breaker: earlier hire first
) E
ORDER BY D.Name, E.BonusPerc DESC;

-- Task 4: Employees Older Than 50 per Department
SELECT
    D.Name AS DepartmentName,
    E.FullName,
    E.Age
FROM Departments D
CROSS APPLY
(
	SELECT 
		CONCAT(FirstName, ' ', LastName) AS FullName,
		FLOOR(DATEDIFF(DAY, DateOfBirth, GETDATE()) / 365.25) AS Age,
		HireDate
	FROM Employees
	WHERE DepartmentID = D.ID AND FLOOR(DATEDIFF(DAY, DateOfBirth, GETDATE()) / 365.25) > 50
) E
ORDER BY D.Name, E.Age DESC , E.HireDate ASC

-- Task 5: Last 3 Exits per Department
SELECT
    D.Name AS DepartmentName,
    E.FullName,
    E.HireDate,
    E.ExitDate,
    E.ServingYears,
    E.ServingMonths,
    E.ServingDays
FROM Departments D
CROSS APPLY
(
    SELECT TOP 3
        CONCAT(FirstName, ' ', LastName) AS FullName,
        HireDate,
        ExitDate,
        DATEDIFF(YEAR, HireDate, ExitDate) - 
			CASE WHEN DATEADD(YEAR, DATEDIFF(YEAR, HireDate, ExitDate), HireDate) > ExitDate
			THEN 1 ELSE 0
		END AS ServingYears,

		DATEDIFF(MONTH, HireDate, ExitDate) % 12 - 
		CASE WHEN DATEADD(MONTH, DATEDIFF(MONTH, HireDate, ExitDate), HireDate) > ExitDate
			THEN 1 ELSE 0
		END AS ServingMonths,

		CASE 
			WHEN DAY(ExitDate) >= DAY(HireDate) THEN DAY(ExitDate) - DAY(HireDate)
			ELSE 
				DAY(EOMONTH(DATEADD(MONTH, -1, ExitDate)))
				- DAY(HireDate)
				+ DAY(ExitDate)
		END AS ServingDays

    FROM Employees
    WHERE DepartmentID = D.ID AND ExitDate IS NOT NULL
    ORDER BY ExitDate DESC
) E
ORDER BY D.Name, E.HireDate;