using DVLD.Global_Classes;
using DVLD.Properties;
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
using static DVLD_Business.clsTestType;

namespace DVLD.Tests.Controls
{
    public partial class ctrlScheduledTest : UserControl
    {
        clsTestAppointment _TestAppointment;
        int _TestAppointmentID = -1;
        clsLocalDrivingLicenseApplication _LDLApplication;
        int _LDLApplicationID = -1;
        clsTestType.enTestType _TestTypeID = enTestType.VisionTest;
        int _TestID = -1;

        public int TestID
        {
            get
            {
                return _TestID;
            }
        }
        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }
        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }

            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        pbTestTypeImage.Image = Resources.Vision_512;
                        gbTestType.Text = "Vision Test";
                        break;

                    case clsTestType.enTestType.WrittenTest:
                        pbTestTypeImage.Image = Resources.Written_Test_512;
                        gbTestType.Text = "Written Test";
                        break;

                    case clsTestType.enTestType.StreetTest:
                        pbTestTypeImage.Image = Resources.driving_test_512;
                        gbTestType.Text = "Street Test";
                        break;
                }
            }
        }

        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        public void FillScheduledTestInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _TestAppointment = clsTestAppointment.Find(_TestAppointmentID);

            if (_TestAppointment == null)
            {
                MessageBox.Show($"Error: No  Appointment ID = {_TestAppointmentID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;
            _LDLApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(_LDLApplicationID);

            if (_LDLApplication == null)
            {
                MessageBox.Show($"Error: No Local Driving License Application with ID = {_LDLApplicationID}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblLocalDrivingLicenseAppID.Text = _LDLApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDrivingClass.Text = _LDLApplication.LicenseClassInfo.ClassName;
            lblFullName.Text = _LDLApplication.FullName;
            lblTrial.Text = _LDLApplication.TotalTrialsPerTest(_TestTypeID).ToString();
            lblDate.Text = clsFormat.DateToShort(_TestAppointment.AppointmentDate);
            lblFees.Text = _TestAppointment.PaidFees.ToString();
            lblTestID.Text = _TestAppointment.TestID == -1 ? "Not Taken Yet" : _TestAppointment.TestID.ToString();
        }
    }
}
