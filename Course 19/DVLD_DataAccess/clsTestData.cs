using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestData
    {
        public static byte GetPassedTestCount(int LDLApplicationID)
        {
            byte PassedTestCount = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT COUNT(*) FROM Tests AS T
                                JOIN TestAppointments AS TE ON TE.TestAppointmentID = T.TestAppointmentID
                            WHERE TE.LocalDrivingLicenseApplicationID = @LDLApplicationID AND T.TestResult = 1";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                Connection.Open();
                PassedTestCount = Convert.ToByte(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return PassedTestCount;
        }
    }
}
