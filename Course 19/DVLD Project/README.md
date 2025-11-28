# 🛂 DVLD – Driving & Vehicle Licensing Department System

A desktop application developed as a course project to simulate the management of driving licenses and related administrative operations within a Driving & Vehicle Licensing Department (DVLD).  
>This system is purely educational and is not associated with any official government institution.
 
Built using **C# Windows Forms**, following a structured layered architecture with **SQL Server** backend and **ADO.NET** data access.

---

## 🧱 Project Architecture

| Layer | Description |
|-------|------------|
| **Presentation Layer (UI)** | Windows Forms providing full graphical interface |
| **Business Layer (Model & Logic)** | Contains business rules, validation, and workflow logic |
| **Data Access Layer (DAL)** | Handles database operations using stored procedures & ADO.NET |
| **Database** | SQL Server with relational tables and constraints |

---

## 🗃 System Modules & Requirements

### ✔ People & Users Management
- Manage people records (add, edit, delete, search)
- User accounts and login authentication
- Account settings and password management

### ✔ Driving License Applications
- Manage application types & fees
- Create and process **Local Driving License Applications**
- Create and process **International Driving License Applications**
- Renew local driving license
- Replace damaged or lost licenses

### ✔ Test Management
- Manage test types (Vision Test, Written Test, Street Test)
- Schedule tests and track appointments
- Record passed/failed test results
- Enforce prerequisite test order and prevent invalid scheduling

### ✔ Detain & Release Licenses
- Detain an active license with reason & penalty fees
- Release detained license after fee payment
- View detained & released history

---

## 🧠 Key Features & Improvements
- Multi-layered architecture separation (UI / Business / DAL)
- Full CRUD operations throughout the system
- Context menu actions for test scheduling and processing
- Validation and logical dependency enforcement for test sequence
- Real-time workflow status updates
- Organized Git commit history with continuous refactoring

---

## 🛠 Technologies Used

| Category | Technology |
|----------|------------|
| Language | C# |
| UI Framework | Windows Forms |
| Database | SQL Server |
| Data Layer | Stored procedures & ADO.NET |

---

## 📦 Setup Guide

### Prerequisites
- .NET Framework 4.8+
- SQL Server 2019+
- Visual Studio 2022

### 🚀 Installation Steps

### 1. Clone the repository
git clone https://github.com/AbdelrahmanRF/ProgrammingAdvices.git

### 2. Configure the database
- Create a new SQL Server database named: DVLD
- Run the script located at: `Course 19/DVLD Project/database/DVLD.sql`
- **Optional but recommended**: Run the seed script to populate sample data: `Course 19/DVLD Project/database/seed.sql`

### 3. Configure the connection string
Update connection string in app.config.

### 4. Build and Run the project
Open solution in Visual Studio and press F5.