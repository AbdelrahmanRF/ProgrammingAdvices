using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsLicense
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 };
        public enMode Mode = enMode.AddNew;
        public int LicenseID {  get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason = enIssueReason.FirstTime;
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }
        public bool IsDetained
        {
            get 
            { 
                return clsDetainedLicense.IsLicenseDetained(this.LicenseID); 
            }
        }
        public int CreatedByUserID;
        public clsLicenseClass LicenseClassInfo;
        public clsDriver DriveInfo;
        public clsDetainedLicense DetainedInfo { get; set; }
        public clsLicense()
        {
            Mode = enMode.AddNew;

            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClass = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = -1;
        }

        clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
            string Notes, float PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            Mode = enMode.Update;

            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;

            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClass);
            this.DriveInfo = clsDriver.FindByDriverID(this.DriverID);
            this.DetainedInfo = clsDetainedLicense.FindByLicenseID(this.LicenseID);
        }

        public static clsLicense FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            string Notes = "";
            float PaidFees = 0;
            bool IsActive = false;
            int IssueReason = 1;
            
            if (clsLicenseData.GetLicenseInfoByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID))
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, 
                    Notes, PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);
            }

            return null;
        }

        public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1;
        }

        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicenseData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }

        public static DataTable GetAllDriverLicenses(int DriverID)
        {
            return clsLicenseData.GetAllDriverLicenses(DriverID);
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.ReplacementForDamaged:
                    return "Replacement for Damaged";
                case enIssueReason.ReplacementForLost:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);

            return (this.LicenseID != -1);
        }

        private bool _UpdateLicense()
        {
            return clsLicenseData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass,
               this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
               this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateLicense();
            }

            return false;
        }

        public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }

        public clsLicense Renew(string Notes, int CreatedByUserID)
        {
            clsApplication RenewApplication = new clsApplication();

            RenewApplication.ApplicantPersonID = this.DriveInfo.PersonID;
            RenewApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicenseService;
            RenewApplication.PaidFees = clsApplicationType.Find(RenewApplication.ApplicationTypeID).ApplicationTypeFees;
            RenewApplication.CreatedByUserID = CreatedByUserID;

            if (!RenewApplication.Save())
                return null;

            clsLicense RenewedLicense = new clsLicense();

            RenewedLicense.ApplicationID = RenewApplication.ApplicationID;
            RenewedLicense.DriverID = this.DriverID;
            RenewedLicense.LicenseClass = this.LicenseClass;
            RenewedLicense.IssueDate = DateTime.Now;
            RenewedLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassInfo.DefaultValidityLength);
            RenewedLicense.Notes = Notes;
            RenewedLicense.PaidFees = this.PaidFees;
            RenewedLicense.IsActive = true;
            RenewedLicense.IssueReason = enIssueReason.Renew;
            RenewedLicense.CreatedByUserID = CreatedByUserID;

            if (!RenewedLicense.Save())
                return null;

            this.IsActive = false;
            this.Save();

            return RenewedLicense;
        }
    }
}
