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
    public partial class frmEditTestType : Form
    {
        clsTestType _TestType;
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public frmEditTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this._TestTypeID = TestTypeID;
        }

        private void _LoadData()
        {
            _TestType = clsTestType.Find(_TestTypeID);
            lblTestTypeID.Text = _TestTypeID.ToString();
            txtTestTypeTitle.Text = _TestType.Title;
            txtTestTypeDescription.Text = _TestType.Description;
            txtTestTypeFees.Text = _TestType.Fees.ToString();
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

        private void txtTestTypeFees_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Fix Validation Errors Before Saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _TestType.Title = txtTestTypeTitle.Text;
            _TestType.Description = txtTestTypeDescription.Text;
            _TestType.Fees = Convert.ToSingle(txtTestTypeFees.Text);

            if (_TestType.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
