using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsCountryDataAccess
    {
        public static bool FindCountryByID(int CountryID, ref string CountryName, ref string Code, ref string PhoneCode)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Countries WHERE CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    CountryName = Reader["CountryName"] != System.DBNull.Value ? (string)Reader["CountryName"] : "";
                    Code = Reader["Code"] != System.DBNull.Value ? (string)Reader["Code"] : "";
                    PhoneCode = Reader["PhoneCode"] != System.DBNull.Value ? (string)Reader["PhoneCode"] : "";
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

            return isFound;
        }

        public static bool FindCountryByName(string CountryName, ref int CountryID, ref string Code, ref string PhoneCode)
        {
            bool isFound  = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryName = @CountryName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    CountryID = (int)Reader["CountryID"];
                    Code = Reader["Code"] != System.DBNull.Value ? (string)Reader["Code"] : "";
                    PhoneCode = Reader["PhoneCode"] != System.DBNull.Value ? (string)Reader["PhoneCode"] : "";
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static int AddNewCountry(string CountryName, string Code, string PhoneCode)
        {
            int CountryID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Countries (CountryName, Code, PhoneCode) 
                            VALUES (@CountryName, @Code, @PhoneCode);
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);

            if (CountryName != "")
                Command.Parameters.AddWithValue("@CountryName", CountryName);
            else
                Command.Parameters.AddWithValue("@CountryName", System.DBNull.Value);


            if (Code != "")
                Command.Parameters.AddWithValue("@Code", Code);
            else
                Command.Parameters.AddWithValue("@Code", System.DBNull.Value);


            if (PhoneCode != "")
                Command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            else
                Command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    CountryID = InsertedID;
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

            return CountryID;
        }

        public static bool UpdateCountry(int CountryID, string CountryName, string Code, string PhoneCode)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Countries 
                                SET CountryName = @CountryName,
                                Code = @Code,
                                PhoneCode = @PhoneCode
                                WHERE CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            if (CountryName != "")
                Command.Parameters.AddWithValue("@CountryName", CountryName);
            else
                Command.Parameters.AddWithValue("@CountryName", System.DBNull.Value);


            if (Code != "")
                Command.Parameters.AddWithValue("@Code", Code);
            else
                Command.Parameters.AddWithValue("@Code", System.DBNull.Value);


            if (PhoneCode != "")
                Command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            else
                Command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool DeleteCountry(int CountryID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM Countries 
                                WHERE CountryID = @CountryID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            
            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                RowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "SELECT * FROM Countries";
            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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

            return dt;
        }

        public static bool IsCountryExistByID(int CountryID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM Countries WHERE CountryID = @CountryID) 
                                THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();
                isFound = (bool)Command.ExecuteScalar();
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
        public static bool IsCountryExistByName(string CountryName)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM Countries WHERE CountryName = @CountryName) 
                                THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                Connection.Open();
                isFound = (bool)Command.ExecuteScalar();
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
