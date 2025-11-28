using DVLD.Global_Classes;
using DVLD.License;
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

namespace DVLD.Applications.Renew_Local_License
{
    public partial class frmRenewLocalDrivingLicenseApplication : Form
    {
        clsLicense _OldLicense;
        clsLicense _RenewedLicense;
        clsApplication _RenewApplication;
        public frmRenewLocalDrivingLicenseApplication()
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            _RenewedLicense = new clsLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.RenewDrivingLicenseService)
                .ApplicationTypeFees.ToString();

            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
        }

        private void ctrlDriverInternationalLicenseInfoWithFilter1_SearchEnded(object sender, int LocalLicenseID)
        {
            if (LocalLicenseID == -1)
            {
                linkShowLicenseHistory.Enabled = false;
                _OldLicense = null;
                return;
            }

            _OldLicense = clsLicense.FindByLicenseID(LocalLicenseID);
            linkShowLicenseHistory.Enabled = true;

            if (!_OldLicense.IsLicenseExpired())
            {
                MessageBox.Show($"Selected License is not yet expired, it will Expire on: {_OldLicense.ExpirationDate.ToString("dd/MM/yyyy")}", 
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_OldLicense.IsActive)
            {
                MessageBox.Show("License must be Active to be Renewed", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblOldLicenseID.Text = LocalLicenseID.ToString();
            lblLicenseFees.Text = _OldLicense.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text = $"{int.Parse(lblLicenseFees.Text) + int.Parse(lblApplicationFees.Text)}";
            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(_OldLicense.LicenseClassInfo.DefaultValidityLength));
            btnRenew.Enabled = true;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you Want to Renew this License?", "Confirm", MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Question) == DialogResult.OK)
            {
                _RenewedLicense = _OldLicense.Renew(txtNotes.Text, clsGlobal.CurrentUser.UserID);
                if (_RenewedLicense != null)
                {
                    MessageBox.Show($"Licensed Renewed Successfully with ID = {_RenewedLicense.LicenseID}",
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnRenew.Enabled = false;
                    ctrlDriverInternationalLicenseInfoWithFilter1.DisableSearch();
                    linkShowNewLicenseInfo.Enabled = true;

                    lblReLApplicationID.Text = _RenewedLicense.ApplicationID.ToString();
                    lblReLicenseID.Text = _RenewedLicense.LicenseID.ToString();
                }
            }
            


        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_OldLicense.DriveInfo.PersonID);
            frm.ShowDialog();
        }

        private void linkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_RenewedLicense.LicenseID);
            frm.ShowDialog();
        }
    }
}
