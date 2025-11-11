using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        public int PersonID { get; set; }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void FillPersonData(clsPerson Person)
        {
            PersonID = Person.PersonID;

            lblPersonID.Text = PersonID.ToString();
            lblName.Text = Person.FullName;
            lblNationalNo.Text = Person.NationalNo;
            lblGendor.Text = Person.Gendor == 0 ? "Male" : "Female";
            pbGendor.Image = Person.Gendor == 0 ? Resources.Man_32 : Resources.Woman_32;
            lblEmail.Text = Person.Email;
            lblAddress.Text = Person.Address;
            lblDOB.Text = clsFormat.DateToShort(Person.DateOfBirth);
            lblPhone.Text = Person.Phone;
            lblCountry.Text = Person.CountryInfo.CountryName;
        }

        private void lblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(PersonID);
            frm.ShowDialog();
        }
    }
}
