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
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        int _LDLAppID = -1;
        clsLocalDrivingLicenseApplication _LDLApplication;
        public frmAddUpdateLocalDrivingLicenseApplication(int LDLAppID)
        {
            InitializeComponent();

            this._LDLAppID = LDLAppID;

            if (LDLAppID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                _LDLApplication = new clsLocalDrivingLicenseApplication();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                cbLicenseClasses.SelectedIndex = 2;
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewLocalDrivingLicenseService).ApplicationTypeFees.ToString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.Username;

                return;
            }


        }

        private void _FillLicenseClassesComboBox()
        {
            DataTable DT = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow Row in DT.Rows)
            {
                cbLicenseClasses.Items.Add(Row["ClassName"]);
            }
        }

        private void frmAddUpdateLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            _FillLicenseClassesComboBox();
            _LoadData();
        }

        private void tcApplicationAddUpdateTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }


    }
}
