using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable DT = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = "SELECT * FROM TestTypes";
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
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return DT;
        }

        public static bool GetTestTypeDataByID(int TestTypeID, ref string Title, ref string Description, ref float Fees)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM TestTypes
                                WHERE TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    Title = Reader["TestTypeTitle"].ToString();
                    Description = Reader["TestTypeDescription"].ToString();
                    Fees = Convert.ToSingle(Reader["TestTypeFees"]);
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

        public static bool UpdateTestType(int TestTypeID, string Title, string Description, float Fees)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE TestTypes
                            SET TestTypeTitle = @TestTypeTitle,
	                            TestTypeDescription = @TestTypeDescription,
	                            TestTypeFees = @TestTypeFees
                            WHERE TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeTitle", Title);
            Command.Parameters.AddWithValue("@TestTypeDescription", Description);
            Command.Parameters.AddWithValue("@TestTypeFees", Fees);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }
    }
}
