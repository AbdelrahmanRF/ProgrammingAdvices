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
                return base.PersonInfo.FullName;
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

            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
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

        public static bool DeleteLDLApplication(int LDLApplicationID)
        {
            int ApplicationID = FindByLDLApplicationID(LDLApplicationID).ApplicationID;

            return clsLocalDrivingLicenseApplicationData.DeleteLDLApplication(LDLApplicationID)
                 && clsApplication.DeleteApplication(ApplicationID);
        }

        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData
                .IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public bool IsThereAnActiveScheduledTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData
                .IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public byte TotalTrialsPerTest(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID,
                (int)TestTypeID);
        }

        public int GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }

        public bool DoesAttendTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesPassTestType(clsTestType.enTestType TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }

        public static Dictionary<clsTestType.enTestType, bool> GetAllTestStatuses(int LDLApplicationID)
        {
            var Results = clsLocalDrivingLicenseApplicationData.GetAllTestStatuses(LDLApplicationID);

            return Results.ToDictionary
                (
                    r => (clsTestType.enTestType)r.Key,
                    r => r.Value
                );
        }

        public clsTest GetLatestTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTest.FindLatestTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public int IssueLicenseForTheFirstTime(string Notes, int CreatedByUserID)
        {
            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (!Driver.Save())
                {
                    return -1;
                }
            }

            clsLicense License = new clsLicense();

            License.ApplicationID = this.ApplicationID;
            License.DriverID = Driver.DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = License.IssueDate.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;


            if (License.Save())
            {
                this.SetComplete();
                return License.LicenseID;
            }
                

            return -1;
        }
    }
}
