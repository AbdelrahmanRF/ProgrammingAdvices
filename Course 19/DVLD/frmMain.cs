using DVLD.Applications.Application_Types;
using DVLD.Global_Classes;
using DVLD.People;
using DVLD.User;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        private Form _LoginForm;
        public frmMain(Form sender)
        {
            InitializeComponent();

            _LoginForm = sender;

            this.FormClosed += FrmMain_FormClosed;
        }
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clsGlobal.CurrentUser != null)
            {
                Application.Exit();
            }
        }
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LoginForm.Show();
            this.Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frm = new frmListUsers();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }
    }
}
