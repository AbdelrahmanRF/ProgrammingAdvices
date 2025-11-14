using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode  = enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }

        public clsUser()
        {
            _Mode = enMode.AddNew;

            this.UserID = -1;
            this.PersonID = -1;
            this.Username = "";
            this.Password = "";
            isActive = false;
        }

        clsUser(int UserID, int PersonID, string Username, string Password, bool isActive)
        {
            _Mode = enMode.Update;

            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.isActive = isActive;
        }

        public static clsUser FindUserByUsernameAndPassword(string username, string password)
        {
            int userID = -1, personID = -1;
            bool isActive = false;

            if (clsUserData.GetUserByUsernameAndPassword(username, password, ref userID, ref personID, ref isActive))
                return new clsUser(userID, personID, username, password, isActive);

            return null;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
    }
}
