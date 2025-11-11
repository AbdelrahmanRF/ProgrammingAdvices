using DVLD_DataAccess;
using System;
using System.Data;

namespace DVLD_Business
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        private clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";

            if (clsCountryDataAccess.Find(CountryID, ref CountryName))
                return new clsCountry(CountryID, CountryName);

            return null;
        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            if (clsCountryDataAccess.Find(CountryName, ref CountryID))
                return new clsCountry(CountryID, CountryName);

            return null;
        }
    }
}
