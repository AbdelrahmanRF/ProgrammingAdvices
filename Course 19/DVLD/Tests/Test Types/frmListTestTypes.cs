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

namespace DVLD.Tests.Test_Types
{
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MaximizeBox = false;
        }

        private void _RefreshTestTypes()
        {
            DataTable DT = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = DT;
            lblTotalRecords.Text = dgvTestTypes.Rows.Count.ToString();
        }

        private void tsmiEditTestType_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypes();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypes();
        }
    }
}
