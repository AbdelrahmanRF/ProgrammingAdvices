using DVLD.Global_Classes;
using DVLD.License;
using DVLD.License.Local_Licenses;
using DVLD.Tests;
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
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        DataTable _LDLAppsList;
        clsLocalDrivingLicenseApplication _CurrentApplication;
        Dictionary<clsTestType.enTestType, bool> _CurrentTestStatuses;
        public frmListLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshLDLApplicationsList()
        {
            _LDLAppsList = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dgvApplicationsList.DataSource = _LDLAppsList;
            lblTotalRecords.Text = dgvApplicationsList.Rows.Count.ToString();
        }

        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbStatus.SelectedIndex = 0;
            _RefreshLDLApplicationsList();

            if (dgvApplicationsList.Rows.Count > 0)
            {
                dgvApplicationsList.Columns[0].HeaderText = "L.D.L.AppID";
                dgvApplicationsList.Columns[1].HeaderText = "Driving Class";
                dgvApplicationsList.Columns[2].HeaderText = "National No";
                dgvApplicationsList.Columns[3].HeaderText = "Full Name";
                dgvApplicationsList.Columns[4].HeaderText = "Application Date";
                dgvApplicationsList.Columns[5].HeaderText = "Passed Tests";
            }

            tsmiScheduleVision.Tag = clsTestType.enTestType.VisionTest;
            tsmiScheduleWritten.Tag = clsTestType.enTestType.WrittenTest;
            tsmiScheduleStreet.Tag = clsTestType.enTestType.StreetTest;
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex != 4;
            cbStatus.Visible = cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex == 4;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 1) return;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string SearchFor = txtFilter.Text;
            BindingSource BS = new BindingSource();
            BS.DataSource = _LDLAppsList;

            if(String.IsNullOrEmpty(SearchFor) || cbFilterBy.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvApplicationsList.DataSource = BS;
                lblTotalRecords.Text = dgvApplicationsList.Rows.Count.ToString();
                return;
            }

            if (cbFilterBy.Text == "L.D.L.AppID")
            {
                BS.Filter = $"Convert(LocalDrivingLicenseApplicationID, 'System.String') LIKE '%{SearchFor}%'";
            }
            else
            { 
                var Column = dgvApplicationsList.Columns[cbFilterBy.Text.Replace(" ", "")];
                string ColumnName = Column.DataPropertyName;
                DataColumn DC = _LDLAppsList.Columns[ColumnName];

                if (DC.DataType == typeof(int))
                    BS.Filter = $"Convert({ColumnName}, 'System.String') LIKE '%{SearchFor}%'";
                else
                    BS.Filter = $"{ColumnName} LIKE '%{SearchFor}%'";
            }
            dgvApplicationsList.DataSource = BS;
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void cbIsStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Status = cbStatus.Text;
            BindingSource BS = new BindingSource();
            BS.DataSource = _LDLAppsList;

            if(Status == "All")
            {
                BS.RemoveFilter();
                dgvApplicationsList.DataSource= BS;
                lblTotalRecords.Text = dgvApplicationsList.Rows.Count.ToString();
                return;
            }

            BS.Filter = $"Status = '{Status}'";
            dgvApplicationsList.DataSource = BS;
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void dgvApplicationsList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvApplicationsList.CurrentRow == null) return;

            int LDLApplicationID = (int)dgvApplicationsList.CurrentRow.Cells[0].Value;
            _CurrentApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLApplicationID);

            if (_CurrentApplication != null)
            {
                _CurrentTestStatuses = clsLocalDrivingLicenseApplication.GetAllTestStatuses(LDLApplicationID);
            }
        }

        private void tsmiEditApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(_CurrentApplication.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void tsmiCancelApplication_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(
                _CurrentApplication.LocalDrivingLicenseApplicationID).ApplicationID;

            clsApplication Application = clsApplication.FindBaseApplication(ApplicationID);

            if (MessageBox.Show("Are You Sure You Want To Cancel This Application?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (Application.CancelApplication())
                {
                    MessageBox.Show("Application Cancelled Successfully", "Cancelled",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLDLApplicationsList();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void cmsRecordOptions_Opening(object sender, CancelEventArgs e)
        {
            string ApplicationStatus = dgvApplicationsList.CurrentRow.Cells["Status"].Value.ToString();

            foreach (ToolStripMenuItem item in cmsRecordOptions.Items.OfType<ToolStripMenuItem>())
            {
                item.Enabled = true;
            }

            tsmiScheduleTests.Enabled = false;
            bool passedAllTests = _CurrentTestStatuses.Values.All(Passed => Passed);

            if (!passedAllTests)
            {
                tsmiScheduleTests.Enabled = true;

                foreach (ToolStripMenuItem item in tsmiScheduleTests.DropDownItems.OfType<ToolStripMenuItem>())
                {
                    if (item.Tag is clsTestType.enTestType TestType)
                    {
                        bool PassedThisTest = _CurrentTestStatuses[TestType];
                        bool PassedPrevTest = Util.DoesPassPrevTestType(_CurrentTestStatuses, TestType);

                        item.Enabled = !PassedThisTest && PassedPrevTest;
                    }
                }

            }

            if (ApplicationStatus == "New")
            {
                tsmiShowLicense.Enabled = false;
                tsmiIssueDrivingLicenseFirstTime.Enabled = passedAllTests;
            }
            else if (ApplicationStatus == "Cancelled")
            {
                tsmiEditApplication.Enabled = false;
                tsmiCancelApplication.Enabled = false;
                tsmiScheduleTests.Enabled = false;
                tsmiIssueDrivingLicenseFirstTime.Enabled = false;
                tsmiShowLicense.Enabled = false;
            }
            else
            {
                tsmiEditApplication.Enabled = false;
                tsmiDeleteApplication.Enabled = false;
                tsmiCancelApplication.Enabled = false;
                tsmiScheduleTests.Enabled = false;
                tsmiIssueDrivingLicenseFirstTime.Enabled = false;
            }
        }

        private void tsmiDeleteApplication_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete This Application?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.DeleteLDLApplication(_CurrentApplication.LocalDrivingLicenseApplicationID))
                {
                    MessageBox.Show("Application Deleted Successfully", "Cancelled",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshLDLApplicationsList();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void tsmiShowApplicationDetails_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(_CurrentApplication.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void tsmiShowLicense_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApp = clsLocalDrivingLicenseApplication
                .FindByLDLApplicationID((int)dgvApplicationsList.CurrentRow.Cells[0].Value);

            int LicenseID = LDLApp.GetActiveLicenseID();

            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }


        private void _OpenTestAppointmentsForm(clsTestType.enTestType TestTypeID)
        {
            frmListTestAppointments frm = new frmListTestAppointments(_CurrentApplication.LocalDrivingLicenseApplicationID, TestTypeID);
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void tsmiScheduleVision_Click(object sender, EventArgs e)
        {
            _OpenTestAppointmentsForm(clsTestType.enTestType.VisionTest);
        }

        private void tsmiScheduleWritten_Click(object sender, EventArgs e)
        {
            _OpenTestAppointmentsForm(clsTestType.enTestType.WrittenTest);
        }

        private void tsmiScheduleStreet_Click(object sender, EventArgs e)
        {
            _OpenTestAppointmentsForm(clsTestType.enTestType.StreetTest);
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int PersonID = clsPerson.Find(dgvApplicationsList.CurrentRow.Cells["NationalNo"].Value.ToString()).PersonID;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void tsmiIssueDrivingLicenseFirstTime_Click(object sender, EventArgs e)
        {
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(_CurrentApplication.LocalDrivingLicenseApplicationID);
            frm.ShowDialog();

            _RefreshLDLApplicationsList();
        }
    }
}
