using System.Data;
using DVLD.DAL;


namespace DVLD.BL
{
    public class Country
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        private Country(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;

        }
        public static Country Find(int ID)
        {

            string CountryName = "";

            if (CountryData.GetCountryInfoByID(ID, ref CountryName))
            {
                return new Country(ID, CountryName);
            }
            else
            {
                return null;
            }
        }
        public static Country Find(string CountryName)
        {

            int ID = -1;

            if (CountryData.GetCountryInfoByName(CountryName, ref ID))
            {
                return new Country(ID, CountryName);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GetAllCountries()
        {
            return CountryData.GetAllCountries();

        }

    }
}
