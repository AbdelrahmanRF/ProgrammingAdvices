-- Database Creation
--CREATE DATABASE DB1;

-- The following code to create a database only if there is no existing database with the same name
--IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'DB4')
--BEGIN
--CREATE DATABASE DB4;
--END

-- Switch Databases
--USE DB1;

-- Delete database
--DROP DATABASE DB3;

-- The following code to drop a database only if there is existing database with the same name
--IF EXISTS(SELECT * FROM sys.databases WHERE name = 'DB4')
--BEGIN
--DROP DATABASE DB4;
--END

USE DB1;

--CREATE TABLE Employees (
--	ID int NOT NULL,
--	Name nvarchar(50) NOT NULL,
--	Phone nvarchar(10) NULL,
--	Salary smallmoney NULL,
--	PRIMARY KEY (ID)
--);

-- delete table
--DROP TABLE Employees;


