namespace WindowsForms_misc_2
{
    partial class FProgressBar
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
            this.lblProgressPercentage = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnIncreaseProgress = new System.Windows.Forms.Button();
            this.btnResetProgress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProgressPercentage
            // 
            this.lblProgressPercentage.AutoSize = true;
            this.lblProgressPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgressPercentage.Location = new System.Drawing.Point(363, 83);
            this.lblProgressPercentage.Name = "lblProgressPercentage";
            this.lblProgressPercentage.Size = new System.Drawing.Size(65, 37);
            this.lblProgressPercentage.TabIndex = 0;
            this.lblProgressPercentage.Text = "0%";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.MediumSpringGreen;
            this.progressBar1.Location = new System.Drawing.Point(137, 144);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(551, 45);
            this.progressBar1.TabIndex = 1;
            // 
            // btnIncreaseProgress
            // 
            this.btnIncreaseProgress.Location = new System.Drawing.Point(228, 226);
            this.btnIncreaseProgress.Name = "btnIncreaseProgress";
            this.btnIncreaseProgress.Size = new System.Drawing.Size(144, 48);
            this.btnIncreaseProgress.TabIndex = 2;
            this.btnIncreaseProgress.Text = "Increase Progress Bar";
            this.btnIncreaseProgress.UseVisualStyleBackColor = true;
            this.btnIncreaseProgress.Click += new System.EventHandler(this.btnIncreaseProgress_Click);
            // 
            // btnResetProgress
            // 
            this.btnResetProgress.Location = new System.Drawing.Point(423, 226);
            this.btnResetProgress.Name = "btnResetProgress";
            this.btnResetProgress.Size = new System.Drawing.Size(144, 48);
            this.btnResetProgress.TabIndex = 3;
            this.btnResetProgress.Text = "Reset Progress Bar";
            this.btnResetProgress.UseVisualStyleBackColor = true;
            this.btnResetProgress.Click += new System.EventHandler(this.btnResetProgress_Click);
            // 
            // FProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnResetProgress);
            this.Controls.Add(this.btnIncreaseProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblProgressPercentage);
            this.Name = "FProgressBar";
            this.Text = "FProgressBar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgressPercentage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnIncreaseProgress;
        private System.Windows.Forms.Button btnResetProgress;
    }
}