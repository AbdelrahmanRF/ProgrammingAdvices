using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsForms_misc_1.Properties;

namespace WindowsForms_misc_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pbPlayerPic.Image = Resources.Messi;
            lbPlayerName.Text = ((Button)sender).Tag.ToString();
            lbPlayerName.ForeColor = Color.Maroon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pbPlayerPic.Image = Resources.Ronaldo;
            lbPlayerName.Text = ((Button)sender).Tag.ToString();
            lbPlayerName.ForeColor = Color.FromArgb(255, 12, 22, 23);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pbPlayerPic.Image = Image.FromFile(@"C:\Users\NewAdmin\Downloads\Modric.jpg");
            lbPlayerName.Text = ((Button)sender).Tag.ToString();
            lbPlayerName.ForeColor = Color.FromArgb(255, 11, 37, 79);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color Black = Color.FromArgb(255, 0, 0, 0);
            Pen Pen = new Pen(Black);

            Pen.Width = 5;

            Pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(Pen, 455, 60, 455, 84);
        }
    }
}
