# Database - Practical

## SQL – Data Definition Language (DDL)

### Create Database

Used to create a new database in SQL Server.

```sql
CREATE DATABASE DBName;
```

---

### Create Database IF NOT EXISTS

If a database with the same name already exists, SQL Server will throw an error.  
To avoid that, use the following code:

```sql
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DB1')
BEGIN
    CREATE DATABASE DB1;
END
```

This creates `DB1` only if it does not already exist.

> 💡 **Comment in SQL:** Use `--` to write single-line comments.

---

### Switch Databases

Used to select a different database to work with:

```sql
USE DB1;
```

After running this command, all SQL operations will apply to `DB1`.

---

### Drop Database

Deletes an existing database:

```sql
DROP DATABASE DB1;
```

> ⚠️ **Note:** This permanently removes the database and all of its tables and data.

---

### Drop Database IF EXISTS

To avoid errors when the database doesn’t exist:

```sql
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'DB1')
BEGIN
    DROP DATABASE DB1;
END
```

---

### Create Table

Used to create a table to store records (data).

```sql
CREATE TABLE Employees (
    ID int NOT NULL,
    Name nvarchar(50) NOT NULL,
    Phone nvarchar(10) NULL,
    Salary smallmoney NULL,
    PRIMARY KEY (ID)
);
```

The `column` parameters specify the column names, and the `datatype` defines the kind of data the column can store (e.g., integer, text, date, etc.).

> 🧠 **Tip:** Always define appropriate data types for each column to ensure data consistency.

---

### SQL Data Types

SQL supports several categories of data types:

#### Exact Numeric
- `int`, `smallint`, `bigint`, `tinyint`
- `decimal`, `numeric` (fixed precision)
- `money`, `smallmoney`

#### Approximate Numeric
- `float`, `real`

#### Character Strings
- `char`, `varchar`, `text`

#### Unicode Strings
- `nchar`, `nvarchar`

#### Date & Time
- `date`, `datetime`, `datetime2`, `time`, `datetimeoffset`

#### Binary
- `binary`, `varbinary`

> ⚠️ **Note:** Avoid deprecated types like `ntext`, `text`, and `image`.  
> Use `nvarchar(max)`, `varchar(max)`, and `varbinary(max)` instead.

📘 Reference: [W3Schools – SQL Data Types](https://www.w3schools.com/sql/sql_datatypes.asp)

---

### Drop Table

Used to delete a table and all its data:

```sql
DROP TABLE Employees;
```

> ⚠️ **Note:** This action is irreversible — all records inside the table will be deleted.

---

## DDL - Alter Table Statement

### Alter Table Statement

The `ALTER TABLE` statement is used to modify an existing table structure.

---

#### Add Column

We can add new columns using `ALTER TABLE` with the `ADD` clause:

```sql
ALTER TABLE Employees
ADD Gender char(1);
```

This adds a column named `Gender` to the `Employees` table.

---

#### Rename Column

##### (Most Databases)
```sql
ALTER TABLE Employees
RENAME COLUMN Gendor TO Gender;
```
This changes the column name `Gendor` to `Gender`.

##### (SQL Server)
You can’t use `ALTER TABLE` to rename columns. Use `sp_rename` instead:

```sql
EXEC sp_rename 'Employees.Gendor', 'Gender', 'COLUMN';
```

> ⚠️ Microsoft recommends dropping and recreating the table instead of using `sp_rename` to avoid dependency issues.

---

#### Rename Table

##### (Most Databases)
```sql
ALTER TABLE OldTableName
RENAME TO NewTableName;
```

##### (SQL Server)
```sql
EXEC sp_rename 'OldTableName', 'NewTableName';
```

---

#### Modify Column

Used to change column data type or constraints.

**SQL Server**
```sql
ALTER TABLE Employees
ALTER COLUMN Name VARCHAR(100);
```

**MySQL**
```sql
ALTER TABLE Employees
MODIFY COLUMN Name VARCHAR(100);
```

**Oracle**
```sql
ALTER TABLE Employees
MODIFY Name VARCHAR(100);
```

**PostgreSQL**
```sql
ALTER TABLE Employees
ALTER COLUMN Name TYPE VARCHAR(100);
```

This changes the data type of the `Name` column.

---

#### Modify Primary Key (PK)

If the PK is not referenced by another table, you can drop it freely.

```sql
-- Find the Existing Constraint Name
SELECT name FROM sys.key_constraints
WHERE parent_object_id = OBJECT_ID('Employees') AND type = 'PK';

-- Drop the Existing PK
ALTER TABLE Employees DROP CONSTRAINT PK__Employee__3214EC2770727688;

-- Modify Column and Add New PK
ALTER TABLE Employees ALTER COLUMN ID tinyint NOT NULL;
ALTER TABLE Employees ADD CONSTRAINT PK_Employees PRIMARY KEY (ID);
```

If your PK **is referenced as a Foreign Key (FK)** in another table (e.g., `Phones.EmployeeID` references `Employees.ID`),  
you must **first drop the FK constraints** in those referencing tables before modifying or dropping the PK.

---

#### Delete Column

We can remove a column using `ALTER TABLE` with the `DROP` clause:

```sql
ALTER TABLE Employees
DROP COLUMN Gender;
```

This removes the `Gender` column from the `Employees` table.

---

## Backup & Restore Database

### BACKUP DATABASE
Regular backups protect data from corruption or loss.

```sql
BACKUP DATABASE MyDatabase1
TO DISK = 'C:\MyDatabase1_backup.bak';
```
This creates a backup file named `MyDatabase1_backup.bak` in the C drive.

> 💡 It’s common to use `.bak` for backup files, but it’s not mandatory.

**Tip:** Always store backups on a separate drive to prevent data loss in case of disk failure.

---

### DIFFERENTIAL BACKUP
A **differential backup** saves only data changed since the last full backup.

```sql
BACKUP DATABASE MyDatabase1
TO DISK = 'C:\MyDatabase1_backup.bak'
WITH DIFFERENTIAL;
```
This appends new changes to the previous backup, reducing backup time.

---

### Restore Database

To restore a database from a backup file:

```sql
RESTORE DATABASE MyDatabase1
FROM DISK = 'C:\MyDatabase1.bak';
```
Restores the `MyDatabase1.bak` file to the SQL Server as the `MyDatabase1` database.

---

## Data Manipulation Language - DML

### **INSERT INTO Statement**
Used to add new records to a table.

**Syntax 1 – Specify Columns:**
```sql
INSERT INTO table_name (column1, column2, column3, ...)
VALUES (value1, value2, value3, ...);
```

**Syntax 2 – All Columns (must match table order):**
```sql
INSERT INTO table_name
VALUES (value1, value2, value3, ...);
```

---

### **UPDATE Statement**
Used to modify existing records in a table.

**Syntax:**
```sql
UPDATE table_name
SET column1 = value1, column2 = value2, ...
WHERE condition;
```

**Example — Conditional Salary Increment:**
```sql
UPDATE Employees
SET Salary = Salary + 
    CASE
        WHEN Salary <= 1000 THEN 200
        WHEN Salary <= 1500 THEN 100
        WHEN Salary <= 2000 THEN 50
        ELSE 0
    END;
```

⚠️ **Important Notes:**
- Always use a `WHERE` clause to avoid updating all rows unintentionally.
- To handle **NULL values**, use `IS NULL`, not `= NULL`.

❌ Incorrect:
```sql
UPDATE Teachers
SET Salary = 1000
WHERE Salary = NULL;
```

✅ Correct:
```sql
UPDATE Teachers
SET Salary = 1000
WHERE Salary IS NULL;
```

---

### **DELETE Statement**
Used to remove records from a table.

**Syntax:**
```sql
DELETE FROM table_name
WHERE condition;
```

⚠️ If you omit the `WHERE` clause, **all rows will be deleted**.

---

### **SELECT INTO Statement**
Copies data from one table into a **new** table.

**Example:**
```sql
SELECT *
INTO EmployeesCopy
FROM Employees;
```

Notes:
- `SELECT INTO` creates a **new table**.
- If the table already exists, the statement will fail.

---

### **INSERT INTO ... SELECT Statement**
Copies data from one **existing table** to another **existing table**.

**Example – Copy all columns:**
```sql
INSERT INTO OldPersons
SELECT * FROM Persons;
```

**Example – Copy with condition:**
```sql
INSERT INTO OldPersons
SELECT *
FROM Persons
WHERE Age >= 30;
```

**Example – Copy specific columns:**
```sql
INSERT INTO table2 (column1, column2, column3)
SELECT column1, column2, column3
FROM table1
WHERE condition;
```

Use `SELECT INTO` when creating a **new** table.  
Use `INSERT INTO SELECT` when copying into an **existing** one.

---

## Miscellaneous SQL Concepts 

### Identity Field (Auto Increment)

Auto-increment allows a unique number to be generated automatically when a new record is inserted into a table.

Often, this is the primary key field that we would like to be created automatically every time a new record is inserted.

#### Syntax for SQL Server
The following SQL statement defines the `Personid` column to be an auto-increment primary key field in the `Persons` table:

```sql
CREATE TABLE Persons (
    Personid int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int
);
```

The **MS SQL Server** uses the `IDENTITY` keyword to perform an auto-increment feature.

In the example above, the starting value for `IDENTITY` is **1**, and it will increment by **1** for each new record.

> 💡 **Tip:** To specify that the `Personid` column should start at value 10 and increment by 5, use `IDENTITY(10,5)`.

To insert a new record into the `Persons` table, we will **not** have to specify a value for the `Personid` column (a unique value will be added automatically):

```sql
INSERT INTO Persons (FirstName, LastName)
VALUES ('Mohammed', 'Salem');
```

This SQL statement inserts a new record into the `Persons` table. The `Personid` column is assigned a unique value, while `FirstName` and `LastName` are filled accordingly.

---

### Delete vs Truncate Statement

The main difference between both statements is that `DELETE FROM` supports a `WHERE` clause, whereas `TRUNCATE` does **not**.

Also, the `DELETE FROM` statement **does not reset** the auto number (identity field), while `TRUNCATE` **resets** the identity field.

That means we can delete single or multiple rows using `DELETE FROM`, while `TRUNCATE` deletes **all** records from the table at once.

Examples:

```sql
DELETE FROM Customers;
```

is similar to:

```sql
TRUNCATE TABLE Customers;
```

> ⚠️ **Note:** Use `DELETE FROM` if you want conditional deletion (using `WHERE`), otherwise `TRUNCATE` is faster for clearing all data.

---

### Foreign Key Constraint

In SQL, we can create a relationship between two tables using the **FOREIGN KEY** constraint.

A foreign key ensures referential integrity — values in one table must correspond to values in another.

Example relationship:

- The `customer_id` field in the `Orders` table is a **FOREIGN KEY** that references the `id` field in the `Customers` table.

This means that the value of `customer_id` in the `Orders` table must exist as an `id` in the `Customers` table.

> 🧠 **Note:** A foreign key can reference any column in the parent table, but it is generally best practice to reference the **primary key**.

#### Example: Creating Tables with Foreign Key

```sql
-- Parent table
CREATE TABLE Customers (
  id INT,
  first_name VARCHAR(40),
  last_name VARCHAR(40),
  age INT,
  country VARCHAR(10),
  PRIMARY KEY (id)
);

-- Child table referencing Customers
CREATE TABLE Orders (
  order_id INT,
  item VARCHAR(40),
  amount INT,
  customer_id INT REFERENCES Customers(id),
  PRIMARY KEY (order_id)
);
```

Here, the value of `customer_id` in `Orders` must exist in the `id` column of `Customers`.

> 📌 **Note:** The syntax may vary slightly across databases — always check your DBMS documentation.

#### Adding a Foreign Key Using ALTER TABLE

We can add a foreign key to an existing table using `ALTER TABLE`:

```sql
-- Create base tables first
CREATE TABLE Customers (
  id INT,
  first_name VARCHAR(40),
  last_name VARCHAR(40),
  age INT,
  country VARCHAR(10),
  PRIMARY KEY (id)
);

CREATE TABLE Orders (
  order_id INT,
  item VARCHAR(40),
  amount INT,
  customer_id INT,
  PRIMARY KEY (order_id)
);

-- Add foreign key constraint after creation
ALTER TABLE Orders
ADD FOREIGN KEY (customer_id) REFERENCES Customers(id);
```
---

## SQL - Queries

### SELECT Statement
The `SELECT` statement is used to retrieve data from a database. The results are stored in a result set.

**Syntax:**
```sql
SELECT column1, column2, ...
FROM table_name;
```
To select all columns:
```sql
SELECT * FROM table_name;
```

**Examples:**
```sql
SELECT * FROM Employees;
SELECT Employees.* FROM Employees;
SELECT ID, FirstName, LastName, MonthlySalary FROM Employees;
SELECT ID, FirstName, DateOfBirth FROM Employees;
SELECT * FROM Departments;
SELECT * FROM Countries;
```

---

### SELECT DISTINCT Statement
The `SELECT DISTINCT` statement returns only unique (different) values.

**Syntax:**
```sql
SELECT DISTINCT column1, column2, ...
FROM table_name;
```

**Examples:**
```sql
SELECT DepartmentID FROM Employees;
SELECT DISTINCT DepartmentID FROM Employees;

SELECT FirstName FROM Employees;
SELECT DISTINCT FirstName FROM Employees;

SELECT FirstName, DepartmentID FROM Employees;
SELECT DISTINCT FirstName, DepartmentID FROM Employees;
```

---

### WHERE Clause (AND, OR, NOT)
The `WHERE` clause filters records based on specified conditions.

**Syntax:**
```sql
SELECT column1, column2, ...
FROM table_name
WHERE condition;
```

The `AND`, `OR`, and `NOT` operators can be used to combine multiple conditions.

**Examples:**
```sql
SELECT * FROM Employees WHERE Gender = 'F';
SELECT * FROM Employees WHERE MonthlySalary <= 500;
SELECT * FROM Employees WHERE NOT MonthlySalary <= 500;
SELECT * FROM Employees WHERE MonthlySalary < 500 AND Gender = 'F';

SELECT * FROM Employees WHERE CountryID = 1;
SELECT * FROM Employees WHERE NOT CountryID = 1;
SELECT * FROM Employees WHERE CountryID <> 1;

SELECT * FROM Employees WHERE DepartmentID = 1;
SELECT * FROM Employees WHERE DepartmentID = 1 AND Gender = 'M';
SELECT * FROM Employees WHERE DepartmentID = 1 OR DepartmentID = 2;

SELECT * FROM Employees WHERE ExitDate IS NULL;
SELECT * FROM Employees WHERE ExitDate IS NOT NULL;
```

---

### IN Operator
The `IN` operator allows specifying multiple values in a `WHERE` clause.

**Syntax:**
```sql
SELECT column_name(s)
FROM table_name
WHERE column_name IN (value1, value2, ...);
```

**Examples:**
```sql
SELECT * FROM Employees WHERE DepartmentID IN (1, 2, 5, 7);
SELECT * FROM Employees WHERE FirstName IN ('Jacob', 'Brooks', 'Harper');

SELECT Departments.Name FROM Departments
WHERE ID IN (SELECT DepartmentID FROM Employees WHERE MonthlySalary <= 210);

SELECT Departments.Name FROM Departments
WHERE ID NOT IN (SELECT DepartmentID FROM Employees WHERE MonthlySalary <= 210);
```

---

### ORDER BY Keyword
The `ORDER BY` keyword sorts the result set in ascending (`ASC`) or descending (`DESC`) order.

**Syntax:**
```sql
SELECT column1, column2, ...
FROM table_name
ORDER BY column1, column2, ... ASC|DESC;
```

**Examples:**
```sql
SELECT ID, FirstName, MonthlySalary FROM Employees
WHERE DepartmentID = 1
ORDER BY FirstName;

SELECT ID, FirstName, MonthlySalary FROM Employees
WHERE DepartmentID = 1
ORDER BY FirstName DESC;

SELECT ID, FirstName, MonthlySalary FROM Employees
WHERE DepartmentID = 1
ORDER BY MonthlySalary ASC;

SELECT ID, FirstName, MonthlySalary FROM Employees
WHERE DepartmentID = 1
ORDER BY FirstName ASC, MonthlySalary DESC;
```

---

### SELECT TOP Statement

**The SQL SELECT TOP Clause**

The `SELECT TOP` clause is used to specify the number of records to return.

It is useful for large tables with thousands of records, as returning too many rows can impact performance.

> **Note:** Not all databases support `SELECT TOP`.  
> MySQL uses `LIMIT`, while Oracle uses `FETCH FIRST n ROWS ONLY` or `ROWNUM`.

**SQL Server / MS Access Syntax:**
```sql
SELECT TOP number|percent column_name(s)
FROM table_name
WHERE condition;
```

**Examples:**

```sql
SELECT * FROM Employees;

-- Show top 5 employees
SELECT TOP 5 * FROM Employees;

-- Show top 10% of data
SELECT TOP 10 PERCENT * FROM Employees;

-- Show all salaries (highest to lowest)
SELECT MonthlySalary FROM Employees
ORDER BY MonthlySalary DESC;

-- Show all unique salaries (highest to lowest)
SELECT DISTINCT MonthlySalary FROM Employees
ORDER BY MonthlySalary DESC;

-- Show the 3 highest salaries
SELECT DISTINCT TOP 3 MonthlySalary FROM Employees
ORDER BY MonthlySalary DESC;

-- Show all employees who take one of the 3 highest salaries
SELECT ID, FirstName, MonthlySalary 
FROM Employees 
WHERE MonthlySalary IN (
    SELECT DISTINCT TOP 3 MonthlySalary FROM Employees
    ORDER BY MonthlySalary DESC
)
ORDER BY MonthlySalary DESC;

-- Show all employees who take one of the 3 lowest salaries
SELECT ID, FirstName, MonthlySalary 
FROM Employees 
WHERE MonthlySalary IN (
    SELECT DISTINCT TOP 3 MonthlySalary FROM Employees
    ORDER BY MonthlySalary ASC
)
ORDER BY MonthlySalary ASC;
```

---

### SELECT AS (Aliases)

**SQL Aliases**

SQL aliases give a temporary name to a table or column to make it more readable.
An alias exists **only for the duration of the query**.

**Syntax:**

```sql
SELECT column_name AS alias_name
FROM table_name;
```

**Examples:**

```sql
SELECT A = 5 * 4, B = 6 / 2;

SELECT A = 5 * 4, B = 6 / 2 FROM Employees;

SELECT ID, FirstName, A = MonthlySalary / 2 FROM Employees;

SELECT ID, FirstName + ' ' + LastName AS FullName FROM Employees;

SELECT ID, FullName = FirstName + ' ' + LastName FROM Employees;

SELECT ID, FirstName, MonthlySalary, YearlySalary = MonthlySalary * 12 FROM Employees;

SELECT ID, FirstName, MonthlySalary,
       YearlySalary = MonthlySalary * 12,
       BonusAmount = MonthlySalary * BonusPerc
FROM Employees;

SELECT Today = GETDATE();

SELECT ID, 
       FullName = FirstName + ' ' + LastName,
       Age = DATEDIFF(YEAR, DateOfBirth, GETDATE())
FROM Employees;
```

---

### BETWEEN Operator

**The SQL BETWEEN Operator**

The BETWEEN operator selects values within a given range.

It is inclusive, meaning both the start and end values are included.

**Syntax:**

```sql
SELECT column_name(s)
FROM table_name
WHERE column_name BETWEEN value1 AND value2;
```

**Examples:**

```sql
SELECT * FROM Employees
WHERE (MonthlySalary >= 500 AND MonthlySalary <= 1000);

SELECT * FROM Employees
WHERE MonthlySalary BETWEEN 500 AND 1000;
```

---

### COUNT(), SUM(), AVG(), MIN(), MAX() Functions

These aggregate functions are used for mathematical calculations on columns.

**COUNT()** → Counts the number of rows that match a condition.

**AVG()** → Returns the average value of a numeric column.

**SUM()** → Returns the total sum of a numeric column.

**MIN()** → Returns the smallest value.

**MAX()** → Returns the largest value.

**Examples:**

```sql
SELECT TotalCount = COUNT(MonthlySalary),
       TotalSum = SUM(MonthlySalary),
       Average = AVG(MonthlySalary),
       MinSalary = MIN(MonthlySalary),
       MaxSalary = MAX(MonthlySalary)
FROM Employees;

SELECT TotalCount = COUNT(MonthlySalary),
       TotalSum = SUM(MonthlySalary),
       Average = AVG(MonthlySalary),
       MinSalary = MIN(MonthlySalary),
       MaxSalary = MAX(MonthlySalary)
FROM Employees
WHERE DepartmentID = 1;

SELECT * FROM Employees;

SELECT TotalEmployees = COUNT(ID) FROM Employees;

-- COUNT only counts non-null values
SELECT ResignedEmployees = COUNT(ExitDate) FROM Employees;
```
---

### GROUP BY Statement

**The SQL GROUP BY Statement**

The GROUP BY statement groups rows with the same values into summary rows.

It is often used with aggregate functions to group results by one or more columns.

**Syntax:**

```sql
SELECT column_name(s)
FROM table_name
WHERE condition
GROUP BY column_name(s)
ORDER BY column_name(s);
```

**Examples:**

```sql
SELECT DepartmentID,
       TotalCount = COUNT(MonthlySalary),
       TotalSum = SUM(MonthlySalary),
       Average = AVG(MonthlySalary),
       MinSalary = MIN(MonthlySalary),
       MaxSalary = MAX(MonthlySalary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;
```

---

### HAVING

The `HAVING` clause was added to SQL because the `WHERE` keyword cannot be used directly with aggregate functions.

**Syntax**

```sql
SELECT column_name(s)
FROM table_name
WHERE condition
GROUP BY column_name(s)
HAVING condition
ORDER BY column_name(s);
```

**Examples:**

```sql
SELECT DepartmentID,
       TotalCount = COUNT(MonthlySalary),
       TotalSum = SUM(MonthlySalary),
       Average = AVG(MonthlySalary),
       MinSalary = MIN(MonthlySalary),
       MaxSalary = MAX(MonthlySalary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID;

-- HAVING acts like WHERE for GROUP BY
SELECT DepartmentID,
       TotalCount = COUNT(MonthlySalary),
       TotalSum = SUM(MonthlySalary),
       Average = AVG(MonthlySalary),
       MinSalary = MIN(MonthlySalary),
       MaxSalary = MAX(MonthlySalary)
FROM Employees
GROUP BY DepartmentID
HAVING COUNT(MonthlySalary) > 100;

-- Same result using a subquery (without HAVING)
SELECT * FROM (
    SELECT DepartmentID,
           TotalCount = COUNT(MonthlySalary),
           TotalSum = SUM(MonthlySalary),
           Average = AVG(MonthlySalary),
           MinSalary = MIN(MonthlySalary),
           MaxSalary = MAX(MonthlySalary)
    FROM Employees
    GROUP BY DepartmentID
) R1
WHERE R1.TotalCount > 100;
```

---

### LIKE 

The `LIKE` operator is used in a `WHERE` clause to search for a specified pattern in a column.

**Wildcards**

- `%` → Represents **zero, one, or multiple characters**

- `_` → Represents **exactly one character**

> **Note**: MS Access uses `*` instead of `%` and `?` instead of `_`.

You can also combine wildcards together for more specific searches.

**Syntax**

```sql
SELECT column1, column2, ...
FROM table_name
WHERE columnN LIKE pattern;
```

**Examples:**

```sql
SELECT * FROM Employees;

-- Finds values starting with "a"
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a%';

-- Finds values ending with "a"
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE '%a';

-- Finds values containing "tell" anywhere
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE '%tell%';

-- Finds values starting and ending with "a"
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a%a';

-- Finds values with "a" in the second position
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE '_a%';

-- Finds values with "a" in the third position
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE '__a%';

-- Finds values starting with "a" and at least 3 chars long
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a__%';

-- Finds values starting with "a" and at least 4 chars long
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a___%';

-- Finds values starting with "a" or "b"
SELECT ID, FirstName FROM Employees
WHERE FirstName LIKE 'a%' OR FirstName LIKE 'b%';
```

---

### Wildcards 

Wildcards are used with the `LIKE` operator to substitute one or more characters in a string.

**Examples:**

| Symbol | Description                                            |
| :----- | :----------------------------------------------------- |
| `%`    | Represents zero or more characters                     |
| `_`    | Represents a single character                          |
| `[]`   | Represents any single character within the brackets    |
| `^`    | Represents any character **not** in the brackets       |
| `-`    | Represents any character within a specified range      |
| `{}`   | Represents escaped characters (used in some databases) |


```sql
-- Update data
UPDATE Employees 
SET FirstName = 'Mohammed', LastName = 'Abu-Hadhoud'
WHERE ID = 285;

UPDATE Employees 
SET FirstName = 'Mohammad', LastName = 'Maher'
WHERE ID = 286;

-- Search for exact names
SELECT ID, FirstName, LastName FROM Employees
WHERE FirstName = 'Mohammed' OR FirstName = 'Mohammad';

-- Search for both 'Mohammed' and 'Mohammad' (pattern)
SELECT ID, FirstName, LastName FROM Employees
WHERE FirstName LIKE 'Mohamm[ae]d';

-- Exclude 'Mohammed' and 'Mohammad'
SELECT ID, FirstName, LastName FROM Employees
WHERE FirstName NOT LIKE 'Mohamm[ae]d';

-- Search for employees whose names start with a, b, or c
SELECT ID, FirstName, LastName FROM Employees
WHERE FirstName LIKE 'a%' OR FirstName LIKE 'b%' OR FirstName LIKE 'c%';

-- Simplified version using character ranges
SELECT ID, FirstName, LastName FROM Employees
WHERE FirstName LIKE '[abc]%';

-- Search for names starting with any letter from a to l
SELECT ID, FirstName, LastName FROM Employees
WHERE FirstName LIKE '[a-l]%';
```

---

## Joins

**What is a JOIN?**

A **JOIN** clause in SQL is used to **combine rows from two or more tables** based on a **related column** between them.

It allows you to retrieve meaningful data spread across multiple tables, avoiding duplication and ensuring data normalization.

## 🔸 Types of SQL JOINs

| Type | Description |
|------|--------------|
| **INNER JOIN** | Returns records that have matching values in both tables. |
| **LEFT (OUTER) JOIN** | Returns all records from the left table, and the matched records from the right table. |
| **RIGHT (OUTER) JOIN** | Returns all records from the right table, and the matched records from the left table. |
| **FULL (OUTER) JOIN** | Returns all records when there is a match in either left or right table. |

---

### (Inner) Join

### Description
`INNER JOIN` returns only the records that have matching values in both tables.  
Rows that do **not** have matches in both tables are **excluded** from the result.

### Syntax
```sql
SELECT columns
FROM table1
INNER JOIN table2
ON table1.column_name = table2.column_name;
```

**Examples**

```sql
SELECT Customers.CustomerID, Customers.FirstName, Orders.Amount
FROM Customers
INNER JOIN Orders
ON Customers.CustomerID = Orders.Customer;

SELECT Customers.CustomerID, Customers.FirstName, Orders.Amount
FROM Customers
INNER JOIN Orders
ON Customers.CustomerID = Orders.Customer
WHERE Orders.Amount >= 500;

-- Inner Join Two Tables
SELECT Employees.ID, Employees.FirstName, Employees.LastName, Departments.Name AS DeptName
FROM Employees
INNER JOIN Departments
ON Employees.DepartmentID = Departments.ID;

-- Inner Join with WHERE
SELECT Employees.ID, Employees.FirstName, Employees.LastName, Departments.Name AS DeptName
FROM Employees
INNER JOIN Departments
ON Employees.DepartmentID = Departments.ID
WHERE Departments.Name = 'IT';

-- Three tables with WHERE
SELECT Employees.ID, Employees.FirstName, Employees.LastName, 
       Departments.Name AS DeptName, Countries.Name AS CountryName
FROM Employees
INNER JOIN Departments ON Employees.DepartmentID = Departments.ID
INNER JOIN Countries ON Employees.CountryID = Countries.ID
WHERE Countries.Name = 'USA';

```

---

### SQL LEFT (OUTER) JOIN

**Description**

`LEFT JOIN` returns all records from the left table, and the matched records from the right table.

If there is no match, the result will still include the left table’s data, with `NULL` values for columns from the right table.

**Syntax**

```sql
SELECT columns
FROM table1
LEFT JOIN table2
ON table1.column_name = table2.column_name;
```

> Note: `LEFT JOIN` and `LEFT OUTER JOIN` are the same.

**Example**

```sql
SELECT Customers.CustomerID, Customers.Name, Orders.Amount
FROM Customers
LEFT JOIN Orders
ON Customers.CustomerID = Orders.CustomerID;
```

---

### SQL RIGHT (OUTER) JOIN

**Description**

`RIGHT JOIN` returns all records from the right table, and the matched records from the left table.
If no match exists, you’ll still get the right table’s record, with `NULLs` for left table columns.

**Syntax**

```sql
SELECT columns
FROM table1
RIGHT JOIN table2
ON table1.column_name = table2.column_name;
```

> Note: `RIGHT JOIN` and `RIGHT OUTER JOIN` are the same.

**Example**

```sql
SELECT Customers.CustomerID, Customers.Name, Orders.Amount
FROM Customers
RIGHT OUTER JOIN Orders
ON Customers.CustomerID = Orders.CustomerID;
```

---

### SQL FULL (OUTER) JOIN

**Description**

`FULL OUTER JOIN` returns all records when there is a match in either table.
This means it includes rows from both tables, with `NULLs` where data doesn’t match.

**Syntax**

```sql
SELECT columns
FROM table1
FULL OUTER JOIN table2
ON table1.column_name = table2.column_name;
```

**Example**

```sql
SELECT Customers.CustomerID, Customers.Name, Orders.Amount
FROM Customers
FULL OUTER JOIN Orders
ON Customers.CustomerID = Orders.CustomerID;
```

### Summary Table

| JOIN Type      | Returns                                         |
| -------------- | ----------------------------------------------- |
| **INNER JOIN** | Only rows with matches in both tables           |
| **LEFT JOIN**  | All rows from left table + matches from right   |
| **RIGHT JOIN** | All rows from right table + matches from left   |
| **FULL JOIN**  | All rows from both tables (matches + unmatched) |

### Notes

- You can join more than two tables by chaining `JOIN` clauses.

- Always use **table aliases** to make queries shorter and clearer.

- `JOIN` order can affect readability but not results (unless using `OUTER JOIN`).

---

## Views

### What is a View?

A **view** in SQL is a **virtual table** that stores a **predefined SQL query**.  
It behaves like a table but doesn’t physically store data — instead, it displays data fetched from one or more real tables whenever you query it.

Views are powerful for:
- Simplifying complex queries.
- Restricting access to sensitive columns.
- Presenting consistent data formats across the database.

### Characteristics of a View

- A view **does not store data itself** — it only stores the query.
- It **fetches fresh data** each time you select from it.
- You can use a view **as if it were a table** in SELECT statements.
- Views can be **based on one or more tables** (or even other views).


### CREATE VIEW Statement

**Syntax**

```sql
CREATE VIEW view_name AS
SELECT column1, column2, ...
FROM table_name
WHERE condition;
```

**Example**

```sql
CREATE VIEW HighSalaryEmployees AS
SELECT FirstName, LastName, DepartmentID, MonthlySalary
FROM Employees
WHERE MonthlySalary > 3000;
```

### Querying a View

You can use a view just like a normal table:

```sql
SELECT * FROM HighSalaryEmployees;
```

### View with Joins

Views can combine multiple tables for easier querying.

**Example:**

```sql
CREATE VIEW EmployeeDetails AS
SELECT e.FirstName, e.LastName, d.Name AS DepartmentName, c.Name AS CountryName
FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.ID
INNER JOIN Countries c ON e.CountryID = c.ID;
```

### Updating a View

**Syntax**

```sql
CREATE OR ALTER VIEW view_name AS
SELECT column1, column2, ...
FROM table_name
WHERE condition;
```

**Example**

```sql
CREATE OR ALTER VIEW HighSalaryEmployees AS
SELECT FirstName, LastName, DepartmentID, MonthlySalary
FROM Employees
WHERE MonthlySalary > 5000;
```

**Explanation:**

This replaces the existing HighSalaryEmployees view and updates the salary condition to 5000.

### Deleting a View

**Syntax**

```sql
DROP VIEW view_name;
```

**Example**

```sql
DROP VIEW HighSalaryEmployees;
```

### Advantages of Using Views

| Benefit            | Description                                                                     |
| ------------------ | ------------------------------------------------------------------------------- |
| **Simplification** | Complex joins and filters can be stored in a single view for easy reuse.        |
| **Security**       | You can hide sensitive columns (like salaries or passwords) from certain users. |
| **Consistency**    | Ensures all users see data in a standardized format.                            |
| **Abstraction**    | Users don’t need to know the underlying table structure.                        |


### Limitations of Views

| Limitation                | Description                                                                            |
| ------------------------- | -------------------------------------------------------------------------------------- |
| **Performance**           | Since a view runs a query each time, large or complex views may slow down performance. |
| **Non-updatable Views**   | Some views cannot be updated (especially those with joins, aggregates, or DISTINCT).   |
| **Dependency Management** | Dropping or renaming tables used in views can break the view.                          |

### Updatable Views

Some views allow you to **INSERT**, **UPDATE**, or **DELETE** data — but only if:

- The view is based on **one table**.

- It does **not** use `DISTINCT`, `GROUP BY`, or `JOIN`.

- It includes all required columns for a valid row.

Example:

```sql
CREATE VIEW BasicEmployeeInfo AS
SELECT ID, FirstName, LastName, DepartmentID
FROM Employees;
```

Now you can:

```sql
UPDATE BasicEmployeeInfo
SET DepartmentID = 2
WHERE ID = 5;
```

**Explanation:**

This updates the `DepartmentID` for employee with `ID = 5` in the original table — because the view directly maps to that table.

### Does a View Store Data?

**No.**

A view is **recomputed every time** you query it.

It always shows **up-to-date** data from the underlying tables.

This ensures accuracy — but also means performance can depend on how complex the view query is.

### Best Practices

- Use **views** to abstract complex queries and simplify access for end-users.

- Avoid nesting multiple views inside each other (can slow down performance).

- Restrict access to base tables and grant permissions only on views when needed.

- Name views descriptively (e.g., `ActiveCustomers`, `EmployeeSummary`).

### Summary

| Command                  | Description               |
| ------------------------ | ------------------------- |
| `CREATE VIEW`            | Creates a new view.       |
| `CREATE OR REPLACE VIEW` | Updates an existing view. |
| `DROP VIEW`              | Deletes an existing view. |
| `SELECT FROM view_name`  | Queries data from a view. |

### In short:

> A view is like a reusable SQL query saved as a virtual table — great for readability, security, and data consistency.

---

