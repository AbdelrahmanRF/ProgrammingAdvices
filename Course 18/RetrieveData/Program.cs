using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Runtime.Remoting.Messaging;

namespace RetrieveData
{
    internal class Program
    {
        static string ConnectionString = ConfigurationManager.ConnectionStrings["ContactsDB"].ConnectionString;

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

        static void PrintContact(SqlDataReader Reader)
        {
            Console.WriteLine($"Contact ID  : {Reader["ContactID"]}");
            Console.WriteLine($"FirstName   : {Reader["FirstName"]}");
            Console.WriteLine($"LastName    : {Reader["LastName"]}");
            Console.WriteLine($"Email       : {Reader["Email"]}");
            Console.WriteLine($"Phone       : {Reader["Phone"]}");
            Console.WriteLine($"Address     : {Reader["Address"]}");
            Console.WriteLine($"Country ID  : {Reader["CountryID"]}");
            Console.WriteLine();
        }

        static void PrintAllContacts()
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                while(Reader.Read())
                {
                    PrintContact(Reader);
                }

                Reader.Close();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

        static void PrintAllContactsWithFirstName(string FirstName)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName = @FirstName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);

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
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

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

                while(Reader.Read())
                {
                    PrintContact(Reader);
                }

                Reader.Close();
                Connection.Close();
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message); 
            }
        }

        static void SearchContactsStartsWith(string StartsWith)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE '' + @StartsWith + '%'";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@StartsWith", StartsWith);
            
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SearchContactsEndsWith(string EndsWith)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE '%' + @EndsWith + ''";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@EndsWith", EndsWith);

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

            string Query = "SELECT * FROM Contacts WHERE FirstName LIKE @Contains";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Contains", "%" + Contains + "%");

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
        static void Main(string[] args)
        {
            //PrintAllContacts();
            //PrintAllContactsWithFirstName("jane");
            //PrintAllContactsWithFirstNameAndCountry("jane", 1);

            //SearchContactsStartsWith("d");
            //SearchContactsEndsWith("e");
            //SearchContactsContains("ae");

            //Console.WriteLine(GetFirstName(1));

            if(FindContactByID(1, out strContact Contact))
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
                Console.WriteLine($"Contact is not found");
            }
        }
    }
}
