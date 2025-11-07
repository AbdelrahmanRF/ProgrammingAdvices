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
    public partial class Form3 : Form
    {
        // Declare a Delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an Event Using the Delegate
        public event DataBackEventHandler DataBack;

        public Form3()
        {
            InitializeComponent();
        }

        private void btnSendDataBack_Click(object sender, EventArgs e)
        {
            int PersonID = int.Parse(tbForm3PersonID.Text);

            DataBack?.Invoke(this, PersonID);

            this.Close();
        }
    }
}
