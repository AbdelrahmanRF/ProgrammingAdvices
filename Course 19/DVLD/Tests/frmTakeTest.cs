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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        clsTest _Test;
        int _TestAppointmentID = -1;
        clsTestAppointment _TestAppointment;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this._TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);

            if (_TestAppointment.TestID != -1)
                _Test = clsTest.Find(_TestAppointment.TestID);
            else
                _Test = new clsTest();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.FillScheduledTestInfo(_TestAppointmentID);

            if (_Test.TestID != -1)
            {
                lblUserMessage.Visible = true;
                btnSave.Enabled = false;
                rbPass.Enabled = false;
                rbFail.Enabled = false;
                txtNotes.Enabled = false;

                if(_Test.TestResult == true)
                    rbPass.Checked = true;
                else
                    rbFail.Checked = true;

                    txtNotes.Text = _Test.Notes;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPass.Checked;
            _Test.Notes = txtNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (MessageBox.Show("Are you sure you want to save? After that, you cannot change the Pass/Fail results.",
                "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (_Test.Save())
                {
                    if (MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information) 
                        == DialogResult.OK)
                    {
                        _TestAppointment.IsLocked = true;
                        _TestAppointment.Save();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
