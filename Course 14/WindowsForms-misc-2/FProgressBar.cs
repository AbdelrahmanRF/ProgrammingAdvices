using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsForms_misc_2
{
    public partial class FProgressBar : Form
    {
        public FProgressBar()
        {
            InitializeComponent();
        }

        private void btnIncreaseProgress_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                if(progressBar1.Value < progressBar1.Maximum)
                {
                    Thread.Sleep(500);

                    progressBar1.Value += 10;
                    lblProgressPercentage.Text = (((float)progressBar1.Value / progressBar1.Maximum) * 100) + "%";

                    progressBar1.Refresh();
                    lblProgressPercentage.Refresh();
                }
                else
                {
                    btnIncreaseProgress.Enabled = false;
                }
            }
        }

        private void btnResetProgress_Click(object sender, EventArgs e)
        {
            lblProgressPercentage.Text = "0%";
            progressBar1.Value = 0;
            btnIncreaseProgress.Enabled = true;
        }
    }
}
