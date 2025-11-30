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
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }
        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.DisplayPersonInfo(this._PersonID);

            if (_PersonID == -1) 
                return;

            ctrlDriverLicenses1.FillDriverLicensesHistoryByPersonID(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
