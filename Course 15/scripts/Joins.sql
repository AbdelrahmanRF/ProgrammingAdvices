use Shop_Database;

-- (Inner) Join
SELECT Customers.CustomerID,
Customers.Name,
Orders.Amount
FROM Customers INNER JOIN Orders ON
Customers.CustomerID = Orders.CustomerID;


use HR_Database;

SELECT Employees.ID, Employees.FirstName, Employees.LastName, Departments.Name AS DeptName
FROM Employees INNER JOIN Departments ON
Employees.DepartmentID = Departments.ID

WHERE Departments.Name = 'IT';

SELECT Employees.ID, Employees.FirstName, Employees.LastName, Departments.Name AS DeptName, Countries.Name AS CountryName
FROM Employees INNER JOIN Departments ON
Employees.DepartmentID = Departments.ID
INNER JOIN Countries ON
Employees.CountryID = Countries.ID;

-- Left (Outer) Join

SELECT Customers.CustomerID,
Customers.Name,
Orders.Amount
FROM Customers LEFT JOIN Orders 
ON Customers.CustomerID = Orders.CustomerID;

-- Right (Outer) Join

SELECT Customers.CustomerID,
Customers.Name,
Orders.Amount
FROM Customers RIGHT JOIN Orders 
ON Customers.CustomerID = Orders.CustomerID;

-- Full (Outer) Join

SELECT Customers.CustomerID,
Customers.Name,
Orders.Amount
FROM Customers FULL JOIN Orders 
ON Customers.CustomerID = Orders.CustomerID;