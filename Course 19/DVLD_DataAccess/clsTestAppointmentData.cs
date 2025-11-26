using System;
using System.Collections.Generic;
using System.Data;
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

        public static bool GetLatestTestAppointment(int LocalDrivingLicenseApplicationID, ref int TestTypeID,
        ref int TestAppointmentID, ref DateTime AppointmentDate, ref float PaidFees, ref int CreatedByUserID,
        ref bool IsLocked, ref int RetakeTestApplicationID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT TOP 1 *
                            FROM TestAppointments
                            WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID
                            ORDER BY TestAppointmentID DESC;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    TestAppointmentID = Convert.ToInt32(Reader["TestAppointmentID"]);
                    TestTypeID = Convert.ToInt32(Reader["TestTypeID"]);
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
                                WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID 
                                      AND TestTypeID = @TestTypeID
                                ORDER BY TestAppointmentID DESC;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LocalDrivingLicenseApplicationID);
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

        public static DataTable GetApplicationTestAppointmentsByTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable DT = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT TestAppointmentID, AppointmentDate, PaidFees, IsLocked 
                                FROM TestAppointments
                                WHERE LocalDrivingLicenseApplicationID = @LDLApplicationID 
                                      AND TestTypeID = @TestTypeID
                                ORDER BY TestAppointmentID DESC;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LDLApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
            float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int TestAppointmentID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"INSERT INTO TestAppointments 
                                (TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, 
                                CreatedByUserID, IsLocked, RetakeTestApplicationID)
                            VALUES
                            (@TestTypeID, @LocalDrivingLicenseApplicationID, @AppointmentDate, 
                                @PaidFees, @CreatedByUserID, @IsLocked, @RetakeTestApplicationID)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID != -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    TestAppointmentID = InsertedID;
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

            return TestAppointmentID;
        }

        public static bool UpdateTestAppointment(int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
            float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            int RowsCount = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE TestAppointments
                                SET
                                    TestTypeID = @TestTypeID, 
                                    LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID, 
                                    AppointmentDate = @AppointmentDate, 
                                    PaidFees = @PaidFees, 
                                    CreatedByUserID = @CreatedByUserID, 
                                    IsLocked = @IsLocked, 
                                    RetakeTestApplicationID = @RetakeTestApplicationID

                                WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeId", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID != -1)
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);
            else
                Command.Parameters.AddWithValue("@RetakeTestApplicationID", System.DBNull.Value);

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
