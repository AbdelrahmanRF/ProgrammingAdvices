--CREATE DATABASE CompanyDB;

Use CompanyDB;

--CREATE TABLE Employees(
--	ID int NOT NULL,
--	Name nvarchar(50) NOT NULL,
--	Phone nvarchar(10) NULL,
--	Salary smallmoney NULL,
--	PRIMARY KEY (ID)
--);

-- Add Column/s
--ALTER TABLE  Employees
--ADD Gendar char(1),
--Religion varchar(50);

-- Rename database (in SQL Server)
-- exec sp_renamedb 'Company', 'CompanyDB';

-- Rename column in table (in SQL Server)
--exec sp_rename 'employees.Religion', 'ReligionName', 'COLUMN';

-- Rename table (in SQL Server)
--exec sp_rename 'Emps', 'Employees';

-- Modify Column in a Table (in SQL Server)
--ALTER TABLE Employees
--ALTER COLUMN ReligionName varchar(25);


---- Modifying PK

-- Find the Existing Constraint Name
--SELECT
--    name
--FROM
--    sys.key_constraints
--WHERE
--    parent_object_id = OBJECT_ID('Employees')
--    AND type = 'PK';

-- Modify PK
--ALTER TABLE Employees DROP CONSTRAINT PK__Employee__3214EC2770727688;

--ALTER TABLE Employees
--ALTER COLUMN ID tinyint NOT NULL;

--ALTER TABLE Employees ADD CONSTRAINT PK_Employees
--PRIMARY KEY (ID);

-- Delete Column in a Table
--ALTER TABLE Employees
--DROP COLUMN ReligionName;