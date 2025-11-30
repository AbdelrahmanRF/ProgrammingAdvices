using DVLD.License.International_Licenses;
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

namespace DVLD.License.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        int _DriverID;
        clsDriver _Driver;
        DataTable _LocalLicenses;
        DataTable _InternationalLicenses;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenses()
        {
            _LocalLicenses = clsLicense.GetAllDriverLicenses(_DriverID);
            dgvLocalLicensesHistory.DataSource = _LocalLicenses;
            lblTotalLocalLicensesRecords.Text = dgvLocalLicensesHistory.Rows.Count.ToString();


            if (dgvLocalLicensesHistory.Rows.Count > 0)
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
            }
        }

        private void _LoadInternationalLicenses()
        {
            _InternationalLicenses = clsInternationalLicense.GetAllDriverInternationalLicenses(_DriverID);
            dgvInternationalLicensesHistory.DataSource = _InternationalLicenses;
            lblTotalInternationalLicensesRecords.Text = dgvInternationalLicensesHistory.Rows.Count.ToString();

            if (dgvInternationalLicensesHistory.Rows.Count > 0)
            {
                dgvInternationalLicensesHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicensesHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicensesHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicensesHistory.Columns[5].HeaderText = "Is Active";
            }
        }

        public void FillDriverLicensesHistory(int DriverID)
        {
            _DriverID = DriverID;
            _Driver = clsDriver.FindByDriverID(_DriverID);

            if (_Driver == null)
            {
                MessageBox.Show($"There is no Driver With ID = {_DriverID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        public void FillDriverLicensesHistoryByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show($"There is no Driver Linked With Person ID = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicenses();
            _LoadInternationalLicenses();
        }

        private void tsmiShowLocalLicenseInfo_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvLocalLicensesHistory.CurrentRow.Cells[0].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LocalLicenseID);
            frm.ShowDialog();
        }

        private void tsmiShowIntLicenseInfo_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)dgvInternationalLicensesHistory.CurrentRow.Cells[0].Value;
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);
            frm.ShowDialog();
        }
    }
}
