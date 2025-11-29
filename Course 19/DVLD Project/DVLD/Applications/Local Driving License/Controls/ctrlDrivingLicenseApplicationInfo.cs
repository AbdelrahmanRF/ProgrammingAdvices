using DVLD.License.Local_Licenses;
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

namespace DVLD.Applications.Local_Driving_License.Controls
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        clsLocalDrivingLicenseApplication _LDLApp;
        int _LDLApplicationID = -1;
        int _LicenseID = -1;

        public int LDLApplicationID
        {
            get {  return _LDLApplicationID; }
        }

        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void _ResetLocalDrivingLicenseApplicationInfo()
        {
            _LDLApplicationID = -1;
            ctrlApplicationBasicInfo1.ResetApplicationInfo();
            lblID.Text = "???";
            lblLicenseClass.Text = "???";
        }

        private void _LoadDrivingApplicationDataToControl()
        {
            _LDLApplicationID = _LDLApp.LocalDrivingLicenseApplicationID;

            ctrlApplicationBasicInfo1.FillApplicationData(_LDLApp.ApplicationID);
            _LicenseID = _LDLApp.GetActiveLicenseID();
            bool hasActiveLicense = clsLicense.IsLicenseExistByPersonID(_LDLApp.ApplicantPersonID, _LDLApp.LicenseClassID);

            lblID.Text = _LDLApplicationID.ToString();
            lblLicenseClass.Text = _LDLApp.LicenseClassInfo.ClassName;
            lblPassedTests.Text = $"{clsTest.GetPassedTestCount(_LDLApplicationID)}/3";

            linkViewLicenseInfo.Enabled = hasActiveLicense;
            pbLicenseInfoFormIcon.Enabled = hasActiveLicense;
        }

        public void FillDrivingApplicationData(int LDLApplicationID)
        {
            _LDLApp = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLApplicationID);

            if (_LDLApp == null)
            {
                _ResetLocalDrivingLicenseApplicationInfo();
                MessageBox.Show($"No Application with ApplicationID = {LDLApplicationID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadDrivingApplicationDataToControl();
        }

        private void linkViewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
    }
}
