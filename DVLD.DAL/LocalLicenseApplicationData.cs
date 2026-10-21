using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD.DAL
{
    public static class LocalLicenseApplicationData
    {
        public static DataTable GetAllApplications()
        {
            var dt = new DataTable();
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplicationID,
                                   ClassName,
                                   NationalNo,
                                   CONCAT_WS(' ', FirstName, SecondName, ThirdName, LastName) AS FullName,
                                   ApplicationDate,
                                   (
                                    SELECT COUNT(TestID)
                                    FROM  LocalDrivingLicenseApplications AS L 
                                    INNER JOIN TestAppointments ON
                                        L.LocalDrivingLicenseApplicationID =
                                            TestAppointments.LocalDrivingLicenseApplicationID
                                    INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                    WHERE TestResult = 1 AND L.LocalDrivingLicenseApplicationID =
                                        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                                   ) AS PassedTests,
                                   CASE ApplicationStatus
                                   WHEN 1 THEN 'New'
                                   WHEN 2 THEN 'Cancelled'
                                   WHEN 3 THEN 'Completed'
                                   END AS ApplicationStatus
                            FROM Applications
                            INNER JOIN LocalDrivingLicenseApplications ON
                                Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                            INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID
                            INNER JOIN LicenseClasses ON
                                LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                            
                            ORDER BY ApplicationDate DESC";

            var command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex) { }
            finally { connection.Close(); }

            return dt;
        }
        public static bool GetApplicationInfo(int LocalDrivingLicenseApplicationID, ref int ApplicationID,
            ref int LicenseClassID)
        {
            bool isFound = false;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                else
                {
                    // The record was not found
                    isFound = false;
                }


            }
            catch (Exception)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewApplication(int ApplicationID, int LicenseClassID)
        {
            //this function will return the new Application id if succeeded and -1 if not.
            int LocalLicenseApplicationID = -1;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LocalDrivingLicenseApplications (ApplicationID, LicenseClassID)
                             VALUES (@ApplicationID, @LicenseClassID);
                             SELECT SCOPE_IDENTITY();";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalLicenseApplicationID = insertedID;
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


            return LocalLicenseApplicationID;
        }
        public static bool UpdateLicenseClassInApplication(int LocalDrivingLicenseApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE  LocalDrivingLicenseApplications  
                SET LicenseClassID = @LicenseClassID
                    where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static int GetNumberOfPassedTestByID(int LocalDrivingLicenseApplicationID)
        {
            int PassedTests = 0;
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT Count(TestResult)
                            FROM  LocalDrivingLicenseApplications AS L 
                            INNER JOIN TestAppointments ON
                                L.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            INNER JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID

                            WHERE TestResult = 1 AND
                                L.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                PassedTests = (int)command.ExecuteScalar();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return 0;

            }

            finally
            {
                connection.Close();
            }


            return PassedTests;
        }
        public static bool Delete(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;
            string query = @"DELETE LocalDrivingLicenseApplications
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, int LicenseClassID)
        {
            int ApplicationID = -1;
            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                             FROM   Applications
                             INNER JOIN LocalDrivingLicenseApplications ON
                                 Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
                             WHERE Applications.ApplicantPersonID = @PersonID 
                             AND LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID
                             AND Applications.ApplicationStatus = 1";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
                ApplicationID = result == null ? -1 : (int)result;

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
    }
}
