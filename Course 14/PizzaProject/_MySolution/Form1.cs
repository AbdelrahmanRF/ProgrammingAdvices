using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            UpdatePizzaPrice();

        }
        private string GetSelectedPizzaSize()
        {
            string PizzaSize;
            if (sizeMedium.Checked)
            {
                PizzaSize = "Medium";
            }
            else if (sizeSmall.Checked)
            {
                PizzaSize = "Small";
            }
            else
            {
                PizzaSize = "Large";
            }

            return PizzaSize;
        }

        private void UpdatePizzaPrice()
        {
            int Total = 0;

            if (sizeMedium.Checked)
            {
                Total = crustTypeThick.Checked ? 40 : 30;
            }else if (sizeSmall.Checked)
            {
                Total = crustTypeThick.Checked ? 30 : 20;
            }
            else
            {
                Total = crustTypeThick.Checked ? 50 : 40;
            }

            foreach (CheckBox rb in gbToppings.Controls.OfType<CheckBox>())
            {
                if (rb.Checked)
                    Total += 5;
            }

            osTotalPriceValue.Text = "$" + Total.ToString();
        }

        private void UpdatePizzaToppingsList()
        {
            byte Counter = 0;
            var selectedToppings = gbToppings.Controls.OfType<CheckBox>();
            string stSelectedToppings = "";

            if (!selectedToppings.Any(el => el.Checked)) 
            {
                osToppingsValue.Text = "No Toppings";
                return;    
            }

            foreach (CheckBox st in selectedToppings)
            {
                if (st.Checked)
                {
                    ++Counter;

                    if (Counter > 1) stSelectedToppings += ", ";

                    stSelectedToppings += st.Text;

                    if (Counter == 3) stSelectedToppings += Environment.NewLine;

                }
            }

            osToppingsValue.Text = stSelectedToppings;
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Order", "Confirm", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;
                btnOrderPizza.Enabled = false;
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            btnOrderPizza.Enabled = true;

            sizeMedium.Checked = true;
            crustTypeThin.Checked = true;
            eatIn.Checked = true;

            foreach (CheckBox st in gbToppings.Controls.OfType<CheckBox>()) 
            {
                if (st.Checked) 
                    st.Checked = false;
            }
        }

        private void eatIn_CheckedChanged(object sender, EventArgs e)
        {
            osWheretoEatValue.Text = eatIn.Checked ? "Eat In" : "Take Out";
        }

        private void crustTypeThin_CheckedChanged(object sender, EventArgs e)
        {
            bool isThinCrust = crustTypeThin.Checked;
            osCrustTypeValue.Text = isThinCrust ? "Thin Crust" : "Thick Crust";

            UpdatePizzaPrice();
        }

        private void sizeMedium_CheckedChanged(object sender, EventArgs e)
        {
            osSizeValue.Text = GetSelectedPizzaSize();
            UpdatePizzaPrice();
        }

        private void sizeSmall_CheckedChanged(object sender, EventArgs e)
        {
            osSizeValue.Text = GetSelectedPizzaSize();
            UpdatePizzaPrice();
        }

        private void toppingOlives_CheckedChanged(object sender, EventArgs e)
        {
           UpdatePizzaPrice();
            UpdatePizzaToppingsList();
        }

        private void toppingOnion_CheckedChanged(object sender, EventArgs e)
        {
           UpdatePizzaPrice();
            UpdatePizzaToppingsList();
        }

        private void toppingExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
           UpdatePizzaPrice();
            UpdatePizzaToppingsList();
        }

        private void toppingMushrooms_CheckedChanged(object sender, EventArgs e)
        {
           UpdatePizzaPrice();
            UpdatePizzaToppingsList();
        }

        private void toppingTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePizzaPrice();
            UpdatePizzaToppingsList();
        }

        private void toppingGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePizzaPrice();
            UpdatePizzaToppingsList();
        }

    }
}
