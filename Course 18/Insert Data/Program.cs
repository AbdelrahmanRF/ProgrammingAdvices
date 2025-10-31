using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Insert_Data
{
    internal class Program
    {
        struct strContact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }

        static string ConnectionString = ConfigurationManager.ConnectionStrings["ContactsDB"].ConnectionString;

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

                if (RowsAffected > 0 )
                {
                    Console.WriteLine("Record Inserted Successfully");
                }
                else
                {
                    Console.WriteLine("Record Insertion Failed");
                }

                    Connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

        static void Main(string[] args)
        {
            strContact Contact = new strContact
            {
                FirstName = "Sami",
                LastName = "Nedal",
                Email = "sn@gmail.com",
                Phone = "111222333",
                Address = "123 Qwe St",
                CountryID = 2
            };

            //AddNewClient(Contact);

            AddNewClientAndGetID(Contact);
        }
    }
}
