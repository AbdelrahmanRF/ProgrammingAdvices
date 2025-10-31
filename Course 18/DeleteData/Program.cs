using System;
using System.Configuration;
using System.Data.SqlClient;


namespace DeleteData
{
    internal class Program
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["ContactsDB"].ConnectionString;

        static void DeleteContact(int ContactID)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"DELETE Contacts
                              WHERE ContactID = @ContactID";
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

        static void DeleteContacts(string ContactIDs)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string Query = @"DELETE Contacts
                              WHERE ContactID in ( " + @ContactIDs + ")";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ContactIDs", ContactIDs);

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
        static void Main(string[] args)
        {
            //DeleteContact(10);

            DeleteContacts("1,2,3");
        }
    }
}
