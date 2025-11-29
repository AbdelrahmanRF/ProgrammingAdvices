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

namespace DVLD.Applications.Application_Types
{
    public partial class frmListApplicationTypes : Form
    {
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void _RefreshApplicationTypesList()
        {
            DataTable DT = clsApplicationType.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = DT;
            lblTotalRecords.Text = DT.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesList();
        }

        private void tsmiEditApplicationType_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesList();
        }
    }
}
