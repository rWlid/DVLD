using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD.DAL
{
    public static class TestTypeData
    {
        public static DataTable GetAllTestTypes()
        {
            var dt = new DataTable();
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT TestTypeID AS ID, 
                                    TestTypeTitle AS Title, 
                                    TestTypeDescription AS Description,
                                    TestTypeFees AS Fees
                             FROM TestTypes";

            var command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }

            return dt;
        }
        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }
        public static bool UpdateTestType(int ID, string Title, string Description, decimal Fees)
        {
            int rowsAffected = 0;
            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"UPDATE TestTypes 
                             SET         TestTypeTitle = @Title,
                                   TestTypeDescription = @Description,
                                          TestTypeFees = @Fees
                             WHERE          TestTypeID = @ID";

            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally { connection.Close(); }

            return (rowsAffected > 0);
        }
        public static bool GetTestTypeByID(int ID, ref string Title, ref string Description, ref decimal Fees)
        {
            bool isFound = false;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT TestTypeTitle, TestTypeDescription, TestTypeFees FROM TestTypes
                              WHERE TestTypeID = @TestTypeID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = (decimal)reader["TestTypeFees"];

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
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
