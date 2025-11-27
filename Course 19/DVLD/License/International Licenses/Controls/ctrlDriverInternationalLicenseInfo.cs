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

namespace DVLD.License.International_Licenses.Controls
{
    public partial class ctrlDriverInternationalLicenseInfo : UserControl
    {
        clsInternationalLicense _InternationalLicense;
        clsPerson _PersonInfo;
        public ctrlDriverInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void FillInternationalLicenseData(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);
            _PersonInfo = _InternationalLicense.DriveInfo.PersonInfo;
            bool isMale = _PersonInfo.Gendor == 0;

            lblName.Text = _PersonInfo.FullName;
            lblIntLicenseID.Text = InternationalLicenseID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicenseID.ToString();
            lblNationalNo.Text = _PersonInfo.NationalNo;
            lblGendor.Text = isMale ? "Male" : "Female";
            pbGendor.Image = isMale ? Resources.Man_32 : Resources.Woman_32;
            lblIssueDate.Text = clsFormat.DateToShort(_InternationalLicense.IssueDate);
            lblApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive ? "Yes" : "No";
            lblDOB.Text = clsFormat.DateToShort(_PersonInfo.DateOfBirth);
            lblDriverID.Text = _InternationalLicense.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.DateToShort(_InternationalLicense.ExpirationDate);

            if (_PersonInfo.ImagePath != "")
                pbImage.Load(_PersonInfo.ImagePath);
            else
                pbImage.Image = isMale? Resources.Male_512 : Resources.Female_512;
        }
    }
}
