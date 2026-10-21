using System;
using System.Data.SqlClient;

namespace DVLD.DAL
{
    public static class LicenseClassData
    {
        public static bool GetLicenseClassInfo(int LicenseClassID, ref string ClassName, ref string ClassDescription,
            ref int MinimumAllowedAge, ref int DefaultValidityLength, ref decimal ClassFees)
        {
            bool isFound = false;

            var connection = new SqlConnection(DataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = Convert.ToInt32(reader["MinimumAllowedAge"]);
                    DefaultValidityLength = Convert.ToInt32(reader["DefaultValidityLength"]);
                    ClassFees = (decimal)reader["ClassFees"];
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
    }
}
