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

---

## IF Statement in T-SQL

---

## Introduction to IF Statement in T-SQL

The **IF statement** in T-SQL is a control-of-flow construct that allows SQL Server to execute different blocks of code based on whether a condition evaluates to **TRUE** or **FALSE**. It enables decision-making logic similar to `if-then-else` in traditional programming languages.

---

## IF Statement Syntax

```sql
IF condition
BEGIN
    -- Executed when condition is TRUE
END
ELSE
BEGIN
    -- Executed when condition is FALSE
END
```

* **condition**: Boolean expression
* **BEGIN / END**: Used when executing multiple statements

---

## Simple IF (Without ELSE) – Example

### Scenario: Salary Adjustment Check

```sql
DECLARE @MonthlySalary DECIMAL(10,2) = 4200;

IF @MonthlySalary < 5000
BEGIN
    PRINT 'Employee qualifies for salary review';
END
```

---

## IF…ELSE Statement – Business Rule Example

### Scenario: Contract Type Classification

```sql
DECLARE @YearsOfService INT = 7;

IF @YearsOfService >= 5
BEGIN
    PRINT 'Eligible for permanent contract';
END
ELSE
BEGIN
    PRINT 'Temporary contract';
END
```

---

## Nested IF Statements

### Scenario: Employee Bonus Eligibility System

Rules:

1. Employee must be **Active**
2. Experience level matters
3. Performance rating affects bonus

```sql
DECLARE @IsActive BIT = 1;
DECLARE @YearsOfExperience INT = 6;
DECLARE @PerformanceRating INT = 4; -- Scale 1–5
DECLARE @Bonus DECIMAL(5,2);

IF @IsActive = 1
BEGIN
    IF @YearsOfExperience >= 5
    BEGIN
        IF @PerformanceRating >= 4
        BEGIN
            SET @Bonus = 0.20;
            PRINT 'Excellent employee – 20% bonus';
        END
        ELSE
        BEGIN
            SET @Bonus = 0.10;
            PRINT 'Experienced employee – 10% bonus';
        END
    END
    ELSE
    BEGIN
        IF @PerformanceRating >= 4
        BEGIN
            SET @Bonus = 0.05;
            PRINT 'High performer with low experience – 5% bonus';
        END
        ELSE
        BEGIN
            SET @Bonus = 0.00;
            PRINT 'No bonus eligibility';
        END
    END
END
ELSE
BEGIN
    SET @Bonus = 0.00;
    PRINT 'Inactive employee – no bonus';
END
```

---

## Using IF with Variables

### Scenario: Access Control by Age

```sql
DECLARE @Age INT = 19;

IF @Age >= 18
BEGIN
    PRINT 'Access granted';
END
ELSE
BEGIN
    PRINT 'Access denied';
END
```

---

## Conditional Assignment Using IF

### Scenario: Selecting Maximum Value

```sql
DECLARE @A INT = 15;
DECLARE @B INT = 22;
DECLARE @MaxValue INT;

IF @A > @B
    SET @MaxValue = @A;
ELSE
    SET @MaxValue = @B;

PRINT @MaxValue;
```

---

## IF with Logical Operators (AND / OR / NOT)

### Scenario 1: Loan Eligibility

```sql
DECLARE @Age INT = 30;
DECLARE @Salary DECIMAL(10,2) = 5200;

IF @Age >= 21 AND @Salary >= 5000
BEGIN
    PRINT 'Eligible for loan';
END
ELSE
BEGIN
    PRINT 'Not eligible for loan';
END
```

---

### Scenario 2: Student Activity Qualification

```sql
DECLARE @Grade CHAR(1) = 'B';
DECLARE @AttendancePercentage INT = 75;

IF @Grade = 'A' OR @AttendancePercentage >= 70
BEGIN
    PRINT 'Qualified for extra activities';
END
ELSE
BEGIN
    PRINT 'Not qualified';
END
```

---

### Scenario 3: Customer Status Check

```sql
DECLARE @CustomerStatus NVARCHAR(10) = 'Inactive';

IF NOT (@CustomerStatus = 'Active')
BEGIN
    PRINT 'Send re-engagement email';
END
ELSE
BEGIN
    PRINT 'Customer is active';
END
```

---

## Error Handling Using IF and @@ERROR (Legacy)

```sql
UPDATE Employees
SET MonthlySalary = MonthlySalary * 1.1
WHERE DepartmentID = 5;

IF @@ERROR <> 0
BEGIN
    PRINT 'An error occurred during update';
END
```

### Key Notes about @@ERROR

* Holds the error number of the **last executed statement**
* Resets after every statement
* Must be checked immediately
* Largely replaced by `TRY...CATCH`

---

## IF with EXISTS (Recommended Pattern)

### Scenario: Employee Existence Check

```sql
IF EXISTS (SELECT 1 FROM Employees WHERE Name = 'John Smith')
BEGIN
    PRINT 'Employee exists';
END
ELSE
BEGIN
    PRINT 'Employee does not exist';
END
```

---

## Best Practices

* Keep IF logic **clear and readable**
* Avoid deep nesting when possible
* Use `CASE` for value mapping
* Prefer `TRY...CATCH` over `@@ERROR`
* Use `EXISTS` instead of `COUNT(*)` for existence checks

---

## Summary

* IF statements control execution flow in T-SQL
* Suitable for business rules, validations, and decision-making
* Can be nested for complex logic
* Must be used carefully to maintain readability and performance
* Fundamental for stored procedures and enterprise SQL logic

---

## CROSS APPLY

### What is CROSS APPLY?

`CROSS APPLY` is a SQL Server–specific operator used to join each row from an outer query with the result of a table-valued expression (subquery or function) that **depends on that row**.

You can think of it as:

* A **row-by-row execution**
* Similar to a **correlated subquery**, but more powerful and readable

If the subquery returns **no rows**, the outer row is **excluded** (like an INNER JOIN).

### Why CROSS APPLY Exists

Standard JOINs work when both sides are independent sets.
`CROSS APPLY` is used when:

* The right-side query **needs values from the left row**
* You need **TOP, ORDER BY, calculations, or filters per row**

### Mental Model

> "For each row on the left, run the query on the right."

### Typical Use Cases

* TOP N per group (latest employee per department)
* Per-row calculations (annual salary, serving time)
* Calling table-valued functions

### Example

```sql
SELECT
    D.Name AS DepartmentName,
    E.FullName,
    E.HireDate
FROM Departments D
CROSS APPLY (
    SELECT TOP 1
        CONCAT(FirstName, ' ', LastName) AS FullName,
        HireDate
    FROM Employees
    WHERE DepartmentID = D.ID
    ORDER BY HireDate DESC
) E;
```

Here:

* SQL loops through **each department**
* For each one, it finds the **most recent hire**

---

## CTE (Common Table Expression)

### What is a CTE?

A CTE is a **temporary named result set** that exists only for the duration of a single query.

It improves:

* Readability
* Logical separation
* Reusability inside the same query

### Syntax

```sql
WITH CTE_Name AS (
    SELECT ...
)
SELECT ... FROM CTE_Name;
```

### Key Characteristics

* Exists only for **one statement**
* Cannot be indexed
* Can be referenced multiple times in the main query

### When to Use CTE

* Complex calculations
* Aggregations
* Recursive logic
* Replacing deeply nested subqueries

### Example

```sql
WITH SalaryCTE AS (
    SELECT
        ID,
        AnnualSalary = ISNULL(MonthlySalary, 0) * 12
    FROM Employees
)
SELECT * FROM SalaryCTE;
```

### CTE vs CROSS APPLY

| Feature   | CTE                      | CROSS APPLY          |
| --------- | ------------------------ | -------------------- |
| Scope     | Query-level              | Row-level            |
| Execution | Set-based                | Per-row              |
| Best for  | Readability, aggregation | Per-row logic, TOP N |

---

## CASE Statement in T-SQL

### Introduction

T-SQL does not have a `SWITCH` statement like C# or Java.

Instead, SQL Server provides the `CASE` statement, which is the **closest equivalent**, but with an important limitation:

> `CASE` works **inside queries**, not as a control-of-flow structure.

You cannot use CASE to control execution like IF/ELSE — only to return values.

---

### Why CASE Is Not IF / SWITCH

* `CASE` **returns a value**
* `IF` **controls execution**

If you need logic outside a query, use:

* `IF...ELSE`
* `WHILE`
* `TRY...CATCH`

---

### Types of CASE Statements

#### 1️⃣ Simple CASE (SWITCH-like)

```sql
CASE input_expression
    WHEN value1 THEN result1
    WHEN value2 THEN result2
    ELSE default_result
END
```

#### Example

```sql
SELECT
    EmployeeID,
    CASE DepartmentID
        WHEN 1 THEN 'Engineering'
        WHEN 2 THEN 'Human Resources'
        WHEN 3 THEN 'Sales'
        ELSE 'Other'
    END AS DepartmentName
FROM Employees;
```

---

#### 2️⃣ Searched CASE (More Flexible)

```sql
CASE
    WHEN condition1 THEN result1
    WHEN condition2 THEN result2
    ELSE default_result
END
```

---

### CASE with CROSS APPLY

```sql
SELECT
    E.ID,
    CASE
        WHEN A.AnnualSalary <= 12000 THEN 'Entry Level'
        WHEN A.AnnualSalary <= 24000 THEN 'Mid Level'
        WHEN A.AnnualSalary > 24000 THEN 'Senior Level'
        ELSE 'Not Specified'
    END AS EmployeeLevel
FROM Employees E
CROSS APPLY (
    SELECT AnnualSalary = ISNULL(E.MonthlySalary, 0) * 12
) A;
```

#### Why This Is Good

* AnnualSalary calculated **once per row**
* CASE logic becomes cleaner
* Avoids repeating expressions

---

### CASE with CTE

```sql
WITH SalaryCTE AS (
    SELECT
        ID,
        AnnualSalary = ISNULL(MonthlySalary, 0) * 12
    FROM Employees
)
SELECT
    ID,
    CASE
        WHEN AnnualSalary <= 12000 THEN 'Entry Level'
        WHEN AnnualSalary <= 24000 THEN 'Mid Level'
        WHEN AnnualSalary > 24000 THEN 'Senior Level'
        ELSE 'Not Specified'
    END AS EmployeeLevel
FROM SalaryCTE;
```

#### When CTE Is Better

* You need to reuse `AnnualSalary`
* You want logical separation

---

### CASE in ORDER BY (Custom Sorting)

```sql
SELECT Name, Salary
FROM Employees
ORDER BY
    CASE
        WHEN Salary > 50000 THEN 1
        ELSE 2
    END;
```

---

### CASE with GROUP BY

```sql
WITH SalaryLevelCTE AS (
    SELECT
        CASE
            WHEN ISNULL(MonthlySalary, 0) * 12 < 15000 THEN 'Entry'
            WHEN ISNULL(MonthlySalary, 0) * 12 BETWEEN 15000 AND 30000 THEN 'Mid'
            WHEN ISNULL(MonthlySalary, 0) * 12 > 30000 THEN 'Senior'
            ELSE 'Not Specified'
        END AS SalaryLevel
    FROM Employees
)
SELECT
    SalaryLevel,
    COUNT(*) AS NumberOfEmployees
FROM SalaryLevelCTE
GROUP BY SalaryLevel
ORDER BY
    CASE
        WHEN SalaryLevel = 'Entry' THEN 1
        WHEN SalaryLevel = 'Mid' THEN 2
        ELSE 3
    END;
```

---

### CASE in UPDATE Statements

```sql
UPDATE Employees2
SET Salary =
    CASE
        WHEN PerformanceRating > 90 THEN Salary * 1.15
        WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 1.10
        WHEN PerformanceRating BETWEEN 50 AND 74 THEN Salary * 1.05
        ELSE Salary
    END;
```

---

### Nested CASE Statements

```sql
SELECT
    Name,
    Department,
    Salary,
    PerformanceRating,
    Bonus = CASE
                WHEN Department = 'Sales' THEN
                    CASE
                        WHEN PerformanceRating > 90 THEN Salary * 0.15
                        WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 0.10
                        ELSE Salary * 0.05
                    END
                WHEN Department = 'HR' THEN
                    CASE
                        WHEN PerformanceRating > 90 THEN Salary * 0.10
                        WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 0.08
                        ELSE Salary * 0.04
                    END
                ELSE
                    CASE
                        WHEN PerformanceRating > 90 THEN Salary * 0.08
                        WHEN PerformanceRating BETWEEN 75 AND 90 THEN Salary * 0.06
                        ELSE Salary * 0.03
                    END
            END
FROM Employees2;
```

---

### Best Practices

* Prefer **Searched CASE** for complex logic
* Avoid deep nesting when possible
* Keep data types consistent
* Use CTE or CROSS APPLY to simplify CASE logic

---

### Summary

* `CROSS APPLY` → row-by-row logic
* `CTE` → query-level structure
* `CASE` → value-based conditional logic inside queries

Used correctly, these tools make T-SQL **clean, readable, and production-ready**.

---
## Loops Statements in T-SQL

### Introduction

Unlike many procedural programming languages, **T-SQL is a set-based language**. This means SQL Server is optimized to work with *sets of rows* rather than iterating row by row.

However, there are scenarios where **procedural logic** is required. For those cases, T-SQL provides **control-of-flow constructs**, the most important of which is the **WHILE loop**.

> ⚠️ Important: Excessive use of loops usually indicates that a **set-based solution should be considered first**.

---

### Looping Capabilities in T-SQL

T-SQL supports:

* ✅ `WHILE` loop
* ✅ `BREAK` and `CONTINUE`
* ⚠️ `CURSOR` (row-by-row, generally discouraged)

T-SQL **does NOT support**:

* ❌ `FOR` loop
* ❌ `DO...WHILE` loop

Therefore:

> **WHILE is the only native looping construct in T-SQL**

---

### WHILE Loop

#### Conceptual Understanding

A `WHILE` loop repeatedly executes a block of statements **as long as a condition evaluates to TRUE**.

Execution model:

1. Evaluate condition
2. If TRUE → execute block
3. Re-evaluate condition
4. If FALSE → exit loop

---

#### Basic Syntax

```sql
WHILE <condition>
BEGIN
    -- statements
END
```

* `<condition>` must be a Boolean expression
* `BEGIN...END` groups multiple statements

---

### BEGIN...END Blocks

#### Purpose

`BEGIN...END` defines a **logical scope** for multiple statements.

Similar to `{ }` in C-like languages.

Used with:

* `IF...ELSE`
* `WHILE`
* Stored procedures
* Triggers

---

#### Example: BEGIN...END

```sql
BEGIN
    PRINT 'Start';
    SELECT COUNT(*) FROM Employees;
    PRINT 'End';
END
```

---

### BREAK and CONTINUE

#### BREAK

* Immediately exits the loop
* Control jumps **outside** the loop

#### CONTINUE

* Skips remaining statements in the loop body
* Jumps to **next iteration**

| Statement | Effect                 |
| --------- | ---------------------- |
| BREAK     | Exit loop completely   |
| CONTINUE  | Skip current iteration |

---

### Examples

---

#### Example 1: Simple Counter

```sql
DECLARE @Counter INT = 1;

WHILE @Counter <= 5
BEGIN
    PRINT 'Counter = ' + CAST(@Counter AS VARCHAR);
    SET @Counter += 1;
END
```

**Use Case:**

* Testing logic
* Controlled iteration

---

#### Example 2: Reverse Loop

```sql
DECLARE @Counter INT = 5;

WHILE @Counter > 0
BEGIN
    PRINT 'Counter = ' + CAST(@Counter AS VARCHAR);
    SET @Counter -= 1;
END
```

---

#### Example 3: Iterating Through a Table (ID-based)

```sql
DECLARE @EmployeeID INT;
DECLARE @MaxID INT;
DECLARE @EmployeeName NVARCHAR(100);

SELECT @EmployeeID = MIN(ID), @MaxID = MAX(ID)
FROM Employees;

WHILE @EmployeeID IS NOT NULL AND @EmployeeID <= @MaxID
BEGIN
    SELECT @EmployeeName = FirstName + ' ' + LastName
    FROM Employees
    WHERE ID = @EmployeeID;

    PRINT @EmployeeName;

    SELECT @EmployeeID = MIN(ID)
    FROM Employees
    WHERE ID > @EmployeeID;
END
```

**Senior Note:**

> This pattern works but should be avoided for large tables.
> Prefer **set-based SELECT** unless row-by-row processing is mandatory.

---

#### Example 4: Conditional Exit with BREAK

```sql
DECLARE @Balance DECIMAL(10,2) = 950;
DECLARE @Withdrawal DECIMAL(10,2) = 100;

WHILE @Balance > 0
BEGIN
    IF @Withdrawal > @Balance
    BEGIN
        PRINT 'Insufficient funds';
        BREAK;
    END

    SET @Balance -= @Withdrawal;
    PRINT 'Remaining Balance: ' + CAST(@Balance AS VARCHAR);
END
```

**Concepts Covered:**

* Business rule enforcement
* Immediate termination

---

#### Example 5: Nested WHILE Loops (Multiplication Table)

```sql
DECLARE @Row INT = 1;
DECLARE @Col INT;

WHILE @Row <= 10
BEGIN
    SET @Col = 1;

    WHILE @Col <= 10
    BEGIN
        PRINT CAST(@Row AS VARCHAR) + ' x ' + CAST(@Col AS VARCHAR) + ' = ' + CAST(@Row * @Col AS VARCHAR);
        SET @Col += 1;
    END

    PRINT '';
    SET @Row += 1;
END
```

---

#### Example 6: CONTINUE Usage (Skip Even Numbers)

```sql
DECLARE @Counter INT = 0;

WHILE @Counter < 10
BEGIN
    SET @Counter += 1;

    IF @Counter % 2 = 0
        CONTINUE;

    PRINT 'Odd Number: ' + CAST(@Counter AS VARCHAR);
END
```

---

### Performance & Best Practices

#### ⚠️ Important Guidelines

1. **Avoid loops for data processing**

   * SQL Server is optimized for sets
   * Loops scale poorly

2. **Use loops for:**

   * Administrative scripts
   * Batch processing
   * Retry logic
   * Controlled simulations

3. **Never loop when a SELECT can do the job**

4. **Always guarantee loop termination**

   * Infinite loops can lock sessions

---

### WHILE vs CURSOR

| Feature     | WHILE        | CURSOR                |
| ----------- | ------------ | --------------------- |
| Complexity  | Low          | High                  |
| Performance | Better       | Worse                 |
| Use case    | Simple logic | Legacy row processing |

> Prefer **WHILE over CURSOR**, but prefer **SET-BASED over WHILE**.

---

### Summary

* T-SQL supports **only WHILE loops** for iteration
* `BEGIN...END` defines execution scope
* `BREAK` exits loops immediately
* `CONTINUE` skips iterations
* Loops should be used **sparingly and deliberately**

> **Senior Rule:** If you can solve it with a SELECT, don’t use a loop.

---

## Error Handling in T-SQL

### Introduction

Error handling in T-SQL is a critical part of writing reliable and production-ready SQL code. Databases are responsible for **data integrity**, **consistency**, and **transaction safety**, so errors must be handled explicitly and correctly.

Unlike application languages, SQL Server executes statements in a **set-based and transactional environment**, which makes proper error handling essential—especially when data is being modified.

---

### Why Error Handling Is Important

#### 1. Prevents Data Corruption

Without proper error handling, part of a transaction may succeed while another part fails, leaving the database in an inconsistent state.

#### 2. Transaction Safety

TRY...CATCH allows you to **commit or rollback** changes safely.

#### 3. Debugging & Diagnostics

SQL Server provides detailed error metadata that helps identify *what failed*, *where*, and *why*.

#### 4. Professional-Grade SQL Code

Production systems, batch jobs, ETL pipelines, and critical domains (finance, healthcare, HR) **must** have predictable error behavior.

---

### TRY...CATCH in T-SQL

#### Concept

T-SQL uses the **TRY...CATCH** construct for structured error handling.

* **TRY block**: Contains statements that might fail
* **CATCH block**: Executes when an error occurs in TRY

#### Syntax

```sql
BEGIN TRY
    -- Statements that may cause an error
END TRY
BEGIN CATCH
    -- Error handling logic
END CATCH
```

Once an error occurs inside the TRY block:

* Execution immediately jumps to the CATCH block
* Remaining statements inside TRY are skipped

---

### Simple Example: Duplicate Key Error

```sql
CREATE TABLE Employees3 (
    EmployeeID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Position NVARCHAR(100)
);

BEGIN TRY
    INSERT INTO Employees3 VALUES (1, 'John Doe', 'Sales Manager');
    INSERT INTO Employees3 VALUES (1, 'Jane Smith', 'Marketing Manager');
END TRY
BEGIN CATCH
    PRINT 'An error occurred: ' + ERROR_MESSAGE();
END CATCH
```

#### What Happens

* First INSERT succeeds
* Second INSERT violates PRIMARY KEY
* Control moves to CATCH block
* Error message is printed

---

### Error Information Functions

Inside a CATCH block, SQL Server exposes detailed error metadata.

| Function            | Description                      |
| ------------------- | -------------------------------- |
| `ERROR_NUMBER()`    | Error code                       |
| `ERROR_SEVERITY()`  | Error severity level             |
| `ERROR_STATE()`     | Internal state code              |
| `ERROR_PROCEDURE()` | Procedure or trigger name        |
| `ERROR_LINE()`      | Line number where error occurred |
| `ERROR_MESSAGE()`   | Full error message               |

#### Example

```sql
BEGIN TRY
    SELECT 1 / 0;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER()    AS ErrorNumber,
        ERROR_SEVERITY()  AS ErrorSeverity,
        ERROR_STATE()     AS ErrorState,
        ERROR_PROCEDURE() AS ErrorProcedure,
        ERROR_LINE()      AS ErrorLine,
        ERROR_MESSAGE()   AS ErrorMessage;
END CATCH
```

---

### TRY...CATCH with Transactions (Critical Pattern)

```sql
BEGIN TRY
    BEGIN TRAN;

    UPDATE Accounts SET Balance = Balance - 100 WHERE AccountID = 1;
    UPDATE Accounts SET Balance = Balance + 100 WHERE AccountID = 2;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    PRINT ERROR_MESSAGE();
END CATCH
```

#### Why This Matters

* Prevents partial updates
* Ensures atomic operations
* Mandatory in financial or sensitive systems

---

### THROW Statement

#### What Is THROW?

`THROW` is used to:

* Raise **custom errors**
* Re-throw the original error to the calling layer

#### Syntax

```sql
THROW error_number, message, state;
```

#### Rules

* Error number must be **>= 50000**
* Message length < 2048 characters
* State between 0 and 255

---

### THROW Without Parameters (Re-Throw Error)

```sql
BEGIN TRY
    SELECT 1 / 0;
END TRY
BEGIN CATCH
    PRINT 'Logging error...';
    THROW;
END CATCH
```

✔ Preserves original error number and line
✔ Best practice for real systems

---

### THROW Example Without Stored Procedures

```sql
DECLARE @NewStockQty INT = -5;

BEGIN TRY
    IF @NewStockQty < 0
        THROW 51000, 'Stock quantity cannot be negative.', 1;

    UPDATE Products
    SET StockQuantity = @NewStockQty
    WHERE ProductID = 1;
END TRY
BEGIN CATCH
    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH
```

#### Why THROW Is Useful

* Enforces business rules
* Produces predictable errors
* Communicates failure clearly to application

---

### @@ERROR (Legacy Error Handling)

#### What Is @@ERROR?

`@@ERROR` returns the error number of the **last executed statement**.

```sql
INSERT INTO Employees3 VALUES (1, 'Ali', 'HR');
IF @@ERROR <> 0
    PRINT 'Error occurred';
```

#### Limitations

* Must be checked immediately
* Only returns error number
* No line, message, or severity
* Poor readability

#### Recommendation

🚫 Avoid in new code
✅ Use TRY...CATCH instead

---

### TRY...CATCH vs @@ERROR

| Feature             | TRY...CATCH | @@ERROR |
| ------------------- | ----------- | ------- |
| Structured handling | ✅           | ❌       |
| Full error info     | ✅           | ❌       |
| Transaction safe    | ✅           | ❌       |
| Readability         | High        | Low     |
| Modern standard     | ✅           | ❌       |

---

### Best Practices

✔ Always wrap transactions in TRY...CATCH
✔ Rollback explicitly on error
✔ Use THROW instead of RAISERROR (deprecated)
✔ Keep error handling logic simple and predictable

---

### Final Note

Error handling in T-SQL is **not optional** in serious systems. While application frameworks handle user-facing errors, **SQL Server is responsible for data correctness**.

---

## Transactions in T-SQL

### Introduction to Transactions

A **transaction** in SQL Server is a sequence of one or more operations executed as a **single logical unit of work**. Transactions ensure that either **all operations succeed** or **none of them are applied**.

Transactions are essential whenever data consistency matters, especially in financial, inventory, or multi-step business processes.

---

### ACID Properties

Transactions in SQL Server follow the **ACID** principles:

#### 1. Atomicity

All operations inside a transaction are treated as one unit.

* Either **everything succeeds**
* Or **everything is rolled back**

Example: Money should not be deducted from one account unless it is added to another.

---

#### 2. Consistency

A transaction moves the database from one **valid state** to another.

* Constraints
* Triggers
* Business rules

are all preserved before and after the transaction.

---

#### 3. Isolation

Concurrent transactions do not interfere with each other.
Each transaction behaves **as if it were executed alone**.

Isolation prevents:

* Dirty reads
* Non-repeatable reads
* Phantom reads

---

#### 4. Durability

Once a transaction is committed, its changes are **permanent**, even if:

* SQL Server crashes
* Power is lost

SQL Server guarantees this using the **transaction log**.

---

### Why Use Transactions?

* Prevent partial updates
* Maintain data integrity
* Ensure business rules are enforced
* Safely handle errors
* Protect against unexpected failures

If your operation touches **more than one table or row**, you almost always need a transaction.

---

### Basic Transaction Syntax

```sql
BEGIN TRANSACTION;

-- SQL statements

COMMIT;   -- make changes permanent
-- OR
ROLLBACK; -- undo changes
```

---

### Transactions with TRY...CATCH (Best Practice)

Transactions should **always** be paired with error handling.

```sql
BEGIN TRAN;

BEGIN TRY
    -- Statements
    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
    THROW; -- rethrow error to caller
END CATCH;
```

This ensures:

* Successful operations are committed
* Failed operations are fully rolled back

---

### Real-World Example: Bank Transfer

#### Setup

```sql
CREATE TABLE Accounts (
    AccountID INT PRIMARY KEY,
    Balance DECIMAL(10,2)
);

CREATE TABLE Transactions (
    TransactionID INT IDENTITY PRIMARY KEY,
    FromAccount INT,
    ToAccount INT,
    Amount DECIMAL(10,2),
    CreatedAt DATETIME
);

INSERT INTO Accounts VALUES (1, 500.00), (2, 300.00);
```

---

#### Transfer Logic

```sql
BEGIN TRAN;

BEGIN TRY
    -- Validate balance
    IF (SELECT Balance FROM Accounts WHERE AccountID = 1) < 100
        THROW 51000, 'Insufficient balance.', 1;

    -- Debit
    UPDATE Accounts
    SET Balance = Balance - 100
    WHERE AccountID = 1;

    -- Credit
    UPDATE Accounts
    SET Balance = Balance + 100
    WHERE AccountID = 2;

    -- Log transaction
    INSERT INTO Transactions (FromAccount, ToAccount, Amount, CreatedAt)
    VALUES (1, 2, 100, GETDATE());

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;

    SELECT
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
```

#### Why This Is Correct

* Balance is validated **before** updates
* All changes are atomic
* Logging happens inside the transaction
* Failure at any point rolls back everything

---

### Nested Transactions (Important Concept)

SQL Server does **not** truly support nested transactions.

```sql
BEGIN TRAN;
    BEGIN TRAN;
    COMMIT;
ROLLBACK;
```

Only the **outermost transaction** controls the final commit.
`@@TRANCOUNT` tracks nesting level.

---

### Checking Transaction State

```sql
SELECT @@TRANCOUNT;
```

* `0` → No active transaction
* `>0` → Active transaction(s)

Always check before committing or rolling back.

---

### Common Mistakes

❌ Forgetting to COMMIT or ROLLBACK

❌ Long-running transactions (locks tables)

❌ Mixing UI logic with transaction logic

❌ Using transactions for read-only queries

---

### Best Practices

✔ Keep transactions **short**

✔ Use TRY...CATCH always

✔ Validate data before starting transaction when possible

✔ Never leave transactions open

✔ Log meaningful failures

---

### When NOT to Use Transactions

* Simple SELECT queries
* Read-only reporting
* Long-running batch jobs (unless absolutely required)

---

### Summary

* Transactions guarantee **data integrity**
* ACID properties define transaction reliability
* TRY...CATCH + TRANSACTION is the professional standard
* Transactions are critical in financial and business systems
* Poor transaction design causes locking and performance issues

---

## Variable Tables (Table Variables)

### Introduction to Table Variables
Table variables in T-SQL are used to store a set of records temporarily. They are similar in concept to temporary tables, but they have **distinct characteristics** that make them suitable for specific scenarios.

Table variables are declared using the `DECLARE` statement and are **scoped to the batch, stored procedure, or function** in which they are defined.

They are commonly used for:
- Intermediate result storage
- Small lookup datasets
- Temporary calculations inside complex queries

---

### Declaring a Table Variable

```sql
DECLARE @EmployeesTable TABLE (
    EmployeeId INT,
    Name VARCHAR(100),
    Department VARCHAR(50)
);
```

Key points:
- The table exists **only in memory scope** (conceptually)
- No `DROP TABLE` is required
- Automatically deallocated when execution ends

---

### Basic Usage Example

```sql
INSERT INTO @EmployeesTable (EmployeeId, Name, Department)
VALUES (10, 'Mohammed', 'Marketing');

INSERT INTO @EmployeesTable (EmployeeId, Name, Department)
VALUES (11, 'Ali', 'Sales');

SELECT *
FROM @EmployeesTable
WHERE Department = 'Sales';
```

This example demonstrates:
- Inserting rows
- Querying data
- Automatic cleanup at the end of execution

---

### Advantages of Table Variables

#### 1. Performance (Small Datasets)
- Ideal for **small to medium row counts**
- Avoids tempdb overhead for simple operations

#### 2. Reduced Transaction Logging
- Generates fewer log records compared to temp tables
- Helpful in performance-sensitive logic

#### 3. Controlled Scope
- Exists only within the current batch / procedure / function
- Simplifies error handling and avoids naming conflicts

---

### Limitations of Table Variables

#### 1. Indexing Limitations
- Only **PRIMARY KEY** or **UNIQUE** constraints can be defined at declaration
- No ability to create additional indexes later

```sql
DECLARE @Orders TABLE (
    OrderId INT PRIMARY KEY,
    Amount DECIMAL(10,2)
);
```

#### 2. No Statistics
- SQL Server does **not generate statistics** for table variables
- Query optimizer assumes very small row counts
- Can cause **poor execution plans** for larger datasets

---

### Table Variables vs Temporary Tables

| Feature | Table Variable | Temporary Table (#Temp) |
|------|--------------|-----------------------|
| Scope | Batch / Procedure / Function | Session or Connection |
| Statistics | ❌ None | ✅ Yes |
| Indexing | Limited | Full |
| Logging | Minimal | Full |
| Rollback on TRANSACTION | ❌ Not rolled back | ✅ Rolled back |

---

### Important Transaction Behavior (Critical)

Table variables **do NOT fully participate in transactions**.

```sql
BEGIN TRANSACTION;

INSERT INTO @EmployeesTable VALUES (20, 'Test', 'IT');

ROLLBACK;

SELECT * FROM @EmployeesTable;
```

🔴 The inserted row **still exists** after `ROLLBACK`.

This behavior makes table variables unsuitable for:
- Financial operations
- Critical transactional workflows

---

### Example: Aggregation + Filtering

```sql
DECLARE @DepartmentSummary TABLE (
    Department VARCHAR(50),
    EmployeeCount INT
);

INSERT INTO @DepartmentSummary
SELECT Department, COUNT(*)
FROM Employees
GROUP BY Department;

SELECT *
FROM @DepartmentSummary
WHERE EmployeeCount > 5;
```

Use case:
- Intermediate aggregation
- Read-only consumption afterward

---

### Example: Using Table Variable with APPLY

```sql
DECLARE @RecentExits TABLE (
    DepartmentId INT,
    EmployeeName VARCHAR(100),
    ExitDate DATE
);

INSERT INTO @RecentExits
SELECT D.ID, CONCAT(E.FirstName, ' ', E.LastName), E.ExitDate
FROM Departments D
CROSS APPLY (
    SELECT TOP 2 *
    FROM Employees
    WHERE DepartmentID = D.ID
    ORDER BY ExitDate DESC
) E;

SELECT * FROM @RecentExits;
```

This demonstrates:
- Using table variables as **intermediate result holders**
- Simplifying complex multi-step queries

---

### Best Practices

- ✅ Use table variables for **small datasets**
- ✅ Use for **short-lived, batch-scoped logic**
- ❌ Avoid for large row counts
- ❌ Avoid when accurate query optimization is critical
- ❌ Avoid for transactional financial data

---

### When to Prefer Table Variables

✔ Small result sets

✔ Lookup data

✔ Intermediate transformations

✔ Logic inside functions

### When NOT to Use Table Variables

✖ Large datasets

✖ Heavy joins

✖ Performance-critical queries

✖ Operations requiring rollback

---

### Conclusion

Table variables are a **powerful but specialized tool** in T-SQL. They shine in small, scoped, non-transactional operations where simplicity and performance matter. However, their limitations—especially around statistics and transactions—mean they must be used **deliberately and carefully**.

---

## Temporary Tables in T-SQL

### Introduction to Temporary Tables

Temporary tables in T-SQL are used to store and process **intermediate results** during query execution. They are physically created inside the **tempdb** system database and are automatically removed when they are no longer needed.

Temporary tables are especially useful in **complex SQL operations** where:

* Results must be reused multiple times
* Queries become easier to read when broken into stages
* Large intermediate datasets must be processed efficiently

---

### Advantages of Temporary Tables

#### Performance

Temporary tables can significantly improve performance by breaking large, complex queries into smaller, more manageable steps. SQL Server can create **statistics** and **indexes** on temp tables, allowing the optimizer to generate better execution plans.

#### Complex Data Processing

They are ideal for:

* Multi-step transformations
* Aggregations reused across queries
* Staging data before final inserts or reports

#### Transaction Management

Temporary tables **participate in transactions**, meaning:

* Changes can be committed or rolled back
* They support ACID behavior inside a transaction

This makes them suitable for scenarios where data consistency is critical.

---

### Types of Temporary Tables

#### Local Temporary Tables (`#TempTable`)

* Prefixed with a single hash `#`
* Visible **only to the session** that created them
* Automatically dropped when the session ends

**Syntax:**

```sql
CREATE TABLE #TempTable (...)
```

#### Global Temporary Tables (`##TempTable`)

* Prefixed with double hash `##`
* Visible to **all sessions**
* Dropped when the **last session using it closes**

**Syntax:**

```sql
CREATE TABLE ##TempTable (...)
```

> ⚠️ Global temp tables are rarely recommended in production due to concurrency and naming conflicts.

---

### Cleaning Up Temporary Tables

Temporary tables are dropped automatically when their scope ends, but **explicitly dropping them** is considered best practice:

```sql
DROP TABLE #TempTable;
```

Benefits of explicit cleanup:

* Frees tempdb resources sooner
* Improves readability
* Avoids name collisions in long sessions

---

### Basic Example: Local Temporary Table

```sql
CREATE TABLE #EmployeesTemp (
    EmployeeId INT,
    Name VARCHAR(100),
    Department VARCHAR(50)
);

INSERT INTO #EmployeesTemp (EmployeeId, Name, Department)
VALUES
(10, 'Mohammed', 'Marketing'),
(11, 'Ali', 'Sales');

SELECT *
FROM #EmployeesTemp
WHERE Department = 'Sales';

DROP TABLE #EmployeesTemp;
```

---

### Example 1: Multi-Step Data Processing

#### Scenario

Generate a report of departments with employee counts **greater than the company average**.

```sql
-- Step 1: Store department employee counts
CREATE TABLE #DeptCounts (
    DepartmentID INT,
    EmployeeCount INT
);

INSERT INTO #DeptCounts
SELECT DepartmentID, COUNT(*)
FROM Employees
GROUP BY DepartmentID;

-- Step 2: Calculate company average
DECLARE @AvgEmployees FLOAT;

SELECT @AvgEmployees = AVG(EmployeeCount)
FROM #DeptCounts;

-- Step 3: Filter departments above average
SELECT d.Name, dc.EmployeeCount
FROM #DeptCounts dc
JOIN Departments d ON d.ID = dc.DepartmentID
WHERE dc.EmployeeCount > @AvgEmployees;

DROP TABLE #DeptCounts;
```

**Why temp tables here?**

* Data reused multiple times
* Optimizer benefits from statistics
* Cleaner than nested subqueries

---

### Example 2: Temp Tables with Transactions

#### Scenario

Update salaries in bulk, but ensure rollback on error.

```sql
BEGIN TRANSACTION;

BEGIN TRY
    CREATE TABLE #SalaryUpdates (
        EmployeeID INT,
        NewSalary DECIMAL(10,2)
    );

    INSERT INTO #SalaryUpdates
    SELECT EmployeeID, Salary * 1.1
    FROM Employees
    WHERE PerformanceRating = 'Excellent';

    UPDATE e
    SET Salary = s.NewSalary
    FROM Employees e
    JOIN #SalaryUpdates s ON s.EmployeeID = e.EmployeeID;

    COMMIT;
END TRY
BEGIN CATCH
    ROLLBACK;
END CATCH;

DROP TABLE #SalaryUpdates;
```

**Key Point:**
Unlike table variables, temp table changes are fully rolled back.

---

### Temporary Tables vs Table Variables

| Aspect       | Temporary Tables         | Table Variables |
| ------------ | ------------------------ | --------------- |
| Storage      | tempdb                   | Memory / tempdb |
| Statistics   | Yes                      | No              |
| Indexing     | Full support             | Limited         |
| Transactions | Fully supported          | Limited         |
| Best for     | Large & complex datasets | Small datasets  |

---

### Temporary Tables vs Permanent Tables

#### Temporary Tables

* Short-lived
* Stored in tempdb
* Not backed up
* Session or connection scoped

#### Permanent Tables

* Persist until dropped
* Stored in user databases
* Included in backups
* Shared across users

---

### Best Practices

* Use temp tables for **large or complex datasets**
* Drop temp tables explicitly
* Avoid global temp tables unless absolutely necessary
* Index temp tables when reused heavily

---

### Conclusion

Temporary tables are a **core tool** in professional T-SQL development. They provide flexibility, performance benefits, and transactional safety when handling complex logic and large intermediate datasets. Knowing when to use temp tables versus table variables or permanent tables is essential for writing efficient, scalable SQL code.

---

## Stored Procedures (T-SQL)

### Introduction to Stored Procedures

Stored procedures in **T-SQL** are one of the most important building blocks in SQL Server–based systems. A stored procedure is a named, precompiled collection of SQL statements stored in the database and executed as a single unit.

They are widely used in **real-world systems** to encapsulate business logic, enforce rules, improve performance, and provide a clean contract between the database and application layers.

#### Why Stored Procedures Matter

**Performance**

* Stored procedures are compiled once and reused.
* Execution plans are cached, reducing repeated parsing and optimization.

**Security**

* Applications can be granted permission to execute procedures without direct access to tables.
* Prevents accidental or malicious data manipulation.

**Maintainability**

* Business logic is centralized inside the database.
* Changes can be made without modifying application code.

**Consistency**

* All applications use the same logic for data access and validation.

---

### What Can Be Written Inside a Stored Procedure

A T-SQL stored procedure can contain almost everything needed to implement business logic:

#### SQL Statements (DML)

* `SELECT`
* `INSERT`
* `UPDATE`
* `DELETE`
* `MERGE`

#### Variable Declarations

```sql
DECLARE @Total INT;
SET @Total = 10;
```

#### Control Flow

* `IF ... ELSE`
* `WHILE`
* `BEGIN ... END`
* `RETURN`

#### Transactions

```sql
BEGIN TRAN;
COMMIT;
ROLLBACK;
```

#### Error Handling

```sql
BEGIN TRY
    -- logic
END TRY
BEGIN CATCH
    THROW;
END CATCH
```

#### Calling Other Objects

* Stored procedures
* Scalar functions
* Table-valued functions

#### Temporary Storage

* Temporary tables (`#TempTable`)
* Table variables (`@TableVar`)

#### Advanced Features

* Dynamic SQL (`sp_executesql`)
* CTEs
* Cursors (rare, but supported)
* XML processing

---

### Understanding Return Values in Stored Procedures

#### What Is a Return Value?

* A **single integer** value returned using `RETURN`.
* Commonly used to indicate **status**, not data.

Typical conventions:

* `1` → Success
* `0` → Not found / false
* `-1` → Invalid input

> ⚠ A stored procedure can return **only one integer value**.

---

### Example: Checking If a Person Exists

#### Stored Procedure

```sql
CREATE PROCEDURE SP_IsPersonExists
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @PersonID IS NULL OR @PersonID <= 0
        RETURN 0;

    IF NOT EXISTS (SELECT 1 FROM People WHERE PersonID = @PersonID)
        RETURN 0;

    RETURN 1;
END;
```

#### Usage

```sql
DECLARE @Result INT;
EXEC @Result = SP_IsPersonExists @PersonID = 5;

IF @Result = 1
    PRINT 'Person exists';
ELSE
    PRINT 'Person not found';
```

This pattern is **very common in real systems** for validation before UPDATE or DELETE operations.

---

### CRUD Stored Procedures – Real-World Design

#### Add New Person

```sql
CREATE PROCEDURE SP_AddNewPerson
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255),
    @NewPersonID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @FirstName IS NULL OR @LastName IS NULL
        RETURN -1;

    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);

    SET @NewPersonID = SCOPE_IDENTITY();
    RETURN 1;
END;
```

---

#### Get All People

```sql
CREATE PROCEDURE SP_GetAllPeople
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM People;
END;
```

---

#### Get Person by ID (Result Set)

```sql
ALTER PROCEDURE SP_GetPersonByID
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;

    IF @PersonID IS NULL OR @PersonID <= 0
        RETURN -1;

    SELECT * FROM People WHERE PersonID = @PersonID;

    IF @@ROWCOUNT = 0
        RETURN 0;

    RETURN 1;
END;
```

---

#### Get Person Info Using OUTPUT Parameters

```sql
CREATE PROCEDURE SP_GetPersonInfoByID
    @PersonID INT,
    @FirstName NVARCHAR(100) OUTPUT,
    @LastName NVARCHAR(100) OUTPUT,
    @Email NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF @PersonID IS NULL OR @PersonID <= 0
        RETURN -1;

    SELECT
        @FirstName = FirstName,
        @LastName = LastName,
        @Email = Email
    FROM People
    WHERE PersonID = @PersonID;

    IF @@ROWCOUNT = 0
        RETURN 0;

    RETURN 1;
END;
```

---

#### Update Person (Transaction + Validation)

```sql
ALTER PROCEDURE SP_UpdatePerson
    @PersonID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Exists INT;
    EXEC @Exists = SP_IsPersonExists @PersonID;

    IF @Exists = 0
        RETURN 0;

    BEGIN TRY
        BEGIN TRAN;

        UPDATE People
        SET FirstName = @FirstName,
            LastName = @LastName,
            Email = @Email
        WHERE PersonID = @PersonID;

        COMMIT;
        RETURN 1;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
```

---

#### Delete Person

```sql
ALTER PROCEDURE SP_DeletePerson
    @PersonID INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Exists INT;
    EXEC @Exists = SP_IsPersonExists @PersonID;

    IF @Exists = 0
        RETURN 0;

    BEGIN TRY
        BEGIN TRAN;

        DELETE FROM People WHERE PersonID = @PersonID;

        COMMIT;
        RETURN 1;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END;
```

---

### Using `sp_helptext`

The `sp_helptext` system stored procedure displays the definition of database objects.

#### Syntax

```sql
EXEC sp_helptext 'SP_DeletePerson';
```

#### Use Cases

* Code review
* Debugging
* Learning legacy systems

> ⚠ Requires proper permissions

---

### Best Practices Summary

✔ Use stored procedures for business logic

✔ Use `RETURN` for status, not data

✔ Use OUTPUT parameters for small structured outputs

✔ Use transactions only for data modification

✔ Avoid cursors when possible

✔ Validate inputs at the database level

✔ Keep procedures small and focused

---

### Final Notes

Stored procedures are **not optional** in serious SQL Server systems.
They form the backbone of:

* APIs
* ERP systems
* Banking systems
* Healthcare platforms

---

## Built-In Functions in T-SQL

This section covers the most commonly used **built-in functions** in T-SQL, including string functions, date functions, and aggregate functions, with practical examples.

---

### 1. String Functions

String functions are essential for manipulating text data in SQL Server.

| Function    | Purpose                                                                          |
| ----------- | -------------------------------------------------------------------------------- |
| `LEN`       | Returns the number of characters in a string (excluding trailing spaces).        |
| `UPPER`     | Converts all characters to uppercase.                                            |
| `LOWER`     | Converts all characters to lowercase.                                            |
| `SUBSTRING` | Returns part of a string from a specified start position for a specified length. |
| `CHARINDEX` | Returns the starting position of a substring in a string.                        |
| `REPLACE`   | Replaces occurrences of a substring with another string.                         |
| `LTRIM`     | Removes leading spaces.                                                          |
| `RTRIM`     | Removes trailing spaces.                                                         |
| `CONCAT`    | Concatenates two or more strings.                                                |
| `LEFT`      | Returns the leftmost characters of a string.                                     |
| `RIGHT`     | Returns the rightmost characters of a string.                                    |
| `TRIM`      | Removes leading and trailing spaces.                                             |

**Example:**

```sql
DECLARE @FullName NVARCHAR(100) = '   John Doe   ';

SELECT 
    LEN(@FullName) AS LengthBeforeTrim,
    LTRIM(@FullName) AS LeftTrimmed,
    RTRIM(@FullName) AS RightTrimmed,
    TRIM(@FullName) AS FullyTrimmed,
    UPPER(@FullName) AS UpperCase,
    LOWER(@FullName) AS LowerCase,
    SUBSTRING(@FullName, 4, 3) AS SubStr,
    CHARINDEX('Doe', @FullName) AS PositionOfDoe,
    REPLACE(@FullName, 'John', 'Jane') AS ReplacedName,
    CONCAT('Hello ', TRIM(@FullName)) AS Greeting;
```

Official Documentation: [String Functions (Transact-SQL)](https://learn.microsoft.com/en-us/sql/t-sql/functions/string-functions-transact-sql?view=sql-server-ver16)

---

### 2. Date and Time Functions

Date functions allow you to manipulate and query datetime data.

| Function        | Purpose                                                         |
| --------------- | --------------------------------------------------------------- |
| `GETDATE()`     | Returns current date and time.                                  |
| `SYSDATETIME()` | Returns system date/time with fractional seconds.               |
| `DATEADD()`     | Adds a specified number of units to a date.                     |
| `DATEDIFF()`    | Calculates difference between two dates in a specific unit.     |
| `DATEPART()`    | Returns a part of the date (year, month, day, etc.).            |
| `DATENAME()`    | Returns the name of the specified date part (e.g., month name). |
| `DAY()`         | Returns day part of a date.                                     |
| `MONTH()`       | Returns month part of a date.                                   |
| `YEAR()`        | Returns year part of a date.                                    |
| `CONVERT()`     | Converts one data type to another (often used for formatting).  |
| `CAST()`        | Similar to CONVERT, changes the data type.                      |
| `EOMONTH()`     | Returns the last day of the month for a given date.             |

**Example:**

```sql
DECLARE @Today DATETIME = GETDATE();

SELECT
    @Today AS CurrentDateTime,
    DATEADD(DAY, 7, @Today) AS NextWeek,
    DATEDIFF(DAY, '2025-01-01', @Today) AS DaysSince2025,
    DATEPART(YEAR, @Today) AS YearPart,
    DATENAME(MONTH, @Today) AS MonthName,
    EOMONTH(@Today) AS EndOfMonth;
```

Official Documentation: [Date and Time Functions (Transact-SQL)](https://learn.microsoft.com/en-us/sql/t-sql/functions/date-and-time-data-types-and-functions-transact-sql?view=sql-server-ver16)

---

### 3. Aggregate Functions

Aggregate functions are used to perform calculations on multiple rows, often with `GROUP BY`.

| Function  | Purpose              |
| --------- | -------------------- |
| `COUNT()` | Counts rows.         |
| `SUM()`   | Adds values.         |
| `AVG()`   | Calculates average.  |
| `MIN()`   | Finds minimum value. |
| `MAX()`   | Finds maximum value. |

**Example Table: Employees2**

| EmployeeID | Department | Salary | PerformanceRating |
| ---------- | ---------- | ------ | ----------------- |
| 1          | Sales      | 5000   | 4                 |
| 2          | Sales      | 5500   | 5                 |
| 3          | IT         | 6000   | 4                 |
| 4          | IT         | 6500   | 5                 |

**Examples of Aggregate Functions:**

```sql
-- Count employees per department
SELECT Department, COUNT(*) AS EmployeeCount
FROM Employees2
GROUP BY Department;

-- Total salary per department
SELECT Department, SUM(Salary) AS TotalSalary
FROM Employees2
GROUP BY Department;

-- Average performance rating per department
SELECT Department, AVG(PerformanceRating) AS AvgRating
FROM Employees2
GROUP BY Department;

-- Minimum salary in the company
SELECT MIN(Salary) AS LowestSalary
FROM Employees2;

-- Maximum salary in the company
SELECT MAX(Salary) AS HighestSalary
FROM Employees2;
```

---

### Key Takeaways

1. **String functions** help with cleaning, formatting, and parsing text data.
2. **Date functions** simplify manipulation, extraction, and formatting of date/time values.
3. **Aggregate functions** are essential for summarizing and analyzing data.
4. Combining these functions with clauses like `WHERE`, `GROUP BY`, and `ORDER BY` allows for advanced queries and reporting.

---

## Window Functions in T-SQL

### What Are Window Functions?

Window functions (also known as **windowed** or **analytic functions**) in T-SQL allow you to perform calculations across a set of rows that are related to the current row.

Unlike aggregate functions with `GROUP BY`, window functions **do not collapse rows**. Instead, they return a value for **each row**, based on a defined *window* of rows.

A window is defined using the `OVER()` clause, which can include:

* `PARTITION BY` (how rows are grouped)
* `ORDER BY` (how rows are ordered)
* Optional frame definitions (ROW/RANGE)

---

### Types of Window Functions in T-SQL

#### 1. Aggregate Window Functions

Perform calculations over a window of rows:

* `SUM()`
* `AVG()`
* `COUNT()`
* `MIN()`
* `MAX()`

#### 2. Ranking Functions

Assign rankings or sequence numbers:

* `ROW_NUMBER()`
* `RANK()`
* `DENSE_RANK()`

#### 3. Analytic Functions

Compare values between rows:

* `LAG()`
* `LEAD()`
* `FIRST_VALUE()`
* `LAST_VALUE()`

---

### Understanding ROW_NUMBER()

#### Definition

`ROW_NUMBER()` assigns a **unique sequential number** to each row.

* Starts at 1
* No duplicates, even if values are tied

#### Example

```sql
SELECT
    StudentID,
    Name,
    Subject,
    Grade,
    ROW_NUMBER() OVER (ORDER BY Grade DESC) AS RowNum
FROM Students;
```

#### Key Points

* Every row gets a unique number
* Useful for **pagination**, **deduplication**, and **top-N queries**

---

### ROW_NUMBER() with PARTITION BY

#### Scenario

Assign row numbers **per subject**:

```sql
SELECT
    StudentID,
    Name,
    Subject,
    Grade,
    ROW_NUMBER() OVER (PARTITION BY Subject ORDER BY Grade DESC) AS RowNum
FROM Students;
```

#### Result

* Numbering restarts for each subject
* Still guarantees uniqueness within each partition

---

### Understanding RANK()

#### Definition

`RANK()` assigns the same rank to tied values, **skipping numbers** afterward.

#### Example

```sql
SELECT
    StudentID,
    Name,
    Grade,
    RANK() OVER (ORDER BY Grade DESC) AS GradeRank
FROM Students;
```

#### Behavior Example

Grades: `95, 95, 90`
Ranks:  `1, 1, 3`

---

### RANK() with PARTITION BY

#### Rank students **within each subject**

```sql
SELECT
    StudentID,
    Name,
    Subject,
    Grade,
    RANK() OVER (PARTITION BY Subject ORDER BY Grade DESC) AS SubjectRank
FROM Students;
```

#### Key Benefit

* Enables **category-based ranking**
* Common in reporting and analytics

---

### RANK() vs DENSE_RANK()

#### Key Difference

| Function     | Handles Ties | Skips Numbers |
| ------------ | ------------ | ------------- |
| RANK()       | Yes          | Yes           |
| DENSE_RANK() | Yes          | No            |

#### Example Grades

`95, 95, 90, 85`

```text
RANK():       1, 1, 3, 4
DENSE_RANK(): 1, 1, 2, 3
```

#### Example Query

```sql
SELECT
    Name,
    Grade,
    DENSE_RANK() OVER (ORDER BY Grade DESC) AS DenseRank
FROM Students;
```

---

### Aggregate Window Functions with PARTITION BY

#### Scenario

Calculate subject-level statistics **without grouping rows**

```sql
SELECT
    StudentID,
    Name,
    Subject,
    Grade,
    AVG(Grade) OVER (PARTITION BY Subject) AS SubjectAvg,
    SUM(Grade) OVER (PARTITION BY Subject) AS SubjectTotal
FROM Students;
```

#### Why This Is Powerful

* Combines **row-level detail** with **group-level insights**
* No `GROUP BY` needed

---

### Example: Running Totals

#### Cumulative grades per subject

```sql
SELECT
    StudentID,
    Name,
    Subject,
    Grade,
    SUM(Grade) OVER (
        PARTITION BY Subject
        ORDER BY Grade DESC
        ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
    ) AS RunningTotal
FROM Students;
```

#### Use Cases

* Financial reports
* Progress tracking
* Cumulative analytics

---

### Using LAG() and LEAD()

#### Purpose

Compare current row values with **previous** or **next** rows

#### Example (Single Query)

```sql
SELECT
    StudentID,
    Name,
    Grade,
    LAG(Grade) OVER (ORDER BY Grade DESC) AS PreviousGrade,
    LEAD(Grade) OVER (ORDER BY Grade DESC) AS NextGrade
FROM Students;
```

#### Interpretation

* `PreviousGrade`: Grade of the row above
* `NextGrade`: Grade of the row below

---

### Example: Grade Difference

```sql
SELECT
    Name,
    Grade,
    Grade - LAG(Grade) OVER (ORDER BY Grade DESC) AS GradeDifference
FROM Students;
```

#### Insight

* Shows performance gaps between students

---

### Paging with OFFSET and FETCH NEXT

#### Variables

```sql
DECLARE @PageNumber INT = 2;
DECLARE @RowsPerPage INT = 3;
```

#### Paging Query

```sql
SELECT StudentID, Name, Subject, Grade
FROM Students
ORDER BY StudentID
OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY;
```

#### How It Works

* Page 1 → Rows 1–3
* Page 2 → Rows 4–6
* Page 3 → Rows 7–9

---

### When to Use Window Functions

✔ Ranking and leaderboards

✔ Pagination

✔ Running totals

✔ Comparative analysis

✔ Analytics without data loss

---

### Summary

Window functions are one of the **most powerful features in T-SQL**. They allow:

* Advanced analytics
* Clean, readable queries
* High-performance reporting

---

## Scalar Functions in T-SQL

### Introduction

Scalar Functions in T-SQL allow you to **encapsulate reusable logic** and return **a single value**. They are useful for calculations, transformations, and enforcing business rules directly inside SQL Server.

A Scalar Function:

* Returns **one value**
* Can be used **anywhere an expression is allowed** (SELECT, WHERE, JOIN, ORDER BY)
* Helps keep SQL logic **clean, reusable, and maintainable**

---

### Creating a Scalar Function

#### Example 1: Average Grade per Subject

```sql
CREATE FUNCTION dbo.GetAverageGrade (@Subject NVARCHAR(50))
RETURNS INT
AS
BEGIN
    DECLARE @AverageGrade INT;

    SELECT @AverageGrade = AVG(Grade)
    FROM Students
    WHERE Subject = @Subject;

    RETURN @AverageGrade;
END;
```

#### How It Works

* Accepts a **subject name** as input
* Calculates the average grade for that subject
* Returns **one integer value**

---

### Using Scalar Functions

#### In a SELECT Statement

```sql
SELECT Name, Subject, dbo.GetAverageGrade(Subject) AS AverageGrade
FROM Teachers;
```

✔ The function runs **once per row** in the Teachers table

---

#### In a WHERE Clause

```sql
SELECT Name, Subject
FROM Teachers
WHERE dbo.GetAverageGrade(Subject) > 80;
```

✔ Filters teachers based on computed values

---

### Example: Salary Bonus Calculation

#### Business Rule

* Performance Rating ≥ 5 → 10% bonus
* Performance Rating < 5 → 5% bonus

#### Scalar Function

```sql
CREATE FUNCTION dbo.CalculateBonus
(
    @PerformanceRating INT,
    @Salary INT
)
RETURNS INT
AS
BEGIN
    DECLARE @Bonus INT;

    IF @PerformanceRating >= 5
        SET @Bonus = @Salary * 0.10;
    ELSE
        SET @Bonus = @Salary * 0.05;

    RETURN @Bonus;
END;
```

#### Usage Example

```sql
DECLARE @Salary INT = 2500;
DECLARE @PerformanceRating INT = 5;
DECLARE @Bonus INT = dbo.CalculateBonus(@PerformanceRating, @Salary);

SELECT
    @Salary AS Salary,
    @Bonus AS Bonus,
    @Salary + @Bonus AS UpdatedSalary;
```

✔ Encapsulates business logic cleanly

---

### Example: Grade Classification Function

#### Business Rule

| Grade | Classification |
| ----- | -------------- |
| ≥ 90  | Excellent      |
| ≥ 75  | Very Good      |
| ≥ 60  | Good           |
| < 60  | Fail           |

#### Scalar Function

```sql
CREATE FUNCTION dbo.GetGradeStatus (@Grade INT)
RETURNS NVARCHAR(20)
AS
BEGIN
    DECLARE @Status NVARCHAR(20);

    SET @Status = CASE
        WHEN @Grade >= 90 THEN 'Excellent'
        WHEN @Grade >= 75 THEN 'Very Good'
        WHEN @Grade >= 60 THEN 'Good'
        ELSE 'Fail'
    END;

    RETURN @Status;
END;
```

#### Usage

```sql
SELECT Name, Subject, Grade, dbo.GetGradeStatus(Grade) AS Status
FROM Students;
```

✔ Converts raw data into meaningful information

---

### Important Notes

⚠ Scalar Functions:

* Are executed **row-by-row**
* Can cause **performance issues** on large datasets
* Should **avoid heavy logic or table scans**

✔ Best Practices:

* Keep logic simple
* Avoid calling scalar functions inside large joins
* Prefer **inline table-valued functions** for performance-critical queries

---

### Summary

✔ Scalar Functions:

* Return a single value
* Improve code reusability
* Encapsulate business rules
* Can be used in SELECT, WHERE, ORDER BY

---

## Table-Valued Functions (TVFs)

### Introduction

Table-Valued Functions (TVFs) are user-defined functions in T-SQL that return **tabular data** instead of a single scalar value. They allow you to encapsulate complex queries and reusable logic into a function that behaves like a table.

TVFs are commonly used to:

* Simplify complex queries
* Improve code reuse
* Encapsulate business logic
* Improve query readability

TVFs can be used anywhere a table expression is allowed, especially in the `FROM` clause.

---

### Types of Table-Valued Functions

SQL Server supports **two types** of TVFs:

#### 1. Inline Table-Valued Functions (ITVFs)

* Defined using `RETURNS TABLE`
* Contain **one SELECT statement only**
* No table variable
* **Best performance** (expanded into calling query)
* Read-only (no INSERT / UPDATE / DELETE)

#### 2. Multi-Statement Table-Valued Functions (MTVFs)

* Use `RETURNS @TableVariable TABLE (...)`
* Can contain **multiple statements**
* Allow procedural logic (IF, loops, multiple inserts)
* Generally **slower** due to table variable usage

---

### Inline Table-Valued Functions (ITVFs)

#### Key Characteristics

* Single SELECT statement
* Cannot modify data
* Optimizer treats them like a view
* Support parameters

---

### Scenario Setup

```sql
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT
);
```

---

### Creating an Inline Table-Valued Function

```sql
CREATE FUNCTION dbo.GetStudentsBySubject
(
    @Subject NVARCHAR(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT StudentID, Name, Subject, Grade
    FROM Students
    WHERE Subject = @Subject
);
```

#### Explanation

* The function accepts a subject name
* Returns all students studying that subject
* Output behaves like a normal table

---

### Using the Inline TVF

#### Example 1: Simple SELECT

```sql
SELECT *
FROM dbo.GetStudentsBySubject('Math');
```

#### Example 2: Aggregation

```sql
SELECT AVG(Grade) AS AverageGrade
FROM dbo.GetStudentsBySubject('Science');
```

---

### Using ITVFs with JOINs

#### Additional Table

```sql
CREATE TABLE Teachers (
    TeacherID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Subject NVARCHAR(50)
);
```

#### JOIN Example

```sql
SELECT
    s.StudentID,
    s.Name AS StudentName,
    t.Name AS TeacherName,
    s.Grade
FROM dbo.GetStudentsBySubject('Math') s
JOIN Teachers t
    ON s.Subject = t.Subject;
```

#### Why This Is Powerful

* ITVFs integrate seamlessly with joins
* Optimizer can reorder joins efficiently
* No performance penalty compared to inline SQL

---

### Filter TVF Example

#### Filter Students by Grade Range

```sql
CREATE FUNCTION dbo.GetStudentsByGradeRange
(
    @MinGrade INT,
    @MaxGrade INT
)
RETURNS TABLE
AS
RETURN
(
    SELECT StudentID, Name, Subject, Grade
    FROM Students
    WHERE Grade BETWEEN @MinGrade AND @MaxGrade
);
```

```sql
SELECT *
FROM dbo.GetStudentsByGradeRange(80, 100);
```

---

### Multi-Statement Table-Valued Functions (MTVFs)

#### Key Characteristics

* Use table variables
* Allow multiple statements
* Support complex procedural logic
* Usually slower than ITVFs

---

### Creating a Multi-Statement TVF

```sql
CREATE FUNCTION dbo.GetTopPerformingStudents()
RETURNS @Result TABLE (
    StudentID INT,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT
)
AS
BEGIN
    INSERT INTO @Result
    SELECT TOP 3 StudentID, Name, Subject, Grade
    FROM Students
    ORDER BY Grade DESC;

    RETURN;
END;
```

#### Explanation

* Table variable `@Result` stores the output
* Allows multiple statements
* Suitable for advanced logic

---

### Using the MTVF

```sql
SELECT *
FROM dbo.GetTopPerformingStudents();
```

---

### MTVF with JOIN Example

```sql
SELECT
    t.Name AS TeacherName,
    s.Name AS StudentName,
    s.Grade
FROM Teachers t
JOIN dbo.GetTopPerformingStudents() s
    ON t.Subject = s.Subject;
```

---

### MTVF Example (Business Logic)

#### Top Students Per Subject

```sql
CREATE FUNCTION dbo.GetTopStudentPerSubject()
RETURNS @Result TABLE (
    Subject NVARCHAR(50),
    StudentName NVARCHAR(50),
    Grade INT
)
AS
BEGIN
    INSERT INTO @Result
    SELECT Subject, Name, Grade
    FROM (
        SELECT *,
               ROW_NUMBER() OVER (PARTITION BY Subject ORDER BY Grade DESC) AS rn
        FROM Students
    ) s
    WHERE rn = 1;

    RETURN;
END;
```

```sql
SELECT *
FROM dbo.GetTopStudentPerSubject();
```

---

### Performance Notes (Very Important)

| Feature             | ITVF      | MTVF      |
| ------------------- | --------- | --------- |
| Optimizer-friendly  | ✅ Yes     | ❌ No      |
| Uses table variable | ❌ No      | ✅ Yes     |
| Performance         | 🚀 Fast   | 🐢 Slower |
| Complex logic       | ❌ Limited | ✅ Yes     |

**Best Practice:**

* Use **ITVFs whenever possible**
* Avoid MTVFs in high-traffic queries

---

### Summary

* TVFs return tables, not scalar values
* ITVFs are best for performance
* MTVFs allow complex logic
* Both can be used like tables
* ITVFs are preferred in production systems

---

Below is a **NEW standalone MD section** (you can save it as
📄 **`Dynamic_SQL_and_SQL_Injection.md`**)
Nothing from previous sections is modified.

---

## Dynamic SQL and SQL Injection Attack

### Dynamic SQL in SQL Server

#### Introduction

**Dynamic SQL** refers to SQL statements that are **constructed at runtime as strings** and then executed.
This technique is useful when parts of the SQL query (table name, column name, sort order, filters, etc.) are not known in advance.

While dynamic SQL provides **flexibility**, it introduces **serious security and performance risks** if not implemented correctly.

---

### Why Use Dynamic SQL?

Dynamic SQL is typically used when:

* Table names or column names are dynamic
* Optional filters are applied conditionally
* Dynamic sorting or pagination is required
* Building reusable generic stored procedures

⚠️ **Dynamic SQL should be the exception, not the default**

---

### Generating Dynamic SQL in Stored Procedures

SQL Server provides **two main ways** to execute dynamic SQL:

1. `EXEC()` / `EXECUTE`
2. `sp_executesql` (recommended)

---

### Method 1: Using EXEC (Unsafe if misused)

#### Example (VULNERABLE ❌)

```sql
CREATE PROCEDURE dbo.GenerateDynamicSQL_Unsafe
    @TableName NVARCHAR(128)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'SELECT * FROM ' + @TableName;
    EXEC(@SQL);
END;
```

#### Problems

* Direct string concatenation
* Fully vulnerable to **SQL Injection**
* No parameter support
* Poor execution plan reuse

🚨 **Never trust input used directly in dynamic SQL**

---

### Method 2: Using sp_executesql (Recommended ✅)

#### Safe Example Using `QUOTENAME`

```sql
CREATE PROCEDURE dbo.GenerateDynamicSQL_Safe
    @TableName NVARCHAR(128)
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = N'SELECT * FROM ' + QUOTENAME(@TableName);
    EXEC sp_executesql @SQL;
END;
```

#### Why This Is Safer

* `QUOTENAME()` prevents injection via object names
* Proper Unicode handling
* Supports parameterization
* Better execution plan reuse

---

### Parameterized Dynamic SQL (BEST PRACTICE)

#### Example: Dynamic WHERE Clause (Safe)

```sql
CREATE PROCEDURE dbo.GetStudentById_Dynamic
    @StudentID INT
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = N'
        SELECT StudentID, Name, Subject, Grade
        FROM Students
        WHERE StudentID = @ID';

    EXEC sp_executesql
        @SQL,
        N'@ID INT',
        @ID = @StudentID;
END;
```

✅ **No concatenation**
✅ **Injection-safe**
✅ **Reusable execution plan**

---

### Dynamic SQL Example (Multiple Filters)

```sql
CREATE PROCEDURE dbo.SearchStudents
    @Subject NVARCHAR(50) = NULL,
    @MinGrade INT = NULL
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX) = N'
        SELECT StudentID, Name, Subject, Grade
        FROM Students
        WHERE 1 = 1';

    IF @Subject IS NOT NULL
        SET @SQL += N' AND Subject = @Subject';

    IF @MinGrade IS NOT NULL
        SET @SQL += N' AND Grade >= @MinGrade';

    EXEC sp_executesql
        @SQL,
        N'@Subject NVARCHAR(50), @MinGrade INT',
        @Subject = @Subject,
        @MinGrade = @MinGrade;
END;
```

💡 This pattern avoids writing **dozens of IF-based queries**

---

### SQL Injection Attack

#### What Is SQL Injection?

SQL Injection occurs when **untrusted input becomes part of SQL code**, allowing attackers to:

* Bypass authentication
* Read sensitive data
* Modify or delete records
* Execute administrative commands

---

### Classic SQL Injection Example (VULNERABLE ❌)

```sql
DECLARE @input NVARCHAR(50) = '1 OR 1=1';
DECLARE @SQL NVARCHAR(MAX);

SET @SQL = 'SELECT * FROM Students WHERE StudentID = ' + @input;
EXEC(@SQL);
```

#### Result

```sql
SELECT * FROM Students WHERE StudentID = 1 OR 1=1
```

✔ Returns **ALL students**

❌ Security breach

---

### SQL Injection Impact

* Unauthorized data access
* Data corruption or deletion
* Privilege escalation
* Full database compromise

🔥 SQL Injection is one of the **top OWASP vulnerabilities**

---

### Preventing SQL Injection (CRITICAL)

#### 1️⃣ Parameterized Queries (MOST IMPORTANT)

```sql
DECLARE @StudentID INT = 1;

SELECT *
FROM Students
WHERE StudentID = @StudentID;
```

✔ Input is treated as **data**, not code

---

#### 2️⃣ Use sp_executesql Instead of EXEC

```sql
EXEC sp_executesql
    N'SELECT * FROM Students WHERE StudentID = @ID',
    N'@ID INT',
    @ID = 1;
```

---

#### 3️⃣ Validate Input

```sql
IF @StudentID <= 0
BEGIN
    THROW 50001, 'Invalid StudentID', 1;
END;
```

---

#### 4️⃣ Use QUOTENAME for Object Names

```sql
SET @SQL = 'SELECT * FROM ' + QUOTENAME(@TableName);
```

Prevents:

```sql
Students; DROP TABLE Students;
```

---

#### 5️⃣ Least Privilege Principle

* Avoid executing dynamic SQL as `dbo`
* Restrict permissions
* Never expose admin procedures to public users

---

### What NOT to Do ❌

| Bad Practice               | Why                  |
| -------------------------- | -------------------- |
| String concatenation       | Injection risk       |
| EXEC only                  | No parameterization  |
| Accepting raw object names | DDL injection        |
| Dynamic SQL everywhere     | Hard to debug & slow |

---

### Dynamic SQL: When to Use vs Avoid

#### ✅ Use Dynamic SQL When

* Object names are dynamic
* Optional filters are needed
* Generic reporting procedures

#### ❌ Avoid Dynamic SQL When

* Query is static
* Can be written with normal SQL
* Performance is critical

---

### Summary

| Topic         | Key Takeaway                  |
| ------------- | ----------------------------- |
| Dynamic SQL   | Powerful but dangerous        |
| EXEC          | Avoid when possible           |
| sp_executesql | Preferred approach            |
| SQL Injection | Critical security risk        |
| Prevention    | Parameterization + validation |

---

## Triggers in T-SQL (Advanced Guide)

### 1. Introduction to Triggers

Triggers in T-SQL are special stored procedures that automatically execute when a specific event occurs on a table or view. These events are usually **DML operations**:

* `INSERT`
* `UPDATE`
* `DELETE`

Triggers are tightly coupled to tables and run **implicitly**, meaning the user does not call them directly.

#### Common Use Cases

* Enforcing complex business rules
* Auditing and logging data changes
* Preventing invalid data modifications
* Synchronizing data across tables
* Automatically updating derived data

⚠️ **Important:** Triggers execute within the same transaction as the original statement. If a trigger fails, the original operation is rolled back.

---

### 2. Trigger Types in SQL Server

#### 2.1 AFTER Triggers (FOR Triggers)

Executed **after** the DML operation succeeds.

* AFTER INSERT
* AFTER UPDATE
* AFTER DELETE

Used mainly for:

* Auditing
* Logging
* Notifications

#### 2.2 INSTEAD OF Triggers

Executed **instead of** the original DML operation.

Commonly used for:

* Views
* Advanced validation
* Conditional inserts/updates

---

### 3. Special Tables: `inserted` and `deleted`

SQL Server automatically creates two **virtual tables** during trigger execution:

| Operation | inserted | deleted  |
| --------- | -------- | -------- |
| INSERT    | New rows | ❌        |
| DELETE    | ❌        | Old rows |
| UPDATE    | New rows | Old rows |

These tables:

* Exist only during trigger execution
* Can contain **multiple rows** (important!)
* Have the same structure as the base table

---

### 4. AFTER INSERT Trigger (Auditing Example)

#### Scenario

Log newly added students.

#### Log Table

```sql
CREATE TABLE StudentInsertLog (
    LogID INT IDENTITY PRIMARY KEY,
    StudentID INT,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT,
    InsertedDateTime DATETIME DEFAULT GETDATE()
);
```

#### Trigger

```sql
CREATE TRIGGER trg_AfterInsertStudent
ON Students
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO StudentInsertLog (StudentID, Name, Subject, Grade)
    SELECT StudentID, Name, Subject, Grade
    FROM inserted;
END;
```

✔ Handles **single-row and multi-row inserts** correctly.

---

### 5. AFTER UPDATE Trigger (Change Tracking)

#### Scenario

Track grade changes only.

#### Audit Table

```sql
CREATE TABLE StudentUpdateLog (
    LogID INT IDENTITY PRIMARY KEY,
    StudentID INT,
    OldGrade INT,
    NewGrade INT,
    UpdatedDateTime DATETIME DEFAULT GETDATE()
);
```

#### Trigger

```sql
CREATE TRIGGER trg_AfterUpdateStudent
ON Students
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(Grade)
    BEGIN
        INSERT INTO StudentUpdateLog (StudentID, OldGrade, NewGrade)
        SELECT
            i.StudentID,
            d.Grade AS OldGrade,
            i.Grade AS NewGrade
        FROM inserted i
        JOIN deleted d ON i.StudentID = d.StudentID;
    END
END;
```

#### Why `UPDATE(column)` Matters

* Prevents unnecessary trigger logic
* Improves performance
* Makes intent explicit

---

### 6. AFTER DELETE Trigger (Audit & Recovery)

#### Scenario

Store deleted student records for auditing.

#### Log Table

```sql
CREATE TABLE StudentDeleteLog (
    LogID INT IDENTITY PRIMARY KEY,
    StudentID INT,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT,
    DeletedDateTime DATETIME DEFAULT GETDATE()
);
```

#### Trigger

```sql
CREATE TRIGGER trg_AfterDeleteStudent
ON Students
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO StudentDeleteLog (StudentID, Name, Subject, Grade)
    SELECT StudentID, Name, Subject, Grade
    FROM deleted;
END;
```

✔ Enables **soft recovery** and forensic analysis.

---

### 7. Example: Prevent Invalid Updates

#### Rule

A student's grade **cannot be decreased by more than 20 points** in a single update.

#### Trigger

```sql
CREATE TRIGGER trg_ValidateGradeChange
ON Students
AFTER UPDATE
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN deleted d ON i.StudentID = d.StudentID
        WHERE d.Grade - i.Grade > 20
    )
    BEGIN
        RAISERROR ('Grade decrease exceeds allowed limit.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
```

🔴 This will cancel the entire update if the rule is violated.

---

### 8. Performance & Best Practices

#### ✅ Do

* Always assume **multi-row operations**
* Keep triggers short and focused
* Use indexes on join columns

#### ❌ Avoid

* Heavy logic inside triggers
* Calling long-running procedures
* Nested triggers unless necessary
* Debugging logic without logging

---

## Instead Of Triggers in T-SQL

### Introduction

Instead Of Triggers are a powerful feature in SQL Server that allow you to **override the default behavior** of `INSERT`, `UPDATE`, or `DELETE` operations on **tables or views**. Unlike AFTER triggers, which run *after* the operation succeeds, Instead Of triggers **replace the operation entirely**.

They are essential when:

* The default operation is not possible (e.g., updating a multi-table view)
* Complex business logic must fully control the data change
* You want to prevent physical deletes (soft delete pattern)

---

### What Are Instead Of Triggers?

An Instead Of Trigger executes **instead of** the triggering DML statement.

If SQL Server encounters an `INSERT`, `UPDATE`, or `DELETE` on an object that has an Instead Of trigger, it:

1. **Stops the default operation**
2. Executes the trigger logic
3. Performs only what you explicitly code inside the trigger

If you do not re‑implement the operation inside the trigger, **nothing happens**.

---

### Key Characteristics

* Overrides default DML behavior
* Works on **tables and views**
* Uses `inserted` and `deleted` pseudo-tables
* Enables advanced validation, transformation, and routing of data
* Commonly used where AFTER triggers are insufficient

---

### inserted and deleted Tables Recap

| Operation | inserted | deleted  |
| --------- | -------- | -------- |
| INSERT    | New rows | ❌        |
| DELETE    | ❌        | Old rows |
| UPDATE    | New rows | Old rows |

These tables are **set-based** and may contain multiple rows.

---

### Scenario 1: Soft Delete Using Instead Of DELETE Trigger

#### Why Not AFTER DELETE?

AFTER DELETE runs **after data is already removed**. Soft delete requires **preventing deletion**.

#### Table Preparation

```sql
ALTER TABLE Students
ADD IsActive BIT DEFAULT 1;
```

#### Trigger Implementation

```sql
CREATE TRIGGER trg_InsteadOfDeleteStudent
ON Students
INSTEAD OF DELETE
AS
BEGIN
    UPDATE S
    SET IsActive = 0
    FROM Students S
    INNER JOIN deleted D ON S.StudentID = D.StudentID;
END;
```

#### Result

* Rows are preserved
* Deletion is logically simulated
* Data history remains intact

---

### Scenario 2: Updating a Multi-Table View (Critical Use Case)

#### Problem

Views based on multiple tables **cannot be updated directly**.

#### Tables

```sql
CREATE TABLE PersonalInfo (
    StudentID INT PRIMARY KEY,
    Name NVARCHAR(100),
    Address NVARCHAR(255)
);

CREATE TABLE AcademicInfo (
    StudentID INT PRIMARY KEY,
    Course NVARCHAR(100),
    Grade INT,
    FOREIGN KEY (StudentID) REFERENCES PersonalInfo(StudentID)
);
```

#### View

```sql
CREATE VIEW StudentView AS
SELECT P.StudentID, P.Name, P.Address, A.Course, A.Grade
FROM PersonalInfo P
JOIN AcademicInfo A ON P.StudentID = A.StudentID;
```

#### Instead Of UPDATE Trigger

```sql
CREATE TRIGGER trg_UpdateStudentView
ON StudentView
INSTEAD OF UPDATE
AS
BEGIN
    UPDATE P
    SET Name = I.Name,
        Address = I.Address
    FROM PersonalInfo P
    JOIN inserted I ON P.StudentID = I.StudentID;

    UPDATE A
    SET Course = I.Course,
        Grade = I.Grade
    FROM AcademicInfo A
    JOIN inserted I ON A.StudentID = I.StudentID;
END;
```

#### Why AFTER UPDATE Fails Here

* View update fails before AFTER trigger fires
* SQL Server cannot map columns automatically

Instead Of trigger **intercepts and redirects** the update.

---

### Scenario 3: Instead Of INSERT on Multi-Table View

#### Trigger

```sql
CREATE TRIGGER trg_InsertStudentView
ON StudentView
INSTEAD OF INSERT
AS
BEGIN
    INSERT INTO PersonalInfo (StudentID, Name, Address)
    SELECT StudentID, Name, Address
    FROM inserted;

    INSERT INTO AcademicInfo (StudentID, Course, Grade)
    SELECT StudentID, Course, Grade
    FROM inserted;
END;
```

#### Test

```sql
INSERT INTO StudentView (StudentID, Name, Address, Course, Grade)
VALUES (3, 'Alice Johnson', '789 Pine Rd', 'Physics', 88);
```

---

### Validation Example (Business Rule Enforcement)

#### Rule

> A student cannot have Grade > 100

```sql
CREATE TRIGGER trg_ValidateGrade
ON Students
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE Grade > 100)
    BEGIN
        RAISERROR ('Grade cannot exceed 100', 16, 1);
        RETURN;
    END

    INSERT INTO Students (StudentID, Name, Subject, Grade)
    SELECT StudentID, Name, Subject, Grade
    FROM inserted;
END;
```

---

### AFTER vs INSTEAD OF Triggers

| Feature              | AFTER      | INSTEAD OF |
| -------------------- | ---------- | ---------- |
| Runs after operation | ✅          | ❌          |
| Replaces operation   | ❌          | ✅          |
| Can block operation  | ❌          | ✅          |
| Works on views       | ⚠️ Limited | ✅          |
| Soft delete support  | ❌          | ✅          |

---

### Best Practices

* Always write **set-based logic**
* Assume multiple rows in `inserted` / `deleted`
* Keep triggers **short and predictable**
* Avoid recursive triggers unless necessary
* Document trigger behavior clearly

---

### Conclusion

Instead Of Triggers are **mandatory tools** for:

* Soft deletes
* Updatable multi-table views
* Complex validation and routing
* Full control over data manipulation

---
