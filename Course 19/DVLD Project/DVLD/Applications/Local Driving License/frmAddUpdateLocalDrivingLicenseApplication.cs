using DVLD.Global_Classes;
using DVLD.People.Controls;
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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        int _LDLAppID = -1;
        int _SelectedPersonID = -1;
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

            lblFormTitle.Text = "Update Local Driving License Application";
            btnSave.Enabled = true;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(_LDLAppID);
            ctrlPersonCardWithFilter1.DisplayPersonInfo(clsPerson.Find(_LDLApplication.ApplicantPersonID).PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;
            _SelectedPersonID = ctrlPersonCardWithFilter1.PersonID;

            lblDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LDLApplication.ApplicationDate);
            lblApplicationFees.Text = _LDLApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindUserByUserID(_LDLApplication.CreatedByUserID).Username;
            cbLicenseClasses.SelectedIndex = cbLicenseClasses.FindString(_LDLApplication.LicenseClassInfo.ClassName);
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
            ctrlPersonCardWithFilter1.FocusFilter();
        }

        private bool _CanGoToNextStep()
        {
            clsPerson SelectedPerson = ctrlPersonCardWithFilter1.SelectedPerson;

            if (SelectedPerson == null)
            {
                MessageBox.Show("You Have to Select Person First", "Person Must be Selected", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
            
            return true;
        }

        private void tcApplicationAddUpdateTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tcApplicationAddUpdateTabs.SelectedTab == tpApplicationInfo)
            {
                if (!_CanGoToNextStep()) 
                { 
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_CanGoToNextStep()) return;

            tcApplicationAddUpdateTabs.SelectedTab = tpApplicationInfo;
            _SelectedPersonID = ctrlPersonCardWithFilter1.PersonID;
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClasses.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID, 
                clsApplication.enApplicationStatus.New, LicenseClassID);

            if (ActiveApplicationID != -1)
            {
                MessageBox.Show("Choose Another License Class, the Selected Person Already have an Active Application for the Selected Class with ID = " + 
                    ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID, LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose different driving class",
                    "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                return;
            }

            _LDLApplication.ApplicantPersonID = _SelectedPersonID;
            _LDLApplication.ApplicationTypeID = 1;
            _LDLApplication.ApplicationDate = DateTime.Now;
            _LDLApplication.ApplicationStatus = enApplicationStatus.New;
            _LDLApplication.LicenseClassID = LicenseClassID;
            _LDLApplication.LastStatusDate = DateTime.Now;
            _LDLApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
            _LDLApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;


            if (_LDLApplication.Save())
            {
                lblDLApplicationID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Local Driving License Application";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
