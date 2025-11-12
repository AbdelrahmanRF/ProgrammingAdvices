using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Data;
using System.Diagnostics.Contracts;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        int _PersonID = -1;
        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        clsPerson _Person;
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            this.MinimizeBox = false;
            this.MaximizeBox = false;

            _PersonID = PersonID;

            if (PersonID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void FillCountriesInComboBox()
        {
            DataTable DT = clsCountry.GetAllCountries();

            foreach(DataRow Row in DT.Rows)
            {
                cbCountry.Items.Add(Row["CountryName"].ToString());
            }
        }

        private void _LoadData()
        {
            FillCountriesInComboBox();
            dtpDOB.MaxDate = DateTime.Now.AddYears(-18);

            if (_Mode == enMode.AddNew)
            {
                cbCountry.SelectedIndex = cbCountry.FindString("Jordan");
                _Person = new clsPerson();
                return;
            }

            _Person = clsPerson.Find(_PersonID);
            lblFormTitle.Text = "Update Person";
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            dtpDOB.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 1)
            {
                rbFemale.Checked = true;
            }

            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            txtAddress.Text = _Person.Address;
            cbCountry.SelectedIndex = cbCountry.FindString(_Person.CountryInfo.CountryName);

            if (_Person.ImagePath != "")
            {
                pbImage.Load(_Person.ImagePath);
            }
            lblRemoveImage.Visible = _Person.ImagePath != "";
        }

        private void ValidateNullOrEmpty(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (String.IsNullOrEmpty(txtBox.Text.Trim()))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, $"{txtBox.Tag} Cannot be Empty!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
        }

        private void ValidateNationalNo(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (String.IsNullOrEmpty(txtBox.Text.Trim()))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, $"{txtBox.Tag} Cannot be Empty!");
            }
            else if (clsPerson.isPersonExist(txtBox.Text))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, "National ID is Used for Another Person!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
        }

        private void ValidateEmail(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBox = sender as TextBox;

            if (String.IsNullOrEmpty(txtBox.Text.Trim()))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
            else if (!clsValidation.ValidateEmail(txtBox.Text.Trim()))
            {
                e.Cancel= true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, "Invalid Email Address Format!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBox, "");
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;
                lblRemoveImage.Visible = true;

                Util.CopyImageToProjectImagesFolder(ref selectedFilePath);

                pbImage.Load(selectedFilePath);

            }
        }

        private void lblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            pbImage.Image = rbMale.Checked ? Resources.Male_512 : Resources.Female_512;
            lblRemoveImage.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;

            if (txtThirdName.Text != null)
                _Person.ThirdName = txtThirdName.Text;
            else
                _Person.ThirdName = "";

            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.Gendor = (short)(rbMale.Checked ? 0 : 1);
            _Person.DateOfBirth = dtpDOB.Value;
            _Person.Address = txtAddress.Text;

            if (txtEmail.Text != null)
                _Person.Email = txtEmail.Text;
            else
                _Person.ThirdName = "";

            _Person.Phone = txtPhone.Text;
            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;

            if (pbImage.ImageLocation != null)
                _Person.ImagePath = pbImage.ImageLocation;
            else
                _Person.ImagePath = "";

            _Person.Save();
            _Mode = enMode.Update;
            lblFormTitle.Text = "Update Person";
            lblPersonID.Text = _Person.PersonID.ToString();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (_Person.ImagePath != "") return;

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;
        }
    }
}
