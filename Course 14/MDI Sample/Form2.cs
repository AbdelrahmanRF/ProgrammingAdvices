using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI_Sample
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void tsmClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void tsmChangeBackColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.OK) return;

            textBox1.BackColor = colorDialog1.Color;
        }

        private void tsmChangeFont_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowEffects = true;
            fontDialog1.ShowColor = true;

            fontDialog1.Font = textBox1.Font;

            if (fontDialog1.ShowDialog() != DialogResult.OK) return;

            textBox1.Font = fontDialog1.Font;
            textBox1.ForeColor = fontDialog1.Color;
        }
    }
}
