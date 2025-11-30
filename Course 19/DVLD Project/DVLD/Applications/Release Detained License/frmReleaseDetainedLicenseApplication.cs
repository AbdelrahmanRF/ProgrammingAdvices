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
using static DVLD_Business.clsApplication;
using static DVLD_Business.clsLicense;

namespace DVLD.Applications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        clsLicense _CurrentLicense;
        clsDetainedLicense _DetainedLicenseInfo;
        int _LicenseID = -1;

        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
        }

        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();

            this._LicenseID = LicenseID;
        }

        private void frmReleaseDetainedLicenseApplication_Shown(object sender, EventArgs e)
        {
            if (_LicenseID == -1)
                return;

            ctrlDriverInternationalLicenseInfoWithFilter1.DisplayLicenseInfo(_LicenseID);
            ctrlDriverInternationalLicenseInfoWithFilter1.FilterEnabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ClearDetainInfo()
        {
            lblDetainID.Text = "???";
            lblLicenseID.Text = "???";
            lblDetainDate.Text = "??/??/????";
            lblCreatedBy.Text = "???";
            lblApplicationFees.Text = "$$$";
            lblFineFees.Text = "$$$";
            lblTotalFees.Text = "$$$";
            lblApplicationID.Text = "???";
        }

        private void _FillDetainInfo()
        {
            lblDetainID.Text = _DetainedLicenseInfo.DetainID.ToString();
            lblLicenseID.Text = _DetainedLicenseInfo.LicenseID.ToString();
            lblDetainDate.Text = clsFormat.DateToShort(_DetainedLicenseInfo.DetainDate);
            lblCreatedBy.Text = _DetainedLicenseInfo.CreatedByUserInfo.Username;
            lblApplicationFees.Text = clsApplicationType
                .Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense)
                .ApplicationTypeFees
                .ToString();
            lblFineFees.Text = _DetainedLicenseInfo.FineFees.ToString();
            lblTotalFees.Text = $"{float.Parse(lblApplicationFees.Text) + float.Parse(lblFineFees.Text)}";
        }

        private void ctrlDriverInternationalLicenseInfoWithFilter1_OnSearchEnded(int LocalLicenseID)
        {
            _ClearDetainInfo();
            btnRelease.Enabled = false;
            linkShowLicenseHistory.Enabled = false;
            _CurrentLicense = null;
            _DetainedLicenseInfo = null;
            lblLicenseID.Text = "???";

            if (LocalLicenseID == -1)
            {
                return;
            }

            _CurrentLicense = ctrlDriverInternationalLicenseInfoWithFilter1.SelectedLicense;
            linkShowLicenseHistory.Enabled = true;

            if (!_CurrentLicense.IsActive)
            {
                MessageBox.Show("License must be Active to be Released", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_CurrentLicense.IsDetained)
            {
                MessageBox.Show("Selected License is not Detained!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DetainedLicenseInfo = _CurrentLicense.DetainedInfo;
            _FillDetainInfo();
            btnRelease.Enabled = true;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure you Want to Release this License?", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                int ReleaseApplicationID = -1;
                bool isReleased = _CurrentLicense.Release(_DetainedLicenseInfo.CreatedByUserID, ref ReleaseApplicationID);

                if (isReleased)
                {
                    MessageBox.Show($"Detained License Released Successfully",
                        "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnRelease.Enabled = false;
                    ctrlDriverInternationalLicenseInfoWithFilter1.FilterEnabled = false;
                    linkShowLicenseInfo.Enabled = true;
                    lblApplicationID.Text = ReleaseApplicationID.ToString();
                }
            }
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_CurrentLicense.DriveInfo.PersonID);
            frm.ShowDialog();
        }

        private void linkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_CurrentLicense.LicenseID);
            frm.ShowDialog();
        }

    }
}
