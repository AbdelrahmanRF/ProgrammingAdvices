using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsTestAppointmentData
    {
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT TestID FROM Tests
                                WHERE TestAppointmentID = @TestAppointmentID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ResultTestID))
                {
                    TestID = ResultTestID;
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

            return TestID;
        }

        public static bool GetTestAppointmentData(int TestAppointmentID, ref int TestTypeId,
                ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID,
                ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM TestAppointments
                                WHERE TestAppointmentID = @TestAppointmentID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    TestTypeId = Convert.ToInt32(Reader["TestTypeID"]);
                    LocalDrivingLicenseApplicationID = Convert.ToInt32(Reader["LocalDrivingLicenseApplicationID"]);
                    AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    IsLocked = Convert.ToBoolean(Reader["IsLocked"]);
                    RetakeTestApplicationID = Reader["RetakeTestApplicationID"] == DBNull.Value ? -1 :
                        Convert.ToInt32(Reader["RetakeTestApplicationID"]);
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

        public static bool GetLatestTestAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID,
                ref int TestAppointmentID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID,
                ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT TOP 1 * FROM TestAppointments
                                WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                      AND TestTypeID = @TestTypeID
                                ORDER BY AppointmentDate DESC;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = Convert.ToInt32(Reader["TestAppointmentID"]);
                    AppointmentDate = Convert.ToDateTime(Reader["AppointmentDate"]);
                    PaidFees = Convert.ToSingle(Reader["PaidFees"]);
                    CreatedByUserID = Convert.ToInt32(Reader["CreatedByUserID"]);
                    IsLocked = Convert.ToBoolean(Reader["IsLocked"]);
                    RetakeTestApplicationID = Reader["RetakeTestApplicationID"] == DBNull.Value ? -1 :
                        Convert.ToInt32(Reader["RetakeTestApplicationID"]);
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
    }
}
