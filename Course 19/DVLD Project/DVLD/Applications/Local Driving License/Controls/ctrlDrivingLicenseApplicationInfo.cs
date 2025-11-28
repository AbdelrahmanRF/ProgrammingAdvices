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
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void FillDrivingApplicationData(int LDLApplicationID, int ApplicationID)
        {
            ctrlApplicationBasicInfo1.FillApplicationData(ApplicationID);
            _LDLApp = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLApplicationID);
            bool hasActiveLicense = clsLicense.IsLicenseExistByPersonID(_LDLApp.ApplicantPersonID, _LDLApp.LicenseClassID);

            lblID.Text = _LDLApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _LDLApp.LicenseClassInfo.ClassName;
            lblPassedTests.Text = $"{clsTest.GetPassedTestCount(LDLApplicationID)}/3";

            linkViewLicenseInfo.Enabled = hasActiveLicense;
            pbLicenseInfoFormIcon.Enabled = hasActiveLicense;
        }

        private void linkViewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int LicenseID = _LDLApp.GetActiveLicenseID();

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }
    }
}
