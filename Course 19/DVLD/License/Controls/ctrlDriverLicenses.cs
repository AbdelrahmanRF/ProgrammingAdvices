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
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void FillDriverLicensesHistory(int DriverID)
        {
            DataTable DT = clsLicense.GetAllDriverLicenses(DriverID);
            dgvLocalLicensesHistory.DataSource = DT;
            lblTotalLocalLicensesRecords.Text = DT.Rows.Count.ToString();

            if (dgvLocalLicensesHistory.Rows.Count > 0 )
            {
                dgvLocalLicensesHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicensesHistory.Columns[1].HeaderText = "App.ID";
                dgvLocalLicensesHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicensesHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicensesHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicensesHistory.Columns[5].HeaderText = "Is Active";
            }

            DT = clsInternationalLicense.GetAllDriverInternationalLicenses(DriverID);
            dgvInternationalLicensesHistory.DataSource = DT;
            lblTotalInternationalLicensesRecords.Text = DT.Rows.Count.ToString();

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
    }
}
