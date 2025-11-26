using DVLD_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode { get; set; }
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public clsTest()
        {
            Mode = enMode.AddNew;

            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;
        }

        clsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            Mode = enMode.Update;

            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            this.TestAppointmentInfo = clsTestAppointment.Find(this.TestAppointmentID);
        }

        public static byte GetPassedTestCount(int LDLApplicationID)
        {
            return clsTestData.GetPassedTestCount(LDLApplicationID);
        }
        public static bool PassedAllTests(int LDLApplicationID)
        {
            return GetPassedTestCount(LDLApplicationID) == 3;
        }

        public static clsTest Find(int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            if (clsTestData.GetTestInfoByID(TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);

            return null;
        }

        private bool _AddNewTest()
        {
            this.TestID = clsTestData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);

            return this.TestID != -1;
        }

        private bool _UpdateTest()
        {
            return clsTestData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, 
                this.CreatedByUserID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTest())
                    {
                        this.Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateTest();
            }


            return false;
        }

    }
}
