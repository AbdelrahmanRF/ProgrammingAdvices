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

namespace DVLD.User.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        int _UserID = -1;
        public int UserID { get; }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        private void _ResetUserInfo()
        {
            lblUserID.Text = "???";
            lblUserName.Text = "???";
            lblIsActive.Text = "???";
        }

        public void FillUserData(int UserID)
        {
            _User = clsUser.FindUserByUserID(UserID);

            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show($"No User With UserID = {UserID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadUserInfoToControl();
        }

        private void _LoadUserInfoToControl()
        {
            ctrlPersonCard1.FillPersonData(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.Username;
            lblIsActive.Text = _User.isActive ? "Yes" : "No";
        }
    }
}
