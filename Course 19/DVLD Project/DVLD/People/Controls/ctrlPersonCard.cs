using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        clsPerson _Person;
        public int PersonID 
        { 
            get { return _PersonID; }
        }

        public clsPerson SelectedPerson
        {
            get { return _Person; }
        }

        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void FillPersonData(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);

            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"No Person with PersonID = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadPersonDataToControl();
        }

        public void FillPersonData(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"No Person with NationalNo = {NationalNo}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LoadPersonDataToControl();
        }

        private void _LoadPersonImage()
        {
            pbImage.Image = _Person.Gendor == 0 ? Resources.Male_512 : Resources.Female_512;

            string ImagePath = _Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbImage.ImageLocation = _Person.ImagePath;
                else
                 MessageBox.Show($"Could not Find this Image : {ImagePath}", 
                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void _LoadPersonDataToControl()
        {
            _PersonID = _Person.PersonID;
            _LoadPersonImage();
            lblEditPersonInfo.Visible = true;

            lblPersonID.Text = PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            pbGendor.Image = _Person.Gendor == 0 ? Resources.Man_32 : Resources.Woman_32;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDOB.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.CountryInfo.CountryName;
        }
        public void ResetPersonInfo()
        {
            lblPersonID.Text = "???";
            lblName.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            pbGendor.Image = Resources.Man_32;
            lblEmail.Text = "???";
            lblAddress.Text = "???";
            lblDOB.Text = "??/??/????";
            lblPhone.Text = "???";
            lblCountry.Text = "???";
            pbImage.Image = Resources.Male_512;
            lblEditPersonInfo.Visible = false;
        }
        private void lblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            FillPersonData(_PersonID);
        }
    }
}
