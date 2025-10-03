namespace WindowsForms_misc_2
{
    partial class TodoList
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
            this.tbTodo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnDeleteAllTasks = new System.Windows.Forms.Button();
            this.pTasksProgressBar = new System.Windows.Forms.ProgressBar();
            this.lblTasksProgress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.tvTasks = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.ForestGreen;
            this.label1.Location = new System.Drawing.Point(285, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "To-Do-list";
            // 
            // tbTodo
            // 
            this.tbTodo.Location = new System.Drawing.Point(27, 107);
            this.tbTodo.Multiline = true;
            this.tbTodo.Name = "tbTodo";
            this.tbTodo.Size = new System.Drawing.Size(246, 36);
            this.tbTodo.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = global::WindowsForms_misc_2.Properties.Resources.add__Custom_;
            this.btnAdd.Location = new System.Drawing.Point(279, 107);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(41, 36);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(24, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Todo";
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.Location = new System.Drawing.Point(27, 180);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(126, 52);
            this.btnDeleteTask.TabIndex = 5;
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnDeleteAllTasks
            // 
            this.btnDeleteAllTasks.BackColor = System.Drawing.Color.SpringGreen;
            this.btnDeleteAllTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAllTasks.Location = new System.Drawing.Point(194, 180);
            this.btnDeleteAllTasks.Name = "btnDeleteAllTasks";
            this.btnDeleteAllTasks.Size = new System.Drawing.Size(126, 52);
            this.btnDeleteAllTasks.TabIndex = 6;
            this.btnDeleteAllTasks.Text = "Delete All Tasks";
            this.btnDeleteAllTasks.UseVisualStyleBackColor = false;
            this.btnDeleteAllTasks.Click += new System.EventHandler(this.btnDeleteAllTasks_Click);
            // 
            // pTasksProgressBar
            // 
            this.pTasksProgressBar.Location = new System.Drawing.Point(429, 414);
            this.pTasksProgressBar.Name = "pTasksProgressBar";
            this.pTasksProgressBar.Size = new System.Drawing.Size(339, 35);
            this.pTasksProgressBar.TabIndex = 7;
            // 
            // lblTasksProgress
            // 
            this.lblTasksProgress.AutoSize = true;
            this.lblTasksProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTasksProgress.ForeColor = System.Drawing.Color.Transparent;
            this.lblTasksProgress.Location = new System.Drawing.Point(778, 420);
            this.lblTasksProgress.Name = "lblTasksProgress";
            this.lblTasksProgress.Size = new System.Drawing.Size(45, 25);
            this.lblTasksProgress.TabIndex = 8;
            this.lblTasksProgress.Text = "0%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(32, 298);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Pending:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(32, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Completed:";
            // 
            // lblPending
            // 
            this.lblPending.AutoSize = true;
            this.lblPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.ForeColor = System.Drawing.Color.Transparent;
            this.lblPending.Location = new System.Drawing.Point(143, 298);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(25, 25);
            this.lblPending.TabIndex = 11;
            this.lblPending.Text = "0";
            // 
            // lblCompleted
            // 
            this.lblCompleted.AutoSize = true;
            this.lblCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.ForeColor = System.Drawing.Color.Transparent;
            this.lblCompleted.Location = new System.Drawing.Point(178, 355);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(25, 25);
            this.lblCompleted.TabIndex = 12;
            this.lblCompleted.Text = "0";
            // 
            // tvTasks
            // 
            this.tvTasks.CheckBoxes = true;
            this.tvTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvTasks.Location = new System.Drawing.Point(429, 108);
            this.tvTasks.Name = "tvTasks";
            this.tvTasks.Size = new System.Drawing.Size(393, 291);
            this.tvTasks.TabIndex = 13;
            this.tvTasks.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvTasks_AfterCheck);
            // 
            // TodoList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(869, 511);
            this.Controls.Add(this.tvTasks);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTasksProgress);
            this.Controls.Add(this.pTasksProgressBar);
            this.Controls.Add(this.btnDeleteAllTasks);
            this.Controls.Add(this.btnDeleteTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbTodo);
            this.Controls.Add(this.label1);
            this.Name = "TodoList";
            this.Text = "TodoList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTodo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnDeleteAllTasks;
        private System.Windows.Forms.ProgressBar pTasksProgressBar;
        private System.Windows.Forms.Label lblTasksProgress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.TreeView tvTasks;
    }
}