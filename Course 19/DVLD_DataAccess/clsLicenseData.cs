using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLicenseData
    {
        public static bool GetLicenseInfoByLicenseID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,
                ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes, ref float PaidFees, 
                ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM Licenses
                    WHERE LicenseID = @LicenseID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
                    LicenseClass = Convert.ToInt32(Reader["LicenseClass"]);
                    IssueDate = Convert.ToDateTime(Reader["IssueDate"]);
                    ExpirationDate = Convert.ToDateTime(Reader["ExpirationDate"]);
                    Notes = Reader["Notes"] == System.DBNull.Value ? "" : Reader["Notes"].ToString();
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);
                    IssueReason = Convert.ToInt32(Reader["IssueReason"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
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
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int ActiveLicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT L.LicenseID FROM Licenses AS L
                                JOIN Drivers AS D ON L.DriverID = D.DriverID
                                WHERE D.PersonID = @PersonID AND L.LicenseClass = @LicenseClassID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int FoundID))
                {
                    ActiveLicenseID = FoundID;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return ActiveLicenseID;
        }
    }
}
