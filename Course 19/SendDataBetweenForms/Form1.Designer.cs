namespace SendDataBetweenForms
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPersonID = new System.Windows.Forms.TextBox();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnOpenForm3 = new System.Windows.Forms.Button();
            this.tbPersonIDFromForm3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person ID";
            // 
            // tbPersonID
            // 
            this.tbPersonID.Location = new System.Drawing.Point(253, 63);
            this.tbPersonID.Name = "tbPersonID";
            this.tbPersonID.Size = new System.Drawing.Size(214, 20);
            this.tbPersonID.TabIndex = 2;
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(497, 62);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(130, 24);
            this.btnSendData.TabIndex = 3;
            this.btnSendData.Text = "Send Data to Form2";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnOpenForm3
            // 
            this.btnOpenForm3.Location = new System.Drawing.Point(109, 203);
            this.btnOpenForm3.Name = "btnOpenForm3";
            this.btnOpenForm3.Size = new System.Drawing.Size(155, 21);
            this.btnOpenForm3.TabIndex = 4;
            this.btnOpenForm3.Text = "Open Form 3";
            this.btnOpenForm3.UseVisualStyleBackColor = true;
            this.btnOpenForm3.Click += new System.EventHandler(this.btnOpenForm3_Click);
            // 
            // tbPersonIDFromForm3
            // 
            this.tbPersonIDFromForm3.Location = new System.Drawing.Point(286, 203);
            this.tbPersonIDFromForm3.Name = "tbPersonIDFromForm3";
            this.tbPersonIDFromForm3.Size = new System.Drawing.Size(280, 20);
            this.tbPersonIDFromForm3.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbPersonIDFromForm3);
            this.Controls.Add(this.btnOpenForm3);
            this.Controls.Add(this.btnSendData);
            this.Controls.Add(this.tbPersonID);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPersonID;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnOpenForm3;
        private System.Windows.Forms.TextBox tbPersonIDFromForm3;
    }
}

