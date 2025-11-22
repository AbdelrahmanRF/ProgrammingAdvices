using DVLD.Global_Classes;
using DVLD.Properties;
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

namespace DVLD.License.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        clsLicense _License;
        clsPerson _PersonInfo;
        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void FillDriverLicensesData(int LicenseID)
        {
            _License = clsLicense.FindByLicenseID(LicenseID);
            _PersonInfo = _License.DriveInfo.PersonInfo;

            lblLicenseClass.Text = _License.LicenseClassInfo.ClassName;
            lblName.Text = _PersonInfo.FullName;
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = _PersonInfo.NationalNo;
            lblGendor.Text = _PersonInfo.Gendor == 0 ? "Male" : "Female";
            pbGendor.Image = _PersonInfo.Gendor == 0 ? Resources.Man_32 : Resources.Woman_32;

            if (_PersonInfo.ImagePath != "")
            {
                pbImage.ImageLocation = _PersonInfo.ImagePath;
            }
            else
            {
                pbImage.Image = lblGendor.Text == "Male" ? Resources.Male_512 : Resources.Female_512;
            }

            lblIssueDate.Text = clsFormat.DateToShort(_License.IssueDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblDOB.Text = clsFormat.DateToShort(_PersonInfo.DateOfBirth);
            lblDriverID.Text = _License.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_License.ExpirationDate);
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
        }
    }
}
