# Database Normalization

## 📘 What is Normalization?

**Normalization** is the process of organizing data in a database to reduce redundancy and improve data consistency.

In simple terms, normalization means breaking down a large, complex table into smaller, more manageable ones — ensuring data is **logically organized** and **free from duplicate or inconsistent information**.

Normalization is achieved by applying a set of rules known as **Normal Forms (NF)**. Each normal form builds upon the previous one, adding stricter requirements for data integrity.

### 🎯 Goals of Normalization
- **Reduce redundancy:** Avoid storing the same data in multiple places.
- **Ensure data consistency:** Make updates, deletions, and insertions reliable.
- **Eliminate anomalies:** Prevent problems like update, insertion, and deletion anomalies.
- **Simplify maintenance:** A normalized database is easier to update, query, and scale.

---

## 🧩 First Normal Form (1NF)

### Definition
A table is in **First Normal Form (1NF)** if:
1. **Each column contains only atomic (indivisible) values.**  
   ➤ No lists, sets, or arrays in a single cell.
2. **Each column has a unique name.**
3. **Each record is uniquely identifiable by a primary key.**

### Explanation
- **Atomicity** means every field should hold only one value — not multiple or composite values.
- **No repeating groups:** Data should not be repeated across multiple columns in the same table.

### Example
❌ **Not in 1NF:**
| StudentID | Name  | Subjects       |
|------------|--------|----------------|
| 1 | Ali | Math, Science |
| 2 | Sara | English |

✅ **In 1NF:**
| StudentID | Name | Subject |
|------------|------|----------|
| 1 | Ali  | Math |
| 1 | Ali  | Science |
| 2 | Sara | English |

Now each column has atomic values, and no repeating groups exist.

---

## 🧠 Second Normal Form (2NF)

### Definition
A table is in **Second Normal Form (2NF)** if:
1. It is already in **1NF**.
2. **All non-key columns are fully dependent on the entire primary key**, not just part of it.

### Explanation
- 2NF eliminates **partial dependencies** — where a non-key attribute depends on part of a composite key.
- This only applies when the primary key is **composite** (made up of multiple columns).

### Example
❌ **Not in 2NF:**
| StudentID | CourseID | StudentName | CourseName |
|------------|-----------|--------------|-------------|
| 1 | C01 | Ali | Math |
| 1 | C02 | Ali | Science |

Here, `StudentName` depends only on `StudentID`, not on both `StudentID` and `CourseID`.

✅ **In 2NF:**
- Split into two tables:

**Students**
| StudentID | StudentName |
|------------|--------------|
| 1 | Ali |

**Courses**
| CourseID | CourseName |
|-----------|-------------|
| C01 | Math |
| C02 | Science |

**Enrollments**
| StudentID | CourseID |
|------------|-----------|
| 1 | C01 |
| 1 | C02 |

Now every non-key column depends on the whole key.

---

## 🧮 Third Normal Form (3NF)

### Definition
A table is in **Third Normal Form (3NF)** if:
1. It is in **2NF**.
2. There are **no transitive dependencies** — meaning no non-key attribute depends on another non-key attribute.

### Explanation
- Each non-key attribute should depend **only on the primary key**, not on another non-key column.

### Example
❌ **Not in 3NF:**
| StudentID | StudentName | DepartmentID | DepartmentName |
|------------|--------------|---------------|----------------|
| 1 | Ali | D01 | Computer Science |
| 2 | Sara | D02 | English |

Here, `DepartmentName` depends on `DepartmentID`, not directly on `StudentID`.

✅ **In 3NF:**
Split the table:

**Students**
| StudentID | StudentName | DepartmentID |
|------------|--------------|---------------|
| 1 | Ali | D01 |
| 2 | Sara | D02 |

**Departments**
| DepartmentID | DepartmentName |
|---------------|----------------|
| D01 | Computer Science |
| D02 | English |

Now every non-key column depends only on the primary key.

---

## 🧠 Boyce-Codd Normal Form (BCNF)

### Definition
A table is in **BCNF** if:
1. It is in **3NF**.
2. For every **functional dependency (X → Y)**, X must be a **super key**.

### Explanation
- BCNF is a stronger version of 3NF.
- It handles special cases where 3NF still allows anomalies.
- In BCNF, every determinant must be a candidate key.

### Example
❌ **Not in BCNF:**
| Course | Instructor | Room |
|---------|-------------|------|
| Math | John | 101 |
| Science | John | 102 |

Here, one instructor can teach only one course, but the instructor is not a key.

✅ **In BCNF:**
Split into:

**InstructorCourse**
| Instructor | Course |
|-------------|--------|
| John | Math |
| John | Science |

**CourseRoom**
| Course | Room |
|--------|------|
| Math | 101 |
| Science | 102 |

---

## 🔹 Fourth Normal Form (4NF)

### Definition
A table is in **4NF** if:
1. It is in **BCNF**.
2. It has **no multi-valued dependencies**.

### Explanation
A multi-valued dependency occurs when one attribute in a table determines multiple independent values of another attribute.

### Example
❌ **Not in 4NF:**
| Student | Skill | Hobby |
|----------|--------|--------|
| Ali | C++ | Football |
| Ali | Java | Football |
| Ali | C++ | Chess |
| Ali | Java | Chess |

Here, `Skill` and `Hobby` are independent but both depend on `Student`.

✅ **In 4NF:**
Split into:

**StudentSkills**
| Student | Skill |
|----------|--------|
| Ali | C++ |
| Ali | Java |

**StudentHobbies**
| Student | Hobby |
|----------|--------|
| Ali | Football |
| Ali | Chess |

Now there are no multi-valued dependencies.

---

## 🔸 Fifth Normal Form (5NF)

### Definition
A table is in **5NF** (also known as **Project-Join Normal Form**) if:
1. It is in **4NF**.
2. It cannot be decomposed further without losing data.

### Explanation
5NF eliminates **join dependencies** — situations where a table can be reconstructed only by joining multiple smaller tables.

### Example
Suppose a company records which **supplier** supplies which **parts** for which **project**.

❌ **Not in 5NF:**
| Supplier | Part | Project |
|-----------|------|----------|
| S1 | P1 | J1 |
| S1 | P2 | J1 |
| S2 | P1 | J2 |

If each relationship can exist independently, we can break this into:

✅ **In 5NF:**
**SupplierPart**
| Supplier | Part |
|-----------|------|
| S1 | P1 |
| S1 | P2 |
| S2 | P1 |

**PartProject**
| Part | Project |
|------|----------|
| P1 | J1 |
| P2 | J1 |
| P1 | J2 |

**SupplierProject**
| Supplier | Project |
|-----------|----------|
| S1 | J1 |
| S2 | J2 |

---

## ✅ Summary of Normal Forms

| Normal Form | Requirement |
|--------------|-------------|
| **1NF** | Atomic values, unique columns, primary key |
| **2NF** | No partial dependency on a composite key |
| **3NF** | No transitive dependency between non-key attributes |
| **BCNF** | Every determinant must be a candidate key |
| **4NF** | No multi-valued dependencies |
| **5NF** | No join dependencies |

---

### 🧠 Final Thoughts
Normalization helps ensure that a database:
- Maintains **data integrity** and **accuracy**.
- Avoids **data duplication**.
- Becomes **easier to scale and manage**.

However, over-normalization can lead to performance issues (too many joins). In real-world systems, database designers often strike a **balance between normalization and performance** — applying denormalization where necessary for speed.