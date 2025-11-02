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

## DataTables

### What is a DataTable?

In **C#**, a `DataTable` (part of ADO.NET) is an **in-memory table** that holds tabular data — rows and columns — similar to a database table or spreadsheet. It’s commonly used for temporary data storage, manipulation, and binding to UI controls.

### Key Concepts & Features

* **Rows and Columns:** A `DataTable` contains a collection of `DataColumn` objects (schema) and `DataRow` objects (data).
* **Data Types:** Each column has a CLR type (e.g., `int`, `string`, `DateTime`) which enforces type safety.
* **Constraints & Keys:** You can define primary keys, unique constraints, and foreign-key-like relations (when used inside a `DataSet`).
* **Disconnected Mode:** `DataTable` works in memory and doesn’t need a live DB connection; you can fill it from the database and then work offline.
* **Data Binding:** Easily bind to UI controls (e.g., `DataGridView`) for display and editing.
* **Querying & Aggregation:** Use `Select()`, `Compute()`, `DefaultView`, and LINQ to query, filter, sort, and aggregate data.
* **Serialization:** Can be written to and read from XML (useful for transfer or persistence).

---

### Example 1 — Create Offline DataTable and List Data

**What it does:** Creates a `DataTable` in memory, defines columns (with types), adds rows, and prints them.

```csharp
DataTable EmployeesDT = new DataTable();

EmployeesDT.Columns.Add("ID", typeof(int));
EmployeesDT.Columns.Add("FirstName", typeof(string));
EmployeesDT.Columns.Add("LastName", typeof(string));
EmployeesDT.Columns.Add("Country", typeof(string));
EmployeesDT.Columns.Add("Salary", typeof(double));
EmployeesDT.Columns.Add("DOB", typeof(DateTime));

EmployeesDT.Rows.Add(1, "Fares", "Haddad", "Lebanon", 3000, new DateTime(1970, 1, 1));
EmployeesDT.Rows.Add(2, "Leila", "Mansour", "Jordan", 4500, new DateTime(1985, 5, 20));
EmployeesDT.Rows.Add(3, "Tariq", "Ali", "Egypt", 3800, new DateTime(1992, 11, 15));
EmployeesDT.Rows.Add(4, "Sara", "Khoury", "Palestine", 5200, new DateTime(1978, 3, 10));
EmployeesDT.Rows.Add(5, "Omar", "Basha", "Syria", 3100, new DateTime(2000, 7, 25));

Console.WriteLine("Employees List:");
foreach (DataRow Row in EmployeesDT.Rows)
{
    Console.WriteLine($"Record: ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDOB: {Row["DOB"]}");
}
```

**Explanation:**

* `Columns.Add(name, type)` defines the schema. Use the correct CLR type to avoid casting issues.
* `Rows.Add(...)` inserts a new `DataRow` with values matching the column order.

---

### Example 2 — Aggregate (Count, Sum, Avg, Min, Max)

**What it does:** Uses `Rows.Count` and `DataTable.Compute()` to calculate aggregates.

```csharp
int EmployeesCount = EmployeesDT.Rows.Count;
double TotalEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("SUM(Salary)", string.Empty));
double AverageEmployeeSalaries = Convert.ToDouble(EmployeesDT.Compute("AVG(Salary)", string.Empty));
double MinSalary = Convert.ToDouble(EmployeesDT.Compute("MIN(Salary)", string.Empty));
double MaxSalary = Convert.ToDouble(EmployeesDT.Compute("MAX(Salary)", string.Empty));

Console.WriteLine($"Count of Employees = {EmployeesCount}");
Console.WriteLine($"Total Employee Salaries = {TotalEmployeeSalaries}");
Console.WriteLine($"Average Employee Salaries = {AverageEmployeeSalaries}");
Console.WriteLine($"Minimum Salary = {MinSalary}");
Console.WriteLine($"Maximum Salary = {MaxSalary}");
```

**Explanation:**

* `Compute(expression, filter)` evaluates a SQL-like aggregate expression. Use an empty filter (`string.Empty`) to apply to all rows.
* Convert the result to the expected numeric type; `Compute` returns `object`.

---

### Example 3 — Filter Rows

**What it does:** Filters rows using `Select()` and then recomputes aggregates for the filtered set.

```csharp
DataRow[] ResultRows = EmployeesDT.Select("Country = 'Jordan'");

Console.WriteLine("Employees List in Jordan:");
foreach (DataRow Row in ResultRows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDOB: {Row["DOB"]}");
}

int FilteredCount = ResultRows.Length;
double FilteredSum = Convert.ToDouble(EmployeesDT.Compute("SUM(Salary)", "Country = 'Jordan'"));
// ... similarly for AVG, MIN, MAX
```

**Explanation:**

* `Select(filterExpression)` returns an array of `DataRow` that match the filter.
* Use `Compute` with the same filter string to aggregate only the filtered rows.

---

### Example 4 — Sorting

**What it does:** Sorts using `DefaultView.Sort`, then converts the view back to a `DataTable`.

```csharp
EmployeesDT.DefaultView.Sort = "ID DESC";
EmployeesDT = EmployeesDT.DefaultView.ToTable();
```

**Explanation:**

* `DefaultView` provides a sorted/filtered view without altering the original row order. `ToTable()` materializes the view into a new `DataTable`.

---

### Example 5 — Delete Rows

**What it does:** Marks rows for deletion and accepts changes to remove them.

```csharp
DataRow[] FilteredRows = EmployeesDT.Select("ID = 4");
foreach (DataRow Row in FilteredRows)
{
    Row.Delete(); // Marks row for deletion
}
EmployeesDT.AcceptChanges(); // Apply deletes
```

**Explanation:**

* `Row.Delete()` marks the row with `RowState.Deleted`. `AcceptChanges()` permanently removes rows with that state from the table.
* If the `DataTable` is tied to a `DataAdapter` for updating the database, call `DataAdapter.Update(DataTable)` before `AcceptChanges()` to persist deletions to the DB.

### Important Note about DataRow References

When you use methods like `Select()` or access rows through `foreach (DataRow row in DataTable.Rows)`,
each `DataRow` you get is a reference to the actual row stored inside the `DataTable`.

**That means:**

If you modify the row (for example, `row["Salary"] = 5000;`), the change is **automatically reflected** in the original `DataTable`.

If you call `row.Delete();`, the row is **marked for deletion** inside the `DataTable` itself.

After calling `DataTable.AcceptChanges();`, the deletion or modification becomes **permanent** in the table.

> In short, a `DataRow` object is **not a copy** — it’s a **live link** to the data inside the `DataTable`. <br>
Any changes you make to the `DataRow` will directly affect the `DataTable` it belongs to.

---

### Best Practices & Tips

* Prefer **strongly typed** access (`row.Field<T>("ColumnName")`) over casting (`(int)row["ID"]`) to avoid invalid casts and `DBNull` issues.
* Handle `DBNull` values using `row.IsNull("ColumnName")` or `row.Field<T?>()` for nullable types.
* For large data sets, consider `DataReader` for forward-only reading to reduce memory footprint.
* When binding to UI, use `DefaultView` or a `BindingSource` for sorting and filtering.
* Dispose of heavy objects and avoid creating too many `DataTable` copies unnecessarily.

---

### DataTable Example 6 (Update Rows)

In this example, we demonstrate how to **update existing rows** in a DataTable. Since each `DataRow` is a reference to the actual row inside the `DataTable`, modifying its values directly updates the table.

### Code Example

```csharp
DataRow[] RowsToUpdate;
RowsToUpdate = EmployeesDT.Select("ID = 3");

foreach(DataRow Row in RowsToUpdate)
{
    Row["LastName"] = "Maher";
    Row["Salary"] = "3200";
}
EmployeesDT.AcceptChanges();

Console.WriteLine("Employees List After Updating Employee 3:");
foreach (DataRow Row in EmployeesDT.Rows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();
```

### Explanation

* The `Select()` method retrieves the rows matching a given condition (`ID = 3`).
* Each returned `DataRow` is **a live reference**, not a copy. Any changes you make are reflected immediately in the DataTable.
* The `AcceptChanges()` method commits the updates — marking all modified rows as unchanged (finalized state).

---

### DataTable Example 7 (Clear)

To remove **all data (rows)** from a DataTable while keeping its structure (columns and schema), use the `Clear()` method.

### Code Example

```csharp
// Clear all data
EmployeesDataTable.Clear();
```

### Explanation

* The `Clear()` method deletes all rows but keeps the column definitions intact.
* This is useful when you want to **reuse the DataTable** structure with fresh data.

> **Note:** If the DataTable has constraints (like foreign keys or unique columns), make sure clearing it doesn’t violate those constraints.

---

### DataTable Example 8 (Primary Key)

A **primary key** ensures that each row in the DataTable is unique and can be easily searched or referenced.

### Code Example

```csharp
// Make ID the primary key
DataColumn[] PrimaryKeyColumns = new DataColumn[1];
PrimaryKeyColumns[0] = EmployeesDT.Columns["ID"];
EmployeesDT.PrimaryKey = PrimaryKeyColumns;
```

### Explanation

* `PrimaryKeyColumns` is an array of one or more `DataColumn` objects that will act as the table’s primary key.
* Setting `EmployeesDT.PrimaryKey` enforces **uniqueness** and speeds up **searches** and **row lookups**.

You can now use `Rows.Find()` to locate a specific record quickly using its primary key.

```csharp
DataRow foundRow = EmployeesDT.Rows.Find(3);
```

---

### DataTable Example 9 (Autoincrement and Others)

In this example, we create a **DataTable from scratch**, defining its columns, data types, and additional properties like auto-increment, captions, and null constraints.

### Code Example

```csharp
DataTable EmployeesDataTable = new DataTable();
DataColumn dtColumn;

// ID Column

dtColumn = new DataColumn();
dtColumn.ColumnName = "ID";
dtColumn.DataType = typeof(int);
dtColumn.AllowDBNull = false;
dtColumn.Unique = true;
dtColumn.Caption = "Employee ID";
dtColumn.AutoIncrement = true;
dtColumn.AutoIncrementSeed = 1;
dtColumn.AutoIncrementStep = 1;
dtColumn.ReadOnly = true;
EmployeesDataTable.Columns.Add(dtColumn);

// Name Column
dtColumn = new DataColumn();
dtColumn.ColumnName = "Name";
dtColumn.DataType = typeof(string);
dtColumn.AllowDBNull = false;
dtColumn.Caption = "FullName";
EmployeesDataTable.Columns.Add(dtColumn);

// Country Column
dtColumn = new DataColumn();
dtColumn.ColumnName = "Country";
dtColumn.DataType = typeof(string);
dtColumn.AllowDBNull = true;
dtColumn.Caption = "Country of Residence";
EmployeesDataTable.Columns.Add(dtColumn);

// DOB Column
dtColumn = new DataColumn();
dtColumn.ColumnName = "DOB";
dtColumn.DataType = typeof(DateTime);
dtColumn.AllowDBNull = false;
dtColumn.Caption = "Date of Birth";
EmployeesDataTable.Columns.Add(dtColumn);

// Salary Column
dtColumn = new DataColumn();
dtColumn.ColumnName = "Salary";
dtColumn.DataType = typeof(decimal);
dtColumn.AllowDBNull = false;
dtColumn.Caption = "Annual Salary";
EmployeesDataTable.Columns.Add(dtColumn);

// Set Primary Key
DataColumn[] PrimaryKeys = new DataColumn[1];
PrimaryKeys[0] = EmployeesDataTable.Columns["ID"];
EmployeesDataTable.PrimaryKey = PrimaryKeys;

// Insert Data
EmployeesDataTable.Rows.Add(null, "Fares Mohammad", "Jordan", new DateTime(1970,1,1), 3200);
EmployeesDataTable.Rows.Add(null, "Amal Zaki", "Iraq", new DateTime(1980, 9, 5), 2400);

// Display Data
Console.WriteLine("Employees List:");
foreach (DataRow Row in EmployeesDataTable.Rows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();
```

### Explanation

* **AutoIncrement**: Automatically generates unique values for new rows.
* **AutoIncrementSeed**: Defines the starting number.
* **AutoIncrementStep**: Defines the increment between generated IDs.
* **AllowDBNull**: Controls whether the column accepts `NULL` values.
* **Unique**: Ensures values in this column are distinct.
* **ReadOnly**: Prevents modification after insertion.
* **Caption**: Provides a human-readable name (useful in data-bound UIs).

> After defining these columns, adding rows automatically assigns IDs.

### Why can we still add rows with null in the ID column?

* The `ID` column has `AutoIncrement = true`.
* When a column is auto-incremented, the `DataTable` **automatically generates** a value for it if you pass `null` or `DBNull.Value`.
* So when you write `Rows.Add(null, ...)`, that `null` is not actually stored — it means “let the table assign the next value automatically.”

That’s why even though `AllowDBNull = false`, there’s no conflict. The final stored value in the `ID` column is always an integer (like `1`, `2`, etc.), not `null`.

### Output

```
Employees List:
ID: 1   Name: Fares Mohammad   Country: Jordan   Salary: 3200   Date of Birth: 1/1/1970
ID: 2   Name: Amal Zaki        Country: Iraq     Salary: 2400   Date of Birth: 9/5/1980
```

---

## DataView

### What is DataView?

A **DataView** in C# provides a dynamic and customizable view of a `DataTable`. It does not duplicate the data — rather, it acts as a *window* through which you can view, filter, sort, and search data efficiently.

#### Key Concepts:

* **Represents a bindable, customizable view** of a `DataTable` for sorting, filtering, searching, editing, and navigation.
* **Connected view**: Changes made through a DataView reflect in its DataTable, and vice versa.
* **Lightweight**: A DataView is faster and uses less memory than working directly with DataTable operations.
* **Subset and customization**: You can display only specific rows or columns from a DataTable.
* **Data binding**: Often used with UI controls (e.g., DataGridView) to reflect dynamic changes instantly.

#### When to Use DataView:

* When you need **sorting or filtering** of data without changing the DataTable.
* When you want to **bind multiple views** (filtered/sorted differently) of the same DataTable to different UI elements.
* When you want **faster data manipulation** (searching, filtering, etc.).

While `DataTable` provides full control over schema and structure (columns, relations, constraints), `DataView` focuses on *viewing and querying* the existing data efficiently.

---

### Creating a DataView from a DataTable

```csharp
DataTable EmployeesDT = new DataTable();
EmployeesDT.Columns.Add("ID", typeof(int));
EmployeesDT.Columns.Add("Name", typeof(string));
EmployeesDT.Columns.Add("Country", typeof(string));
EmployeesDT.Columns.Add("DOB", typeof(DateTime));
EmployeesDT.Columns.Add("Salary", typeof(double));

EmployeesDT.Rows.Add(1, "Fares Haddad", "Lebanon", new DateTime(1970, 1, 1), 3000.00);
EmployeesDT.Rows.Add(2, "Ahmad Al-Hassan", "Jordan", new DateTime(1990, 5, 15), 75000.50);
EmployeesDT.Rows.Add(3, "Sara Khaled", "Jordan", new DateTime(1995, 11, 28), 62000.00);
EmployeesDT.Rows.Add(4, "Omar Abdulaziz", "UAE", new DateTime(1985, 3, 10), 98500.25);
EmployeesDT.Rows.Add(5, "Laila Hassan", "Egypt", new DateTime(1982, 7, 20), 45000.00);

// Create a DataView from the existing DataTable
DataView EmployeesDV1 = EmployeesDT.DefaultView;

Console.WriteLine("Employees List From DataView1:");
foreach (DataRowView Row in EmployeesDV1)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();
```

**Explanation:**

* `DefaultView` gives a default `DataView` representation of the `DataTable`.
* Iterating through `DataRowView` objects allows you to access each record as seen through the DataView.
* Since the DataView is linked to the DataTable, any modification made to the view (like editing or deleting a record) is reflected in the original table.

---

### Filtering and Sorting Data in a DataView

```csharp
// Sort records by Country in ascending order
EmployeesDV1.Sort = "Country ASC";

Console.WriteLine("Employees List Sorted By Country:");
foreach (DataRowView Row in EmployeesDV1)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();

// Filter only employees from Jordan and Egypt
EmployeesDV1.RowFilter = "Country = 'Jordan' OR Country = 'Egypt'";

Console.WriteLine("Employees From Jordan & Egypt:");
foreach (DataRowView Row in EmployeesDV1)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();
```

**Explanation:**

* `Sort` allows ordering by one or more columns (ASC/DESC).
* `RowFilter` lets you apply SQL-like conditions to display specific records.
* The filter affects **only the view**, not the underlying `DataTable`.
* You can chain filters and sorts for flexible data views.

---

### Summary

| Feature                     | Description                                                                                      |
| --------------------------- | ------------------------------------------------------------------------------------------------ |
| **Connection to DataTable** | DataView directly references its DataTable — changes sync both ways.                             |
| **Sorting**                 | Controlled via the `Sort` property using SQL-like syntax.                                        |
| **Filtering**               | Controlled via the `RowFilter` property using conditional expressions.                           |
| **Binding**                 | Ideal for data binding in UI controls like DataGridView or ComboBox.                             |
| **Performance**             | Faster and more memory-efficient for read/query operations than manipulating DataTable directly. |

---

**In short:**

> DataView is a lightweight, real-time, and customizable window to view, sort, and filter data from a DataTable — without duplicating the data itself.

---

## Dataset in C#  

### What is Dataset?  

In C#, a **DataSet** is an in-memory representation of a collection of structured data. It is part of the ADO.NET framework and is used for storing, manipulating, and managing data offline. A DataSet can contain multiple **DataTable** objects, which represent tables of data. Each DataTable has **DataColumn** objects for defining columns and **DataRow** objects for storing records.  

**Key points about DataSet:**  
- A DataSet is a **disconnected**, in-memory representation of data. Once filled with data, it does not require a continuous connection to the data source.  
- It can store multiple DataTables along with relationships and constraints between them.  
- Acts as a **local copy of your database**, including tables, relationships, and constraints.  
- DataSet is part of the **`System.Data`** namespace.  
- Compared to **DataReader**, DataSet has more overhead because it stores all data in memory and supports advanced operations, so it can be slower for large datasets.  

**Advantages:**  
- Supports multiple tables, constraints, and relations.  
- Can be used for offline data manipulation.  
- Data can be accessed by table name or index.  

**When to use:**  
- Use DataSet when you need to work with multiple related tables in memory.  
- If performance is critical for reading large datasets sequentially, consider using **DataReader** instead.  

---

### Create a Dataset  

```csharp
// Create Employees DataTable
DataTable EmployeesDT = new DataTable();
EmployeesDT.Columns.Add("ID", typeof(int));
EmployeesDT.Columns.Add("Name", typeof(string));
EmployeesDT.Columns.Add("Country", typeof(string));
EmployeesDT.Columns.Add("DOB", typeof(DateTime));
EmployeesDT.Columns.Add("Salary", typeof(Double));

EmployeesDT.Rows.Add(1, "Fares Haddad", "Lebanon", new DateTime(1970, 1, 1), 3000.00);
EmployeesDT.Rows.Add(2, "Ahmad Al-Hassan", "Jordan", new DateTime(1990, 5, 15), 75000.50);
EmployeesDT.Rows.Add(3, "Sara Khaled", "Jordan", new DateTime(1995, 11, 28), 62000.00);
EmployeesDT.Rows.Add(4, "Omar Abdulaziz", "UAE", new DateTime(1985, 3, 10), 98500.25);
EmployeesDT.Rows.Add(5, "Laila Hassan", "Egypt", new DateTime(1982, 7, 20), 45000.00);

// Create Departments DataTable
DataTable DepartmentsDT = new DataTable();
DepartmentsDT.Columns.Add("DeptID", typeof(int));
DepartmentsDT.Columns.Add("DeptName", typeof(string));

DepartmentsDT.Rows.Add(1, "Information Technology");
DepartmentsDT.Rows.Add(2, "Human Resources");
DepartmentsDT.Rows.Add(3, "Finance");

// Display Employees
Console.WriteLine("Employees List");
foreach(DataRow Row in EmployeesDT.Rows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}" +
    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();

// Display Departments
Console.WriteLine("Departments List");
foreach (DataRow Row in DepartmentsDT.Rows)
{
    Console.WriteLine($"Department: ID: {Row["DeptID"]}\tName: {Row["DeptName"]}");
}
Console.WriteLine();

// Create DataSet and add tables
DataSet ds = new DataSet();
ds.Tables.Add(EmployeesDT);
ds.Tables.Add(DepartmentsDT);

// Access Employees Table inside DataSet
Console.WriteLine("Employees List From DataSet");
foreach (DataRow Row in ds.Tables[0].Rows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}" +
    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();

```

---

### Access DataTables Inside a DataSet by Name

> You can access tables in a DataSet using their names rather than indexes. This is especially useful when working with multiple tables.

```csharp
// Create Employees DataTable with name
DataTable EmployeesDT = new DataTable("EmployeesDT");

Console.WriteLine("Employees List Using Table Name");
foreach (DataRow Row in ds.Tables["EmployeesDT"].Rows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["Name"]}" +
    $"\t\tCountry: {Row["Country"]}\tSalary: {Row["Salary"]}\tDate of Birth: {Row["DOB"]}");
}
Console.WriteLine();
```

### Explanation:

* `ds.Tables[0]` accesses the first table by index.

* `ds.Tables["EmployeesDT"]` accesses the table by name.

* A DataSet allows easy organization of multiple related DataTables in one object.

---

## DataAdapter

### What is DataAdapter?

In C#, a **DataAdapter** is a class in ADO.NET that acts as a bridge between a **DataSet** and a data source, such as a SQL database. It allows you to **populate a DataSet** with data from the database and also **update the database** with changes made to the DataSet.

**Key points:**  
- The DataAdapter is **disconnected**, meaning it does not maintain an open connection to the database after filling the DataSet.  
- It provides methods such as `.Fill()` to populate DataTables in a DataSet, and `.Update()` to propagate changes (insert, update, delete) back to the database.  
- Typically used when working with **offline data manipulation**, allowing you to fetch data, make changes, and then sync with the database.  

**Advantages:**  
- Works well with DataSets for in-memory data manipulation.  
- Supports batch updates to the database.  
- Can automatically handle INSERT, UPDATE, DELETE commands if configured.  

---

### DataAdapter Example

```csharp
// Connection string
string ConnectionString = ConfigurationManager.ConnectionStrings["HR_Database"].ConnectionString;

// Create a DataSet to hold data
DataSet ds = new DataSet();

// SQL query to fetch data
string Query = "SELECT * FROM Employees";

// Create DataAdapter with query and connection
SqlDataAdapter DataAdapter = new SqlDataAdapter(Query, ConnectionString);

// Automatically generate Insert/Update/Delete commands
SqlCommandBuilder CommandBuilder = new SqlCommandBuilder(DataAdapter);

// Fill DataSet with data
using(SqlConnection Connection = new SqlConnection(ConnectionString))
{
    Connection.Open();

    // Assign the connection to the SelectCommand
    //DataAdapter.SelectCommand.Connection = Connection;

    // Fill DataSet with Employees table
    DataAdapter.Fill(ds, "Employees");
}

// Access the DataTable from DataSet
DataTable EmployeesDT = ds.Tables["Employees"];

// Display data from DataTable
Console.WriteLine("Before Update:");
foreach(DataRow Row in EmployeesDT.Rows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
    $"\tGender: {Row["Gendor"]}\tDate of Birth: {Row["DateOfBirth"]}\tSalary: {Row["MonthlySalary"]}");
}

DataRow[] ResultRows = EmployeesDT.Select("ID = 287");
foreach(DataRow Row in ResultRows)
{
    Row["MonthlySalary"] = 8500m;
    Row["BonusPerc"] = 0.1;
}

// Apply changes to the database
DataAdapter.Update(ds, "Employees");

Console.WriteLine("\nAfter Update:");
foreach(DataRow Row in EmployeesDT.Rows)
{
    Console.WriteLine($"ID: {Row["ID"]}\tName: {Row["FirstName"]} {Row["LastName"]}" +
    $"\tGender: {Row["Gendor"]}\tDate of Birth: {Row["DateOfBirth"]}\tSalary: {Row["MonthlySalary"]}");
}

// Update the database with any changes made in the DataSet
// using (SqlConnection Connection = new SqlConnection(ConnectionString))
// {
//     Connection.Open();

//     // Assign the connection to UpdateCommand
//     DataAdapter.UpdateCommand.Connection = Connection;

//     // Propagate changes back to database
//     DataAdapter.Update(ds, "Employees");
// }
```

### Explanation:

* `.Fill(ds, "Employees")` loads the result of the SQL query into the `Employees` DataTable inside the DataSet.

* Any modifications (add, edit, delete rows) on `EmployeesDT` are made **in-memory**.

* `.Update(ds, "Employees")` pushes the changes back to the database.

* The DataAdapter uses **SelectCommand**, **InsertCommand**, **UpdateCommand**, **DeleteCommand** to manage database operations.

* This approach allows you to work with the database data offline and synchronize later.


### Important Note:

* Changes in the DataTable **must be tracked** by the DataAdapter to propagate correctly.

* If commands for Insert/Update/Delete are not provided, you may need to generate them automatically or set them manually.

* Always use `SqlCommandBuilder` if you want to auto-generate `UpdateCommand` for a `DataAdapter`.

* Connection is closed automatically after the Fill() or Update() operation is done.

* This works because DataAdapter.Fill() and DataAdapter.Update() internally check the connection