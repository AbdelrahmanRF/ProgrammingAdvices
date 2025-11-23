using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestAppointmentID { get; set; }
        public clsTestType.enTestType TestTypeId { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int RetakeTestApplicationID { get; set; }
        public clsApplication RetakeTestApplicationInfo { get; set; }
        public int TestID
        {
            get { return _GetTestID(); }
        }

        public clsTestAppointment()
        {
            Mode = enMode.AddNew;

            this.TestAppointmentID = -1;
            this.TestTypeId = clsTestType.enTestType.VisionTest;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
        }

        clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID,
           int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, float PaidFees,
           int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            Mode = enMode.Update;
            
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeId = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.RetakeTestApplicationID = RetakeTestApplicationID;

            this.RetakeTestApplicationInfo = clsApplication.FindBaseApplication(this.RetakeTestApplicationID);
        }

        int _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(TestAppointmentID);
        }

        public static clsTestAppointment Find(int TestAppointmentID)
        {
            int CreatedByUserID = -1, RetakeTestApplicationID = -1, LocalDrivingLicenseApplicationID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;
            int TestTypeId = 1;

            if (clsTestAppointmentData.GetTestAppointmentData(TestAppointmentID, ref TestTypeId, 
                ref LocalDrivingLicenseApplicationID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID,
                ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeId, LocalDrivingLicenseApplicationID,
                     AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }

            return null;
        }

        public static clsTestAppointment GetLatestTestAppointment(int LocalDrivingLicenseApplicationID)
        {
            int CreatedByUserID = -1, RetakeTestApplicationID = -1, TestAppointmentID = -1, TestTypeID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;

            if (clsTestAppointmentData.GetLatestTestAppointment(LocalDrivingLicenseApplicationID, ref TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID,
                ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                     AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }

            return null;
        }

        public static clsTestAppointment GetLatestTestAppointment(int LocalDrivingLicenseApplicationID, 
            clsTestType.enTestType TestTypeID)
        {
            int CreatedByUserID = -1, RetakeTestApplicationID = -1, TestAppointmentID = -1;
            DateTime AppointmentDate = DateTime.Now;
            float PaidFees = 0;
            bool IsLocked = false;

            if (clsTestAppointmentData.GetLatestTestAppointment(LocalDrivingLicenseApplicationID, (int)TestTypeID,
                ref TestAppointmentID, ref AppointmentDate, ref PaidFees, ref CreatedByUserID,
                ref IsLocked, ref RetakeTestApplicationID))
            {
                return new clsTestAppointment(TestAppointmentID, (clsTestType.enTestType)TestTypeID, LocalDrivingLicenseApplicationID,
                     AppointmentDate, PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
            }

            return null;
        }
    }
}
