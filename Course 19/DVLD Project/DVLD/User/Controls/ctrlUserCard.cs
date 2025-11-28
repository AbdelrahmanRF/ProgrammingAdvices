using DVLD.People.Controls;
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

namespace DVLD.User.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public int UserID { get; set; }
        public ctrlUserCard()
        {
            InitializeComponent();
        }

        public void FillUserData(clsUser User)
        {
            ctrlPersonCard1.FillPersonData(clsPerson.Find(User.PersonID));
            lblUserID.Text = User.UserID.ToString();
            lblUserName.Text = User.Username;
            lblIsActive.Text = User.isActive ? "Yes" : "No";
        }
    }
}
