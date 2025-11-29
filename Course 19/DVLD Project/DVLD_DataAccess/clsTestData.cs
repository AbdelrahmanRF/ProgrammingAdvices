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

        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, 
            ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM Tests WHERE TestID = @TestID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = Convert.ToInt32(Reader["TestAppointmentID"]);
                    TestResult = Convert.ToBoolean(Reader["TestResult"]);
                    Notes = Reader["Notes"] == System.DBNull.Value ? "" : Reader["Notes"].ToString();
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

        public static bool GetLatestTestPerPersonAndLicenseClass(int ApplicantPersonID, int LicenseClassID, int TestTypeID, 
            ref int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT TOP 1 T.* FROM Tests AS T
                                JOIN TestAppointments AS TA ON T.TestAppointmentID = TA.TestAppointmentID
                                JOIN LocalDrivingLicenseApplications AS LDL 
                                    ON TA.LocalDrivingLicenseApplicationID = LDL.LocalDrivingLicenseApplicationID
                                JOIN Applications AS A ON LDL.ApplicationID = A.ApplicationID

                             WHERE TA.TestTypeID = @TestTypeID AND LDL.LicenseClassID = @LicenseClassID 
                                AND A.ApplicantPersonID = @ApplicantPersonID
                             ORDER BY T.TestAppointmentID DESC;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    TestID = Convert.ToInt32(Reader["TestID"]);
                    TestAppointmentID = Convert.ToInt32(Reader["TestAppointmentID"]);
                    TestResult = Convert.ToBoolean(Reader["TestResult"]);
                    Notes = Reader["Notes"] == System.DBNull.Value ? "" : Reader["Notes"].ToString();
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
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int TestID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"INSERT INTO Tests 
                                (TestAppointmentID, TestResult, Notes, CreatedByUserID)
                            VALUES
                                (@TestAppointmentID, @TestResult, @Notes, @CreatedByUserID);
                            UPDATE TestAppointments 
                                SET IsLocked = 1
                            WHERE TestAppointmentID = @TestAppointmentID
                            SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "")
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    TestID = InsertedID;
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

        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int RowsCount = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE Tests
                            SET
                                TestAppointmentID = @TestAppointmentID, 
                                TestResult = @TestResult, 
                                Notes = @Notes, 
                                CreatedByUserID = @CreatedByUserID

                            WHERE TestID = @TestID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);

            if (Notes != "")
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@TestID", TestID);

            try
            {
                Connection.Open();
                RowsCount = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return RowsCount > 0;
        }
    }
}
