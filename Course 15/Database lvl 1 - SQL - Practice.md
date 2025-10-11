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


