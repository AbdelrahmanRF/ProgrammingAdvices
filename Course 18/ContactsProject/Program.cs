using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsProject
{
    internal class Program
    {
        static void testFindContact(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if (Contact == null)
            {
                Console.WriteLine($"Contact [{ID}] not found!");
            }
            else
            {
                Console.WriteLine(Contact.FirstName + " " + Contact.LastName);
                Console.WriteLine(Contact.Email);
                Console.WriteLine(Contact.Phone);
                Console.WriteLine(Contact.Address);
                Console.WriteLine(Contact.CountryID);
                Console.WriteLine(Contact.ImagePath);
            }
        }
        static void testAddNewContact()
        {
            clsContact Contact = new clsContact();

            Contact.FirstName = "Ahmad";
            Contact.LastName = "Fadi";
            Contact.Email = "a.f@gmail.com";
            Contact.Phone = "070707070";
            Contact.DateOfBirth = new DateTime(1970, 12, 4, 10, 30, 0);
            Contact.Address = "adress1";
            Contact.CountryID = 1;
            Contact.ImagePath = "";

            if(Contact.Save())
            {
                Console.WriteLine($"Contact Added Successfully With ID = {Contact.ID}");
            }
            
        }
        static void testUpdateContact(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            Contact.FirstName = "Mohammad";
            Contact.LastName = "Qasem";
            Contact.Email = "m.q@gmail.com";
            Contact.Phone = "790790900";
            Contact.DateOfBirth = new DateTime(1977, 06, 11, 01, 25, 0);
            Contact.Address = "adress2";
            Contact.CountryID = 1;
            Contact.ImagePath = "";

            if (Contact.Save())
            {
                Console.WriteLine("Contact Updated Successfully");
            }
            
        }
        static void testDeleteContact(int ID)
        {
            if (clsContact.DeleteContact(ID))
            {
                Console.WriteLine("Contact Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Failed to Delete Contact");
            }
        }
        static void testListContacts()
        {
            DataTable dataTable = new DataTable();

            dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contact Details:");
            foreach(DataRow Row in dataTable.Rows)
            {
                Console.WriteLine($"{Row["ContactID"]}, {Row["FirstName"]} {Row["LastName"]}");
            }
        }
        static void testIsContactExist(int ID)
        {
            if(clsContact.isContactExist(ID))
                Console.WriteLine("Yes, Contact Exist");
            else
                Console.WriteLine("No Contact Does\'t Exist");
        }

        static void testFindCountryByID(int ID)
        {
            clsCountry Country = clsCountry.FindByID(ID);

            if (Country == null)
            {
                Console.WriteLine($"Country [{ID}] not found!");
            }
            else
            {
                Console.WriteLine($"{Country.CountryID} {Country.CountryName} {Country.Code} {Country.PhoneCode}");
            }
        }
        static void testFindCountryByName(string CountryName)
        {
            clsCountry Country = clsCountry.FindByName(CountryName);

            if (Country == null)
            {
                Console.WriteLine($"Country [{CountryName}] not found!");
            }
            else
            {
                Console.WriteLine($"{Country.CountryID} {Country.CountryName} {Country.Code} {Country.PhoneCode}");
            }
        }
        static void testAddNewCountry()
        {
            clsCountry Country = new clsCountry();

            Country.CountryName = "China";
            Country.Code = "CN";
            Country.PhoneCode = "86";

            if (Country.Save())
            {
                Console.WriteLine($"Country Added Successfully With ID = {Country.CountryID}");
            }
        }
        static void testUpdateCountry(int ID)
        {
            clsCountry Country = clsCountry.FindByID(ID);

            Country.CountryName = "Jordan";
            Country.Code = "JOR";
            Country.PhoneCode = "962";

            if (Country.Save())
            {
                Console.WriteLine("Country Updated Successfully");
            }
        }
        static void testDeleteCountry(int ID)
        {
            if (clsCountry.DeleteCountry(ID))
            {
                Console.WriteLine("Country Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Failed to Delete Country");
            }
        }
        static void testListCountries()
        {
            DataTable dataTable = new DataTable();

            dataTable = clsCountry.GetAllCountries();

            Console.WriteLine("Countries List:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]} {row["CountryName"]} {row["Code"]} {row["PhoneCode"]}");
            }
        }
        static void testIsCountryExistByID(int ID)
        {
            if (clsCountry.isCountryExistByID(ID))
                Console.WriteLine("Yes, Country Exist");
            else
                Console.WriteLine("No Country Does\'t Exist");
        }
        static void testIsCountryExistByName(string CountryName)
        {
            if (clsCountry.isCountryExistByName(CountryName))
                Console.WriteLine("Yes, Country Exist");
            else
                Console.WriteLine("No Country Does\'t Exist");
        }
        static void Main(string[] _)
        {
            //testFindContact(1);
            //testAddNewContact();
            //testUpdateContact(2);
            //testDeleteContact(2);
            //testListContacts();
            //testIsContactExist(1);
            //testIsContactExist(17);

            //testFindCountryByID(6);
            //testFindCountryByName("Jordan");
            testAddNewCountry();
            //testUpdateCountry(6);
            //testDeleteCountry(1);
            //testDeleteCountry(9);
            //testListCountries();
            //testIsCountryExistByID(1);
            //testIsCountryExistByName("Jordan");
        }
    }
}
