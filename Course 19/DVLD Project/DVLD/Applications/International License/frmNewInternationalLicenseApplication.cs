using DVLD.Global_Classes;
using DVLD.License;
using DVLD.License.International_Licenses;
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

namespace DVLD.Applications.International_License
{
    public partial class frmNewInternationalLicenseApplication : Form
    {
        clsInternationalLicense _InternationalLicense;
        clsLicense _LocalLicense;
        public frmNewInternationalLicenseApplication()
        {
            InitializeComponent();

            _InternationalLicense = new clsInternationalLicense();
        }

        private bool _CheckLicenseValidity()
        {
            if (clsInternationalLicense.FindActiveInternationalLicenseIDByLocalLicenseID(_LocalLicense.LicenseID) != -1)
            {
                MessageBox.Show("Person already has an active international license", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_LocalLicense.LicenseClass != 3)
            {
                MessageBox.Show("License Class Must be Class 3 — Ordinary driving license", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_LocalLicense.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("License must not be Expired", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!_LocalLicense.IsActive)
            {
                MessageBox.Show("License must be Active", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblIssueDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewInternationalLicense)
                .ApplicationTypeFees.ToString();

            lblExpirationDate.Text = clsFormat.DateToShort(DateTime.Now.AddYears(1));
            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
        }

        private void ctrlDriverInternationalLicenseInfoWithFilter1_OnSearchEnded(int LocalLicenseID)
        {
            btnIssue.Enabled = false;
            linkShowLicenseHistory.Enabled = false;
            _LocalLicense = null;
            lblLocalLicenseID.Text = "???";

            if (LocalLicenseID == -1)
            {
                return;
            }

            _LocalLicense = ctrlDriverInternationalLicenseInfoWithFilter1.SelectedLicense;
            linkShowLicenseHistory.Enabled = true;

            if (!_CheckLicenseValidity())
                return;

            lblLocalLicenseID.Text = LocalLicenseID.ToString();
            btnIssue.Enabled = true;
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_LocalLicense.DriveInfo.PersonID);
            frm.ShowDialog();
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _InternationalLicense.ApplicantPersonID = _LocalLicense.DriveInfo.PersonID;
            _InternationalLicense.PaidFees = Convert.ToSingle(lblFees.Text);
            _InternationalLicense.DriverID = _LocalLicense.DriverID;
            _InternationalLicense.IssuedUsingLocalLicenseID = _LocalLicense.LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _InternationalLicense.ApplicationStatus = clsApplication.enApplicationStatus.Completed;

            if (MessageBox.Show("Are you Sure you Want to Issue the License?", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_InternationalLicense.Save())
                {
                    MessageBox.Show($"International License Issued Successfully with ID = {_InternationalLicense.InternationalLicenseID}",
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnIssue.Enabled = false;
                    ctrlDriverInternationalLicenseInfoWithFilter1.FilterEnabled = false;
                    linkShowLicenseInfo.Enabled = true;

                    lblIntApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                    lblIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                }
            }
        }

    }
}
