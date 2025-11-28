using DVLD.Global_Classes;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.License.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        clsLicense _CurrentLicense;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }

        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = clsFormat.DateToShort(DateTime.Now);
            lblCreatedBy.Text = clsGlobal.CurrentUser.Username;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDriverInternationalLicenseInfoWithFilter1_SearchEnded(object sender, int LocalLicenseID)
        {
            btnDetain.Enabled = false;
            linkShowLicenseHistory.Enabled = false;
            linkShowLicenseInfo.Enabled = false;
            _CurrentLicense = null;
            lblLicenseID.Text = "???";

            if (LocalLicenseID == -1)
            {
                return;
            }

            _CurrentLicense = clsLicense.FindByLicenseID(LocalLicenseID);
            linkShowLicenseHistory.Enabled = true;

            if (!_CurrentLicense.IsActive)
            {
                MessageBox.Show("License must be Active to be Detained", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_CurrentLicense.IsDetained)
            {
                MessageBox.Show("Selected License Already Detained!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLicenseID.Text = LocalLicenseID.ToString();
            btnDetain.Enabled = true;
        }

        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            string FineFeesText = txtFineFees.Text.Trim();

            if (_CurrentLicense == null)
                return;

            if (String.IsNullOrEmpty(FineFeesText))
            {
                e.Cancel = true;
                txtFineFees.Focus();
                errorProvider1.SetError(txtFineFees, "Fine Fees is Required.");
            }
            else
            {
                if (float.TryParse(FineFeesText, out float FineFeesValue))
                {
                    if (FineFeesValue > 0)
                    {
                        e.Cancel = false;
                        errorProvider1.SetError(txtFineFees, "");
                    }
                    else
                    {
                        e.Cancel = true;
                        txtFineFees.Focus();
                        errorProvider1.SetError(txtFineFees, "Please Enter a Value Greater than 0");
                    }
                }
                else
                {
                    e.Cancel = true;
                    txtFineFees.Focus();
                    errorProvider1.SetError(txtFineFees, "Invalid format. Please Enter a Valid Number for Fine Fees.");
                }
            }
        }

        private void txtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtFineFees.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Fix Validation Errors Before Saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you Sure you Want to Detain this License?", "Confirm", MessageBoxButtons.OKCancel,
               MessageBoxIcon.Question) == DialogResult.OK)
            {

                if(float.TryParse(txtFineFees.Text, out float FineFees))
                {
                    int DetainID = _CurrentLicense.Detain(FineFees, clsGlobal.CurrentUser.UserID);

                    if (DetainID != -1)
                    {
                        MessageBox.Show($"Licensed Replaced Detained with Detain ID = {DetainID}",
                        "License Detained", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnDetain.Enabled = false;
                        ctrlDriverInternationalLicenseInfoWithFilter1.DisableSearch();
                        linkShowLicenseInfo.Enabled = true;

                        lblDetainID.Text = DetainID.ToString();
                    }
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
