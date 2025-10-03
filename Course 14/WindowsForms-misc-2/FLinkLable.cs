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
    public partial class FLinkLable : Form
    {
        public FLinkLable()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FLinkLabel.LinkVisited = true;

            System.Diagnostics.Process.Start("www.linkedin.com/in/abd-alrahman-alfar-233a68269");
        }
    }
}
