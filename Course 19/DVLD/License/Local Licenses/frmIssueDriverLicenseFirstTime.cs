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

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            _LDLApplicationID = LDLApplicationID;

            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLApplicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmIssueDriverLicenseFirstTime_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1
                .FillDrivingApplicationData(_LDLApplicationID, _LDLApplication.ApplicationID);
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsDriver Driver = clsDriver.FindByPersonID(_LDLApplication.ApplicantPersonID);

            if (Driver == null)
            {
                Driver = new clsDriver();
                Driver.PersonID = _LDLApplication.ApplicantPersonID;
                Driver.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Driver.Save())
                {
                    MessageBox.Show("Failed to Create Driver Record.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            clsLicense License = new clsLicense();

            License.ApplicationID = _LDLApplication.ApplicationID;
            License.DriverID = Driver.DriverID;
            License.LicenseClass = _LDLApplication.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = License.IssueDate.AddYears(_LDLApplication.LicenseClassInfo.DefaultValidityLength);
            License.Notes = txtNotes.Text;
            License.PaidFees = _LDLApplication.LicenseClassInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (License.Save())
            {
                LicenseCreated?.Invoke(this, License.LicenseID);

                if (MessageBox.Show($"License issued successfully with ID = {License.LicenseID}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Failed to issue license.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
