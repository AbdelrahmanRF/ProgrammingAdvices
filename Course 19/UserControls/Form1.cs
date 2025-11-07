using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShowResult_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ctrlSimpleCalc1.Result.ToString());
        }

        private void ctrlSimpleCalc1_onCalculationEnd(double obj)
        {
            double Result = obj;
            MessageBox.Show(Result.ToString());
        }
    }
}
