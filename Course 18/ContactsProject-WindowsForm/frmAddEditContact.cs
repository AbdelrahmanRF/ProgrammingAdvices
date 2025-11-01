using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsProject_WindowsForm
{
    public partial class frmAddEditContact : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }

        enMode _Mode = enMode.AddNew;
        int _ContactID = 0;
        clsContact _Contact;
        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (ContactID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;
        }

        private void _FillCountriesInComboBox()
        {
            DataTable dt = clsCountry.GetAllCountries();

            foreach (DataRow Row in dt.Rows)
            {
                cbCountry.Items.Add(Row["CountryName"]);
            }
        }

        private void _LoadData()
        {
            _FillCountriesInComboBox();
            cbCountry.SelectedIndex = 0;

            if (_Mode == enMode.AddNew)
            {
                lblFormTitle.Text = "Add New Contact";
                _Contact = new clsContact();
                return;
            }

            _Contact = clsContact.Find(_ContactID);
            lblFormTitle.Text = "Edit Contact ID = " + _Contact.ID;
            lblContactID.Text = _Contact.ID.ToString();
            txtFirstName.Text = _Contact.FirstName;
            txtLastName.Text = _Contact.LastName;
            txtEmail.Text = _Contact.Email;
            txtPhone.Text = _Contact.Phone;
            dtpDOB.Value = _Contact.DateOfBirth;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountry.FindByID(_Contact.CountryID).CountryName);
            txtAddress.Text = _Contact.Address;

            if (_Contact.ImagePath != "")
            {
                pbImage.Load(_Contact.ImagePath);
            }

            linkRemove.Visible = _Contact.ImagePath != "";
        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void linkRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.ImageLocation = null;
            linkRemove.Visible = false;
        }

        private void linkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;

                pbImage.Load(selectedFilePath);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.FindByName(cbCountry.Text).CountryID;
            _Contact.FirstName = txtFirstName.Text;
            _Contact.LastName = txtLastName.Text;
            _Contact.Email = txtEmail.Text;
            _Contact.Phone = txtPhone.Text;
            _Contact.Address = txtAddress.Text;
            _Contact.DateOfBirth = dtpDOB.Value;
            _Contact.CountryID = CountryID;

            if (pbImage.ImageLocation != null)
                _Contact.ImagePath = pbImage.ImageLocation;
            else
                _Contact.ImagePath = "";

            if (_Contact.Save())
                MessageBox.Show("Data Saved Successfully");
            else
                MessageBox.Show("Error: Data is not saved");

            _Mode = enMode.Update;
            lblFormTitle.Text = "Edit Contact ID = " + _Contact.ID;
            lblContactID.Text = _Contact.ID.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
