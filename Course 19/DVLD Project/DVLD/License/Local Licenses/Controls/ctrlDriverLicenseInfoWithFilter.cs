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

namespace DVLD.License.International_Licenses.Controls
{
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {
        public delegate void SearchEndedEventHandler(object sender, int LocalLicenseID);
        public event SearchEndedEventHandler SearchEnded;

        clsLicense _License;
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void btnSearchLicense_Click(object sender, EventArgs e)
        {
            if(!int.TryParse(txtFilter.Text, out int LocalLicenseID))
            {
                return;
            }

            _License = clsLicense.FindByLicenseID(LocalLicenseID);

            if (_License == null)
            {
                MessageBox.Show($"No License with ID = {LocalLicenseID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LocalLicenseID = -1;
                ctrlDriverLicenseInfo1.Clear();
            }
            else
                ctrlDriverLicenseInfo1.FillDriverLicensesData(LocalLicenseID);

            SearchEnded?.Invoke(this, LocalLicenseID);
        }

        public void DisableSearch()
        {
            gbFilter.Enabled = false;
        }

        public void DisplayLicenseInfo(int LocalLicenseID)
        {
            txtFilter.Text = LocalLicenseID.ToString();
            btnSearchLicense.PerformClick();
            DisableSearch();
        }
    }
}
