namespace DVLD.Applications.Local_Driving_License
{
    partial class frmListLocalDrivingLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            this.cbIsStatus = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvApplicationsList = new System.Windows.Forms.DataGridView();
            this.cmsRecordOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiIssueDrivingLicenseFirstTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddNewApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationsList)).BeginInit();
            this.cmsRecordOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbIsStatus
            // 
            this.cbIsStatus.BackColor = System.Drawing.SystemColors.Control;
            this.cbIsStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsStatus.FormattingEnabled = true;
            this.cbIsStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancelled",
            "Completed"});
            this.cbIsStatus.Location = new System.Drawing.Point(296, 256);
            this.cbIsStatus.Name = "cbIsStatus";
            this.cbIsStatus.Size = new System.Drawing.Size(101, 21);
            this.cbIsStatus.TabIndex = 31;
            this.cbIsStatus.Visible = false;
            this.cbIsStatus.SelectedIndexChanged += new System.EventHandler(this.cbIsStatus_SelectedIndexChanged);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(296, 257);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(236, 20);
            this.txtFilter.TabIndex = 30;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.SystemColors.Control;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(100, 256);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(181, 21);
            this.cbFilterBy.TabIndex = 29;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Filter By:";
            // 
            // dgvApplicationsList
            // 
            this.dgvApplicationsList.AllowUserToAddRows = false;
            this.dgvApplicationsList.AllowUserToDeleteRows = false;
            this.dgvApplicationsList.AllowUserToOrderColumns = true;
            this.dgvApplicationsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvApplicationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationsList.ContextMenuStrip = this.cmsRecordOptions;
            this.dgvApplicationsList.Location = new System.Drawing.Point(17, 283);
            this.dgvApplicationsList.Name = "dgvApplicationsList";
            this.dgvApplicationsList.ReadOnly = true;
            this.dgvApplicationsList.Size = new System.Drawing.Size(1119, 278);
            this.dgvApplicationsList.TabIndex = 27;
            // 
            // cmsRecordOptions
            // 
            this.cmsRecordOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiShowApplicationDetails,
            this.toolStripSeparator1,
            this.tsmiEditApplication,
            this.tsmiDeleteApplication,
            this.toolStripSeparator2,
            this.tsmiCancelApplication,
            this.toolStripSeparator3,
            this.tsmiScheduleTests,
            this.toolStripSeparator4,
            this.tsmiIssueDrivingLicenseFirstTime,
            this.toolStripSeparator5,
            this.tsmiShowLicense,
            this.toolStripSeparator6,
            this.tsmiShowPersonLicenseHistory});
            this.cmsRecordOptions.Name = "cmsRecordOptions";
            this.cmsRecordOptions.Size = new System.Drawing.Size(275, 254);
            // 
            // tsmiShowApplicationDetails
            // 
            this.tsmiShowApplicationDetails.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiShowApplicationDetails.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.tsmiShowApplicationDetails.Name = "tsmiShowApplicationDetails";
            this.tsmiShowApplicationDetails.Size = new System.Drawing.Size(274, 24);
            this.tsmiShowApplicationDetails.Text = "Show Application Details";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(271, 6);
            // 
            // tsmiEditApplication
            // 
            this.tsmiEditApplication.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiEditApplication.Image = global::DVLD.Properties.Resources.edit_32;
            this.tsmiEditApplication.Name = "tsmiEditApplication";
            this.tsmiEditApplication.Size = new System.Drawing.Size(274, 24);
            this.tsmiEditApplication.Text = "Edit Application";
            this.tsmiEditApplication.Click += new System.EventHandler(this.tsmiEditApplication_Click);
            // 
            // tsmiDeleteApplication
            // 
            this.tsmiDeleteApplication.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiDeleteApplication.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.tsmiDeleteApplication.Name = "tsmiDeleteApplication";
            this.tsmiDeleteApplication.Size = new System.Drawing.Size(274, 24);
            this.tsmiDeleteApplication.Text = "Delete Application";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(271, 6);
            // 
            // tsmiCancelApplication
            // 
            this.tsmiCancelApplication.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiCancelApplication.Image = global::DVLD.Properties.Resources.Delete_32;
            this.tsmiCancelApplication.Name = "tsmiCancelApplication";
            this.tsmiCancelApplication.Size = new System.Drawing.Size(274, 24);
            this.tsmiCancelApplication.Text = "Cancel Application";
            this.tsmiCancelApplication.Click += new System.EventHandler(this.tsmiCancelApplication_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(271, 6);
            // 
            // tsmiScheduleTests
            // 
            this.tsmiScheduleTests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiScheduleTests.Image = global::DVLD.Properties.Resources.Schedule_Test_32;
            this.tsmiScheduleTests.Name = "tsmiScheduleTests";
            this.tsmiScheduleTests.Size = new System.Drawing.Size(274, 24);
            this.tsmiScheduleTests.Text = "Schedule Tests";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(271, 6);
            // 
            // tsmiIssueDrivingLicenseFirstTime
            // 
            this.tsmiIssueDrivingLicenseFirstTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiIssueDrivingLicenseFirstTime.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.tsmiIssueDrivingLicenseFirstTime.Name = "tsmiIssueDrivingLicenseFirstTime";
            this.tsmiIssueDrivingLicenseFirstTime.Size = new System.Drawing.Size(274, 24);
            this.tsmiIssueDrivingLicenseFirstTime.Text = "Issue Driving License (First Time)";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(271, 6);
            // 
            // tsmiShowLicense
            // 
            this.tsmiShowLicense.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiShowLicense.Image = global::DVLD.Properties.Resources.License_View_32;
            this.tsmiShowLicense.Name = "tsmiShowLicense";
            this.tsmiShowLicense.Size = new System.Drawing.Size(274, 24);
            this.tsmiShowLicense.Text = "Show License";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(271, 6);
            // 
            // tsmiShowPersonLicenseHistory
            // 
            this.tsmiShowPersonLicenseHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tsmiShowPersonLicenseHistory.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_32;
            this.tsmiShowPersonLicenseHistory.Name = "tsmiShowPersonLicenseHistory";
            this.tsmiShowPersonLicenseHistory.Size = new System.Drawing.Size(274, 24);
            this.tsmiShowPersonLicenseHistory.Text = "Show Person License History";
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.ForeColor = System.Drawing.Color.Black;
            this.lblTotalRecords.Location = new System.Drawing.Point(106, 572);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(14, 16);
            this.lblTotalRecords.TabIndex = 26;
            this.lblTotalRecords.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 572);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "# Records: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(388, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(377, 26);
            this.label1.TabIndex = 22;
            this.label1.Text = "Local Driving License Applications";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Local_321;
            this.pictureBox2.Location = new System.Drawing.Point(674, 98);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::DVLD.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1054, 567);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 38);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddNewApplication
            // 
            this.btnAddNewApplication.BackgroundImage = global::DVLD.Properties.Resources.New_Application_64;
            this.btnAddNewApplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddNewApplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewApplication.Location = new System.Drawing.Point(1095, 236);
            this.btnAddNewApplication.Name = "btnAddNewApplication";
            this.btnAddNewApplication.Size = new System.Drawing.Size(41, 41);
            this.btnAddNewApplication.TabIndex = 23;
            this.btnAddNewApplication.UseVisualStyleBackColor = true;
            this.btnAddNewApplication.Click += new System.EventHandler(this.btnAddNewApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications1;
            this.pictureBox1.Location = new System.Drawing.Point(485, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // frmListLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 620);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.cbIsStatus);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvApplicationsList);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAddNewApplication);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmListLocalDrivingLicenseApplications";
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationsList)).EndInit();
            this.cmsRecordOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIsStatus;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvApplicationsList;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddNewApplication;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ContextMenuStrip cmsRecordOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiEditApplication;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiScheduleTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiIssueDrivingLicenseFirstTime;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowPersonLicenseHistory;
    }
}