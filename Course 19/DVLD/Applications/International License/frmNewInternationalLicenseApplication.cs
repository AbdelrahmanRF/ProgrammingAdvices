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

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            _InternationalLicense = new clsInternationalLicense();
        }

        private bool _CheckLicenseValidity()
        {
            string ErrorMessage = "";
            int ActiveInternationalLicenseID = clsInternationalLicense
                .FindActiveInternationalLicenseIDByLocalLicenseID(_LocalLicense.LicenseID);

            if (ActiveInternationalLicenseID != -1)
                ErrorMessage = $"Person already have an active international license with ID {ActiveInternationalLicenseID}";

            if (_LocalLicense.LicenseClass != 3)
                ErrorMessage = "License Class Must be Class 3 — Ordinary driving license";

            if (_LocalLicense.ExpirationDate < DateTime.Now)
                ErrorMessage = "License must not be Expired";

            if (!_LocalLicense.IsActive)
                ErrorMessage = "License must be Active";

            if (ErrorMessage == "")
                return true;
            else
            {
                MessageBox.Show(ErrorMessage, "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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

        private void ctrlDriverInternationalLicenseInfoWithFilter1_SearchEnded(object sender, int LocalLicenseID)
        {
            if (LocalLicenseID == -1)
            {
                linkShowLicenseHistory.Enabled = false;
                _LocalLicense = null;
                return;
            }

            _LocalLicense = clsLicense.FindByLicenseID(LocalLicenseID);
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

            if (MessageBox.Show("Are you Sure you Want to Issue the License?", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_InternationalLicense.Save())
                {
                    MessageBox.Show($"International License Issued Successfully with ID = {_InternationalLicense.InternationalLicenseID}",
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnIssue.Enabled = false;
                    ctrlDriverInternationalLicenseInfoWithFilter1.DisableSearch();
                    linkShowLicenseInfo.Enabled = true;

                    lblIntApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
                    lblIntLicenseID.Text = _InternationalLicense.InternationalLicenseID.ToString();
                }
            }
        }
    }
}
