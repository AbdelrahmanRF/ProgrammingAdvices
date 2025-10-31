using ContactsDataAccessLayer;
using System;
using System.Data;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode { AddNew = 0, Update = 1 }

        public enMode Mode = enMode.AddNew;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }

        public clsContact() 
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.ImagePath = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;

            Mode = enMode.AddNew;
        }
        private clsContact(int ID, string FirstName, string LastName, string Email, string Phone, string Address,
            string ImagePath, DateTime DateOfBirth, int CountryID)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;

            Mode = enMode.Update;
        }
        
        private bool _AddNewContact()
        {
            this.ID = clsContactDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.ImagePath, this.DateOfBirth, this.CountryID);

            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return clsContactDataAccess.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.ImagePath, this.DateOfBirth, this.CountryID);
        }
        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (clsContactDataAccess.GetContactInfoByID(ID, ref FirstName, ref LastName, ref Email, ref Phone, ref Address,
                ref ImagePath, ref DateOfBirth, ref CountryID))
            {
                return new clsContact(ID, FirstName, LastName, Email, Phone, Address,
                ImagePath, DateOfBirth, CountryID);
            }

            return null;
        }

        public static DataTable GetAllContacts()
        {
            return clsContactDataAccess.GetAllContacts();
        }

        public static bool DeleteContact(int ID)
        {
            return clsContactDataAccess.DeleteContact(ID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateContact();

            }
            return false;
        }

        public static bool isContactExist(int ID)
        {
            return clsContactDataAccess.IsContactExist(ID);
        }
    }
}
