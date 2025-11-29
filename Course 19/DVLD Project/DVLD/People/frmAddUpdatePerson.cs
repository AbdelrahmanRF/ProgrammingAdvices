using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        int _PersonID = -1;
        public enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.AddNew;
        clsPerson _Person;

        public delegate void DataBackEventHandler(int PersonID);
        public event DataBackEventHandler DataBack;

        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            _Mode = enMode.Update;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable DT = clsCountry.GetAllCountries();

            foreach(DataRow Row in DT.Rows)
            {
                cbCountry.Items.Add(Row["CountryName"].ToString());
            }
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                lblFormTitle.Text = "Update Person";
            }

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;

            dtpDOB.MaxDate = DateTime.Now.AddYears(-18);
            dtpDOB.MinDate = DateTime.Now.AddYears(-100);
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            lblPersonID.Text = _PersonID.ToString();
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
                pbImage.ImageLocation = _Person.ImagePath;
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
            string NationalNo = txtBox.Text.Trim();

            bool IDExists = clsPerson.isPersonExist(NationalNo);
            bool IsSamePerson = (_Mode == enMode.Update) && (_Person.NationalNo == NationalNo);

            if (String.IsNullOrEmpty(NationalNo))
            {
                e.Cancel = true;
                txtBox.Focus();
                errorProvider1.SetError(txtBox, $"{txtBox.Tag} Cannot be Empty!");
            } 
            else if (IDExists && !IsSamePerson)
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
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
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

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
 
                    }
                }

                if (pbImage.ImageLocation != null)
                {
                    string SourceImageFile = pbImage.ImageLocation.ToString();

                    if (Util.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Fix Validation Errors Before Saving.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_HandlePersonImage())
                return;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();

            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Gendor = (short)(rbMale.Checked ? 0 : 1);
            _Person.DateOfBirth = dtpDOB.Value;
            _Person.Address = txtAddress.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();

            _Person.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;

            if (pbImage.ImageLocation != null)
                _Person.ImagePath = pbImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Mode = enMode.Update;
                lblFormTitle.Text = "Update Person";
                lblPersonID.Text = _Person.PersonID.ToString();
                DataBack?.Invoke(_Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImage.ImageLocation != null) return;

            if (rbMale.Checked)
                pbImage.Image = Resources.Male_512;
            else
                pbImage.Image = Resources.Female_512;
        }
    }
}
