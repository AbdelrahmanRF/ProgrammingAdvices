--USE CompanyDB;

-- Identity Field (Auto Increment)
--CREATE TABLE Departments
--(
--	ID int IDENTITY(1,1) NOT NULL PRIMARY KEY,
--	Name nvarchar(100) NOT NULL
--);

--INSERT INTO Departments
--VALUES 
--('HR'),
--('Marketing'),
--('Finance');

--this will delete all rows but will not reset the identity counter.
--delete from Departments;

--this will delete all rows and reset the identity counter.
--TRUNCATE TABLE Departments;


--Print @@iDENTITY;
--SELECT * FROM Departments;

USE DB1;

CREATE TABLE Customers
(
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Country varchar(50),
	Age int
);

CREATE TABLE Orders
(
	OrderID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Item varchar(50),
	Amount int,
	CustomerID int REFERENCES Customers(ID) NOT NULL,
);

-- OR
--CREATE TABLE Orders
--(
--	OrderID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
--	Item varchar(50),
--	Amount int,
--	CustomerID int NOT NULL,
--);

--ALTER TABLE Orders
--ADD FOREIGN KEY CustomerID REFERENCES Customers(ID);