using DVLD.Global_Classes;
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

namespace DVLD.License.Local_Licenses
{
    public partial class frmIssueDriverLicenseFirstTime : Form
    {
        int _LDLApplicationID;
        clsLocalDrivingLicenseApplication _LDLApplication;

        public delegate void LicenseCreatedEventHandler(object sender, int NewLicenseID);
        public event LicenseCreatedEventHandler LicenseCreated;
        public frmIssueDriverLicenseFirstTime(int LDLApplicationID)
        {
            InitializeComponent();

            this._LDLApplicationID = LDLApplicationID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(_LDLApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show($"Error: No Local Driving License Application with ID = {_LDLApplicationID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (!clsTest.PassedAllTests(_LDLApplicationID))
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = _LDLApplication.GetActiveLicenseID();
            if (LicenseID != -1)
            {
                MessageBox.Show($"Person Already has License Before with License ID = {LicenseID}", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlDrivingLicenseApplicationInfo1.FillDrivingApplicationData(_LDLApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int LicenseID = _LDLApplication.IssueLicenseForTheFirstTime(txtNotes.Text.Trim(), clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LicenseCreated?.Invoke(this, LicenseID);
                this.Close();
            }
            else
            {
                MessageBox.Show("License Was not Issued !",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
