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
        int _RetakeTestID;
        clsTestType.enTestType _TestTypeID;
        clsLocalDrivingLicenseApplication _LDLApplication;
        clsApplication _RetakeTestApplication;
        public frmScheduleTest(int LDLApplicationID, clsTestType.enTestType TestTypeID)
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
    }
}
