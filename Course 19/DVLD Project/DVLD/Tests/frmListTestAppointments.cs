using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsApplication;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Tests
{
    public partial class frmListTestAppointments : Form
    {
        int _LDLApplicationID;
        clsTestType.enTestType _TestTypeID;
        clsLocalDrivingLicenseApplication _LDLApplication;

        public frmListTestAppointments(int LDLApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this._LDLApplicationID = LDLApplicationID;
            this._LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(LDLApplicationID);
            this._TestTypeID = TestTypeID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _RefreshTestAppointments()
        {
            DataTable DT = clsTestAppointment
                .GetApplicationTestAppointmentsByTestType(this._LDLApplicationID, this._TestTypeID);

            dgvLicenseTestAppointments.DataSource = DT;
            lblTotalRecords.Text = dgvLicenseTestAppointments.Rows.Count.ToString();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlDrivingLicenseApplicationInfo1.FillDrivingApplicationData(_LDLApplicationID, _LDLApplication.ApplicationID);
            _RefreshTestAppointments();

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
            }

            if (this._TestTypeID == clsTestType.enTestType.VisionTest)
            {
                this.Text = "Vision Test Appointments";
                lblTestType.Text = this.Text;
                pbTestTypeImage.Image = Resources.Vision_512;
            }
            else if (this._TestTypeID == clsTestType.enTestType.WrittenTest)
            {
                this.Text = "Written Test Appointments";
                lblTestType.Text = this.Text;
                pbTestTypeImage.Image = Resources.Written_Test_512;
            }
            else
            {
                this.Text = "Street Test Appointments";
                lblTestType.Text = this.Text;
                pbTestTypeImage.Image = Resources.driving_test_512;
            }
        }

        private void _ShowScheduleTestForm(int TestAppointmentID = -1)
        {
            frmScheduleTest frm = new frmScheduleTest(this._LDLApplicationID, this._TestTypeID, TestAppointmentID);
            frm.ShowDialog();
            _RefreshTestAppointments();
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            bool isThereActiveTestAppointment = clsLocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_LDLApplicationID, _TestTypeID); ;

            clsTestAppointment LatestTestAppointment = clsTestAppointment
                .GetLatestTestAppointment(this._LDLApplicationID, this._TestTypeID);

            if (isThereActiveTestAppointment)
            {
                MessageBox.Show("Person Already have an Active Appointment for this Test, You Cannot Add New Appointment", 
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_LDLApplication.DoesPassTestType(_TestTypeID))
            {
                MessageBox.Show("This Person Already Passed this Test Before, You Can Only Retake Failed Test",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ShowScheduleTestForm();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            _ShowScheduleTestForm(TestAppointmentID);
        }

        private void tsmiTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(TestAppointmentID);
            frm.ShowDialog();

            _RefreshTestAppointments();
        }
    }
}
