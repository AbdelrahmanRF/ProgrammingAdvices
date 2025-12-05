using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Events
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculator1_OnCalculationComplete(object sender, Calculator.CalculationCompleteEventArgs e)
        {
            MessageBox.Show($"Val1 = {e.Val1}, Val2 = {e.Val2}, Result = {e.Result}");
        }
    }
}
