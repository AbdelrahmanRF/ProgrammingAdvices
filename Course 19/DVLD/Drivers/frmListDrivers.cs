using DVLD.License;
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

namespace DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        DataTable _DriversList;
        public frmListDrivers()
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void _RefreshDriversList()
        {
            _DriversList = clsDriver.GetAllDrivers();
            dgvDriversList.DataSource = _DriversList;
            lblTotalRecords.Text = dgvDriversList.Rows.Count.ToString();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {
            _RefreshDriversList();
            cbFilterBy.SelectedIndex = 0;

            if (dgvDriversList.Rows.Count > 0)
            {
                dgvDriversList.Columns[0].HeaderText = "Driver ID";
                dgvDriversList.Columns[1].HeaderText = "Person ID";
                dgvDriversList.Columns[2].HeaderText = "National No";
                dgvDriversList.Columns[3].HeaderText = "Full Name";
                dgvDriversList.Columns[4].HeaderText = "Date";
                dgvDriversList.Columns[5].HeaderText = "Active Licenses";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilterBy.SelectedIndex != 0;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string SearchFor = txtFilter.Text;
            BindingSource BS = new BindingSource();
            BS.DataSource = _DriversList;

            if (cbFilterBy.SelectedIndex == 0 || String.IsNullOrEmpty(SearchFor))
            {
                BS.RemoveFilter();
                dgvDriversList.DataSource = BS;
                lblTotalRecords.Text = dgvDriversList.Rows.Count.ToString();
                return;
            }

            var Column = dgvDriversList.Columns[cbFilterBy.Text.Replace(" ", "")];
            string ColumnName = Column.DataPropertyName;
            DataColumn DC = _DriversList.Columns[ColumnName];

            if (DC.DataType == typeof(int))
                BS.Filter = $"Convert({ColumnName}, System.String) LIKE '%{SearchFor}%'";
            else
                BS.Filter = $"{ColumnName} LIKE '%{SearchFor}%'";

            dgvDriversList.DataSource = BS;
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 1 && cbFilterBy.SelectedIndex != 2) return;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tsmiShowPersonInfo_Click(object sender, EventArgs e)
        {
            string NationalNo = dgvDriversList.CurrentRow.Cells["NationalNo"].Value.ToString();
            frmShowPersonInfo frm = new frmShowPersonInfo(NationalNo);
            frm.ShowDialog();
            _RefreshDriversList();
        }

        private void tsmiShowPersonLicenseHistory_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvDriversList.CurrentRow.Cells["PersonID"].Value;
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}
