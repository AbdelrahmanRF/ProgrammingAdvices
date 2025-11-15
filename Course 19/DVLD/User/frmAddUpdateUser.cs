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

namespace DVLD.User
{
    public partial class frmAddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        int UserID = -1;
        clsUser _User;
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;


            this.UserID = UserID;

            if (UserID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }
        private bool _CanGoToNextStep()
        {
            clsPerson SelectedPerson = ctrlPersonCardWithFilter1.Person;

            if (SelectedPerson == null)
            {
                MessageBox.Show("You Have to Select Person First", "Person Must be Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (clsUser.isUserExistByPersonID(SelectedPerson.PersonID) && _Mode != enMode.Update)
            {
                MessageBox.Show("Selected Person already has a user, choose another one.", "Select Another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void _LoadData()
        {
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();
                return;
            }

            _User = clsUser.FindUserByUserID(UserID);
            lblUserID.Text = UserID.ToString();
            txtUserName.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.isActive;
            ctrlPersonCardWithFilter1.LoadPersonInfoForUpdate(_User.PersonID);
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!_CanGoToNextStep()) return;

            tcUseAddUpdateTabs.SelectedTab = tpLoginInfo;
            btnSave.Enabled = true;
        }

        private void tcUseAddUpdateTabs_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tcUseAddUpdateTabs.SelectedTab == tpLoginInfo)
            {
                if (!_CanGoToNextStep())
                {
                    e.Cancel = true;
                    return;
                }
            }

        }

        private void ValidateUserName(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            string UserName = txtBox.Text.Trim();

            bool IsUserNameExists = clsUser.isUserExistByUserName(UserName);
            bool IsSameUser = (_Mode == enMode.Update) && (_User.Username == UserName);

            if (String.IsNullOrEmpty(UserName))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, $"{txtBox.Tag} Cannot be Empty!");
            }
            else if (IsUserNameExists && !IsSameUser)
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, "UserName is Used, Chose Another One!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            string Password = txtBox.Text;

            if (String.IsNullOrEmpty(Password))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, $"{txtBox.Tag} Cannot be Empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            string ConfPassword = txtBox.Text;

            if (ConfPassword != txtPassword.Text)
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, "Password Conformation does not Match Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Fix Validation Errors Before Saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _User.PersonID = ctrlPersonCardWithFilter1.Person.PersonID;
            _User.Username = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.isActive = chkIsActive.Checked;

            if (_User.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblUserID.Text = _User.UserID.ToString();
                lblFormTitle.Text = "Update User";
                this.Text = "Update User";
            }
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
