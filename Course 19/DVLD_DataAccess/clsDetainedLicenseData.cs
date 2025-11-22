using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsDetainedLicenseData
    {
        public static bool GetDetainedLicenseInfoByLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, 
            ref float FineFees, ref int CreatedByUserID, ref bool IsReleased, ref DateTime ReleaseDate, 
            ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicenses
                    WHERE LicenseID = @LicenseID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    isFound = true;

                    DetainID = Convert.ToInt32(Reader["DetainID"]);
                    DetainDate = Convert.ToDateTime(Reader["DetainDate"]);
                    FineFees = Convert.ToSingle(Reader["FineFees"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    IsReleased = Convert.ToBoolean(Reader["IsReleased"]);
                    ReleaseDate = Reader["ReleaseDate"] == System.DBNull.Value ? DateTime.MaxValue : Convert.ToDateTime(Reader["ReleaseDate"]);
                    ReleasedByUserID = Reader["ReleasedByUserID"] == System.DBNull.Value ? -1 : Convert.ToInt32(Reader["ReleasedByUserID"]);
                    ReleaseApplicationID = Reader["ReleaseApplicationID"] == System.DBNull.Value ? -1 : Convert.ToInt32(Reader["ReleaseApplicationID"]);
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
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT CASE WHEN 
                    EXISTS (SELECT 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0) THEN CAST (1 AS BIT)
                    ELSE CAST (0 AS BIT) END;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                isFound = (bool)Command.ExecuteScalar();
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
    }
}
