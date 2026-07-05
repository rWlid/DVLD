using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD.DAL
{
    public class clsPersonDataAccess
    {

        public static DataTable GetAllPeople() 
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT CAST(People.PersonID AS NVARCHAR(20)) AS PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, CASE People.Gendor WHEN 0 THEN 'Male' WHEN 1 THEN 'Female' END AS Gender, People.Phone, People.Email, Countries.CountryName AS Nationality FROM Countries INNER JOIN People ON Countries.CountryID = People.NationalityCountryID";

            SqlCommand command = new SqlCommand(query, connection);

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
    }
}
