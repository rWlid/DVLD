using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD.DAL
{
    public class PeopleData
    {

        public static DataTable GetAllPeople() 
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ";
            return dt;
        }
    }
}
