using ContactsBusinessLayer;
using System;
using System.Windows.Forms;

namespace ContactsProject_WindowsForm
{
    public partial class frmListContacts : Form
    {
        public frmListContacts()
        {
            InitializeComponent();
        }

        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }

        private void frmListContacts_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void btnAddNewContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact(-1);
            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void tsmEdit_Click(object sender, EventArgs e)
        {
            frmAddEditContact frm = new frmAddEditContact((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshContactsList();
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show($"Are you sure you want to delete contact [{dgvAllContacts.CurrentRow.Cells[0].Value}]", 
                "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully.");
                    _RefreshContactsList();
                }
                else
                {
                    MessageBox.Show("Contact is not Deleted.");
                }
            }
        }
    }
}
