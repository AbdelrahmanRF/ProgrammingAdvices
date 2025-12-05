namespace Events
{
    partial class Form1
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
            this.calculator1 = new Events.Calculator();
            this.SuspendLayout();
            // 
            // calculator1
            // 
            this.calculator1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.calculator1.Location = new System.Drawing.Point(21, 23);
            this.calculator1.Name = "calculator1";
            this.calculator1.Size = new System.Drawing.Size(597, 247);
            this.calculator1.TabIndex = 0;
            this.calculator1.OnCalculationComplete += new System.EventHandler<Events.Calculator.CalculationCompleteEventArgs>(this.calculator1_OnCalculationComplete);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 350);
            this.Controls.Add(this.calculator1);
            this.Name = "Form1";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        private Calculator calculator1;
    }
}

