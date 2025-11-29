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
        public int ApplicationID { get; set; }
        clsApplication _Application;
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }

        public void FillApplicationData(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            this.ApplicationID = ApplicationID;

            lblID.Text = ApplicationID.ToString();
            lblStatus.Text = _Application.StatusText;
            lblFees.Text = _Application.PaidFees.ToString();
            lblApplicationType.Text = _Application.ApplicationTypeInfo.ApplicationTypeTitle;
            lblApplicantName.Text = _Application.ApplicantFullName;
            lblApplicationDate.Text = clsFormat.DateToShort(_Application.ApplicationDate);
            lblLastStatusDate.Text = clsFormat.DateToShort(_Application.LastStatusDate);
            lblCreatedBy.Text = _Application.CreatedByUserInfo.Username;
        }

        private void linkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
            frm.ShowDialog();
            FillApplicationData(ApplicationID);
        }
    }
}
