namespace WindowsForms_misc_2
{
    partial class FLinkLable
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
            this.FLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // FLinkLabel
            // 
            this.FLinkLabel.AutoSize = true;
            this.FLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FLinkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(125)))), ((int)(((byte)(250)))));
            this.FLinkLabel.Location = new System.Drawing.Point(331, 198);
            this.FLinkLabel.Name = "FLinkLabel";
            this.FLinkLabel.Size = new System.Drawing.Size(128, 25);
            this.FLinkLabel.TabIndex = 0;
            this.FLinkLabel.TabStop = true;
            this.FLinkLabel.Text = "My LinkedIn";
            this.FLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FLinkLable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FLinkLabel);
            this.Name = "FLinkLable";
            this.Text = "LinkLable";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel FLinkLabel;
    }
}