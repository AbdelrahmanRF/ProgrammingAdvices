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
        public event Action<int> OnSearchEnded;
        protected virtual void SearchEnded(int LocalLicenseID)
        {
            Action<int> Handler = OnSearchEnded;

            if (Handler != null)
                Handler(LocalLicenseID);
        }

        clsLicense _License;

        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get { return _FilterEnabled; }

            set 
            { 
                _FilterEnabled = value; 
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        int _LicenseID = -1;

        public int LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }

        public clsLicense SelectedLicense
        {
            get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; }
        }

        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void FocusSearchInput()
        {
            txtFilter.Focus();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);

            if (e.KeyChar == (char)13)
                btnSearchLicense.PerformClick();
        }
        private void btnSearchLicense_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Fix Validation Errors Before Saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtFilter.Text, out int LocalLicenseID))
            {
                return;
            }

            _License = clsLicense.FindByLicenseID(LocalLicenseID);

            if (_License == null)
            {
                MessageBox.Show($"No License with ID = {LocalLicenseID}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                LocalLicenseID = -1;

                if (OnSearchEnded != null && FilterEnabled)
                    OnSearchEnded(-1);

                return;
            }
            else
                ctrlDriverLicenseInfo1.FillDriverLicensesData(LocalLicenseID);

            if (OnSearchEnded != null && FilterEnabled)
                OnSearchEnded(ctrlDriverLicenseInfo1.LicenseID);
        }

        public void DisplayLicenseInfo(int LocalLicenseID)
        {
            txtFilter.Text = LocalLicenseID.ToString();
            btnSearchLicense.PerformClick();
            gbFilter.Enabled = false;
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (String.IsNullOrEmpty(txtBox.Text))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, "This Field is Required.");
            }
            else if (!int.TryParse(txtBox.Text, out int LocalLicenseID))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, "Invalid format. Please Enter a Valid Number.");
            }
        }
    }
}
