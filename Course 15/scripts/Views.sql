-- Create VIEW
CREATE VIEW ActiveEmployees AS
SELECT * FROM Employees
WHERE ExitDate IS NULL;

-- Query on VIEW
SELECT * FROM ActiveEmployees;

-- View with Joins

CREATE VIEW EmployeeDetails AS

SELECT Employees.ID, Employees.FirstName, Employees.LastName, Departments.Name
FROM Employees INNER JOIN Departments ON
Employees.DepartmentID = Departments.ID;

SELECT * FROM EmployeeDetails;

-- Updating a View

CREATE OR ALTER VIEW EmployeeDetails AS
SELECT Employees.ID, Employees.FirstName, Employees.LastName, Departments.Name AS DeptName
FROM Employees INNER JOIN Departments ON
Employees.DepartmentID = Departments.ID;

SELECT * FROM EmployeeDetails;

-- Deleting a View
DROP VIEW EmployeeDetails;


