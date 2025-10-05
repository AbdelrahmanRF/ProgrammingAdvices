# Database 
---

## Introduction

### What is Database?

A **database** is an organized collection of data that can be easily accessed, managed, and updated.

To handle and control databases, we use **Database Management Systems (DBMS)**.

### Types of DBMS

There are two main types of database management systems:

**1. Non-Relational (DBMS):**

These systems store data in formats other than tables, such as file systems, **XML**, **JSON**, etc.

**2. Relational (RDBMS):**
An enhanced version of DBMS that organizes data into **tables** with **rows** and **columns**, and defines **relationships** between those tables.

Examples include **SQL Server**, **Oracle**, and **MySQL**.


### In RDBMS

Data is stored in an organized structure of tables, each containing rows (records) and columns (fields).

Relationships can be defined between tables to maintain data integrity and enable complex queries.

| Term       | Also Called       | Description                                                          |
| ---------- | ----------------- | -------------------------------------------------------------------- |
| **Table**  | Entity Set        | A collection of related data organized in rows and columns.          |
| **Column** | Field / Attribute | Represents a specific type of data (e.g., Name, Age, Email).         |
| **Row**    | Record / Entity   | Represents a single entry in a table (e.g., a specific user’s data). |

---

### What is NULL?

In a database, **NULL** is a special marker used to indicate that a data value **does not exist** or is **unknown** in the database.

It represents a **missing** value in a table column.

### Key Points

- When a column in a table has a **NULL** value, it means that the field has **no value at all**.

    It’s **not the same as**:

    - an **empty string** (`''`)

    - a **zero** (`0`)

    - or a **blank space**

- **NULL** is treated as a **distinct value** in databases.

- It can be used to:

    - represent **missing data**

    - mark **optional fields**

    - serve as a **placeholder** for values that are not yet known

### Important Note

Use **NULL** values carefully —

they can affect query results and calculations in unexpected ways because comparisons or arithmetic with NULL typically return **NULL** (unknown result).

---

### Primary Key vs Foreign Key / Referential Integrity

### Primary Key

A **Primary Key** is a column (or a combination of columns) in a table that **uniquely identifies each record** in that table.

### Key Points:

- Each table **must have** one primary key.

- The primary key value must be:

    - **Unique** (no duplicates)

    - **Not NULL**

    - **Stable** (should not change over time)

- It acts as the **main identifier** for records and can be **referenced by other tables**.

**Example:**

| StudentID (PK) | Name  | Age |
| -------------- | ----- | --- |
| 1              | Ahmed | 21  |
| 2              | Lina  | 22  |

Here, `StudentID` is the **Primary Key** — each student has a unique ID.

### Foreign Key

A **Foreign Key** is a column (or set of columns) in one table that **refers to the Primary Key** in another table.

It creates a **relationship** between the two tables.

### Key Points:

- Establishes **links** between related data in different tables.

- Ensures **referential integrity**, meaning:

    - A value in the foreign key column **must exist** in the primary key column of the referenced table.

- Helps prevent orphaned records (data that points to non-existent entries).

**Example:**

| EnrollmentID | StudentID (FK) | CourseName       |
| ------------ | -------------- | ---------------- |
| 1            | 1              | Database Systems |
| 2            | 2              | Networking       |

Here, `StudentID` in the Enrollments table is a **Foreign Key** that references ``StudentID`` in the Students table.


### Referential Integrity

- Ensures that relationships between tables remain **consistent**.

- Example rule:

    - You cannot insert an Enrollment record with `StudentID = 5` if no student with `StudentID = 5` exists in the Students table.

---

### What is Redundancy? and why it's a problem?

### What is Redundancy?

**Redundancy** refers to the **duplication of data** within a database.

It happens when the same information is **stored multiple times**, or when some data can be **derived from other existing data**.

### Why Redundancy Is a Problem

| Problem                         | Description                                                                                          |
| ------------------------------- | ---------------------------------------------------------------------------------------------------- |
| **Wasted Space**             | Repeated data consumes unnecessary storage.                                                          |
| **Data Inconsistency**       | If one copy of the data is updated but others aren’t, the database can show conflicting information. |
| **Data Corruption**          | Multiple versions of the same data increase the risk of errors during updates or deletions.          |
| **Missing / Incomplete Data** | Inconsistent updates can result in partial or missing information.                                   |
| **Data Integrity Problems**  | Redundant data makes it harder to maintain accuracy and reliability.                                 |
| **Hard to Maintain**         | Managing updates, deletions, and synchronization becomes complex and error-prone.                    |


### Example of Redundancy

| StudentID | StudentName | CourseName       | Instructor |
| --------- | ----------- | ---------------- | ---------- |
| 1         | Ahmed       | Database Systems | Dr. Khair  |
| 2         | Lina        | Database Systems | Dr. Khair  |


### When Redundancy Is Useful (Intentional Redundancy)

While redundancy is usually avoided, in some cases it can be **useful** — especially for **performance optimization** or **reporting purposes**.

**Examples:**

- **Caching frequently used data:**

Storing pre-calculated values (like total sales, average ratings, or student count per course) can **speed up queries** instead of recalculating them every time.

- **Example Scenario:**
Instead of running this query repeatedly:

```sql
SELECT COUNT(*) FROM Student WHERE CourseID = 101;
```

You could store a column `StudentCount` in the `Course` table:

| CourseID | CourseName       | StudentCount |
| -------- | ---------------- | ------------ |
| 101      | Database Systems | 35           |
| 102      | Networking       | 27           |




### Normalization

**Normalization** is the process of organizing data in a database to reduce redundancy and improve data integrity.

It involves:

- Breaking large tables into smaller, related tables.

- Linking them through **Primary** and **Foreign Keys**.

- Following **normal forms (1NF, 2NF, 3NF, etc.)** to ensure consistency.

### Summary

| Concept                     | Description                                                                                 |
| --------------------------- | ------------------------------------------------------------------------------------------- |
| **Uncontrolled Redundancy** | Causes inconsistency, corruption, and maintenance problems.                                 |
| **Controlled Redundancy**   | Intentionally added for faster queries or simplified access, but must be carefully managed. |
| **Normalization**           | Reduces redundancy and improves data integrity.                                             |


---

### What is Data Integrity? and Why it's Important and Critical?

### What is Data Integrity?

**Data Integrity** refers to the **accuracy**, **consistency**, **and reliability** of data throughout its entire life cycle — from creation to storage, usage, and eventual deletion.

In simple terms, it ensures that data remains **complete**, **correct**, and **trustworthy**.

### Factors That Can Affect Data Integrity

There are several factors that can impact data integrity, including:

- **Human errors** (e.g., accidental data entry mistakes)

- **Hardware or software failures**

- **Security breaches** (e.g., unauthorized access or modification)

- **Data transfer errors** (e.g., incomplete or corrupted data during transmission)


To protect integrity, organizations must use:

- **Data validation rules**

- **Access control policies**

- **Encryption**

- **Regular backups and recovery mechanisms**


### Types of Data Integrity

**1. Entity Integrity**

- Ensures that each record in a table is **unique and identifiable**.

- Achieved using **Primary Keys** — no two rows share the same key, and it cannot be `NULL`.

**2. Referential Integrity**

- Ensures that **relationships between tables** remain valid and consistent.

- Achieved using **Foreign Keys** — every foreign key value must exist in the related primary key column.

- Prevents **orphaned records** (records that reference non-existent data).

**3. Domain Integrity**

- Ensures that data entered into a column **fits within valid ranges or types**.

- Example:

    - A “DateOfBirth” column must contain valid dates.

    - A “Salary” field must contain positive numbers only.

- Enforced using **data types**, **constraints**, and **validation rules**.

**4. Business Integrity**

- Ensures that data adheres to **business-specific rules** or policies.

- Example:

    - A bank enforces a **minimum account balance** rule.

    - A hospital enforces **patient confidentiality**.

These are usually implemented using **constraints**, **stored procedures**, or **application logic**.


### Why Data Integrity Is Important and Critical

Maintaining data integrity is crucial for any organization that relies on accurate data to make informed decisions.

Without it:

- Data may become **incomplete**, **inaccurate**, or **outdated**.

- Businesses may suffer **financial losses**.

- Decisions could be made on **false or inconsistent data**.

- The organization’s **reputation and trustworthiness** may be damaged.

---

### What is Constraint? and Why it's Important?

### What is a Constraint?

In databases, a **constraint** is a **rule or restriction** applied to table columns to ensure that the data stored in the database is **accurate**, **consistent**, and **reliable**.

Constraints enforce **data integrity** by controlling the type of data that can be entered, updated, or deleted.

### Why Constraints Are Important

- **Accuracy** – Prevents invalid or inconsistent data from being entered.

- **Consistency** – Ensures that relationships and values remain logical across tables.

- **Reliability** – Guarantees that the database always follows defined business rules.

- **Ease of maintenance** – Reduces the need for manual data checks or cleanup.

### Common Types of Constraints

**1. Primary Key Constraint**

- Ensures that each record in a table is **unique and not null**.

- Used to **identify rows uniquely**.

**2. Foreign Key Constraint**

- Establishes a **relationship** between two tables.

- Ensures that the value in one table **exists** in another table’s primary key column.

**3. Unique Constraint**

- Ensures that all values in a column (or combination of columns) are **unique**, but allows one **NULL** (unlike Primary Key).

**4. Not Null Constraint**

- Ensures that a column **cannot have NULL (empty)** values.

**5. Check Constraint**

- Ensures that data entered into a column meets a specific **condition**.

---

### What is SQL?

**SQL (Structured Query Language)** is a standardized programming language used to **interact with databases**.

It allows you to **store**, **retrieve**, **update**, and **delete** data easily and efficiently — all through simple statements rather than complex code or loops.

### Why SQL is Important

SQL is important because it:

- Provides an **easy way to communicate** with databases.

- Ensures **data consistency and accuracy** through structured queries.

- Works across most major database systems (MySQL, SQL Server, Oracle, PostgreSQL, etc.).

- Supports both **data definition** (creating tables) and **data manipulation** (querying or modifying data).

### What You Can Do with SQL

| Action          | Example                                                 |
| --------------- | ------------------------------------------------------- |
| Retrieve data   | `SELECT * FROM Employees;`                              |
| Insert data     | `INSERT INTO Employees VALUES (1, 'Ali', 'Maan', 800);` |
| Update data     | `UPDATE Employees SET Salary = 1000 WHERE ID = 1;`      |
| Delete data     | `DELETE FROM Employees WHERE ID = 1;`                   |
| Create database | `CREATE DATABASE CompanyDB;`                            |
| Create table    | `CREATE TABLE Employees (ID int, Name varchar(255));`   |
| Set permissions | `GRANT SELECT ON Employees TO User1;`                   |

### Types of SQL Statements

| Type    | Full Form                    | Common Commands                       | Purpose                                              |
| ------- | ---------------------------- | ------------------------------------- | ---------------------------------------------------- |
| **DDL** | Data Definition Language     | `CREATE`, `DROP`, `ALTER`, `TRUNCATE` | Define or modify structure (tables, databases).      |
| **DML** | Data Manipulation Language   | `INSERT`, `UPDATE`, `DELETE`          | Manipulate or change data inside tables.             |
| **DQL** | Data Query Language          | `SELECT`                              | Query and retrieve data.                             |
| **DCL** | Data Control Language        | `GRANT`, `REVOKE`                     | Control access and permissions.                      |
| **TCL** | Transaction Control Language | `COMMIT`, `ROLLBACK`, `SAVEPOINT`     | Manage database transactions (save or undo changes). |

---

### DBMS vs RDBMS

### DBMS vs RDBMS — Comparison Table

| Feature                          | **DBMS**                        | **RDBMS**                             |
| -------------------------------- | ------------------------------- | ------------------------------------- |
| **Full Form**                    | Database Management System      | Relational Database Management System |
| **Data Storage**                 | Files or non-tabular structures | Tables with rows & columns            |
| **Relations Between Data**       | No relations                  | Relationships between tables        |
| **Query Language**               | No standard query language      | Uses **SQL**                          |
| **Users**                        | Single-user system              | Multi-user system                     |
| **Data Integrity & Consistency** | Weak (no normalization)         | Strong (uses normalization)           |
| **Redundancy (Duplicate Data)**  | High                            | Low                                   |
| **Security**                     | Less secure                     | More secure                           |
| **Backup & Recovery**            | Hard                            | Easy                                  |
| **Scalability**                  | Limited                         | Highly scalable                       |
| **Ease of Use**                  | Hard to manage                  | Easy to manage                        |
| **Example**                      | File System, XML                | MySQL, Oracle, SQL Server             |


### Summary

- **DBMS** → Old, simple system, **no relations**, **hard to scale**.

- **RDBMS** → Advanced system, **uses tables** + **relations**, **more secure**, **SQL-based**, and **multi-user friendly**.