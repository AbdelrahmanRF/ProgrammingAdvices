using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable DT = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM vwLDLAppsSummary
                                    ORDER BY ApplicationDate DESC";
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

        public static int AddNewLDLApplication(int ApplicationID, int LicenseClassID)
        {
            int LDLApplicationID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                                VALUES (@ApplicationID, @LicenseClassID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if ( Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    LDLApplicationID = InsertedID;
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

            return LDLApplicationID;
        }

        public static bool UpdateLDLApplication(int LDLApplicationID, int ApplicationID, int LicenseClassID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE LocalDrivingLicenseApplications
                                SET ApplicationID = @ApplicationID,
                                    LicenseClassID = @LicenseClassID
                                WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return RowsAffected > 0;
        }

        public static bool GetLDLApplicationInfoByID(int LDLApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM LocalDrivingLicenseApplications
                                WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    LicenseClassID = Convert.ToInt32(Reader["LicenseClassID"]);
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

        public static bool DeleteLDLApplication(int LDLApplicationID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"DELETE LocalDrivingLicenseApplications
                                WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool IsThereAnActiveScheduledTest(int LDLApplicationID, int TestTypeID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT 
                                CASE WHEN EXISTS (
                                    SELECT TOP 1 1 FROM TestAppointments
                                           WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID
                                                 AND TestTypeID = @TestTypeID AND IsLocked = 0
                                           ORDER BY TestAppointmentID DESC)
                                THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static byte TotalTrialsPerTest(int LDLApplicationID, int TestTypeID)
        {
            byte TotalTrials = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT Count(*) FROM TestAppointments
                                WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID 
                                AND TestTypeID = @TestTypeID AND IsLocked = 1;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                TotalTrials = Convert.ToByte(Command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return TotalTrials;
        }

        public static bool DoesPassTestType(int LDLApplicationID, int TestTypeID)
        {
            bool isPassed = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT 
                            CASE WHEN EXISTS 
                            (
                                SELECT 1 
                                FROM TestAppointments TA 
                                JOIN Tests T ON TA.TestAppointmentID = T.TestAppointmentID
                                WHERE TA.LocalDrivingLicenseApplicationID = @LDLApplicationID 
                                      AND TA.TestTypeID = @TestTypeID 
                                      AND T.TestResult = 1
                            )
                            THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) 
                        END;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LDLApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                isPassed = (bool)Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return isPassed;
        }
    }
}
