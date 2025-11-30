using DVLD.License;
using DVLD.License.Detain_License;
using DVLD.License.Local_Licenses;
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

namespace DVLD.Applications.Release_Detained_License
{
    public partial class frmListDetainedLicenses : Form
    {
        DataTable _DetainedLicensesList;
        clsDriver _CurrentDriver;
        clsLicense _CurrentLicense;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshDetainedLicensesList()
        {
            _DetainedLicensesList = clsDetainedLicense.GetAllDetainedLicenses();

            dgvDetainedLicensesList.DataSource = _DetainedLicensesList;
            lblTotalRecords.Text = dgvDetainedLicensesList.Rows.Count.ToString();
        }

        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshDetainedLicensesList();
            cbFilterBy.SelectedIndex = 0;
            cbIsReleased.SelectedIndex = 0;

            if (dgvDetainedLicensesList.Rows.Count > 0)
            {
                dgvDetainedLicensesList.Columns[0].HeaderText = "D.ID";
                dgvDetainedLicensesList.Columns[1].HeaderText = "L.ID";
                dgvDetainedLicensesList.Columns[2].HeaderText = "D.Date";
                dgvDetainedLicensesList.Columns[3].HeaderText = "Is Released";
                dgvDetainedLicensesList.Columns[4].HeaderText = "Fine Fees";
                dgvDetainedLicensesList.Columns[5].HeaderText = "Release Date";
                dgvDetainedLicensesList.Columns[6].HeaderText = "N.No";
                dgvDetainedLicensesList.Columns[7].HeaderText = "Full Name";
                dgvDetainedLicensesList.Columns[8].HeaderText = "Release App.lD";
            }
        }

        private void dgvDetainedLicensesList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDetainedLicensesList.CurrentRow == null) 
                return;

            _CurrentLicense = clsLicense.FindByLicenseID((int)dgvDetainedLicensesList.CurrentRow.Cells[1].Value);
            _CurrentDriver = _CurrentLicense.DriveInfo;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex != 2;
            cbIsReleased.Visible = cbFilterBy.SelectedIndex == 2;
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!cbFilterBy.Text.Contains("ID"))
                return;

            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string SearchFor = txtFilter.Text;
            BindingSource BS = new BindingSource();
            BS.DataSource = _DetainedLicensesList;

            if (String.IsNullOrEmpty(SearchFor) || cbFilterBy.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvDetainedLicensesList.DataSource = BS;
                lblTotalRecords.Text = dgvDetainedLicensesList.Rows.Count.ToString();
                return;
            }

            var Column = dgvDetainedLicensesList.Columns[cbFilterBy.Text.Replace(" ", "")];
            string ColumnName = Column.DataPropertyName;
            DataColumn DC = _DetainedLicensesList.Columns[ColumnName];

            if (DC.DataType == typeof(int))
                BS.Filter = $"Convert({ColumnName}, 'System.String') LIKE '%{SearchFor}%'";
            else
                BS.Filter = $"{ColumnName} LIKE '%{SearchFor}%'";

            dgvDetainedLicensesList.DataSource = BS;
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingSource BS = new BindingSource();
            BS.DataSource = _DetainedLicensesList;

            if (cbIsReleased.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvDetainedLicensesList.DataSource = BS;
                lblTotalRecords.Text = dgvDetainedLicensesList.Rows.Count.ToString();
                return;
            }

            bool isReleased = cbIsReleased.SelectedIndex == 1;

            BS.Filter = $"IsReleased = {isReleased}";

            dgvDetainedLicensesList.DataSource = BS;
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void cmsRecordOptions_Opening(object sender, CancelEventArgs e)
        {
            tsmiReleaseDetainedLicense.Enabled = !(bool)dgvDetainedLicensesList.CurrentRow.Cells[3].Value;
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_CurrentDriver.PersonID);
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }

        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_CurrentLicense.LicenseID);
            frm.ShowDialog();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_CurrentDriver.PersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void tsmiReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication(_CurrentLicense.LicenseID);
            frm.ShowDialog();
            _RefreshDetainedLicensesList();
        }
    }
}
