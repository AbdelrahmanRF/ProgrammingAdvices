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
            UpdateTotalPrice();
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

            foreach (CheckBox Topping in gbToppings.Controls.OfType<CheckBox>())
                Topping.Checked = false;
        }

        private void UpdateSize()
        {
            UpdateTotalPrice();

            if (sizeMedium.Checked)
            {
                osSizeValue.Text = "Medium";
            }
            else if (sizeSmall.Checked)
            {
                 osSizeValue.Text = "Small";
            }
            else
            {
                 osSizeValue.Text = "Large";
            }
        }

        private void UpdateCrust()
        {
            UpdateTotalPrice();

            osCrustTypeValue.Text = crustTypeThick.Checked ? "Thick Crust" : "Thin Crust";
        }

        private void UpdateToppings()
        {
            UpdateTotalPrice();

            byte Counter = 0;
            var selectedToppings = gbToppings.Controls.OfType<CheckBox>()
                .OrderBy(Topping => Topping.TabIndex)
                .Where(Topping => Topping.Checked);

            var stSelectedToppings = new System.Text.StringBuilder();

            if (!selectedToppings.Any(el => el.Checked))
            {
                osToppingsValue.Text = "No Toppings";
                return;
            }

            foreach (CheckBox Topping in selectedToppings)
            {
                ++Counter;

                if (Counter > 1) stSelectedToppings.Append(", ");

                stSelectedToppings.Append(Topping.Text);

                if (Counter % 3 == 0) stSelectedToppings.Append("\n");
            }

            osToppingsValue.Text = stSelectedToppings.ToString();

        }

        float GetCrustTypePrice()
        {
            if (crustTypeThin.Checked)
            {
                return Convert.ToSingle(crustTypeThin.Tag);
            }

            return Convert.ToSingle(crustTypeThick.Tag);
        }

        float CalculateToppingsPrice()
        {
            float Total = 0;

            foreach (CheckBox Topping in gbToppings.Controls.OfType<CheckBox>()) 
            {
                if (Topping.Checked)
                    Total += Convert.ToSingle(Topping.Tag);
            }

            return Total;
        }

        float GetSelectedSizePrice()
        {
            if (sizeSmall.Checked)
            {
                return Convert.ToSingle(sizeSmall.Tag);
            }

            if (sizeMedium.Checked)
            {
                return Convert.ToSingle(sizeMedium.Tag);
            }

            return Convert.ToSingle(sizeLarge.Tag);
        }

        float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalculateToppingsPrice() + GetCrustTypePrice();
        }

        private void UpdateTotalPrice()
        {
            osTotalPriceValue.Text = "$" + CalculateTotalPrice().ToString();
        }

        private void sizeSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void sizeMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void sizeLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void crustTypeThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void crustTypeThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void toppingExtraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void toppingOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void toppingMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void toppingOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void toppingTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void toppingGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }
    }
}
