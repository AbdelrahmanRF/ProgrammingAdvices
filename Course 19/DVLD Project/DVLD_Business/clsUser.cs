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

            if (clsUserData.GetUserByUsernameAndPassword(username, clsHash.ComputeHash(password), ref userID, ref personID, ref isActive))
                return new clsUser(userID, personID, username, password, isActive);

            return null;
        }

        public static clsUser FindUserByUserID(int userID)
        {
            int personID = -1;
            string username = "", password = "";
            bool isActive = false;

            if (clsUserData.GetUserByUserID(userID, ref personID, ref username, ref password, ref isActive))
                return new clsUser(userID, personID, username, password, isActive);

            return null;
        }

        public static bool isUserExistByUserName(string username)
        {
            return clsUserData.isUserExistByUserName(username);
        }

        public static bool isUserExistByPersonID(int personID)
        {
            return clsUserData.isUserExistByPersonID(personID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username, clsHash.ComputeHash(this.Password), this.isActive);

            return UserID != -1;
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username, clsHash.ComputeHash(this.Password), this.isActive);
        }

        public bool UpdatePassword()
        {
            return clsUserData.UpdatePassword(this.UserID, clsHash.ComputeHash(this.Password));
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }

                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        public static bool DeleteUser(int userID)
        {
            return clsUserData.DeleteUser(userID);
        }
    }
}
