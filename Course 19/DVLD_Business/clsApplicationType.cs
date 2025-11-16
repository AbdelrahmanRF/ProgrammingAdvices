using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int ApplicationTypeID {  get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationTypeFees { get; set; }

        clsApplicationType()
        {
            _Mode = enMode.AddNew;

            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationTypeFees = 0;
        }

        public clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationTypeFees)
        {
            _Mode = enMode.Update;

            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;
        }

        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {
            string ApplicationTypeTitle = "";
            float ApplicationTypeFees = 0;

            if (clsApplicationTypeData.GetApplicationTypeByID(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFees))
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);

            return null;
        }

        private bool _UpdateApplicationType()
        {
            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle,
                this.ApplicationTypeFees);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.Update:
                        return _UpdateApplicationType();
            }

            return false;
        }
    }
}
