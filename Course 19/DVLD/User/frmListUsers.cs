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
    public partial class frmListUsers : Form
    {
        DataTable _UsersList;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void _RefreshUsers()
        {
            _UsersList = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _UsersList;
            lblTotalRecords.Text = _UsersList.Rows.Count.ToString();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsers();
            cbFilterBy.SelectedIndex = 0;
            cbIsActive.SelectedIndex = 0;
            cbIsActive.Visible = false;
            txtFilter.Visible = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilterBy.SelectedIndex != 0 && cbFilterBy.SelectedIndex != 5;
            cbIsActive.Visible = cbFilterBy.SelectedIndex == 5;


        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            int isActive = cbIsActive.Text == "Yes" ? 1 : 0;
            BindingSource BS = new BindingSource();
            BS.DataSource = _UsersList;

            if (cbIsActive.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvUsersList.DataSource = BS;
                lblTotalRecords.Text = _UsersList.Rows.Count.ToString();
                return;
            }

            BS.Filter = $"IsActive = {isActive}";
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string SearchFor = txtFilter.Text.Trim();

            BindingSource BS = new BindingSource();
            BS.DataSource = _UsersList;

            if (String.IsNullOrEmpty(SearchFor) || cbFilterBy.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvUsersList.DataSource = BS;
                lblTotalRecords.Text = _UsersList.Rows.Count.ToString();
                return;
            }

            var Column = dgvUsersList.Columns[cbFilterBy.Text.Replace(" ", "")];
            string ColumnName = Column.DataPropertyName;
            DataColumn DC = _UsersList.Columns[ColumnName];

            if (DC.DataType == typeof(int))
                BS.Filter = $"Convert({ColumnName}, 'System.String') LIKE '%{SearchFor}%'";
            else
                BS.Filter = $"{ColumnName} LIKE '%{SearchFor}%'";

            dgvUsersList.DataSource = BS;
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 1 && cbFilterBy.SelectedIndex != 2) return;

            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
