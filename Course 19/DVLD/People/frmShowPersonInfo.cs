using DVLD.People.Controls;
using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmShowPersonInfo : Form
    {
        string _NationalNo = "";
        public frmShowPersonInfo(string NationalNo)
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MaximizeBox = false;

            this._NationalNo = NationalNo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find(_NationalNo);
            ctrlPersonCard1.FillPersonData(Person);
        }
    }
}
