using DVLD_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmListPeople : Form
    {
        DataTable _PeopleList;
        int _CurrentPersonID;
        public frmListPeople()
        {
            InitializeComponent();
        }

        private void dgvPeopleList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPeopleList.CurrentRow == null) 
                return;

            _CurrentPersonID = (int)dgvPeopleList.CurrentRow.Cells[0].Value;
        }

        private void _RefreshPeopleList()
        {
            _PeopleList = clsPerson.GetAllPeople();
            dgvPeopleList.DataSource = _PeopleList;
            lblTotalRecords.Text = _PeopleList.Rows.Count.ToString();
        }

        private void frmListPeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
            cbFilterBy.SelectedIndex = 0;
            txtFilter.Visible = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilterBy.SelectedIndex != 0;
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string SearchFor = txtFilter.Text;

            BindingSource BS = new BindingSource();
            BS.DataSource = _PeopleList;

            if (string.IsNullOrEmpty(SearchFor) || cbFilterBy.SelectedIndex == 0)
            {
                BS.RemoveFilter();
                dgvPeopleList.DataSource = BS;
                lblTotalRecords.Text = _PeopleList.Rows.Count.ToString();
                return;
            }

            var Column = dgvPeopleList.Columns[cbFilterBy.Text.Replace(" ", "")];
            string ColumnName = Column.DataPropertyName;

            DataColumn DC = _PeopleList.Columns[ColumnName];

            if (DC.DataType == typeof(int))
                BS.Filter = $"Convert({ColumnName}, 'System.String') LIKE '%{SearchFor}%'";
            else
                BS.Filter = $"{ColumnName} LIKE '%{SearchFor}%'";

            dgvPeopleList.DataSource = BS;
            lblTotalRecords.Text = BS.List.Count.ToString();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex != 1) return;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void _ShowAddEditForm(bool LoadForEdit = true)
        {
            frmAddUpdatePerson frm;
            if (!LoadForEdit)
                frm = new frmAddUpdatePerson();
            else
                frm = new frmAddUpdatePerson(_CurrentPersonID);

            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmiShowDetails_Click(object sender, EventArgs e)
        {
            string NationalNo = dgvPeopleList.CurrentRow.Cells[1].Value.ToString();

            frmShowPersonInfo frm = new frmShowPersonInfo(NationalNo);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void tsmiAddNewPerson_Click(object sender, EventArgs e)
        {
            _ShowAddEditForm();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            _ShowAddEditForm();
        }
        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            _ShowAddEditForm(true);
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                clsPerson.DeletePerson(_CurrentPersonID);
                _RefreshPeopleList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
