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
        clsTestType.enTestType _TestTypeID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }

        public void FillScheduledTestInfo(int TestAppointmentID)
        {
            _TestAppointment = clsTestAppointment.Find(TestAppointmentID);
            _TestTypeID = _TestAppointment.TestTypeID;
            _LDLApplication = clsLocalDrivingLicenseApplication.FindByLDLApplicationID(_TestAppointment.LocalDrivingLicenseApplicationID);

            if (_TestTypeID == clsTestType.enTestType.VisionTest)
            {
                pbTestTypeImage.Image = Resources.Vision_512;
                gbTestType.Text = "Vision Test";
            }
            if (_TestTypeID == clsTestType.enTestType.WrittenTest)
            {
                pbTestTypeImage.Image = Resources.Written_Test_512;
                gbTestType.Text = "Written Test";
            }
            else
            {
                gbTestType.Text = "Street Test";
            }

            if (_TestAppointment.RetakeTestApplicationID != -1)
            {
                lblTitle.Text = "Schedule Retake Test";
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
