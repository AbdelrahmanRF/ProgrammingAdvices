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

namespace DVLD.License
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        int _PersonID;
        clsDriver _Driver;
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            _PersonID = PersonID;

            _Driver = clsDriver.FindByPersonID(PersonID);
        }
        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.DisplayPersonInfo(this._PersonID);

            if (_Driver == null) return;
                ctrlDriverLicenses1.FillDriverLicensesHistory(this._Driver.DriverID);
        }
    }
}
