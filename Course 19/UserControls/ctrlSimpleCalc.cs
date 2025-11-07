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
    public partial class ctrlSimpleCalc : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<double> onCalculationEnd;

        // Create a protected method to raise the event with a parameter
        protected virtual void CalculationEnd(double CalculationResult)
        {
            Action<double> Handler = onCalculationEnd;

            if (Handler != null)
            {
                Handler(CalculationResult); // Raise the event with the parameter
            }
        }
        public ctrlSimpleCalc()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool Num1IsValid = double.TryParse(tbNum1.Text, out double Num1);
            bool Num2IsValid = double.TryParse(tbNum2.Text, out double Num2);

            if (Num1IsValid && Num2IsValid)
            {
                double Sum = Num1 + Num2;
                lblResult.Text = Sum.ToString();

                if (onCalculationEnd != null)
                {
                    // Raise the event with a parameter
                    onCalculationEnd(Sum);
                }
            }
            else
            {
                MessageBox.Show("Please ensure both inputs are valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!Num1IsValid)
                {
                    tbNum1.Text = "";
                    tbNum1.Focus();
                }
                else if (!Num2IsValid)
                {
                    tbNum2.Text = "";
                    tbNum2.Focus();
                }

                lblResult.Text = "0";
            }
        }

        public float Result 
        { 
            get { 
                return (float)Convert.ToDouble(lblResult.Text);
            } 
        }

        
    }
}
