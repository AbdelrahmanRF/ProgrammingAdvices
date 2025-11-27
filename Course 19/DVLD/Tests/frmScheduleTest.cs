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
        int _LDLApplicationID;
        int _TestAppointmentID;
        clsTestType.enTestType _TestTypeID;
        public frmScheduleTest(int LDLApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            this._LDLApplicationID = LDLApplicationID;
            this._TestTypeID = TestTypeID;
        }

        public frmScheduleTest(int LDLApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID)
                : this(LDLApplicationID, TestTypeID)
        {
            this._TestAppointmentID = TestAppointmentID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            crlScheduleTest1.FillTestInfo(_LDLApplicationID, _TestTypeID, _TestAppointmentID);
        }
    }
}
