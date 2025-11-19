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


        public static int GetActiveApplicationIDForLicenseClass(int ApplicantPersonID, byte ApplicationStatus, 
            int LicenseClassID)
        {
            int ActiveApplicationID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT A.ApplicationID FROM Applications AS A
                                JOIN  LocalDrivingLicenseApplications AS LDL 
                                ON A.ApplicationID = LDL.ApplicationID
                                WHERE A.ApplicantPersonID = @ApplicantPersonID 
                                AND A.ApplicationStatus = @ApplicationStatus 
                                AND LDL.LicenseClassID = @LicenseClassID;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int FoundActiveApplicationID))
                    ActiveApplicationID = FoundActiveApplicationID;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return ActiveApplicationID;
        }


        public static int AddNewNewBaseApplication(int ApplicantPersonID, int ApplicationTypeID, DateTime ApplicationDate
                , byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int ApplicationID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"INSERT INTO Applications(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus,
                                LastStatusDate, PaidFees, CreatedByUserID)
                            VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus,
                                    @LastStatusDate, @PaidFees, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if(Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                    ApplicationID = InsertedID;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;
        }

        public static bool UpdateBaseApplication(int ApplicationID, int ApplicantPersonID, int ApplicationTypeID, 
            DateTime ApplicationDate, byte ApplicationStatus, DateTime LastStatusDate, float PaidFees, int CreatedByUserID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE Applications
                                SET ApplicantPersonID = @ApplicantPersonID,
	                                ApplicationDate = @ApplicantPersonID,
	                                ApplicationTypeID = ApplicationTypeID,
	                                ApplicationStatus = ApplicationStatus,
	                                LastStatusDate = LastStatusDate,
	                                PaidFees = PaidFees,
	                                CreatedByUserID = CreatedByUserID
                                WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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

        public static bool SetApplicationStatus(int ApplicationID, byte ApplicationStatus)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"UPDATE Applications
	                            SET ApplicationStatus = @ApplicationStatus
                            WHERE ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

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
