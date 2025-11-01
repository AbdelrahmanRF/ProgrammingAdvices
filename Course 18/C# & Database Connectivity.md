# C# & Database Connectivity

## ADO.NET

### What is ADO.NET?

**ADO.NET (ActiveX Data Objects .NET)** is a data access technology provided by Microsoft as part of the .NET Framework. It is designed to enable developers to interact with relational databases and other data sources in a consistent and efficient manner.

ADO.NET provides a set of **classes and components** that allow developers to:

* Connect to databases
* Execute queries and stored procedures
* Retrieve, insert, update, and delete data
* Work with disconnected data (via `DataSet` and `DataTable`)
* Handle transactions and manage connection pooling

In short, ADO.NET is a **powerful and flexible** technology for accessing and manipulating data in .NET applications, providing efficient and scalable data access capabilities.

### Databases Supported by ADO.NET

ADO.NET supports connecting to various database systems, including:

* **SQL Server**
* **Oracle**
* **MySQL**
* **MongoDB** (via third-party providers)
* **PostgreSQL**, **SQLite**, and others through .NET data providers

Each database type requires its corresponding **data provider**, such as:

* `System.Data.SqlClient` for SQL Server
* `MySql.Data.MySqlClient` for MySQL
* `Oracle.ManagedDataAccess.Client` for Oracle

### Applications That Use ADO.NET

ADO.NET can be used in nearly all .NET-based applications that require data access, such as:

* **ASP.NET Web Form Applications**
* **Windows Forms Applications**
* **ASP.NET MVC Applications**
* **Console Applications**
* **ASP.NET Web API Applications**
* **ASP.NET Core Applications**

### Other Ways to Connect to Databases in C#

While ADO.NET is the foundational data access layer, developers can also use higher-level frameworks:

* **Entity Framework (EF):** An Object-Relational Mapper (ORM) that simplifies database operations by allowing developers to work with data as .NET objects instead of SQL queries.
* **Dapper:** A lightweight ORM that extends ADO.NET for easier and faster data querying.

These technologies internally use ADO.NET to manage connections and execute commands, providing more convenience and abstraction to developers.

---

### ADO.NET Framework Data Providers

A **data provider** is used to connect to a database, execute commands, and retrieve records. It is a lightweight component with high performance and allows data to be placed into a `DataSet` for further use in applications.

### Commonly Used ADO.NET Data Providers

#### 1. **System.Data.SqlClient (SQL Server)**

* Designed specifically for **Microsoft SQL Server** databases.
* Provides classes such as:

  * `SqlConnection` – to establish a connection to SQL Server.
  * `SqlCommand` – to execute SQL queries and stored procedures.
  * `SqlDataAdapter` – to fill datasets with data.
  * `SqlDataReader` – to read data in a forward-only, read-only manner.

#### 2. **System.Data.OracleClient (Oracle)**

* Enables connectivity to **Oracle** databases.
* Provides classes like `OracleConnection`, `OracleCommand`, `OracleDataAdapter`, and `OracleDataReader`.
* Note: This provider has been deprecated; modern applications often use **Oracle.ManagedDataAccess.Client** instead.

#### 3. **System.Data.MySqlClient (MySQL)**

* Used to connect to **MySQL** databases.
* Provided through MySQL’s official **MySQL Connector/NET**.
* Supports classes similar to other providers (`MySqlConnection`, `MySqlCommand`, etc.).

#### 4. **System.Data.OleDb (OLE DB)**

* Based on **OLE DB (Object Linking and Embedding Database)** technology.
* Allows access to multiple databases via OLE DB drivers (e.g., Access, Oracle, MySQL, SQL Server).
* Primarily used on **Windows** systems.
* Key classes include:

  * `OleDbConnection`
  * `OleDbCommand`
  * `OleDbDataAdapter`
  * `OleDbDataReader`

#### 5. **System.Data.Odbc (ODBC)**

* Based on the **ODBC (Open Database Connectivity)** standard.
* Platform-independent and widely supported (Windows, macOS, Linux).
* Works with any database that provides an ODBC driver.
* Key classes:

  * `OdbcConnection`
  * `OdbcCommand`
  * `OdbcDataAdapter`
  * `OdbcDataReader`

#### 6. **MongoDB.Driver (MongoDB)**

* Provides access to **MongoDB** databases.
* Allows developers to interact with collections and documents directly in C#.
* Fully supports LINQ queries and asynchronous operations.

#### 7. **Entity Framework (EF)**

* An **Object-Relational Mapping (ORM)** framework built on top of ADO.NET.
* Enables developers to work with databases using **object-oriented code** instead of raw SQL.
* Supports multiple databases (SQL Server, Oracle, MySQL, PostgreSQL, etc.) via specific providers.
* Uses classes like `DbContext` and `DbSet` for high-level data operations.

### What Is a Data Provider?

A **.NET Framework Data Provider** is used for:

* Connecting to a database
* Executing commands
* Retrieving results

The retrieved results can be:

* Processed directly
* Stored in a `DataSet` for later use
* Combined with data from multiple sources
* Transferred between application layers

ADO.NET supports a **consistent programming model**, allowing developers to work with various databases using similar code structures, regardless of the specific database type.

---

### ADO.NET Architecture (Components)

ADO.NET provides a powerful architecture for data manipulation and efficient data access. Its components are designed to handle both **connected** and **disconnected** data operations, allowing developers to build flexible and scalable database applications.

### Main Components of ADO.NET

ADO.NET consists of two major parts:

1. **Data Provider** – Used for direct, connected access to a data source.
2. **DataSet** – Used for disconnected access, storing data in memory.

Together, these two components form the backbone of ADO.NET’s architecture.

### .NET Framework Data Provider Objects

The **Data Provider** is responsible for establishing connections, executing commands, and retrieving results from a database. It consists of several core objects:

#### 1. **Connection**

* Establishes a connection to a specific data source (e.g., SQL Server, Oracle, MySQL).
* Manages transactions and ensures proper opening and closing of database connections.
* Example: `SqlConnection`, `OleDbConnection`, `OdbcConnection`.

#### 2. **Command**

* Represents a SQL query or stored procedure executed against a database.
* Supports methods like `ExecuteReader()`, `ExecuteScalar()`, and `ExecuteNonQuery()`.
* Example: `SqlCommand`, `OleDbCommand`, `OdbcCommand`.

#### 3. **DataReader**

* Provides a **fast, forward-only, read-only** stream of data from a data source.
* Ideal for reading large volumes of data efficiently.
* Example: `SqlDataReader`, `OleDbDataReader`, `OdbcDataReader`.

#### 4. **DataAdapter**

* Acts as a **bridge** between a data source and a `DataSet`.
* Uses `SelectCommand`, `InsertCommand`, `UpdateCommand`, and `DeleteCommand` to manage data flow.
* Example: `SqlDataAdapter`, `OleDbDataAdapter`, `OdbcDataAdapter`.

#### 5. **DataSet**

* Represents an **in-memory cache** of data.
* Can store multiple tables, their relationships, and constraints.
* Operates in a disconnected mode — changes can later be synchronized with the database.

#### 6. **DataView**

* Provides a customizable view of data stored in a `DataTable` or `DataSet`.
* Allows sorting, filtering, and data binding to UI controls.


### .NET Framework Data Provider for SQL Server

The **.NET Framework Data Provider for SQL Server** is optimized for high performance, providing direct access to SQL Server without passing through any middle layer such as ODBC. This results in faster and more efficient data operations.

Namespace:

```csharp
using System.Data.SqlClient;
```

Key classes within this namespace:

* **`SqlConnection`** – Creates and manages connections to SQL Server. *(Sealed class)*
* **`SqlCommand`** – Executes SQL statements and stored procedures. *(Sealed class)*
* **`SqlDataAdapter`** – Manages data retrieval and updates between a SQL Server database and a `DataSet`. *(Sealed class)*
* **`SqlDataReader`** – Reads data in a forward-only stream. *(Sealed class)*
* **`SqlException`** – Represents errors that occur when interacting with SQL Server. *(Sealed class)*


**In summary**, ADO.NET’s architecture is built around flexible, modular components that separate the concerns of **data access** and **data manipulation**, allowing developers to choose between connected and disconnected models depending on application needs.

--- 

## Connect to SQL Server Database - Retrieve Data

### ADO.NET Code Example: Get All Contacts

Below is a simple example demonstrating how to connect to a **SQL Server database** and retrieve all records from a `Contacts` table using **ADO.NET**.

```csharp
using System;
using System.Data.SqlClient;

namespace RetrieveData
{
    internal class Program
    {
        // Define the SQL Server connection string
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa; Password=123456";

        static void PrintAllContacts()
        {
            // Step 1: Create a connection to SQL Server
            SqlConnection Connection = new SqlConnection(ConnectionString);

            // Step 2: Define the SQL query
            string Query = "SELECT * FROM Contacts";

            // Step 3: Create a command object
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                // Step 4: Open the connection
                Connection.Open();

                // Step 5: Execute the query and obtain a DataReader
                SqlDataReader Reader = Command.ExecuteReader();

                // Step 6: Read and display the data
                while (Reader.Read())
                {
                    int ContactID = (int)Reader["ContactID"];
                    string FirstName = (string)Reader["FirstName"];
                    string LastName = (string)Reader["LastName"];
                    string Email = (string)Reader["Email"];
                    string Phone = (string)Reader["Phone"];
                    string Address = (string)Reader["Address"];
                    int CountryID = (int)Reader["CountryID"];

                    Console.WriteLine($"Contact ID  : {ContactID}");
                    Console.WriteLine($"First Name  : {FirstName}");
                    Console.WriteLine($"Last Name   : {LastName}");
                    Console.WriteLine($"Email       : {Email}");
                    Console.WriteLine($"Phone       : {Phone}");
                    Console.WriteLine($"Address     : {Address}");
                    Console.WriteLine($"Country ID  : {CountryID}");
                    Console.WriteLine();
                }

                // Step 7: Close the DataReader and the Connection
                Reader.Close();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            PrintAllContacts();
        }
    }
}
```

### Explanation of the Code

1. **Connection String** – Specifies the database server, database name, and login credentials.

   ```csharp
   static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa; Password=123456";
   ```

2. **SqlConnection** – Establishes a connection to the SQL Server database.

3. **SqlCommand** – Contains the SQL query to be executed.

4. **SqlDataReader** – Reads the returned records in a forward-only, read-only stream.

5. **Try-Catch Block** – Handles any runtime exceptions such as connection errors.

6. **Connection Management** – Always close both `SqlDataReader` and `SqlConnection` to free up resources.

### Best Practices

* Always use `using` statements to automatically close connections.
* Never hard-code credentials in production code.
* Use parameterized queries to prevent SQL injection.
* Handle exceptions gracefully and log errors properly.

Example (with `using`):

```csharp
using (SqlConnection connection = new SqlConnection(ConnectionString))
{
    SqlCommand command = new SqlCommand("SELECT * FROM Contacts", connection);
    connection.Open();
    using (SqlDataReader reader = command.ExecuteReader())
    {
        while (reader.Read())
        {
            Console.WriteLine(reader["FirstName"]);
        }
    }
}
```

---

### Parameterized Query

Parameterized queries are a secure and efficient way to execute SQL commands with user input. They help prevent **SQL injection attacks** by treating input values as data rather than part of the SQL command.

### Example: Retrieve Contacts by First Name and Country ID

```csharp
static void PrintAllContactsWithFirstNameAndCountry(string FirstName, int CountryID)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);

    string Query = "SELECT * FROM Contacts WHERE FirstName = @FirstName AND CountryID = @CountryID";

    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@FirstName", FirstName);
    Command.Parameters.AddWithValue("@CountryID", CountryID);

    try
    {
        Connection.Open();
        SqlDataReader Reader = Command.ExecuteReader();

        while (Reader.Read())
        {
            int ContactID = (int)Reader["ContactID"];
            string Firstname = (string)Reader["FirstName"];
            string LastName = (string)Reader["LastName"];
            string Email = (string)Reader["Email"];
            string Phone = (string)Reader["Phone"];
            string Address = (string)Reader["Address"];
            int CountryId = (int)Reader["CountryID"];

            Console.WriteLine($"Contact ID  : {ContactID}");
            Console.WriteLine($"FirstName   : {Firstname}");
            Console.WriteLine($"LastName    : {LastName}");
            Console.WriteLine($"Email       : {Email}");
            Console.WriteLine($"Phone       : {Phone}");
            Console.WriteLine($"Address     : {Address}");
            Console.WriteLine($"Country ID  : {CountryId}");
            Console.WriteLine();
        }

        Reader.Close();
        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```

### Explanation

* **@FirstName** and **@CountryID** are placeholders for parameters.
* `AddWithValue()` safely assigns user input to the parameters.
* The query is executed with these values, ensuring that input is treated as data (not code).

### Advantages of Parameterized Queries

| Benefit         | Description                                                      |
| --------------- | ---------------------------------------------------------------- |
| **Security**    | Prevents SQL injection attacks by escaping inputs automatically. |
| **Performance** | SQL Server can cache execution plans for parameterized queries.  |
| **Readability** | Cleaner, more maintainable code than string concatenation.       |
| **Type Safety** | Parameters enforce proper data types.                            |

---

### Parameterized Query with LIKE Operator

Parameterized queries can also be used with the `LIKE` operator to perform flexible pattern matching such as searching for names that start with, end with, or contain a given substring.

#### Example: Search Contacts Using LIKE

```csharp
static void SearchContactsStartsWith(string StartsWith)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);

    string Query = "SELECT * FROM Contacts WHERE FirstName LIKE @Pattern";
    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@Pattern", StartsWith + "%");

    try
    {
        Connection.Open();
        SqlDataReader Reader = Command.ExecuteReader();

        while (Reader.Read())
        {
            PrintContact(Reader);
        }

        Reader.Close();
        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void SearchContactsEndsWith(string EndsWith)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);

    string Query = "SELECT * FROM Contacts WHERE FirstName LIKE @Pattern";
    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@Pattern", "%" + EndsWith);

    try
    {
        Connection.Open();
        SqlDataReader Reader = Command.ExecuteReader();

        while (Reader.Read())
        {
            PrintContact(Reader);
        }

        Reader.Close();
        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static void SearchContactsContains(string Contains)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);

    string Query = "SELECT * FROM Contacts WHERE FirstName LIKE @Pattern";
    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@Pattern", "%" + Contains + "%");

    try
    {
        Connection.Open();
        SqlDataReader Reader = Command.ExecuteReader();

        while (Reader.Read())
        {
            PrintContact(Reader);
        }

        Reader.Close();
        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```

#### Explanation

| Function                        | Pattern Example | Description                                              |
| ------------------------------- | --------------- | -------------------------------------------------------- |
| `SearchContactsStartsWith("A")` | `A%`            | Finds all contacts whose first name **starts with** 'A'. |
| `SearchContactsEndsWith("n")`   | `%n`            | Finds all contacts whose first name **ends with** 'n'.   |
| `SearchContactsContains("oh")`  | `%oh%`          | Finds all contacts whose first name **contains** 'oh'.   |

> ✅ **Tip:** Always use parameters with `LIKE` instead of string concatenation to prevent SQL injection and ensure proper handling of special characters.

---

### Retrieve a Single Value (ExecuteScalar)

`ExecuteScalar()` is used when a query returns only **one value**, such as a count or a single column value.

```csharp
static string GetFirstName(int ContactID)
{
    string FirstName = "";
    SqlConnection Connection = new SqlConnection(ConnectionString);

    string Query = "SELECT FirstName FROM Contacts WHERE ContactID = @ContactID";
    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@ContactID", ContactID);

    try
    {
        Connection.Open();
        object Result = Command.ExecuteScalar();

        if (Result != null)
        {
            FirstName = Result.ToString();
        }
        else
        {
            FirstName = "";
        }

        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    return FirstName;
}
```

### Notes:

* **`ExecuteScalar()`** returns the value of the first column of the first row in the result set.
* Use it for queries like:

  * Counting rows: `SELECT COUNT(*) FROM Contacts`
  * Getting specific data: `SELECT Name FROM Employees WHERE ID = 1`

---

### Find Single Row

You can also create a reusable method to fetch a single contact record neatly.

```csharp
public struct strContact
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public int CountryID { get; set; }
}

static bool FindContactByID(int ContactId, out strContact Contact)
{
    Contact = new strContact();
    bool isFound = false;

    using (SqlConnection Connection = new SqlConnection(ConnectionString))
    {
        string Query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";
        using (SqlCommand Command = new SqlCommand(Query, Connection))
        {
            Command.Parameters.AddWithValue("@ContactID", ContactId);
            
            try
            {
                Connection.Open();
                using (SqlDataReader Reader = Command.ExecuteReader())
                {
                    if (Reader.Read())
                    {
                        isFound = true;
                        Contact.ID = (int)Reader["ContactID"];
                        Contact.FirstName = (string)Reader["FirstName"];
                        Contact.LastName = (string)Reader["LastName"];
                        Contact.Email = (string)Reader["Email"];
                        Contact.Phone = (string)Reader["Phone"];
                        Contact.Address = (string)Reader["Address"];
                        Contact.CountryID = (int)Reader["CountryID"];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    return isFound;
}
```

#### Example Usage

```csharp
if (FindContactByID(1, out strContact Contact))
{
    Console.WriteLine($"Contact ID  : {Contact.ID}");
    Console.WriteLine($"FirstName   : {Contact.FirstName}");
    Console.WriteLine($"LastName    : {Contact.LastName}");
    Console.WriteLine($"Email       : {Contact.Email}");
    Console.WriteLine($"Phone       : {Contact.Phone}");
    Console.WriteLine($"Address     : {Contact.Address}");
    Console.WriteLine($"Country ID  : {Contact.CountryID}");
}
else
{
    Console.WriteLine("Contact not found.");
}
```

**Notes:**

* `out` is preferred over `ref` here for clarity when returning a new object.
* `using` ensures that `SqlConnection` and `SqlDataReader` are properly disposed.
* This method fetches a single row efficiently and avoids leaving resources open.

---

## Insert/Add Data

In ADO.NET, inserting data into a database can be done using the `SqlCommand` object with an **INSERT** statement. To insert a new record, you use the `ExecuteNonQuery()` method, which executes a command that doesn’t return a result set but instead returns the number of affected rows.

#### Insert-Add Data

This example demonstrates how to insert a new record into the `Contacts` table using parameterized queries to prevent SQL injection.

```csharp
static void AddNewClient(strContact Contact)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);
    string Query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                    VALUES(@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";

    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
    Command.Parameters.AddWithValue("@LastName", Contact.LastName);
    Command.Parameters.AddWithValue("@Email", Contact.Email);
    Command.Parameters.AddWithValue("@Phone", Contact.Phone);
    Command.Parameters.AddWithValue("@Address", Contact.Address);
    Command.Parameters.AddWithValue("@CountryID", Contact.CountryID);

    try
    {
        Connection.Open();
        int RowsAffected = Command.ExecuteNonQuery();

        if (RowsAffected > 0)
        {
            Console.WriteLine("Record Inserted Successfully");
        }
        else
        {
            Console.WriteLine("Record Insertion Failed");
        }

        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```

### Explanation

* **`ExecuteNonQuery()`** executes the SQL command and returns the number of affected rows.

---

### Retrieve Auto Number after Inserting/Adding Data

If your table uses an **IDENTITY column** (like `ContactID`) that auto-generates values, you can retrieve the newly inserted ID using the `SCOPE_IDENTITY()` function.

```csharp
static void AddNewClientAndGetID(strContact Contact)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);
    string Query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                    VALUES(@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                    SELECT SCOPE_IDENTITY();";

    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
    Command.Parameters.AddWithValue("@LastName", Contact.LastName);
    Command.Parameters.AddWithValue("@Email", Contact.Email);
    Command.Parameters.AddWithValue("@Phone", Contact.Phone);
    Command.Parameters.AddWithValue("@Address", Contact.Address);
    Command.Parameters.AddWithValue("@CountryID", Contact.CountryID);

    try
    {
        Connection.Open();
        object Result = Command.ExecuteScalar();

        if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
        {
            Console.WriteLine($"Newly Inserted ID: {InsertedID}");
        }
        else
        {
            Console.WriteLine("Failed to Retrieve Inserted ID");
        }

        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```

### Explanation

* `SCOPE_IDENTITY()` returns the **last identity value generated** in the current session and scope.
* `ExecuteScalar()` retrieves the first value of the first row from the result — in this case, the new `ContactID`.
* The returned value is converted to an `int` and displayed.

### Example Usage

```csharp
strContact NewContact = new strContact
{
    FirstName = "Omar",
    LastName = "Saleh",
    Email = "omar.saleh@example.com",
    Phone = "+962777000123",
    Address = "Amman, Jordan",
    CountryID = 1
};

AddNewClient(NewContact);
AddNewClientAndGetID(NewContact);
```

### Notes

* Use `ExecuteNonQuery()` for **INSERT**, **UPDATE**, and **DELETE** operations.
* Use `ExecuteScalar()` when expecting **a single value** (like a newly generated ID).

---

## Update Data

```csharp
static void UpdateContact(int ContactID, strContact Contact)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);
    string Query = @"UPDATE Contacts SET
                        FirstName = @FirstName, LastName = @LastName, Email = @Email,
                        Phone = @Phone, Address = @Address, CountryID = @CountryID
                    WHERE ContactID = @ContactID";

    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
    Command.Parameters.AddWithValue("@LastName", Contact.LastName);
    Command.Parameters.AddWithValue("@Email", Contact.Email);
    Command.Parameters.AddWithValue("@Phone", Contact.Phone);
    Command.Parameters.AddWithValue("@Address", Contact.Address);
    Command.Parameters.AddWithValue("@CountryID", Contact.CountryID);
    Command.Parameters.AddWithValue("@ContactID", ContactID);

    try
    {
        Connection.Open();
        int RowsAffected = Command.ExecuteNonQuery();

        if (RowsAffected > 0)
        {
            Console.WriteLine("Record Updated Successfully");
        }
        else
        {
            Console.WriteLine("Record Updating Failed");
        }

        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```
---

## Delete Data

```csharp
static void DeleteContact(int ContactID)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);
    string Query = @"DELETE Contacts WHERE ContactID = @ContactID";

    SqlCommand Command = new SqlCommand(Query, Connection);
    Command.Parameters.AddWithValue("@ContactID", ContactID);

    try
    {
        Connection.Open();
        int RowsAffected = Command.ExecuteNonQuery();

        if (RowsAffected > 0)
        {
            Console.WriteLine("Record Deleted Successfully");
        }
        else
        {
            Console.WriteLine("Record Deleting Failed");
        }

        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```
---

## Handle IN Statement

```csharp
static void DeleteContacts(string ContactIDs)
{
    SqlConnection Connection = new SqlConnection(ConnectionString);
    string Query = @"DELETE Contacts WHERE ContactID IN (" + ContactIDs + ")";

    SqlCommand Command = new SqlCommand(Query, Connection);

    try
    {
        Connection.Open();
        int RowsAffected = Command.ExecuteNonQuery();

        if (RowsAffected > 0)
        {
            Console.WriteLine("Record/s Deleted Successfully");
        }
        else
        {
            Console.WriteLine("Record/s Deleting Failed");
        }

        Connection.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```

---

## What are CRUD Operations?

CRUD stands for **Create**, **Read**, **Update**, and **Delete** — the four fundamental operations used to manage data in a database.  
Every data-driven application relies on these core actions to interact with its underlying database.

### **Create**
- **Purpose:** Add new data (records) into a table.  
- **SQL Command Used:** `INSERT`  
- **C# Example:** Executing an `INSERT` statement using `ExecuteNonQuery()`.  
- **Use Case:** Adding a new contact into the `Contacts` table.

### **Read**
- **Purpose:** Retrieve or view existing data.  
- **SQL Command Used:** `SELECT`  
- **C# Example:** Using `ExecuteReader()` or `ExecuteScalar()` to fetch data.  
- **Use Case:** Listing all contacts or displaying details of a specific contact by `ContactID`.

### **Update**
- **Purpose:** Modify or change existing data in a table.  
- **SQL Command Used:** `UPDATE`  
- **C# Example:** Running an `UPDATE` command with `ExecuteNonQuery()`.  
- **Use Case:** Editing an existing contact’s email or phone number.

### 🔴 **Delete**
- **Purpose:** Remove existing data from a table.  
- **SQL Command Used:** `DELETE`  
- **C# Example:** Executing a `DELETE` command via `ExecuteNonQuery()`.  
- **Use Case:** Deleting a contact by `ContactID`.

### Summary

| Operation | SQL Keyword | Description | Common C# Method |
|------------|--------------|--------------|------------------|
| Create     | INSERT       | Adds new records | `ExecuteNonQuery()` |
| Read       | SELECT       | Retrieves data | `ExecuteReader()` / `ExecuteScalar()` |
| Update     | UPDATE       | Modifies data | `ExecuteNonQuery()` |
| Delete     | DELETE       | Removes records | `ExecuteNonQuery()` |

These operations together form the **CRUD** cycle, providing complete control over how data is added, accessed, modified, and removed in relational databases.

---

## Foreign Key Delete Behavior

When deleting a record that is **referenced by a foreign key** in another table, the outcome depends on how the **foreign key constraint** is defined.  
Here are the main possible behaviors:

---

### 1. **Restrict / No Action (Default)**
- The database **prevents deletion** of the parent record if child records exist.
- **Example:** Deleting a customer who has orders in the `Orders` table will fail.
- **Use Case:** Ensures data integrity and prevents accidental loss of related data.

---

### 2. **Cascade**
- Deleting the parent record **automatically deletes** all related child records.
- **Example:** Deleting a customer removes all their orders.
- **Use Case:** Useful when dependent data should always be removed with the parent.

---

### 3. **Set Null**
- The foreign key values in child records are set to `NULL`.
- **Example:** Deleting a customer makes the `CustomerID` in their orders `NULL`.
- **Use Case:** Keeps child records but removes their link to the deleted parent.

---

### 4. **Set Default**
- The foreign key values in child records are set to a **default** value.
- **Example:** Deleting a customer sets their orders’ `CustomerID` to a default (e.g., `0`).
- **Use Case:** Maintains valid data by redirecting references to a default entity.

---

### 🔹 Summary of Delete Behaviors

| Behavior | Description | Result When Parent Deleted |
|-----------|--------------|-----------------------------|
| **Restrict / No Action** | Prevents deletion if child exists | Deletion blocked |
| **Cascade** | Deletes related child rows | Child records deleted |
| **Set Null** | Sets FK to `NULL` in child table | Link removed |
| **Set Default** | Sets FK to default value | Default value applied |

The delete behavior is defined when creating the **foreign key constraint** and determines how the database maintains **referential integrity** during deletions.

---


