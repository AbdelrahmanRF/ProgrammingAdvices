using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_misc_2
{
    public partial class MaskedTextBox : Form
    {
        public MaskedTextBox()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                maskedTextBox1.BackColor = Color.LawnGreen;
            }
            else
            {
                maskedTextBox1.BackColor = Color.Tomato;
            }
        }
    }
}
