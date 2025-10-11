USE CompanyDB;

-- Insert Into Statement
--INSERT INTO Employees
--VALUES
--(1, 'EMP1', '0781234567', 300, 'f')

--INSERT INTO Employees
--VALUES
--(2, 'EMP2', '0781234567', 400, 'f'),
--(3, 'EMP3', '0781334567', 500, 'm'),
--(4, 'EMP4', '0781434567', 2000, 'm');

--INSERT INTO Employees (ID, Name)
--VALUES
--(5, 'EMP5')

--INSERT INTO Employees (ID, Name)
--VALUES
--(6, 'EMP6');

-- Update Statement
--UPDATE Employees
--SET
--Phone = '0781434567',
--Salary = 500,
--Gendar = 'm'
--WHERE ID = 5;

--UPDATE Employees
--SET
--Salary = Salary * 1.1
--WHERE Salary <= 1000 AND Gendar = 'f';

--UPDATE Employees
--SET
--Salary = 800
--WHERE Salary IS NULL;

--UPDATE Employees
--SET
--Salary = Salary + 
--CASE
--WHEN Salary >= 1000 THEN 100
--WHEN Salary >= 800 THEN 80
--WHEN Salary >= 700 THEN 70
--ELSE 0
--END;


--DELETE FROM Employees;
--DELETE FROM Employees
--WHERE Salary IS NULL;

-- Select Into Statement
--SELECT *
--INTO EmployeesCopy1
--FROM Employees;

--SELECT ID, Name
--INTO EmployeesCopy2
--FROM Employees

--SELECT *
--INTO EmployeesCopy3
--FROM Employees
--WHERE 5 = 6;

--SELECT * FROM Employees;

--SELECT * FROM EmployeesCopy1;

--SELECT * FROM EmployeesCopy2;

--SELECT * FROM EmployeesCopy3;

-- Insert Into ..Select From Statement

SELECT * FROM Persons;

SELECT * FROM OldPersons;

DELETE FROM OldPersons;

INSERT INTO OldPersons
SELECT * FROM Persons
WHERE Age >= 30;