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
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        clsLocalDrivingLicenseApplication _LDLApplication;
        clsTestAppointment _TestAppointment;
        public crlScheduleTest()
        {
            InitializeComponent();
        }

        public void FillTestInfo(int LDLApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLApplicationID);
            _TestTypeID = TestTypeID;
            clsTestAppointment LatestTestAppointment = clsTestAppointment.GetLatestTestAppointment(LDLApplicationID, TestTypeID);

            if (TestAppointmentID != -1)
            {
                _Mode = enMode.Update;
                _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            }
            else
            {
                _Mode = enMode.AddNew;
                _TestAppointment = new clsTestAppointment();
            }

            if (TestTypeID == clsTestType.enTestType.VisionTest)
            {
                pbTestTypeImage.Image = Resources.Vision_512;
                gbTestType.Text = "Vision Test";
            }
            if (TestTypeID == clsTestType.enTestType.WrittenTest)
            {
                pbTestTypeImage.Image = Resources.Written_Test_512;
                gbTestType.Text = "Written Test";
            }
            else
            {
                gbTestType.Text = "Street Test";
            }

            if (_TestAppointment.RetakeTestApplicationID != -1 || (LatestTestAppointment != null && _Mode != enMode.Update))
            {
                lblTitle.Text = "Schedule Retake Test";
                gbRetakeTestInfo.Enabled = true;
                lblRetakeAppFees.Text = clsApplicationType.Find((int)enApplicationType.RetakeTest)
                .ApplicationTypeFees.ToString();
            }

            if (_TestAppointment.IsLocked == true)
            {
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                dtpTestDate.Enabled = false;
            }

            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LDLApplication.FullName;
            lblTrial.Text = _LDLApplication.TotalTrialsPerTest(TestTypeID).ToString();
            dtpTestDate.Value = _Mode == enMode.AddNew ? DateTime.Now : _TestAppointment.AppointmentDate;
            lblFees.Text = clsTestType.Find(TestTypeID).Fees.ToString();
            lblTotalFees.Text = $"{int.Parse(lblRetakeAppFees.Text) + int.Parse(lblFees.Text)}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestAppointment.TestTypeID = _TestTypeID;
            _TestAppointment.LocalDrivingLicenseApplicationID = _LDLApplication.LocalDrivingLicenseApplicationID;
            _TestAppointment.AppointmentDate = dtpTestDate.Value;
            _TestAppointment.PaidFees = Convert.ToSingle(lblTotalFees.Text);
            _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _TestAppointment.IsLocked = false;

            if (gbRetakeTestInfo.Enabled)
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
                    MessageBox.Show("Something Went Wrong", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _TestAppointment.RetakeTestApplicationID = RetakeTestApplication.ApplicationID;
                lblRetakeTestAppID.Text = RetakeTestApplication.ApplicationID.ToString();
            }

            if (_TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
