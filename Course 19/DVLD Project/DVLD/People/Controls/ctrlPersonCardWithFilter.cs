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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;

            if (Handler != null)
                Handler(PersonID);
        }

        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; } 

            set
            {
                _ShowAddPerson = value;
                btnAddPerson.Visible = value;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }

            set
            { 
                _FilterEnabled = value; 
                gbFilter.Enabled = value;
            }
        }

        private int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }

        private clsPerson _Person;
        public clsPerson SelectedPerson
        {
            get { return ctrlPersonCard1.SelectedPerson; }
        }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        public void FocusFilter()
        {
            txtFilter.Focus();
        }

        public void FindPerson()
        {
            string FilterText = txtFilter.Text.Trim();

            if (cbFindBy.Text == "National ID")
                ctrlPersonCard1.FillPersonData(FilterText);
            else
                ctrlPersonCard1.FillPersonData(int.Parse(FilterText));

            if (OnPersonSelected != null && FilterEnabled)
                OnPersonSelected(ctrlPersonCard1.PersonID);
        }

        public void DisplayPersonInfo(int PersonID)
        {
            cbFindBy.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();

            FindPerson();
        }

        private void DataBackEvent(int PersonID)
        {
            cbFindBy.SelectedIndex = 1;
            txtFilter.Text = PersonID.ToString();

            ctrlPersonCard1.FillPersonData(PersonID);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFindBy.SelectedIndex = 0;
            txtFilter.Focus();
        }
        private void cbFindBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            txtFilter.Focus();
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Fix Validation Errors, and Search Again.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FindPerson();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }

        private void txtFilter_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                e.Cancel = true;
                FocusFilter();
                errorProvider1.SetError(txtFilter, "This Field is Required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFilter, "");
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnSearchUser.PerformClick();

            if (cbFindBy.Text == "Person ID") 
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
