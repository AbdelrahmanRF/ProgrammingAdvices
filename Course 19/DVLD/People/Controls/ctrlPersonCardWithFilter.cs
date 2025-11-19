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

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public clsPerson Person;
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();

            cbFindBy.SelectedIndex = 0;
        }

        private void btnSearchUser_Click(object sender, EventArgs e)
        {
            string FilterText = txtFilter.Text.Trim();

            if (cbFindBy.Text == "National ID")
                Person = clsPerson.Find(FilterText);
            else
            {
                if (int.TryParse(FilterText, out int PersonID))
                    Person = clsPerson.Find(PersonID);
            }

            if (Person == null)
                MessageBox.Show($"No Person with {cbFindBy.Text} = {FilterText}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ctrlPersonCard1.FillPersonData(Person);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.DataBack += ctrlPersonCard1.FillPersonData;
            frm.ShowDialog();
            Person = clsPerson.Find(ctrlPersonCard1.PersonID);
        }

        public void LoadPersonInfoForUpdate(int PersonID)
        {
            Person = clsPerson.Find(PersonID);

            if (Person == null)
            {
                MessageBox.Show($"No Person with PersonID = {PersonID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            gbFilter.Enabled = false;
            ctrlPersonCard1.FillPersonData(Person);
            txtFilter.Text = PersonID.ToString();
            cbFindBy.SelectedIndex = 1;
        }
    }
}
