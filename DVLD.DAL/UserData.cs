using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD.DAL
{
    public static class UserData
    {
        public static DataTable GetAllUsers()
        {
            var dt = new DataTable();
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT 
                                Users.UserID,
                                Users.PersonID,
                                CONCAT_WS(' ', People.FirstName, People.SecondName, People.ThirdName,
                                          People.LastName) AS FullName,
                                Users.UserName, 
                                Users.IsActive
                             FROM Users
                             INNER JOIN People ON Users.PersonID = People.PersonID";

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
        public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string UserName, ref bool IsActive)
        {
            bool isFound = false;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT PersonID,UserName,IsActive FROM Users WHERE UserID = @UserID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    IsActive = (bool)reader["IsActive"];

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
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName, ref bool IsActive)
        {
            bool isFound = false;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT UserID,UserName,IsActive FROM Users WHERE PersonID = @PersonID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    IsActive = (bool)reader["IsActive"];

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
        public static bool GetUserInfoByUsername(string UserName, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT UserID,PersonID,IsActive FROM Users WHERE UserName = @UserName";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

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
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            //this function will return the new User id if succeeded and -1 if not.
            int UserID = -1;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                             VALUES (@PersonID, @UserName, @Password, @IsActive);
                             SELECT SCOPE_IDENTITY();";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    UserID = insertedID;
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


            return UserID;
        }
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int rowsAffected = 0;
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE  Users  
                            SET UserName = @UserName, 
                                Password = @Password, 
                                IsActive = @IsActive
                            WHERE UserID = @UserID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;

            }

            finally
            {
                connection.Close();
            }


            return (rowsAffected > 0);
        }
        public static bool DeleteUser(int UserID)
        {
            int rowsAffected = 0;
            string query = @"DELETE Users WHERE UserID = @UserID";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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
        public static bool UpdatePassword(int UserID, string newPassword)
        {
            int rowsAffected = 0;
            string query = @"UPDATE Users  
                            SET Password = @Password
                            WHERE UserID = @UserID";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", newPassword);

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
        public static bool IsUserExist(int UserID)
        {
            bool isFound = false;
            string query = @"SELECT Found=1 FROM Users WHERE UserID = @UserID";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                isFound = command.ExecuteScalar() != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return isFound;
        }
        public static bool IsUserExist(string UserName)
        {
            bool isFound = false;
            string query = @"SELECT Found=1 FROM Users WHERE UserName = @UserName";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                isFound = command.ExecuteScalar() != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return isFound;
        }
        public static bool IsUserExistForPerson(int PersonID)
        {
            bool isFound = false;
            string query = @"SELECT Found=1 FROM Users WHERE PersonID = @PersonID";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                isFound = command.ExecuteScalar() != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return isFound;
        }
        public static bool AreCredentialsValid(int UserID, string Password)
        {
            bool valid = false;
            string query = @"SELECT Found=1 FROM Users WHERE UserID = @UserID AND Password = @Password";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                valid = command.ExecuteScalar() != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return valid;
        }
        public static bool AreCredentialsValid(string UserName, string Password)
        {
            bool valid = false;
            string query = @"SELECT Found=1 FROM Users WHERE UserName = @UserName AND Password = @Password";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                valid = command.ExecuteScalar() != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return valid;
        }
        public static bool GetUserInfoByUsernameAndPassword(string UserName, string Password, ref int UserID,
            ref int PersonID, ref bool IsActive)
        {
            bool isFound = false;
            string query = @"SELECT UserID, PersonID, IsActive FROM Users
                             WHERE UserName = @UserName AND Password = @Password";

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);
            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    IsActive = (bool)reader["IsActive"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
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

            return isFound;
        }

    }
}
