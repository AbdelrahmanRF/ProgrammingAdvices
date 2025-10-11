USE HR_Database;

-- Select Statement

SELECT * FROM Employees;

SELECT Employees.* FROM Employees;

SELECT FirstName, LastName, MonthlySalary FROM Employees;

SELECT DepartmentID FROM Employees;

SELECT DISTINCT DepartmentID FROM Employees;

SELECT DISTINCT FirstName, DepartmentID FROM Employees;

-- Where Statement + AND , OR, NOT
SELECT * FROM Employees 
WHERE Gendor = 'M';

SELECT * FROM Employees 
WHERE Gendor = 'M' AND MonthlySalary < 500;

SELECT * FROM Employees 
WHERE Gendor = 'M' AND MonthlySalary <> 500;

SELECT * FROM Employees 
WHERE CountryID = 1 OR CountryID = 2;

SELECT * FROM Employees 
WHERE ExitDate IS NOT NULL;

SELECT * FROM Employees 
WHERE ExitDate IS NULL;

-- "In" Operator
SELECT * FROM Employees 
WHERE CountryID IN(1, 2, 3);


SELECT Departments.Name FROM Departments
WHERE
ID IN (SELECT DepartmentID FROM Employees WHERE MonthlySalary <= 210);

SELECT Countries.Name FROM Countries
WHERE
ID NOT IN (SELECT CountryID FROM Employees Where MonthlySalary >= 3000);

-- Sorting : Order By

SELECT ID, FirstName, LastName, MonthlySalary FROM Employees
WHERE DepartmentID = 1
ORDER BY FirstName ASC;

SELECT ID, FirstName, LastName, MonthlySalary FROM Employees
WHERE DepartmentID = 1
ORDER BY MonthlySalary DESC;

SELECT ID, FirstName, LastName, MonthlySalary FROM Employees
WHERE DepartmentID = 1
ORDER BY FirstName ASC, MonthlySalary DESC;


-- Select Top Statement
SELECT TOP 5 ID, FirstName, LastName FROM Employees;

SELECT TOP 5 * FROM Employees;

SELECT TOP 5 PERCENT * FROM Employees;

SELECT DISTINCT TOP 3 MonthlySalary FROM Employees ORDER BY MonthlySalary DESC;

SELECT ID , FirstName, MonthlySalary FROM Employees WHERE MonthlySalary IN
(
	SELECT DISTINCT TOP 3 MonthlySalary FROM Employees ORDER BY MonthlySalary DESC
)
ORDER BY MonthlySalary DESC;

SELECT ID , FirstName, MonthlySalary FROM Employees WHERE MonthlySalary IN
(
	SELECT DISTINCT TOP 3 MonthlySalary FROM Employees ORDER BY MonthlySalary ASC
)
ORDER BY MonthlySalary ASC;


-- Select As

SELECT A = 5 * 4
FROM Employees;

SELECT ID, FirstName, A = MonthlySalary / 2
FROM Employees;

SELECT ID, FirstName + ' ' + LastName AS FullName
FROM Employees;

SELECT ID, FullName = FirstName + ' ' + LastName  
FROM Employees;

SELECT ID, FullName = FirstName + ' ' + LastName, MonthlySalary, YearlySalary = MonthlySalary * 12  
FROM Employees;

SELECT ID, FullName = FirstName + ' ' + LastName, MonthlySalary, YearlySalary = MonthlySalary * 12, BonusAmount = MonthlySalary * BonusPerc
FROM Employees;

SELECT ID, FullName = FirstName + ' ' + LastName, DateOfBirth, Age = DATEDIFF(YEAR, DateOfBirth, GETDATE()) 
FROM Employees;

-- Between Operator

SELECT * FROM Employees
WHERE 
MonthlySalary BETWEEN 500 AND 1000;

-- Count, Sum, Avg, Min, Max Functions

SELECT 
'Total Count'     = COUNT(MonthlySalary),
'Total SUM'		  = SUM(MonthlySalary),
'Total Average'   = AVG(MonthlySalary),
'Min Salary'      = MIN(MonthlySalary),
'Max Salary'      = MAX(MonthlySalary)
FROM Employees;

SELECT 
'Total Count'     = COUNT(MonthlySalary),
'Total SUM'		  = SUM(MonthlySalary),
'Total Average'   = AVG(MonthlySalary),
'Min Salary'      = MIN(MonthlySalary),
'Max Salary'      = MAX(MonthlySalary)
FROM Employees
WHERE DepartmentID = 1;

SELECT 'Total Employees' = COUNT(ID) FROM Employees;

SELECT 'Resigned Employees' = COUNT(ExitDate) FROM Employees;

-- Group By

SELECT 
DepartmentID,
'Total Count'     = COUNT(MonthlySalary),
'Total SUM'		  = SUM(MonthlySalary),
'Total Average'   = AVG(MonthlySalary),
'Min Salary'      = MIN(MonthlySalary),
'Max Salary'      = MAX(MonthlySalary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

-- Having

SELECT 
DepartmentID,
TotalCount     = COUNT(MonthlySalary),
TotalSUM	  = SUM(MonthlySalary),
TotalAverage   = AVG(MonthlySalary),
MinSalary      = MIN(MonthlySalary),
MaxSalary      = MAX(MonthlySalary)

FROM Employees
GROUP BY DepartmentID
HAVING COUNT(MonthlySalary) > 100
ORDER BY DepartmentID;

-- Like

--Finds any values that starts with "a"
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a%';

--Finds any values that end with "a"
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE '%a';

--Finds any values that starts and ends with "a"
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a%a';

--Finds any values that have "a" in the second position
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE '_a%';

--Finds any values that start with "a" and are at least 3 characters in length
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a__%';

--Finds any values that have "ell" in any position
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE '%ell%';

-- WildCards

-- will search form Abdalrahman or Abdelrahman
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE 'Abd[ae]lrahman';

-- search for all employees that their first name start with a or b or c
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE '[aec]%';

-- search for all employees that their first name start with any letter from a to l
SELECT FirstName, LastName FROM Employees
WHERE FirstName LIKE '[a-l]%';

