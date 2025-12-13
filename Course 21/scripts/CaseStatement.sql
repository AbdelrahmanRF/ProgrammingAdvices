Use C21_DB1;

-- CASE as SWITCH

SELECT 
    EmployeeID,
    CASE DepartmentID
        WHEN 1 THEN 'Engineering'
        WHEN 2 THEN 'HR'
        WHEN 3 THEN 'Sales'
        WHEN 4 THEN 'IT'
        ELSE 'Other'
    END AS DepartmentName
FROM Employees;

-- Searched CASE
    Use HR_Database;

    -- CROSS APPLY
    SELECT 
        E.ID,
        CASE 
            WHEN A.AnnualSalary <= 12000 THEN 'Entry Level'
            WHEN A.AnnualSalary <= 24000 THEN 'Mid Level'
            WHEN A.AnnualSalary > 24000 THEN 'Senior Level'
            ELSE 'Not Specified'
        END AS EmployeeLevel
        FROM Employees E
    CROSS APPLY (
        SELECT ISNULL(E.MonthlySalary, 0) * 12 AS AnnualSalary
    ) A;

    -- CTE (Common Table Expression)
    WITH SalaryCTE AS
    (
        SELECT
        ID,
        ISNULL(MonthlySalary, 0) * 12 AS AnnualSalary
        FROM Employees
    )
    SELECT 
    ID,
    CASE
        WHEN AnnualSalary <= 12000 THEN 'Entry Level'
        WHEN AnnualSalary <= 24000 THEN 'Mid Level'
        WHEN AnnualSalary > 24000 THEN 'Senior Level'
        ELSE 'Not Specified'
    END AS EmployeeLevel
    FROM SalaryCTE;

-- Using CASE in ORDER BY (Custom Sorting)
Use C21_DB1;

SELECT * FROM Sales
ORDER BY 
    CASE 
        WHEN SaleAmount >= 200 THEN 1
        WHEN SaleAmount >= 100 THEN 2
        ELSE 3
    END
, SaleAmount DESC;

-- CASE in UPDATE Statements (Conditional Data Modification)
UPDATE Employees2
SET Salary = 
    CASE 
        WHEN PerformanceRating > 90 THEN Salary * 1.15
        WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 1.10
		WHEN PerformanceRating BETWEEN 50 AND 74 THEN Salary * 1.05
        ELSE Salary
    END;

-- Nested Case Statements

SELECT
    Name,
    Department,
    Salary,
    PerformanceRating,
    CASE 
        WHEN Department = 'Sales' THEN
            CASE
                WHEN PerformanceRating > 90 THEN Salary * 0.15
                WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 0.1
                ELSE Salary * 0.05
            END
        WHEN Department = 'HR' THEN
            CASE
                WHEN PerformanceRating > 90 THEN Salary * 0.10
                WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 0.08
                ELSE Salary * 0.04
            END
        ELSE
            CASE
                WHEN PerformanceRating > 90 THEN Salary * 0.08
                WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 0.06
                ELSE Salary * 0.03
            END
    END AS Bonus
FROM Employees2;


-- CASE statement within a GROUP BY

WITH PerformanceCategoryCTE AS (
    SELECT 
        Name,
        Salary,
        CASE
            WHEN PerformanceRating >= 80 THEN 'High'
            WHEN PerformanceRating >= 60 THEN 'Medium'
            ELSE 'Low'
        END AS PerformanceCategory
    FROM Employees2
)
SELECT
    PerformanceCategory,
    COUNT(*) AS NumberOfEmployees,
    AVG(Salary) AS AverageSalary
FROM PerformanceCategoryCTE
GROUP BY PerformanceCategory;
