using DVLD.Tests.Controls;
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
    public partial class frmScheduleTest : Form
    {
        int _LDLApplicationID = -1;
        int _TestAppointmentID = -1;
        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public frmScheduleTest(int LDLApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();

            this._LDLApplicationID = LDLApplicationID;
            this._TestTypeID = TestTypeID;
            this._TestAppointmentID = TestAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            crlScheduleTest1.TestTypeID = _TestTypeID;
            crlScheduleTest1.FillTestInfo(_LDLApplicationID, _TestAppointmentID);
        }
    }
}
