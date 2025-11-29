using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Application_Types
{
    public partial class frmEditApplicationType : Form
    {
        int _ApplicationTypeID = -1;
        clsApplicationType _ApplicationType;
        public frmEditApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            this._ApplicationTypeID = ApplicationTypeID;
        }

        private void _LoadData()
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtApplicationTypeTitle.Text = _ApplicationType.ApplicationTypeTitle;
            txtApplicationTypeFees.Text = _ApplicationType.ApplicationTypeFees.ToString();
        }

        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidateNullOrEmpty(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (String.IsNullOrEmpty(textBox.Text.Trim()))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, $"{textBox.Tag} Cannot be Empty");
            }
            else if (textBox.Tag.ToString() == "Fees" && !decimal.TryParse(textBox.Text, out _))
            {
                e.Cancel = true;
                textBox.Focus();
                errorProvider1.SetError(textBox, $"{textBox.Tag} Must contain a valid number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox, "");
            }
        }

        private void txtApplicationTypeFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
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

            _ApplicationType.ApplicationTypeTitle = txtApplicationTypeTitle.Text;
            _ApplicationType.ApplicationTypeFees = Convert.ToSingle(txtApplicationTypeFees.Text);

            if (_ApplicationType.Save())
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
