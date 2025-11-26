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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        public int LDLAppID {  get; set; }
        clsLocalDrivingLicenseApplication _LDLApplication;
        public frmLocalDrivingLicenseApplicationInfo(int LDLAppID)
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this.LDLAppID = LDLAppID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLAppID);

            ctrlDrivingLicenseApplicationInfo1
                .FillDrivingApplicationData(_LDLApplication.LocalDrivingLicenseApplicationID, _LDLApplication.ApplicationID);
        }
    }
}
