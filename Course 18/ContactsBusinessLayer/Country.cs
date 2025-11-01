using System;
using System.Data;
using ContactsDataAccessLayer;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string Code { get; set; }
        public string PhoneCode { get; set; }

        public clsCountry() 
        { 
            this.CountryID = -1;
            this.CountryName = "";
            this.Code = "";
            this.PhoneCode = "";

            Mode = enMode.AddNew;
        }

        private clsCountry(int CountryID, string CountryName, string Code, string PhoneCode)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            this.Code = Code;
            this.PhoneCode = PhoneCode;

            Mode = enMode.Update;
        }

        private bool _AddNewCountry()
        {
            this.CountryID = clsCountryDataAccess.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);

            return this.CountryID != -1;
        }

        private bool _UpdateCountry()
        {
            return clsCountryDataAccess.UpdateCountry(this.CountryID, this.CountryName, this.Code, this.PhoneCode);
        }

        public static clsCountry FindByID(int CountryID)
        {
            string CountryName = "", Code = "", PhoneCode = "";

            if (clsCountryDataAccess.FindCountryByID(CountryID, ref CountryName, ref Code, ref PhoneCode))
                return new clsCountry(CountryID, CountryName, Code, PhoneCode);

            return null;
        }
        public static clsCountry FindByName(string CountryName)
        {
            int CountryID = -1;
            string Code = "", PhoneCode = "";

            if (clsCountryDataAccess.FindCountryByName(CountryName, ref CountryID, ref Code, ref PhoneCode))
                return new clsCountry(CountryID, CountryName, Code, PhoneCode);

            return null;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateCountry();
            }

            return false;
        }

        public static bool DeleteCountry(int CountryID)
        {
            return clsCountryDataAccess.DeleteCountry(CountryID);
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }

        public static bool isCountryExistByID(int CountryID)
        {
            return clsCountryDataAccess.IsCountryExistByID(CountryID);
        }

        public static bool isCountryExistByName(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExistByName(CountryName);
        }
    }
}
