using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsApplication;

namespace DVLD.Tests.Controls
{
    public partial class crlScheduleTest : UserControl
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;

        enum enCreationMode { FirstTimeScheduleIe = 0, RetakeTestSchedule = 1 }
        enCreationMode _CreationMode = enCreationMode.FirstTimeScheduleIe;

        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        clsLocalDrivingLicenseApplication _LDLApplication;
        int _LDLApplicationID = -1;
        clsTestAppointment _TestAppointment;
        int _TestAppointmentID = -1;

        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        pbTestTypeImage.Image = Resources.Vision_512;
                        gbTestType.Text = "Vision Test";
                    break;

                    case clsTestType.enTestType.WrittenTest:
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        gbTestType.Text = "Written Test";
                    break;

                    case clsTestType.enTestType.StreetTest:
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        gbTestType.Text = "Street Test";
                    break;
                }
            }
        }
        public crlScheduleTest()
        {
            InitializeComponent();
        }
        private bool _LoadTestAppointmentData()
        {
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                btnSave.Enabled = false;
                MessageBox.Show($"No Appointment with ID = {_TestAppointmentID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (DateTime.Compare(DateTime.Now, _TestAppointment.AppointmentDate) < 0)
                dtpTestDate.MinDate = DateTime.Now;
            else
                dtpTestDate.MinDate = _TestAppointment.AppointmentDate;

            if (_TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                lblRetakeAppFees.Text = _TestAppointment.RetakeTestApplicationInfo.PaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lblTitle.Text = "Schedule Retake Test";
                lblRetakeTestAppID.Text = _TestAppointment.RetakeTestApplicationInfo.ApplicationID.ToString();
            }

            dtpTestDate.Value = _TestAppointment.AppointmentDate;
            lblRetakeAppFees.Text = _TestAppointment.PaidFees.ToString();

            return true;
        }

        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication
                .IsThereAnActiveScheduledTest(_LDLApplicationID, _TestTypeID))
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment locked.";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }
        private bool _HandleAppointmentLockedConstraint()
        {
            if (_TestAppointment.IsLocked)
            {
                lblUserMessage.Visible = true;
                lblUserMessage.Text = "Person already sat for the test, appointment locked.";
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }
        private bool _HandlePreviousTestConstraint()
        {
            Dictionary<clsTestType.enTestType, bool> CurrentTestStatuses = clsLocalDrivingLicenseApplication
                .GetAllTestStatuses(_LDLApplicationID);

            if (!Util.DoesPassPrevTestType(CurrentTestStatuses, _TestTypeID))
            {
                lblUserMessage.Text = "Cannot Schedule, Previous Test should be passed first";
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
                return false;
            }

            return true;
        }
        private bool _HandelRetakeApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication RetakeTestApplication = new clsApplication();
                RetakeTestApplication.ApplicantPersonID = _LDLApplication.ApplicantPersonID;
                RetakeTestApplication.ApplicationTypeID = (int)enApplicationType.RetakeTest;
                RetakeTestApplication.ApplicationDate = DateTime.Now;
                RetakeTestApplication.ApplicationStatus = enApplicationStatus.Completed;
                RetakeTestApplication.LastStatusDate = DateTime.Now;
                RetakeTestApplication.PaidFees = Convert.ToSingle(lblRetakeAppFees.Text);
                RetakeTestApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!RetakeTestApplication.Save())
                {
                    MessageBox.Show("Failed to Create Application", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                _TestAppointment.RetakeTestApplicationID = RetakeTestApplication.ApplicationID;
                lblRetakeTestAppID.Text = RetakeTestApplication.ApplicationID.ToString();
            }

            return true;
        }

        public void FillTestInfo(int LDLApplicationID, int TestAppointmentID = -1)
        {
            if (TestAppointmentID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }

            _LDLApplicationID = LDLApplicationID;
            _TestAppointmentID = TestAppointmentID;

            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLApplicationID);
            if (_LDLApplication == null)
            {
                btnSave.Enabled = false;
                MessageBox.Show($"No Local Driving License Application with ID = {LDLApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_LDLApplication.DoesAttendTestType(_TestTypeID))
                _CreationMode = enCreationMode.RetakeTestSchedule;
            else
                _CreationMode = enCreationMode.FirstTimeScheduleIe;

            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
                lblRetakeAppFees.Text = clsApplicationType.Find((int)enApplicationType.RetakeTest)
                    .ApplicationTypeFees.ToString();
                lblRetakeTestAppID.Text = "0";
            }
            else
            {
                lblTitle.Text = "Schedule Test";
                gbRetakeTestInfo.Enabled = false;
                lblRetakeAppFees.Text = "0";
                lblRetakeTestAppID.Text = "N/A";
            }

            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LDLApplication.FullName;
            lblTrial.Text = _LDLApplication.TotalTrialsPerTest(TestTypeID).ToString();

            if (_Mode == enMode.AddNew)
            {
                _TestAppointment = new clsTestAppointment();
                dtpTestDate.MinDate = DateTime.Now;
                lblFees.Text = clsTestType.Find(TestTypeID).Fees.ToString();
                lblRetakeTestAppID.Text = "N/A";
            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }

            lblTotalFees.Text = $"{Convert.ToSingle(lblRetakeAppFees.Text) + Convert.ToSingle(lblFees.Text)}";

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePreviousTestConstraint())
                return;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandelRetakeApplication())
                return;

            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Error: Data is not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
