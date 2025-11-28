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

namespace DVLD.Applications.Replace_for_Lost_or_Damaged_License
{
    public partial class frmReplaceLostOrDamagedLicenseApplication : Form
    {
        clsLicense _OldLicense;
        clsLicense _ReplacedLicense;
        clsLicense.enIssueReason _IssueReason;
        clsApplication.enApplicationType _ApplicationType;
        public frmReplaceLostOrDamagedLicenseApplication()
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

        }

        private void _UpdateFormApplicationType()
        {
            string IssueReasonText;
            if (rbDamaged.Checked == true)
            {
                _IssueReason = clsLicense.enIssueReason.ReplacementForDamaged;
                _ApplicationType = clsApplication.enApplicationType.ReplacementForADamagedDrivingLicense;
            }
            else
            {
                _IssueReason = clsLicense.enIssueReason.ReplacementForLost;
                _ApplicationType = clsApplication.enApplicationType.ReplacementForLostDrivingLicense;
            }

            IssueReasonText = clsLicense.GetIssueReasonText(_IssueReason);

            this.Text = $"{IssueReasonText} License";
            lblReplacementFor.Text = $"{IssueReasonText} License";

            lblApplicationFees.Text = clsApplicationType.Find((int)_ApplicationType).ApplicationTypeFees.ToString();

        }
        private void frmReplaceLostOrDamagedLicenseApplication_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = clsFormat.DateToShort(DateTime.Now);
            _UpdateFormApplicationType();
            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            _UpdateFormApplicationType();
        }

        private void ctrlDriverInternationalLicenseInfoWithFilter1_SearchEnded(object sender, int LocalLicenseID)
        {
            btnIssue.Enabled = false;
            linkShowLicenseHistory.Enabled = false;
            _OldLicense = null;
            lblOldLicenseID.Text = "???";

            if (LocalLicenseID == -1)
            {
                return;
            }

            _OldLicense = clsLicense.FindByLicenseID(LocalLicenseID);
            linkShowLicenseHistory.Enabled = true;

            if (!_OldLicense.IsActive)
            {
                MessageBox.Show("License must be Active to be Replaced", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblOldLicenseID.Text = LocalLicenseID.ToString();
            btnIssue.Enabled = true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you Want to Replace this License?", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                _ReplacedLicense = _OldLicense.Replace(_IssueReason, _ApplicationType, clsGlobal.CurrentUser.UserID);
                if (_ReplacedLicense != null)
                {
                    MessageBox.Show($"Licensed Replaced Successfully with ID = {_ReplacedLicense.LicenseID}",
                        "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnIssue.Enabled = false;
                    ctrlDriverInternationalLicenseInfoWithFilter1.DisableSearch();
                    linkShowNewLicenseInfo.Enabled = true;

                    lblReplaceLicenseApplicationID.Text = _ReplacedLicense.ApplicationID.ToString();
                    lblReplacedLicenseID.Text = _ReplacedLicense.LicenseID.ToString();
                }
            }
        }

        private void linkShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_ReplacedLicense.LicenseID);
            frm.ShowDialog();
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_OldLicense.DriveInfo.PersonID);
            frm.ShowDialog();
        }
    }
}
