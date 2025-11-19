using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int LicenseClassID { set; get; }
        public clsLicenseClass LicenseClassInfo;
        public string FullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }
        }

        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            _Mode = enMode.AddNew;
        }

        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             float PaidFees, int CreatedByUserID, int LicenseClassID)
        {
            _Mode = enMode.Update;

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;

            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            this.CreatedByUserInfo = clsUser.FindUserByUserID(CreatedByUserID);
        }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }

        public static clsLocalDrivingLicenseApplication FindByLDLApplicationID(int LDLApplicationID)
        {
            int ApplicationID = -1, LicenseClassID = -1;

            bool isFound = clsLocalDrivingLicenseApplicationData.GetLDLApplicationInfoByID(LDLApplicationID,
                ref ApplicationID, ref LicenseClassID);

            if (!isFound)
                return null;

            clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

            return new clsLocalDrivingLicenseApplication(LDLApplicationID, Application.ApplicationID, Application.ApplicantPersonID,
                Application.ApplicationDate, Application.ApplicationTypeID, Application.ApplicationStatus, Application.LastStatusDate,
                Application.PaidFees, Application.CreatedByUserID, LicenseClassID);
        }

        private bool _AddNewLDLApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.
                AddNewLDLApplication(this.ApplicationID, this.LicenseClassID);

            return this.LocalDrivingLicenseApplicationID != -1;
        }

        private bool _UpdateLDLApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLDLApplication(this.LocalDrivingLicenseApplicationID, 
                this.ApplicationID, this.LicenseClassID);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;

            if (!base.Save()) 
                return false;

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLDLApplication())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateLDLApplication();
            }

            return false;
        }
    }
}
