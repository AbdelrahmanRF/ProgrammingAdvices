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
using static DVLD_Business.clsTestType;
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
                .GetApplicationTestAppointmentsByTestType(_LDLApplicationID, _TestTypeID);

            dgvLicenseTestAppointments.DataSource = DT;
            lblTotalRecords.Text = dgvLicenseTestAppointments.Rows.Count.ToString();
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                        lblTestType.Text = "Vision Test Appointments";
                        this.Text = lblTestType.Text;
                        pbTestTypeImage.Image = Resources.Vision_512;
                        break;

                case clsTestType.enTestType.WrittenTest:
                    lblTestType.Text = "Written Test Appointments";
                        this.Text = lblTestType.Text;
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        break;

                case clsTestType.enTestType.StreetTest:
                    lblTestType.Text = "Street Test Appointments";
                        this.Text = lblTestType.Text;
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        break;
            }
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            ctrlDrivingLicenseApplicationInfo1.FillDrivingApplicationData(_LDLApplicationID);
            _RefreshTestAppointments();

            if (dgvLicenseTestAppointments.Rows.Count > 0)
            {
                dgvLicenseTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvLicenseTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvLicenseTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvLicenseTestAppointments.Columns[3].HeaderText = "Is Locked";
            }
            
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(_LDLApplicationID);

            clsTestAppointment LatestTestAppointment = clsTestAppointment
                .GetLatestTestAppointment(_LDLApplicationID, _TestTypeID);

            if (LDLApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already have an Active Appointment for this Test, You Cannot Add New Appointment", 
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTest LatestTest = LDLApplication.GetLatestTestPerTestType(_TestTypeID);

            if (LatestTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LDLApplicationID, _TestTypeID);
                frm1.ShowDialog();
                _RefreshTestAppointments();
                return;
            }

            if (LatestTest.TestResult == true)
            {
                MessageBox.Show("This Person Already Passed this Test Before, You Can Only Retake Failed Test",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest(_LDLApplicationID, _TestTypeID);
            frm2.ShowDialog();
            _RefreshTestAppointments();
        }

        private void tsmiEdit_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;

            frmScheduleTest frm = new frmScheduleTest(_LDLApplicationID, _TestTypeID, TestAppointmentID);
            frm.ShowDialog();
            _RefreshTestAppointments();
        }

        private void tsmiTakeTest_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)dgvLicenseTestAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(TestAppointmentID, _TestTypeID);
            frm.ShowDialog();

            _RefreshTestAppointments();
        }
    }
}
