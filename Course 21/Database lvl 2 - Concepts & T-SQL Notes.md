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

