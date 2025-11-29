using DVLD.Global_Classes;
using DVLD.People;
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

namespace DVLD.Applications.Controls
{
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private int _ApplicationID = -1;
        public int ApplicationID { get; }
        clsApplication _Application;
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void ResetApplicationInfo()
        {
            _Application = null;
            _ApplicationID = -1;

            lblID.Text = "???";
            lblStatus.Text = "???";
            lblFees.Text = "$$$";
            lblApplicationType.Text = "???";
            lblApplicantName.Text = "???";
            lblApplicationDate.Text = "??/??/????";
            lblLastStatusDate.Text = "??/??/????";
            lblCreatedBy.Text = "???";
        }
        private void _FillApplicationInfo()
        {
            _ApplicationID = ApplicationID;

            lblID.Text = ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicationType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicantName.Text = _Application.ApplicantFullName;
            lblApplicationDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblLastStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedBy.Text = _Application.CreatedByUserInfo.Username;
        }

        public void FillApplicationData(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);

            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void linkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();
            FillApplicationData(ApplicationID);
        }
    }
}
