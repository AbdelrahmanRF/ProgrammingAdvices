namespace MyFirstWindowsForm
{
    partial class frmCheckRadioGroup
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
            this.chkReceiveEmails = new System.Windows.Forms.CheckBox();
            this.mGender = new System.Windows.Forms.RadioButton();
            this.fGender = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.gbGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkReceiveEmails
            // 
            this.chkReceiveEmails.AutoSize = true;
            this.chkReceiveEmails.Location = new System.Drawing.Point(44, 88);
            this.chkReceiveEmails.Name = "chkReceiveEmails";
            this.chkReceiveEmails.Size = new System.Drawing.Size(185, 17);
            this.chkReceiveEmails.TabIndex = 0;
            this.chkReceiveEmails.Text = "Do You Want to Receive Emails?";
            this.chkReceiveEmails.UseVisualStyleBackColor = true;
            this.chkReceiveEmails.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // mGender
            // 
            this.mGender.AutoSize = true;
            this.mGender.Location = new System.Drawing.Point(6, 19);
            this.mGender.Name = "mGender";
            this.mGender.Size = new System.Drawing.Size(48, 17);
            this.mGender.TabIndex = 3;
            this.mGender.TabStop = true;
            this.mGender.Text = "Male";
            this.mGender.UseVisualStyleBackColor = true;
            // 
            // fGender
            // 
            this.fGender.AutoSize = true;
            this.fGender.Location = new System.Drawing.Point(6, 45);
            this.fGender.Name = "fGender";
            this.fGender.Size = new System.Drawing.Size(59, 17);
            this.fGender.TabIndex = 4;
            this.fGender.TabStop = true;
            this.fGender.Text = "Female";
            this.fGender.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(40, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // gbGender
            // 
            this.gbGender.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbGender.Controls.Add(this.fGender);
            this.gbGender.Controls.Add(this.mGender);
            this.gbGender.Location = new System.Drawing.Point(351, 88);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(162, 76);
            this.gbGender.TabIndex = 7;
            this.gbGender.TabStop = false;
            this.gbGender.Text = "Gender";
            // 
            // frmCheckRadioGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkReceiveEmails);
            this.Name = "frmCheckRadioGroup";
            this.Text = "frmCheckRadioGroup";
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkReceiveEmails;
        private System.Windows.Forms.RadioButton mGender;
        private System.Windows.Forms.RadioButton fGender;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox gbGender;
    }
}