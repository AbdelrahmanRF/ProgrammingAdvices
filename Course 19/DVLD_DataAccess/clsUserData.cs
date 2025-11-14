using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsUserData
    {
        public static bool GetUserByUsernameAndPassword(string Username, string Password, ref int UserId, 
            ref int PersonID, ref bool isActive)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM Users
                            WHERE UserName = @Username AND Password = @Password";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@Username", Username);
            Command.Parameters.AddWithValue("@Password", Password);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    isActive = (bool)Reader["IsActive"];
                    UserId = Convert.ToInt32(Reader["UserId"]);
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                }

                Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllUsers()
        {
            DataTable DT = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT 
                            U.UserID,
                            U.PersonID,
                            P.FirstName + ' ' + P.SecondName + ' ' + ISNULL(P.ThirdName, '') + ' ' + P.LastName AS FullName,
                            U.UserName,
                            U.IsActive
                            FROM Users AS U
                            JOIN People AS P
                            ON U.PersonID = P.PersonID;";
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
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return DT;
        }
    }
}
