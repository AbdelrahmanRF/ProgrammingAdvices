using DVLD.Global_Classes;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.License.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        private int _LicenseID = -1;
        clsLicense _License;
        clsPerson _PersonInfo;
        public int LicenseID
        {
            get {  return _LicenseID; }
        }
        public clsLicense SelectedLicenseInfo
        {
            get { return _License; }
        }

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        private void _LoadPersonImage()
        {
            pbImage.Image = _PersonInfo.Gendor == 0 ? Resources.Male_512 : Resources.Female_512;

            string ImagePath = _PersonInfo.ImagePath;

            if (ImagePath != "")
            {
                if (File.Exists(ImagePath)) 
                    pbImage.ImageLocation = _PersonInfo.ImagePath;
                else
                    MessageBox.Show($"Could not Find this Image : {ImagePath}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public void FillDriverLicensesData(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.FindByLicenseID(_LicenseID);

            if (_License == null)
            {
                MessageBox.Show($"Could not Find License ID = {LicenseID}",
                    "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _LicenseID = -1;
                return;
            }

            _PersonInfo = _License.DriveInfo.PersonInfo;
            _LoadPersonImage();

            lblLicenseClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _PersonInfo.FullName;
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = _PersonInfo.NationalNo;
            lblGendor.Text = _PersonInfo.Gendor == 0 ? "Male" : "Female";
            pbGendor.Image = _PersonInfo.Gendor == 0 ? Resources.Man_32 : Resources.Woman_32;
            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDOB.Text = clsFormat.DateToShort(_PersonInfo.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
        }

        public void Clear()
        {
            _License = null;
            _PersonInfo = null;

            lblLicenseClass.Text = "???";
            lblLicenseID.Text = "???";
            lblIssueDate.Text = "???";
            lblIssueReason.Text = "???";
            lblNotes.Text = "???";
            lblIsActive.Text = "???";
            lblDriverID.Text = "???";
            lblExpirationDate.Text = "???";
            lblIsDetained.Text = "???";

            lblName.Text = "???";
            lblNationalNo.Text = "???";
            lblGendor.Text = "???";
            lblDOB.Text = "???";

            pbImage.Image = Resources.Male_512;

            pbGendor.Image = Resources.Man_32;
        }
    }
}
