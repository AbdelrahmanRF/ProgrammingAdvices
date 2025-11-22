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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicenseApplications : Form
    {
        DataTable _LDLAppsList;
        int _LatestTestAppointmentID = -1;
        int _CurrentTestTypeID = 1;

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
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(-1);
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void frmListLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbIsStatus.SelectedIndex = 0;
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
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex != 4;
            cbIsStatus.Visible = cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex == 4;
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
            string Status = cbIsStatus.Text;
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

        private void tsmiEditApplication_Click(object sender, EventArgs e)
        {
            int LDLApplicationID = (int)dgvApplicationsList.CurrentRow.Cells[0].Value;
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(LDLApplicationID);
            frm.ShowDialog();
            _RefreshLDLApplicationsList();
        }

        private void tsmiCancelApplication_Click(object sender, EventArgs e)
        {
            int ApplicationID = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(
                (int)dgvApplicationsList.CurrentRow.Cells[0].Value).ApplicationID;

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

        private void _SetLatestTestAppointmentID()
        {
            int LDLApplicationID = (int)dgvApplicationsList.CurrentRow.Cells[0].Value;
            clsTestAppointment LatestTestAppointment;

            for(int i = 3; i >= 0;  i--)
            {
                LatestTestAppointment = clsTestAppointment.GetLatestTestAppointment(LDLApplicationID, 
                    (clsTestType.enTestType)i);

                if (LatestTestAppointment != null)
                {
                    _LatestTestAppointmentID = LatestTestAppointment.TestAppointmentID;
                    _CurrentTestTypeID = i;
                    return;
                }
            }
        }

        private void cmsRecordOptions_Opening(object sender, CancelEventArgs e)
        {
            string ApplicationStatus = dgvApplicationsList.CurrentRow.Cells["Status"].Value.ToString();
            _SetLatestTestAppointmentID();

            foreach (ToolStripMenuItem item in cmsRecordOptions.Items.OfType<ToolStripMenuItem>())
            {
                item.Enabled = true;
            }

            foreach (ToolStripMenuItem childItem in tsmiScheduleTests.DropDownItems.OfType<ToolStripMenuItem>())
            {
                childItem.Enabled = false;
            }

            if (ApplicationStatus == "New")
            {
                tsmiShowLicense.Enabled = false;
                tsmiIssueDrivingLicenseFirstTime.Enabled = false;

                if(_CurrentTestTypeID == 1)
                    tsmiScheduleVision.Enabled = true;
                else if (_CurrentTestTypeID == 2)
                    tsmiScheduleWritten.Enabled = true;
                else
                    tsmiScheduleStreet.Enabled = true;
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
            int LDLApplicationID = (int)dgvApplicationsList.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You Sure You Want To Delete This Application?", "Confirm",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.DeleteLDLApplication(LDLApplicationID))
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
            int LDLApplicationID = (int)dgvApplicationsList.CurrentRow.Cells[0].Value;
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(LDLApplicationID);
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
    }
}
