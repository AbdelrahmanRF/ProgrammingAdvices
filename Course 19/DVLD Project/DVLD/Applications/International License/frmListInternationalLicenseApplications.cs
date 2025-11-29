using DVLD.License;
using DVLD.License.International_Licenses;
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

namespace DVLD.Applications.International_License
{
    public partial class frmListInternationalLicenseApplications : Form
    {
        DataTable _InternationalLicenseApplications;
        clsDriver _CurrentDriver;
        int _InternationalLicenseID;
        public frmListInternationalLicenseApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshInternationalLicenseApplications()
        {
            _InternationalLicenseApplications = clsInternationalLicense.GetAllInternationalLicenses();
            dgvApplicationsList.DataSource = _InternationalLicenseApplications;
            lblTotalRecords.Text = dgvApplicationsList.Rows.Count.ToString();
        }

        private void frmListInternationalLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
            _RefreshInternationalLicenseApplications();

            if (dgvApplicationsList.Rows.Count > 0)
            {
                dgvApplicationsList.Columns[0].HeaderText = "Int.License ID";
                dgvApplicationsList.Columns[1].HeaderText = "Application ID";
                dgvApplicationsList.Columns[2].HeaderText = "Driver ID";
                dgvApplicationsList.Columns[3].HeaderText = "L.License ID";
                dgvApplicationsList.Columns[4].HeaderText = "Issue Date";
                dgvApplicationsList.Columns[5].HeaderText = "Expiration Date";
                dgvApplicationsList.Columns[6].HeaderText = "Is Active";
            }
        }

        private void dgvApplicationsList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvApplicationsList.CurrentRow == null) return;

            _InternationalLicenseID = (int)dgvApplicationsList.CurrentRow.Cells[0].Value;
            int DriverID = (int)dgvApplicationsList.CurrentRow.Cells["DriverID"].Value;
            _CurrentDriver = clsDriver.FindByDriverID(DriverID);
        }
        private void btnAddNewApplication_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
            _RefreshInternationalLicenseApplications();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex != 5;
            cbIsActive.Visible = cbFilterBy.SelectedIndex == 5;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string SearchFor = txtFilter.Text;
            BindingSource BS = new BindingSource();
            BS.DataSource = _InternationalLicenseApplications;
            string ColumnName;

            if (String.IsNullOrEmpty(SearchFor) || cbFilterBy.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvApplicationsList.DataSource = BS;
                lblTotalRecords.Text = dgvApplicationsList.Rows.Count.ToString();
                return;
            }

            if (cbFilterBy.Text != "Local License ID")
            {
                var Column = dgvApplicationsList.Columns[cbFilterBy.Text.Replace(" ", "")];
                ColumnName = Column.DataPropertyName;
            }
            else
            {
                ColumnName = "IssuedUsingLocalLicenseID";
            }

            BS.Filter = $"Convert({ColumnName}, 'System.String') LIKE '%{SearchFor}%'";

            dgvApplicationsList.DataSource = BS;

            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isActive = cbIsActive.Text == "Yes";
            BindingSource BS = new BindingSource();
            BS.DataSource = _InternationalLicenseApplications;

            if (cbIsActive.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvApplicationsList.DataSource = BS;
                lblTotalRecords.Text = dgvApplicationsList.Rows.Count.ToString();
                return;
            }

            BS.Filter = $"IsActive = {isActive}";

            dgvApplicationsList.DataSource = BS;

            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void tsmiShowPersonDetails_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo(_CurrentDriver.PersonID);
            frm.ShowDialog();
        }

        private void tsmiShowLicenseDetails_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(_CurrentDriver.PersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
