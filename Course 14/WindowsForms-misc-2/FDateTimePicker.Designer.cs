namespace WindowsForms_misc_2
{
    partial class FDateTimePicker
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnShortDateString = new System.Windows.Forms.Button();
            this.lblLongDateString = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnSelectedRange = new System.Windows.Forms.Button();
            this.btnRangeStart = new System.Windows.Forms.Button();
            this.btnRangeEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(56, 59);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(268, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(432, 59);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(77, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Formated Date";
            // 
            // btnShortDateString
            // 
            this.btnShortDateString.Location = new System.Drawing.Point(56, 149);
            this.btnShortDateString.Name = "btnShortDateString";
            this.btnShortDateString.Size = new System.Drawing.Size(118, 36);
            this.btnShortDateString.TabIndex = 2;
            this.btnShortDateString.Text = "Short Date String";
            this.btnShortDateString.UseVisualStyleBackColor = true;
            this.btnShortDateString.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblLongDateString
            // 
            this.lblLongDateString.Location = new System.Drawing.Point(206, 149);
            this.lblLongDateString.Name = "lblLongDateString";
            this.lblLongDateString.Size = new System.Drawing.Size(118, 36);
            this.lblLongDateString.TabIndex = 3;
            this.lblLongDateString.Text = "Long Date String";
            this.lblLongDateString.UseVisualStyleBackColor = true;
            this.lblLongDateString.Click += new System.EventHandler(this.lblLongDateString_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(244, 240);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            // 
            // btnSelectedRange
            // 
            this.btnSelectedRange.Location = new System.Drawing.Point(125, 432);
            this.btnSelectedRange.Name = "btnSelectedRange";
            this.btnSelectedRange.Size = new System.Drawing.Size(118, 36);
            this.btnSelectedRange.TabIndex = 5;
            this.btnSelectedRange.Text = "Selected Range";
            this.btnSelectedRange.UseVisualStyleBackColor = true;
            this.btnSelectedRange.Click += new System.EventHandler(this.btnSelectedRange_Click);
            // 
            // btnRangeStart
            // 
            this.btnRangeStart.Location = new System.Drawing.Point(305, 432);
            this.btnRangeStart.Name = "btnRangeStart";
            this.btnRangeStart.Size = new System.Drawing.Size(118, 36);
            this.btnRangeStart.TabIndex = 6;
            this.btnRangeStart.Text = "Start";
            this.btnRangeStart.UseVisualStyleBackColor = true;
            this.btnRangeStart.Click += new System.EventHandler(this.btnRangeStart_Click);
            // 
            // btnRangeEnd
            // 
            this.btnRangeEnd.Location = new System.Drawing.Point(488, 432);
            this.btnRangeEnd.Name = "btnRangeEnd";
            this.btnRangeEnd.Size = new System.Drawing.Size(118, 36);
            this.btnRangeEnd.TabIndex = 7;
            this.btnRangeEnd.Text = "End";
            this.btnRangeEnd.UseVisualStyleBackColor = true;
            this.btnRangeEnd.Click += new System.EventHandler(this.btnRangeEnd_Click);
            // 
            // FDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 506);
            this.Controls.Add(this.btnRangeEnd);
            this.Controls.Add(this.btnRangeStart);
            this.Controls.Add(this.btnSelectedRange);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.lblLongDateString);
            this.Controls.Add(this.btnShortDateString);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "FDateTimePicker";
            this.Text = "FDateTimePicker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnShortDateString;
        private System.Windows.Forms.Button lblLongDateString;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnSelectedRange;
        private System.Windows.Forms.Button btnRangeStart;
        private System.Windows.Forms.Button btnRangeEnd;
    }
}