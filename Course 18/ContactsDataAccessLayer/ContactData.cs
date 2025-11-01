using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {
        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName, ref string Email, 
            ref string Phone, ref string Address, ref string ImagePath, ref DateTime DateOfBirth, ref int CountryID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    isFound = true;

                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                    Email = (string)Reader["Email"];
                    Phone = (string)Reader["Phone"];
                    Address = (string)Reader["Address"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    ImagePath = Reader["ImagePath"] != DBNull.Value ? (string)Reader["ImagePath"] : "";
                    CountryID = (int)Reader["CountryID"];
                }

                Reader.Close();
            }
            catch(Exception ex) 
            {
                //Console.WriteLine($"Error: {ex.Message}");
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static int AddNewContact(string FirstName, string LastName, string Email,
            string Phone, string Address, string ImagePath, DateTime DateOfBirth, int CountryID)
        {
            int ContactID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, 
                ImagePath, DateOfBirth, CountryID)
                VALUES (@FirstName, @LastName, @Email, @Phone, @Address, 
                @ImagePath, @DateOfBirth, @CountryID);
                SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);

            if (ImagePath != "")
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    ContactID = InsertedID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return ContactID;
        }

        public static bool UpdateContact(int ID, string FirstName, string LastName, string Email,
            string Phone, string Address, string ImagePath, DateTime DateOfBirth, int CountryID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Contacts
                            SET FirstName = @FirstName,
                                LastName = @LastName,
                                Email = @Email,
                                Phone = @Phone,
                                Address = @Address,
                                ImagePath = @ImagePath,
                                DateOfBirth = @DateOfBirth,
                                CountryID = @CountryID
                            WHERE ContactID = @ContactID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ContactID", ID);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);

            if (ImagePath != "")
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool DeleteContact(int ID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE Contacts
                             WHERE ContactID = @ContactID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

        public static DataTable GetAllContacts()
        {
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            DataTable DT = new DataTable();

            string Query = "SELECT * FROM Contacts";
            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    DT.Load(Reader);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return DT;
        }

        public static bool IsContactExist(int ID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM Contacts WHERE ContactID = @ContactID) 
                            THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                Connection.Open();
                isFound = (bool)(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            { 
                Connection.Close();
            }

            return isFound;
        }
    }
}
