using System;
using System.Data.SqlClient;
using System.Configuration;


namespace UpdateData
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            strContact Contact = new strContact
            {
                FirstName = "Omar",
                LastName = "Saleh",
                Email = "omar.saleh@example.com",
                Phone = "777000123",
                Address = "148 Yii St",
                CountryID = 1
            };

            UpdateContact(1, Contact);
        }
    }
}
