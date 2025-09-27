namespace PizzaProject
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelHeader = new System.Windows.Forms.Label();
            this.sizeSmall = new System.Windows.Forms.RadioButton();
            this.sizeMedium = new System.Windows.Forms.RadioButton();
            this.sizeLarge = new System.Windows.Forms.RadioButton();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.gbCrustType = new System.Windows.Forms.GroupBox();
            this.crustTypeThick = new System.Windows.Forms.RadioButton();
            this.crustTypeThin = new System.Windows.Forms.RadioButton();
            this.gbWhereToEat = new System.Windows.Forms.GroupBox();
            this.eatOut = new System.Windows.Forms.RadioButton();
            this.eatIn = new System.Windows.Forms.RadioButton();
            this.btnOrderPizza = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.toppingExtraCheese = new System.Windows.Forms.CheckBox();
            this.toppingMushrooms = new System.Windows.Forms.CheckBox();
            this.toppingTomatoes = new System.Windows.Forms.CheckBox();
            this.toppingGreenPeppers = new System.Windows.Forms.CheckBox();
            this.toppingOlives = new System.Windows.Forms.CheckBox();
            this.toppingOnion = new System.Windows.Forms.CheckBox();
            this.gbToppings = new System.Windows.Forms.GroupBox();
            this.gbOrderSummary = new System.Windows.Forms.GroupBox();
            this.osWheretoEatValue = new System.Windows.Forms.Label();
            this.osCrustTypeValue = new System.Windows.Forms.Label();
            this.osToppingsValue = new System.Windows.Forms.Label();
            this.osSizeValue = new System.Windows.Forms.Label();
            this.osTotalPriceValue = new System.Windows.Forms.Label();
            this.osTotalPriceLabel = new System.Windows.Forms.Label();
            this.osWheretoEatLabel = new System.Windows.Forms.Label();
            this.osCrustTypeLabel = new System.Windows.Forms.Label();
            this.osToppingsLabel = new System.Windows.Forms.Label();
            this.osSizeLabel = new System.Windows.Forms.Label();
            this.gbSize.SuspendLayout();
            this.gbCrustType.SuspendLayout();
            this.gbWhereToEat.SuspendLayout();
            this.gbToppings.SuspendLayout();
            this.gbOrderSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.Color.Red;
            this.labelHeader.Location = new System.Drawing.Point(206, 24);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(454, 60);
            this.labelHeader.TabIndex = 0;
            this.labelHeader.Text = "Make Your Pizza";
            // 
            // sizeSmall
            // 
            this.sizeSmall.AutoSize = true;
            this.sizeSmall.Location = new System.Drawing.Point(27, 26);
            this.sizeSmall.Name = "sizeSmall";
            this.sizeSmall.Size = new System.Drawing.Size(50, 17);
            this.sizeSmall.TabIndex = 1;
            this.sizeSmall.Text = "Small";
            this.sizeSmall.UseVisualStyleBackColor = true;
            this.sizeSmall.CheckedChanged += new System.EventHandler(this.sizeSmall_CheckedChanged);
            // 
            // sizeMedium
            // 
            this.sizeMedium.AutoSize = true;
            this.sizeMedium.Checked = true;
            this.sizeMedium.Location = new System.Drawing.Point(27, 61);
            this.sizeMedium.Name = "sizeMedium";
            this.sizeMedium.Size = new System.Drawing.Size(62, 17);
            this.sizeMedium.TabIndex = 2;
            this.sizeMedium.TabStop = true;
            this.sizeMedium.Text = "Medium";
            this.sizeMedium.UseVisualStyleBackColor = true;
            this.sizeMedium.CheckedChanged += new System.EventHandler(this.sizeMedium_CheckedChanged);
            // 
            // sizeLarge
            // 
            this.sizeLarge.AutoSize = true;
            this.sizeLarge.Location = new System.Drawing.Point(27, 96);
            this.sizeLarge.Name = "sizeLarge";
            this.sizeLarge.Size = new System.Drawing.Size(52, 17);
            this.sizeLarge.TabIndex = 3;
            this.sizeLarge.TabStop = true;
            this.sizeLarge.Text = "Large";
            this.sizeLarge.UseVisualStyleBackColor = true;
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.sizeLarge);
            this.gbSize.Controls.Add(this.sizeMedium);
            this.gbSize.Controls.Add(this.sizeSmall);
            this.gbSize.Location = new System.Drawing.Point(63, 131);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(143, 128);
            this.gbSize.TabIndex = 4;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Size";
            // 
            // gbCrustType
            // 
            this.gbCrustType.Controls.Add(this.crustTypeThick);
            this.gbCrustType.Controls.Add(this.crustTypeThin);
            this.gbCrustType.Location = new System.Drawing.Point(63, 291);
            this.gbCrustType.Name = "gbCrustType";
            this.gbCrustType.Size = new System.Drawing.Size(143, 98);
            this.gbCrustType.TabIndex = 5;
            this.gbCrustType.TabStop = false;
            this.gbCrustType.Text = "Crust Type";
            // 
            // crustTypeThick
            // 
            this.crustTypeThick.AutoSize = true;
            this.crustTypeThick.Location = new System.Drawing.Point(27, 61);
            this.crustTypeThick.Name = "crustTypeThick";
            this.crustTypeThick.Size = new System.Drawing.Size(79, 17);
            this.crustTypeThick.TabIndex = 2;
            this.crustTypeThick.TabStop = true;
            this.crustTypeThick.Text = "Thick Crust";
            this.crustTypeThick.UseVisualStyleBackColor = true;
            // 
            // crustTypeThin
            // 
            this.crustTypeThin.AutoSize = true;
            this.crustTypeThin.Checked = true;
            this.crustTypeThin.Location = new System.Drawing.Point(27, 26);
            this.crustTypeThin.Name = "crustTypeThin";
            this.crustTypeThin.Size = new System.Drawing.Size(73, 17);
            this.crustTypeThin.TabIndex = 1;
            this.crustTypeThin.TabStop = true;
            this.crustTypeThin.Text = "Thin Crust";
            this.crustTypeThin.UseVisualStyleBackColor = true;
            this.crustTypeThin.CheckedChanged += new System.EventHandler(this.crustTypeThin_CheckedChanged);
            // 
            // gbWhereToEat
            // 
            this.gbWhereToEat.Controls.Add(this.eatOut);
            this.gbWhereToEat.Controls.Add(this.eatIn);
            this.gbWhereToEat.Location = new System.Drawing.Point(288, 291);
            this.gbWhereToEat.Name = "gbWhereToEat";
            this.gbWhereToEat.Size = new System.Drawing.Size(179, 66);
            this.gbWhereToEat.TabIndex = 6;
            this.gbWhereToEat.TabStop = false;
            this.gbWhereToEat.Text = "Where to Eat";
            // 
            // eatOut
            // 
            this.eatOut.AutoSize = true;
            this.eatOut.Location = new System.Drawing.Point(93, 26);
            this.eatOut.Name = "eatOut";
            this.eatOut.Size = new System.Drawing.Size(70, 17);
            this.eatOut.TabIndex = 2;
            this.eatOut.TabStop = true;
            this.eatOut.Text = "Take Out";
            this.eatOut.UseVisualStyleBackColor = true;
            // 
            // eatIn
            // 
            this.eatIn.AutoSize = true;
            this.eatIn.Checked = true;
            this.eatIn.Location = new System.Drawing.Point(27, 26);
            this.eatIn.Name = "eatIn";
            this.eatIn.Size = new System.Drawing.Size(53, 17);
            this.eatIn.TabIndex = 1;
            this.eatIn.TabStop = true;
            this.eatIn.Text = "Eat In";
            this.eatIn.UseVisualStyleBackColor = true;
            this.eatIn.CheckedChanged += new System.EventHandler(this.eatIn_CheckedChanged);
            // 
            // btnOrderPizza
            // 
            this.btnOrderPizza.Location = new System.Drawing.Point(272, 444);
            this.btnOrderPizza.Name = "btnOrderPizza";
            this.btnOrderPizza.Size = new System.Drawing.Size(129, 42);
            this.btnOrderPizza.TabIndex = 13;
            this.btnOrderPizza.Text = "Order Pizza";
            this.btnOrderPizza.UseVisualStyleBackColor = true;
            this.btnOrderPizza.Click += new System.EventHandler(this.btnOrderPizza_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Location = new System.Drawing.Point(452, 444);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(129, 42);
            this.btnResetForm.TabIndex = 14;
            this.btnResetForm.Text = "Reset Form";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // toppingExtraCheese
            // 
            this.toppingExtraCheese.AutoSize = true;
            this.toppingExtraCheese.Location = new System.Drawing.Point(20, 29);
            this.toppingExtraCheese.Name = "toppingExtraCheese";
            this.toppingExtraCheese.Size = new System.Drawing.Size(89, 17);
            this.toppingExtraCheese.TabIndex = 7;
            this.toppingExtraCheese.Text = "Extra Cheese";
            this.toppingExtraCheese.UseVisualStyleBackColor = true;
            this.toppingExtraCheese.CheckedChanged += new System.EventHandler(this.toppingExtraCheese_CheckedChanged);
            // 
            // toppingMushrooms
            // 
            this.toppingMushrooms.AutoSize = true;
            this.toppingMushrooms.Location = new System.Drawing.Point(20, 64);
            this.toppingMushrooms.Name = "toppingMushrooms";
            this.toppingMushrooms.Size = new System.Drawing.Size(80, 17);
            this.toppingMushrooms.TabIndex = 9;
            this.toppingMushrooms.Text = "Mushrooms";
            this.toppingMushrooms.UseVisualStyleBackColor = true;
            this.toppingMushrooms.CheckedChanged += new System.EventHandler(this.toppingMushrooms_CheckedChanged);
            // 
            // toppingTomatoes
            // 
            this.toppingTomatoes.AutoSize = true;
            this.toppingTomatoes.Location = new System.Drawing.Point(20, 99);
            this.toppingTomatoes.Name = "toppingTomatoes";
            this.toppingTomatoes.Size = new System.Drawing.Size(73, 17);
            this.toppingTomatoes.TabIndex = 11;
            this.toppingTomatoes.Text = "Tomatoes";
            this.toppingTomatoes.UseVisualStyleBackColor = true;
            this.toppingTomatoes.CheckedChanged += new System.EventHandler(this.toppingTomatoes_CheckedChanged);
            // 
            // toppingGreenPeppers
            // 
            this.toppingGreenPeppers.AutoSize = true;
            this.toppingGreenPeppers.Location = new System.Drawing.Point(128, 99);
            this.toppingGreenPeppers.Name = "toppingGreenPeppers";
            this.toppingGreenPeppers.Size = new System.Drawing.Size(97, 17);
            this.toppingGreenPeppers.TabIndex = 12;
            this.toppingGreenPeppers.Text = "Green Peppers";
            this.toppingGreenPeppers.UseVisualStyleBackColor = true;
            this.toppingGreenPeppers.CheckedChanged += new System.EventHandler(this.toppingGreenPeppers_CheckedChanged);
            // 
            // toppingOlives
            // 
            this.toppingOlives.AutoSize = true;
            this.toppingOlives.Location = new System.Drawing.Point(128, 64);
            this.toppingOlives.Name = "toppingOlives";
            this.toppingOlives.Size = new System.Drawing.Size(55, 17);
            this.toppingOlives.TabIndex = 10;
            this.toppingOlives.Text = "Olives";
            this.toppingOlives.UseVisualStyleBackColor = true;
            this.toppingOlives.CheckedChanged += new System.EventHandler(this.toppingOlives_CheckedChanged);
            // 
            // toppingOnion
            // 
            this.toppingOnion.AutoSize = true;
            this.toppingOnion.Location = new System.Drawing.Point(128, 29);
            this.toppingOnion.Name = "toppingOnion";
            this.toppingOnion.Size = new System.Drawing.Size(54, 17);
            this.toppingOnion.TabIndex = 8;
            this.toppingOnion.Text = "Onion";
            this.toppingOnion.UseVisualStyleBackColor = true;
            this.toppingOnion.CheckedChanged += new System.EventHandler(this.toppingOnion_CheckedChanged);
            // 
            // gbToppings
            // 
            this.gbToppings.Controls.Add(this.toppingGreenPeppers);
            this.gbToppings.Controls.Add(this.toppingOlives);
            this.gbToppings.Controls.Add(this.toppingOnion);
            this.gbToppings.Controls.Add(this.toppingTomatoes);
            this.gbToppings.Controls.Add(this.toppingMushrooms);
            this.gbToppings.Controls.Add(this.toppingExtraCheese);
            this.gbToppings.Location = new System.Drawing.Point(288, 131);
            this.gbToppings.Name = "gbToppings";
            this.gbToppings.Size = new System.Drawing.Size(232, 130);
            this.gbToppings.TabIndex = 16;
            this.gbToppings.TabStop = false;
            this.gbToppings.Text = "Toppings";
            // 
            // gbOrderSummary
            // 
            this.gbOrderSummary.Controls.Add(this.osWheretoEatValue);
            this.gbOrderSummary.Controls.Add(this.osCrustTypeValue);
            this.gbOrderSummary.Controls.Add(this.osToppingsValue);
            this.gbOrderSummary.Controls.Add(this.osSizeValue);
            this.gbOrderSummary.Controls.Add(this.osTotalPriceValue);
            this.gbOrderSummary.Controls.Add(this.osTotalPriceLabel);
            this.gbOrderSummary.Controls.Add(this.osWheretoEatLabel);
            this.gbOrderSummary.Controls.Add(this.osCrustTypeLabel);
            this.gbOrderSummary.Controls.Add(this.osToppingsLabel);
            this.gbOrderSummary.Controls.Add(this.osSizeLabel);
            this.gbOrderSummary.Location = new System.Drawing.Point(627, 131);
            this.gbOrderSummary.Name = "gbOrderSummary";
            this.gbOrderSummary.Size = new System.Drawing.Size(235, 306);
            this.gbOrderSummary.TabIndex = 17;
            this.gbOrderSummary.TabStop = false;
            this.gbOrderSummary.Text = "Order Summary";
            // 
            // osWheretoEatValue
            // 
            this.osWheretoEatValue.AutoSize = true;
            this.osWheretoEatValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osWheretoEatValue.Location = new System.Drawing.Point(115, 149);
            this.osWheretoEatValue.Name = "osWheretoEatValue";
            this.osWheretoEatValue.Size = new System.Drawing.Size(35, 13);
            this.osWheretoEatValue.TabIndex = 10;
            this.osWheretoEatValue.Text = "Eat In";
            // 
            // osCrustTypeValue
            // 
            this.osCrustTypeValue.AutoSize = true;
            this.osCrustTypeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osCrustTypeValue.Location = new System.Drawing.Point(105, 117);
            this.osCrustTypeValue.Name = "osCrustTypeValue";
            this.osCrustTypeValue.Size = new System.Drawing.Size(55, 13);
            this.osCrustTypeValue.TabIndex = 9;
            this.osCrustTypeValue.Text = "Thin Crust";
            // 
            // osToppingsValue
            // 
            this.osToppingsValue.AutoSize = true;
            this.osToppingsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osToppingsValue.Location = new System.Drawing.Point(27, 82);
            this.osToppingsValue.Name = "osToppingsValue";
            this.osToppingsValue.Size = new System.Drawing.Size(68, 13);
            this.osToppingsValue.TabIndex = 8;
            this.osToppingsValue.Text = "No Toppings";
            // 
            // osSizeValue
            // 
            this.osSizeValue.AutoSize = true;
            this.osSizeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osSizeValue.Location = new System.Drawing.Point(55, 32);
            this.osSizeValue.Name = "osSizeValue";
            this.osSizeValue.Size = new System.Drawing.Size(44, 13);
            this.osSizeValue.TabIndex = 7;
            this.osSizeValue.Text = "Medium";
            // 
            // osTotalPriceValue
            // 
            this.osTotalPriceValue.AutoSize = true;
            this.osTotalPriceValue.Font = new System.Drawing.Font("Cooper Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osTotalPriceValue.ForeColor = System.Drawing.Color.Green;
            this.osTotalPriceValue.Location = new System.Drawing.Point(108, 221);
            this.osTotalPriceValue.Name = "osTotalPriceValue";
            this.osTotalPriceValue.Size = new System.Drawing.Size(82, 55);
            this.osTotalPriceValue.TabIndex = 6;
            this.osTotalPriceValue.Text = "$0";
            // 
            // osTotalPriceLabel
            // 
            this.osTotalPriceLabel.AutoSize = true;
            this.osTotalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osTotalPriceLabel.Location = new System.Drawing.Point(27, 183);
            this.osTotalPriceLabel.Name = "osTotalPriceLabel";
            this.osTotalPriceLabel.Size = new System.Drawing.Size(73, 13);
            this.osTotalPriceLabel.TabIndex = 5;
            this.osTotalPriceLabel.Text = "Total Price:";
            // 
            // osWheretoEatLabel
            // 
            this.osWheretoEatLabel.AutoSize = true;
            this.osWheretoEatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osWheretoEatLabel.Location = new System.Drawing.Point(27, 150);
            this.osWheretoEatLabel.Name = "osWheretoEatLabel";
            this.osWheretoEatLabel.Size = new System.Drawing.Size(86, 13);
            this.osWheretoEatLabel.TabIndex = 4;
            this.osWheretoEatLabel.Text = "Where to Eat:";
            // 
            // osCrustTypeLabel
            // 
            this.osCrustTypeLabel.AutoSize = true;
            this.osCrustTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osCrustTypeLabel.Location = new System.Drawing.Point(27, 117);
            this.osCrustTypeLabel.Name = "osCrustTypeLabel";
            this.osCrustTypeLabel.Size = new System.Drawing.Size(72, 13);
            this.osCrustTypeLabel.TabIndex = 3;
            this.osCrustTypeLabel.Text = "Crust Type:";
            // 
            // osToppingsLabel
            // 
            this.osToppingsLabel.AutoSize = true;
            this.osToppingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osToppingsLabel.Location = new System.Drawing.Point(21, 61);
            this.osToppingsLabel.Name = "osToppingsLabel";
            this.osToppingsLabel.Size = new System.Drawing.Size(63, 13);
            this.osToppingsLabel.TabIndex = 1;
            this.osToppingsLabel.Text = "Toppings:";
            // 
            // osSizeLabel
            // 
            this.osSizeLabel.AutoSize = true;
            this.osSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.osSizeLabel.Location = new System.Drawing.Point(21, 32);
            this.osSizeLabel.Name = "osSizeLabel";
            this.osSizeLabel.Size = new System.Drawing.Size(35, 13);
            this.osSizeLabel.TabIndex = 0;
            this.osSizeLabel.Text = "Size:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 510);
            this.Controls.Add(this.gbOrderSummary);
            this.Controls.Add(this.gbToppings);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.btnOrderPizza);
            this.Controls.Add(this.gbWhereToEat);
            this.Controls.Add(this.gbCrustType);
            this.Controls.Add(this.gbSize);
            this.Controls.Add(this.labelHeader);
            this.Name = "frmMain";
            this.Text = "Pizza Order";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.gbCrustType.ResumeLayout(false);
            this.gbCrustType.PerformLayout();
            this.gbWhereToEat.ResumeLayout(false);
            this.gbWhereToEat.PerformLayout();
            this.gbToppings.ResumeLayout(false);
            this.gbToppings.PerformLayout();
            this.gbOrderSummary.ResumeLayout(false);
            this.gbOrderSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.RadioButton sizeSmall;
        private System.Windows.Forms.RadioButton sizeMedium;
        private System.Windows.Forms.RadioButton sizeLarge;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.GroupBox gbCrustType;
        private System.Windows.Forms.RadioButton crustTypeThick;
        private System.Windows.Forms.RadioButton crustTypeThin;
        private System.Windows.Forms.GroupBox gbWhereToEat;
        private System.Windows.Forms.RadioButton eatOut;
        private System.Windows.Forms.RadioButton eatIn;
        private System.Windows.Forms.Button btnOrderPizza;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.CheckBox toppingExtraCheese;
        private System.Windows.Forms.CheckBox toppingMushrooms;
        private System.Windows.Forms.CheckBox toppingTomatoes;
        private System.Windows.Forms.CheckBox toppingGreenPeppers;
        private System.Windows.Forms.CheckBox toppingOlives;
        private System.Windows.Forms.CheckBox toppingOnion;
        private System.Windows.Forms.GroupBox gbToppings;
        private System.Windows.Forms.GroupBox gbOrderSummary;
        private System.Windows.Forms.Label osToppingsLabel;
        private System.Windows.Forms.Label osSizeLabel;
        private System.Windows.Forms.Label osTotalPriceValue;
        private System.Windows.Forms.Label osTotalPriceLabel;
        private System.Windows.Forms.Label osWheretoEatLabel;
        private System.Windows.Forms.Label osToppingsValue;
        private System.Windows.Forms.Label osSizeValue;
        private System.Windows.Forms.Label osCrustTypeValue;
        private System.Windows.Forms.Label osWheretoEatValue;
        private System.Windows.Forms.Label osCrustTypeLabel;
    }
}

