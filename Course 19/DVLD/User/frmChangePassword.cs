using DVLD.Global_Classes;
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
    public partial class frmChangePassword : Form
    {
        int _UserID = -1;
        clsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this._UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _User = clsUser.FindUserByUserID(_UserID);
            ctrlUserCard1.FillUserData(_User);
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text != _User.Password)
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Current Password is Wrong");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (String.IsNullOrEmpty(textBox.Text.Trim()))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "New Password Cannot be Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, "Password Conformation does not Match Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
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

            _User.Password = txtNewPassword.Text;

            if (_User.UpdatePassword())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurrentPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";

                if (_User.UserID == clsGlobal.CurrentUser.UserID)
                {
                    clsGlobal.CurrentUser = null;

                    clsGlobal.RememberUsernameAndPassword(_User.Username, "");
                    Application.Restart();
                }
            }
        }
    }
}
