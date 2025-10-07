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

---

## Database Design: Conceptual Design


### What is ERD? and Why?

### What is ERD?

- **ERD (Entity Relationship Diagram)** is a **visual representation** that shows how entities (tables) in a database are related to each other.

- It serves as a **blueprint** or **structural design** for a database before it’s implemented.

- ERDs are built using **entities**, **attributes**, and **relationships**.


### What is an ER Model?

- The **Entity-Relationship Model** defines the **logical structure** of a database using diagrams.

- It is part of the **database design process** and helps analyze data requirements **before implementation**.

- ER modeling ensures that the database structure aligns with business rules and data relationships.

### Why Use ER Diagrams in DBMS?

- Helps **visualize and conceptualize** the database design.

- Shows which **fields (attributes)** belong to which **entities**.

- Provides a clear overview of **data relationships**, **reducing design complexity**.

- Enables **faster and more accurate** database development.

- Serves as a **communication tool** between designers, developers, and stakeholders.

- Offers a **preview of the logical structure** of the database before actual creation.

### Conclusion

- ER Diagrams are essential for **conceptual database design** in RDBMS.

- They help ensure **clarity**, **consistency**, and **correctness** before implementation.

- Both developers and users can understand the **database structure** easily through an ERD.

---

### ERD Symbols

### Basic ERD Symbols

| Symbol                  | Meaning          | Description                                                                                                        |
| ----------------------- | ---------------- | ------------------------------------------------------------------------------------------------------------------ |
| **Rectangle**        | **Entity**       | Represents an entity (a real-world object or concept that has data stored about it, e.g., *Student*, *Course*).    |
| **Double Rectangle** | **Weak Entity**  | Represents an entity that depends on another entity for its identification (e.g., *OrderItem* depends on *Order*). |
| **Diamond**          | **Relationship** | Shows the relationship between entities (e.g., *Enrolls*, *Contains*, *Assigned To*).                              |
| **Line**              | **Connection**   | Connects entities to relationships or attributes to entities.                                                      |


### Attribute Symbols

| Symbol                            | Meaning                         | Description                                                                                                               |
| --------------------------------- | ------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| **Ellipse**                     | **Attribute**                   | Represents a property or characteristic of an entity (e.g., *Name*, *Salary*).                                            |
| **Double Ellipse**              | **Multivalued Attribute**       | Represents attributes that can have multiple values (e.g., *Phone Numbers*).                                              |
| **Dashed Ellipse**              | **Derived Attribute**           | Represents attributes that can be derived or calculated from other attributes (e.g., *Age* derived from *Date of Birth*). |
| **Ellipses Connected Together** | **Composite Attribute**         | Represents an attribute made up of smaller parts (e.g., *Full Name* made of *First Name* and *Last Name*).                |
| **Underlined Attribute**        | **Key Attribute (Primary Key)** | Represents a unique identifier for the entity (e.g., *StudentID*).                                                        |

---

### Components of ERD

**An Entity Relationship Diagram (ERD)** is based on three main components:

**1. Entities**

- Strong Entity

- Weak Entity


**2. Attributes**

- Key Attribute

- Composite Attribute

- Multivalued Attribute

- Derived Attribute

**3. Relationships**

- One-to-One (1:1)

- One-to-Many (1:N)

- Many-to-One (N:1)

- Many-to-Many (M:N)

---

### Entity (Strong) and Weak Entity


**1. Strong Entity**

- A **Strong Entity** represents an independent object or concept — something that exists on its own without depending on another entity.

- Represented by a **single rectangle** in an ER diagram.

- Each strong entity **must have a primary key**, which uniquely identifies each record.

- Example:

    - In a Student–Course system, both `Student` and `Course` are strong entities.

    - `StudentID` and `CourseID` are their respective primary keys.


**2. Weak Entity**

- A **Weak Entity** depends on another entity (called the **owner entity**) for its existence.

- It **does not have a primary key** of its own — instead, it uses a **partial key** (also called a discriminator) combined with the owner’s key to create uniqueness.

- Represented by a **double rectangle** in an ER diagram.

- Example:

    - `Employee` → strong entity (has primary key `EmployeeID`)

    - `Dependent` → weak entity (depends on `Employee`, uses something like `DependentName` as a discriminator).

    - Together, `EmployeeID + DependentName` uniquely identify each dependent.


---

### Attributes


### What is an Attribute?

- An **attribute** represents a property or characteristic of an entity.

- In an ER diagram, **attributes are shown as ovals (ellipses)** connected to their entity.

- Example:

    - For the entity `Student`, attributes can include `StudentID`, `Name`, `Age`, and `Email`.


**1. Key Attribute**

- **A key attribute** uniquely identifies each record in an entity set.

- It is **underlined** in an ER diagram.

- Example:

    - `StudentID` uniquely identifies each `Student`.

- Symbol: Single oval with the attribute name underlined

**2. Composite Attribute**

- **A composite attribute** is made up of multiple sub-attributes.

- It represents data that can be broken down into smaller meaningful parts.

- Example:

    - `FullName` → consists of `FirstName` and `LastName`.

- Symbol: An oval connected to smaller ovals representing its components.

**3. Multivalued Attribute**

- **A multivalued attribute** can hold multiple values for a single entity.

- Example:

    - A `Student` can have multiple `PhoneNumbers`.

- Symbol: Double oval.

**4. Derived Attribute**

- A **derived attribute** is one that can be **calculated or derived** from another attribute.

- Example:

    - `Age` can be derived from `DateOfBirth`.

- Symbol: Dashed oval.

---

### Relationships

### What is a Relationship?

- A **relationship** shows how two or more entities are connected to each other in a database.

- Represented by a **diamond shape** in an ER diagram.

- Relationships help define how data in one entity relates to data in another.


### Examples of Relationships

- Student → Enrolled → Course

    - `Student` and Course are `entities`.

    - Enrolled is the relationship that shows which student is enrolled in which course.

- Customer → Makes → Order → Contains → Product

    - A `Customer` places an `Order`.

    - An `Order` contains one or more `Products`.

    - This shows a chain of relationships between multiple entities.

- Employee → WorksOn → Project

    - An `Employee` works on one or more `Projects`.

    - Additionally, an `Employee` can Manage a `Project`.

### Self-Referencing Relationship

- When an entity is related to itself, it’s called a **self-relationship** (or **recursive relationship**).

- Example:

    - Each `Employee` has one `Manager`, and the `Manager` is also an `Employee`.

### Types of Relationships

- **One-to-One (1:1)**

- **One-to-Many (1:N)**

- **Many-to-One (N:1)**

- **Many-to-Many (M:N)**

---

### One-to-One Relationship

A **One-to-One (1:1) Relationship** means that **one entity** instance is associated with **only one instance** of another entity — and **vice versa**.

In ER diagrams, this is shown by connecting two entities with a line labeled “1” on both ends.

### Examples

**1. Student — Identification Card**

- **Entities**: Student, Identification-Card

- **Relationship**: Has

- Each **student** has **only one ID card**, and each **ID card** belongs to **only one student**.

**Diagram:**

`Student (1) ───<has>─── (1) Identification-Card`


**2. Citizen — Car**

- **Entities**: Citizen, Car

- **Relationship**: Own

- Each **citizen** owns **one car**, and each **car** is owned by **only one citizen**.

**Diagram:**

`Citizen (1) ───<own>─── (1) Car`

---

### One-to-Many/Many-to-One Relationship

A **One-to-Many (1:N)** or **Many-to-One (N:1)** relationship occurs when **a single record in one entity** is related to **multiple records in another entity**, but each of those records relates **back to only one** in the first entity.


**1. One-to-Many (1:N) Relationship**

**Definition:**

When a **single element** of an entity is associated with **more than one element** of another entity.

**Example:**

- A **customer** can place **many orders**,

- But an **order** belongs to **only one customer**.

**Diagram:**

`Customer (1) ───<places>─── (N) Order`


**2. Many-to-One (N:1) Relationship**

**Definition:**

When **many elements** of an entity relate to **one element** of another entity.

**Example:**

- **Many employees** can work on the **same project**,

- But each **employee** works on **only one project**.

**Diagram:**

`Employee (N) ───<works on>─── (1) Project`


**3. Self-Referencing One-to-Many Relationship**

**Example:**

- Each **employee** has **one manager**,

- But **a manager** can manage **many employees**.

`Employee (1) <──<manages>── (N) Employee`

--- 

### Many-to-Many (M:N) Relationship

A **Many-to-Many (M:N)** relationship occurs when **multiple elements** of one entity are related to **multiple elements** of another entity.

In other words:

One record in Entity A can relate to many records in Entity B,

And one record in Entity B can also relate to many records in Entity A.


### Example 1 — Student & Course

**Entities**: Student, Course

**Relationship**: Enrolled

- A **student** can enroll in **many courses**,

- A **course** can have **many students** enrolled.

**Diagram:**

`Student (M) ───<Enrolled>─── (N) Course`

**Important:**

In a real database, **a bridge (junction)** table is used to handle many-to-many relationships — for example, `Enrollment(StudentID, CourseID)`.


### Example 2 — Customer, Order, and Product

**Entities**: Customer, Order, Product

**Relationships**: Place, Contains

- A **customer** can place **many orders**,

- Each **order** can contain **many products**,

- And each **product** can appear in **many orders**.

**Diagram:**

`Customer ───<Place>─── Order ───<Contains>─── Product`

This means the `Order` entity often acts as a **bridge** between **Customer** and **Product**.

---

### Cardinality vs Ordinality

### Cardinality

- **Definition**:

Cardinality defines the **maximum number** of times an instance in one entity can be associated with instances of another entity.

- **Purpose**:

It shows the **upper limit** of participation in a relationship.

- **Examples:**

    - A **customer** can place **many orders** → (Maximum = Many)

    - A **student** can enroll in **up to 5 courses** → (Maximum = 5)

- **Notation Example**:

    - 1 (One)

    - N / M (Many)


### Ordinality

- **Definition**:

Ordinality specifies the **minimum number** of times an instance in one entity must be associated with an instance in another entity.

In simpler terms — it tells whether the relationship is **optional** or **mandatory**.

- **Purpose**:

It defines the **lower limit** of participation in a relationship.

- **Examples:**

    - A **customer** may or may not place an order → (Minimum = 0 → Optional)

    - An **order** must belong to a customer → (Minimum = 1 → Mandatory)


### Common Representation in ERD

Cardinality and Ordinality are often written together as:

- (0,1) → Optional, at most one

- (1,1) → Mandatory, exactly one

- (0,N) → Optional, many

- (1,N) → Mandatory, many

**Example:**

`Customer (1,N)──<Places>──(1,1) Order`

→ Each order must belong to exactly one customer, but a customer can place many orders.

---

