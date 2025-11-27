using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;

namespace DVLD_DataAccess
{
	public class clsPersonDataAccess
	{
		public static DataTable GetAllPeople()
		{
			DataTable DT = new DataTable();
			SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);

			string Query = @"SELECT 
							P.PersonID,
							P.NationalNo,
							P.FirstName,
							P.SecondName,
							P.ThirdName,
							P.LastName,
							CASE 
								WHEN P.Gendor = 0 THEN 'Male'
								WHEN P.Gendor = 1 THEN 'Female' 
							END AS Gendor,
							P.DateOfBirth,
							C.CountryName AS Nationality,
							P.Phone,
							P.Email 
							FROM People AS P
							JOIN Countries AS C
							ON P.NationalityCountryID = C.CountryID
							ORDER BY P.FirstName;";
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

			}
			finally
			{
				Connection.Close();
			}

			return DT;
		}

		public static bool GetPersonInfoByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, 
			ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, 
			ref short Gendor, ref string Address, ref string Phone, ref string Email, 
			ref int NationalityCountryID, ref string ImagePath)
		{
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
			string Query = @"SELECT * FROM People
								WHERE NationalNo = @NationalNo;";
            SqlCommand Command = new SqlCommand(Query, Connection);
			Command.Parameters.AddWithValue("@NationalNo", NationalNo);

			try
			{
				Connection.Open();
				SqlDataReader Reader = Command.ExecuteReader();

				if (Reader.Read())
				{
                    isFound = true;

                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"] == DBNull.Value ? "" : Reader["ThirdName"].ToString();
                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
					Gendor = Convert.ToInt16(Reader["Gendor"]);
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Email = Reader["Email"] == DBNull.Value ? "" : Reader["Email"].ToString();
                    NationalityCountryID = Convert.ToInt32(Reader["NationalityCountryID"]);
                    ImagePath = Reader["ImagePath"] == DBNull.Value ? "" : Reader["ImagePath"].ToString();

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

        public static bool GetPersonInfoByPersonID(int PersonID, ref string NationalNo, ref string FirstName,
            ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth,
            ref short Gendor, ref string Address, ref string Phone, ref string Email,
            ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
            string Query = @"SELECT * FROM People
								WHERE PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;

                    NationalNo = Reader["NationalNo"].ToString();
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"] == DBNull.Value ? "" : Reader["ThirdName"].ToString();
                    LastName = Reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gendor = Convert.ToInt16(Reader["Gendor"]);
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Email = Reader["Email"] == DBNull.Value ? "" : Reader["Email"].ToString();
                    NationalityCountryID = Convert.ToInt32(Reader["NationalityCountryID"]);
                    ImagePath = Reader["ImagePath"] == DBNull.Value ? "" : Reader["ImagePath"].ToString();

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

        public static bool isPersonExist(string NationalNo)
		{
			bool isFound = false;

			SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
			string Query = @"SELECT CASE WHEN EXISTS (SELECT 1 FROM People WHERE NationalNo = @NationalNo) 
								THEN CAST (1 AS BIT)
								ELSE CAST (0 AS BIT)
							END";
			SqlCommand Command = new SqlCommand(Query, Connection);
			Command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

		public static int AddNewPerson(string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            short Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
		{
			int PersonID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
			string Query = @"INSERT INTO People 
			(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, 
				Email, NationalityCountryID, ImagePath)
			VALUES
			(@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gendor, @Address,
				@Phone, @Email, @NationalityCountryID, @ImagePath);
			SELECT SCOPE_IDENTITY();";

			SqlCommand Command = new SqlCommand(Query, Connection);
			Command.Parameters.AddWithValue("@NationalNo", NationalNo);
			Command.Parameters.AddWithValue("@FirstName", FirstName);
			Command.Parameters.AddWithValue("@SecondName", SecondName);

			if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
			else
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "")
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

			try
			{
                Connection.Open();
				object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
					PersonID = InsertedID;
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

            return PersonID;
		}

		public static bool UpdatePerson(int PersonID, string NationalNo, string FirstName,
            string SecondName, string ThirdName, string LastName, DateTime DateOfBirth,
            short Gendor, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
		{
			int RowsAffected = 0;
			SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);
			string Query = @"UPDATE People
								SET NationalNo = @NationalNo,
									FirstName = @FirstName,
									SecondName = @SecondName,
									ThirdName = @ThirdName,
									LastName = @LastName,
									DateOfBirth = @DateOfBirth,
									Gendor = @Gendor,
									Address = @Address,
									Phone = @Phone,
									Email = @Email,
									NationalityCountryID = @NationalityCountryID,
									ImagePath = @ImagePath
								WHERE PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != "")
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            else
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);

            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != "")
                Command.Parameters.AddWithValue("@Email", Email);
            else
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);

            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != "")
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

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
        public static bool DeletePerson(int PersonID)
		{
			int RowsAffected = 0;
			SqlConnection Connection = new SqlConnection(clsDataAccessingSettings.ConnectionString);

			string Query = @"DELETE FROM People
							WHERE PersonID = @PersonID";

			SqlCommand Command = new SqlCommand(Query, Connection);
			Command.Parameters.AddWithValue("@PersonID", PersonID);

			try
			{
                Connection.Open();

				RowsAffected = Command.ExecuteNonQuery();
            }
			catch (SqlException ex)
			{
				if (ex.Errors.Count > 0)
				{
					switch(ex.Errors[0].Number)
					{
                        case 547:
                            throw new InvalidOperationException("Person was not Deleted Because it has Data Linked to it.", ex);
                        default:
                            throw new Exception();
                    }
				}
            }
			finally
			{
				Connection.Close();
			}

			return RowsAffected > 0;
        }
    }
}
