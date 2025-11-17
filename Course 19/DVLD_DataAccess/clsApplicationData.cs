using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsApplicationData
    {
        public static bool GetBaseApplication(int ApplicationID, ref int ApplicantPersonID, ref int ApplicationTypeID, 
            ref DateTime ApplicationDate, ref byte ApplicationStatus, ref DateTime LastStatusDate, ref float PaidFees, 
            ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM Applications
                                WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    ApplicantPersonID = Convert.ToInt32(Reader["ApplicantPersonID"]);
                    ApplicationTypeID = Convert.ToInt32(Reader["ApplicationTypeID"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);

                    ApplicationDate = Convert.ToDateTime(Reader["ApplicationDate"]);
                    LastStatusDate = Convert.ToDateTime(Reader["LastStatusDate"]);

                    ApplicationStatus = Convert.ToByte(Reader["ApplicationStatus"]);
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
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

            return isFound;
        }
    }
}
