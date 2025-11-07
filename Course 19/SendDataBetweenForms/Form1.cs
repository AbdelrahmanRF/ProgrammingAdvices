using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendDataBetweenForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if (int.TryParse(tbPersonID.Text, out PersonID))
            {
                Form frm = new Form2(PersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Person ID Should be a Number!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPersonID.Focus();
            }

        }

        private void btnOpenForm3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.DataBack += SetPersonId; // Subscribe to the event
            frm.ShowDialog();
        }

        private void SetPersonId(object sender, int PersonID)
        {
            tbPersonIDFromForm3.Text = PersonID.ToString();
        }
    }
}
