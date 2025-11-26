using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public static DataTable GetAllDriverLicenses(int DriverID)
        {
            DataTable DT = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT 
                                L.LicenseID, 
                                L.ApplicationID,
                                LC.ClassName,
                                L.IssueDate,
                                L.ExpirationDate,
                                L.IsActive
                            FROM Licenses AS L
                            JOIN LicenseClasses AS LC
                            ON L.LicenseClass = LC.LicenseClassID
                            WHERE DriverID = @DriverID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

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

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"INSERT INTO Licenses (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, 
                                PaidFees, IsActive, IssueReason, CreatedByUserID)
                            VALUES
                                (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, 
                                    @IsActive, @IssueReason, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes != "")
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if(Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    LicenseID = InsertedID;
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

            return LicenseID;
        }

        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate,
            DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE Licenses
                                SET
                                    ApplicationID = @ApplicationID,
                                    DriverID = @DriverID,
                                    LicenseClass = @LicenseClass,
                                    IssueDate = @IssueDate,
                                    ExpirationDate = @ExpirationDate,
                                    Notes = @Notes,
                                    PaidFees = @PaidFees,
                                    IsActive = @IsActive,
                                    IssueReason = @IssueReason,
    
                                WHERE LicenseID = @LicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes != "")
                Command.Parameters.AddWithValue("@Notes", Notes);
            else
                Command.Parameters.AddWithValue("@Notes", System.DBNull.Value);

            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
    }
}
