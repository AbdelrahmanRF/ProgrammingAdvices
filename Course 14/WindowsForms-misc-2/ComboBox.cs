using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_misc_2.Properties;

namespace WindowsForms_misc_2
{
    public partial class ComboBox : Form
    {
        public ComboBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("New Option");
        }

        private void ComboBox_Load(object sender, EventArgs e)
        {
            cbPlayers.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.Text);

            switch (cbPlayers.SelectedIndex)
            {
                case 0:
                pbPlayerImg.Image = Resources.Messi;
                lblPlayerName.Text = "Messi";
                break;

                case 1:
                pbPlayerImg.Image = Resources.Ronaldo;
                lblPlayerName.Text = "Ronaldo";
                break;

                case 2:
                pbPlayerImg.Image = Resources.Modric;
                lblPlayerName.Text = "Modric";
                break;


            }
        }
    }
}
