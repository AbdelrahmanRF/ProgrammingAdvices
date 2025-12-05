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
    public partial class Calculator : UserControl
    {
        public class CalculationCompleteEventArgs : EventArgs
        {
            public int Val1 { get; }
            public int Val2 { get; }
            public int Result { get; }

            public CalculationCompleteEventArgs(int Result, int Val1, int Val2)
            {
                this.Val1 = Val1;
                this.Val2 = Val2;
                this.Result = Result;
            }
        }


        public event EventHandler<CalculationCompleteEventArgs> OnCalculationComplete;

        public void RaiseCalculationComplete(int Result, int Val1, int Val2)
        {
            RaiseCalculationComplete(new CalculationCompleteEventArgs(Result, Val1, Val2));
        }

        protected virtual void RaiseCalculationComplete(CalculationCompleteEventArgs e)
        {
            OnCalculationComplete?.Invoke(this, e);
        }

        public Calculator()
        {
            InitializeComponent();
        }

        private void _ResetUI()
        {
            txtNumber1.Text = "";
            txtNumber2.Text = "";
            lblResult.Text = "???";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNumber1.Text, out int Number1) && int.TryParse(txtNumber2.Text, out int Number2))
            {
                int Result = Number1 + Number2;

                lblResult.Text = Result.ToString();

                if (OnCalculationComplete != null)
                    RaiseCalculationComplete(Result, Number1, Number2);
            }
            else
            {
                _ResetUI();

                if (OnCalculationComplete != null)
                    RaiseCalculationComplete(int.MinValue, int.MinValue, int.MinValue);
            }
        }
    }
}
