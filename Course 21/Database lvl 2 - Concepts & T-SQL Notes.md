# Database Level 2: Concepts & T‑SQL

## Introduction to T‑SQL

### What is T‑SQL?

Transact‑SQL (T‑SQL) is Microsoft’s proprietary extension of SQL, used mainly in **SQL Server** and **Azure SQL Database**. It extends standard SQL with additional features for:

* Database querying and manipulation
* Procedural programming (variables, conditions, loops)
* Error handling
* Transactions
* Security

### Why T‑SQL Exists

Standard SQL is powerful, but limited in procedural capabilities. T‑SQL adds programming constructs and SQL Server-specific features to help developers build more complex logic directly inside the database.

### Key Capabilities of T‑SQL

* **Data Querying:** SELECT, JOIN, WHERE, GROUP BY, etc.
* **Data Manipulation (DML):** INSERT, UPDATE, DELETE
* **Data Definition (DDL):** CREATE, ALTER, DROP objects
* **Procedural Logic:** DECLARE variables, IF/ELSE, WHILE loops
* **Transactions:** BEGIN TRANSACTION, COMMIT, ROLLBACK for data integrity
* **Stored Procedures & Functions:** Reusable, precompiled, faster logic
* **Error Handling:** TRY...CATCH blocks
* **Security:** Permissions, roles, encryption

### Enterprise Importance

T‑SQL is widely used in enterprise environments due to its:

* Strong integration with Microsoft tools
* High performance for server-side logic
* Robust error and transaction control
* Ability to centralize business logic inside the database layer

---

## T‑SQL vs PL/SQL (Oracle)

Both T‑SQL and PL/SQL extend SQL with procedural features, but each is tied to its own ecosystem.

| Feature                 | T‑SQL                                 | PL/SQL                                           |
| ----------------------- | ------------------------------------- | ------------------------------------------------ |
| Vendor                  | Microsoft                             | Oracle                                           |
| Database                | SQL Server                            | Oracle Database                                  |
| Syntax Style            | SQL‑focused with procedural additions | More programming‑oriented (closer to Ada/Pascal) |
| Main Use                | Microsoft enterprise stack            | Oracle enterprise systems                        |
| Error Handling          | TRY...CATCH                           | EXCEPTION blocks                                 |
| Procedural Capabilities | Strong                                | Very strong                                      |

PL/SQL is used **only** in Oracle, while T‑SQL is used **only** in Microsoft SQL Server.

---

## Variables in T-SQL

---

## What is a Variable?

* A **variable in T-SQL** is an object that stores **a single value** of a specific data type.
* Variables are used to store data **temporarily** during the execution of a batch, stored procedure, or trigger.

```sql
DECLARE @EmployeeID INT;
DECLARE @EmployeeName NVARCHAR(100);
```

---

## Assigning Values to Variables

Variables must be **declared first**, then assigned a value.

### Using `SET`

* Assigns **one value only**
* Safer when assigning scalar values

```sql
SET @EmployeeName = 'John Doe';
```

### Using `SELECT`

* Can assign values from table queries
* Can assign **multiple variables at once**

```sql
SELECT @EmployeeName = 'John Doe';
```

Example with table data:

```sql
SELECT @EmployeeFullName = FirstName + ' ' + LastName
FROM Employees
WHERE ID = 285;
```

⚠️ The query **must return one row**, otherwise the last row value is used.

---

## Using Variables in Queries

Once declared and assigned, variables can be used anywhere literals are used.

```sql
DECLARE @Name NVARCHAR(50) = 'Abdelrahman';

SELECT * FROM Employees
WHERE FirstName = @Name;
```

---

## Variable Scope

* Variables are **local** to:

  * The current batch
  * Stored procedure
  * Trigger
* Variables are destroyed once execution ends

```sql
DECLARE @Temp INT = 5;
-- @Temp is not accessible outside this batch
```

---

## Common Data Types for Variables

### Numeric Types

* `INT`, `SMALLINT`, `BIGINT`
* `DECIMAL(p,s)`, `NUMERIC(p,s)`

### Character Types

* `CHAR(n)` – fixed length
* `VARCHAR(n)` – variable length
* `NVARCHAR(n)` – Unicode support

### Date & Time Types

* `DATE`
* `DATETIME`
* `DATETIME2`

---

## Special System Variables

### `@@IDENTITY`

* Stores the **last inserted identity value** in the current session

```sql
SELECT @@IDENTITY;
```

### `@@ROWCOUNT`

* Stores the **number of rows affected** by the last statement

```sql
UPDATE Employees
SET BonusPerc = 0.1
WHERE MonthlySalary < 600;

SELECT @@ROWCOUNT;
```

---

## Practical Examples

---

### Example 1 – Department Hiring Report

```sql
DECLARE @DepartmentID INT = 3;
DECLARE @StartDate DATE = '2023-01-01';
DECLARE @EndDate DATE = '2023-12-31';
DECLARE @TotalEmployees INT;
DECLARE @DepartmentName VARCHAR(50);

SELECT @DepartmentName = Name
FROM Departments
WHERE DepartmentID = @DepartmentID;

SELECT @TotalEmployees = COUNT(*)
FROM Employees
WHERE DepartmentID = @DepartmentID
AND HireDate BETWEEN @StartDate AND @EndDate;

PRINT 'Department Report';
PRINT 'Department Name: ' + @DepartmentName;
PRINT 'Reporting Period: ' + CAST(@StartDate AS VARCHAR) + ' to ' + CAST(@EndDate AS VARCHAR);
PRINT 'Total Employees: ' + CAST(@TotalEmployees AS VARCHAR);
```

---

### Example 2 – Monthly Sales Summary

```sql
DECLARE @Year INT = 2023;
DECLARE @Month INT = 6;
DECLARE @TotalSales DECIMAL(10,2);
DECLARE @TotalTransactions INT;
DECLARE @AverageSales DECIMAL(10,2);

SELECT @TotalSales = ISNULL(SUM(SaleAmount), 0.00)
FROM Sales
WHERE YEAR(SaleDate) = @Year AND MONTH(SaleDate) = @Month;

SELECT @TotalTransactions = COUNT(*)
FROM Sales
WHERE YEAR(SaleDate) = @Year AND MONTH(SaleDate) = @Month;

SET @AverageSales = @TotalSales / NULLIF(@TotalTransactions, 0);

PRINT 'Monthly Sales Summary';
PRINT 'Total Sales: ' + CAST(@TotalSales AS VARCHAR);
PRINT 'Average Sale: ' + CAST(@AverageSales AS VARCHAR);
```

---

### Example 3 – Employee Attendance Report

```sql
DECLARE @ReportYear INT = 2023;
DECLARE @ReportMonth INT = 7;
DECLARE @EmployeeID INT = 101;
DECLARE @TotalDays INT;
DECLARE @PresentDays INT;
DECLARE @AbsentDays INT;
DECLARE @LeaveDays INT;

SET @TotalDays = DAY(EOMONTH(DATEFROMPARTS(@ReportYear, @ReportMonth, 1)));

SELECT
    @PresentDays = SUM(CASE WHEN Status = 'Present' THEN 1 ELSE 0 END),
    @AbsentDays  = SUM(CASE WHEN Status = 'Absent' THEN 1 ELSE 0 END),
    @LeaveDays   = SUM(CASE WHEN Status = 'Leave' THEN 1 ELSE 0 END)
FROM EmployeeAttendance
WHERE EmployeeID = @EmployeeID
AND AttendanceDate >= DATEFROMPARTS(@ReportYear, @ReportMonth, 1)
AND AttendanceDate < DATEADD(MONTH, 1, DATEFROMPARTS(@ReportYear, @ReportMonth, 1));

PRINT 'Employee Attendance Report';
PRINT 'Present Days: ' + CAST(@PresentDays AS VARCHAR);
```

---

### Example 4 – Customer Loyalty Points

```sql
DECLARE @CustomerID INT = 1;
DECLARE @TotalSpent DECIMAL(10,2);
DECLARE @PointsEarned INT;
DECLARE @CurrentYear INT = YEAR(GETDATE());

SELECT @TotalSpent = ISNULL(SUM(Amount), 0)
FROM Purchases
WHERE CustomerID = @CustomerID
AND YEAR(PurchaseDate) = @CurrentYear;

SET @PointsEarned = CAST(@TotalSpent / 10 AS INT);

UPDATE Customers
SET LoyaltyPoints = LoyaltyPoints + @PointsEarned
WHERE CustomerID = @CustomerID;
```

---

## Best Practices

* Always **initialize variables**
* Use **descriptive names**
* Choose the **correct data type**
* Avoid functions on indexed columns when filtering
* Use `NULLIF` to prevent division by zero

---

## Conclusion

* Variables make T-SQL **dynamic and flexible**
* They reduce hard-coded values
* Essential for reports, logic, and stored procedures
* Core building block for advanced T-SQL programming
