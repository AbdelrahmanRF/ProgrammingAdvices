using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, float FineFees,
                int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, 
                                ReleaseDate, ReleasedByUserID, ReleaseApplicationID)
                            VALUES
                            (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, @IsReleased, @ReleaseDate, 
                                @ReleasedByUserID, @ReleaseApplicationID);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (IsReleased)
            {
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
            {
                Command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
                Command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
                Command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);
            }

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    DetainID = InsertedID;
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

            return DetainID;
        }

        public static bool UpdateDetainedLicense(int DetainID, int LicenseID, DateTime DetainDate, float FineFees,
        int CreatedByUserID, bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE DetainedLicenses
                            SET
                                LicenseID = @LicenseID, 
                                DetainDate = @DetainDate, 
                                FineFees = @FineFees, 
                                CreatedByUserID = @CreatedByUserID, 
                                IsReleased = @IsReleased, 
                                ReleaseDate = @ReleaseDate, 
                                ReleasedByUserID = @ReleasedByUserID, 
                                ReleaseApplicationID = @ReleaseApplicationID
                            WHERE DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@DetainID", DetainID);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);

            if (IsReleased)
            {
                Command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                Command.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
                Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            }
            else
            {
                Command.Parameters.AddWithValue("@ReleaseDate", System.DBNull.Value);
                Command.Parameters.AddWithValue("@ReleasedByUserID", System.DBNull.Value);
                Command.Parameters.AddWithValue("@ReleaseApplicationID", System.DBNull.Value);
            }

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

        public static DataTable GetAllDetainedLicenses()
        {
            DataTable DT = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM DetainedLicenses_View 
                                ORDER BY DetainID DESC;";
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
    }
}
