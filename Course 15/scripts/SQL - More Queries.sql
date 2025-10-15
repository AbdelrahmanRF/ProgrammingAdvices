USE Shop_Database;

-- Exists

SELECT X = 'yes'
WHERE EXISTS
(
	SELECT * FROM Orders 
	WHERE CustomerID = 3 AND Amount < 600
);


SELECT * FROM Customers T1
WHERE
EXISTS
(
	SELECT TOP 1 R ='R' FROM Orders
	WHERE CustomerID = T1.CustomerID AND Amount < 600
);

USE HR_Database;

SELECT * FROM Employees C1
WHERE 
EXISTS
(
	SELECT TOP 1 M = 'M' FROM Employees
	WHERE
	ID = C1.ID AND MonthlySalary > 2500
);

-- Union

SELECT * FROM ActiveEmployees
UNION
SELECT * FROM ResignedEmployees;

SELECT * FROM Departments
UNION
SELECT * FROM Departments;

-- Default behaviuor is distinct but we can use UNION ALL for append
SELECT * FROM Departments
UNION ALL
SELECT * FROM Departments;


-- CASE

SELECT ID, FirstName, LastName, GendorTitle =
CASE
	WHEN Gendor = 'M' THEN 'Male'
	WHEN Gendor = 'F' THEN 'Female'
	ELSE 'Unknown'
END,

Status =
CASE
	WHEN ExitDate IS NULL THEN 'Active'
	WHEN ExitDate IS NOT NULL THEN 'Resigned'
END
FROM Employees