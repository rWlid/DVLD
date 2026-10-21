using System;
using System.Data.SqlClient;

namespace DVLD.DAL
{
    public static class ApplicationData
    {
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            //this function will return the new Application id if succeeded and -1 if not.
            int ApplicationID = -1;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications
                                (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus,
                                 LastStatusDate, PaidFees, CreatedByUserID)
                             VALUES (@ApplicantPersonID, @ApplicationDate, @ApplicationTypeID, @ApplicationStatus,
                                     @LastStatusDate, @PaidFees, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return ApplicationID;
        }
        public static bool UpdateApplicationStatus(int ApplicationID, int ApplicationStatus)
        {
            int rowsAffected = 0;
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE  Applications  
                SET ApplicationStatus = @ApplicationStatus, LastStatusDate = @LastStatusDate
                    where ApplicationID = @ApplicationID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;

            }

            finally
            {
                connection.Close();
            }


            return (rowsAffected > 0);
        }
        public static bool GetApplicationInfo(int ApplicationID, ref int ApplicantPersonID,
            ref DateTime ApplicationDate, ref int ApplicationTypeID, ref int ApplicationStatus,
            ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            bool isFound = false;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = Convert.ToInt32(reader["ApplicationStatus"]);
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool Delete(int ApplicationID)
        {
            int rowsAffected = 0;
            string query = @"DELETE Applications WHERE ApplicationID = @ApplicationID
                             AND ( ApplicationStatus = 1 OR ApplicationStatus = 0 )"; //Only New Applications.

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);
        }

    }
}
