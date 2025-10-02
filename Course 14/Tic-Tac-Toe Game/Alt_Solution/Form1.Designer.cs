namespace Tic_Tac_Toe_Game
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblTurn = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnC3 = new System.Windows.Forms.Button();
            this.btnB3 = new System.Windows.Forms.Button();
            this.btnA3 = new System.Windows.Forms.Button();
            this.btnC2 = new System.Windows.Forms.Button();
            this.btnB2 = new System.Windows.Forms.Button();
            this.btnA2 = new System.Windows.Forms.Button();
            this.btnC1 = new System.Windows.Forms.Button();
            this.btnB1 = new System.Windows.Forms.Button();
            this.btnA1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(403, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tic-Tac-Toe Game";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(94, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Turn";
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.ForeColor = System.Drawing.Color.White;
            this.lblTurn.Location = new System.Drawing.Point(74, 172);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(113, 28);
            this.lblTurn.TabIndex = 11;
            this.lblTurn.Tag = "Player 1";
            this.lblTurn.Text = "Player 1";
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.Lime;
            this.lblWinner.Location = new System.Drawing.Point(54, 280);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(152, 28);
            this.lblWinner.TabIndex = 13;
            this.lblWinner.Text = "In Progress";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(79, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "Winner";
            // 
            // btnRestart
            // 
            this.btnRestart.BackColor = System.Drawing.Color.Black;
            this.btnRestart.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(59, 336);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(165, 46);
            this.btnRestart.TabIndex = 14;
            this.btnRestart.Text = "Restart Game";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnC3
            // 
            this.btnC3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC3.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnC3.Location = new System.Drawing.Point(620, 323);
            this.btnC3.Name = "btnC3";
            this.btnC3.Size = new System.Drawing.Size(92, 99);
            this.btnC3.TabIndex = 32;
            this.btnC3.Tag = "?";
            this.btnC3.UseVisualStyleBackColor = true;
            this.btnC3.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnB3
            // 
            this.btnB3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB3.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnB3.Location = new System.Drawing.Point(498, 323);
            this.btnB3.Name = "btnB3";
            this.btnB3.Size = new System.Drawing.Size(92, 99);
            this.btnB3.TabIndex = 31;
            this.btnB3.Tag = "?";
            this.btnB3.UseVisualStyleBackColor = true;
            this.btnB3.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnA3
            // 
            this.btnA3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA3.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnA3.Location = new System.Drawing.Point(376, 323);
            this.btnA3.Name = "btnA3";
            this.btnA3.Size = new System.Drawing.Size(92, 99);
            this.btnA3.TabIndex = 30;
            this.btnA3.Tag = "?";
            this.btnA3.UseVisualStyleBackColor = true;
            this.btnA3.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnC2
            // 
            this.btnC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC2.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnC2.Location = new System.Drawing.Point(620, 210);
            this.btnC2.Name = "btnC2";
            this.btnC2.Size = new System.Drawing.Size(92, 94);
            this.btnC2.TabIndex = 29;
            this.btnC2.Tag = "?";
            this.btnC2.UseVisualStyleBackColor = true;
            this.btnC2.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnB2
            // 
            this.btnB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB2.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnB2.Location = new System.Drawing.Point(498, 210);
            this.btnB2.Name = "btnB2";
            this.btnB2.Size = new System.Drawing.Size(92, 94);
            this.btnB2.TabIndex = 28;
            this.btnB2.Tag = "?";
            this.btnB2.UseVisualStyleBackColor = true;
            this.btnB2.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnA2
            // 
            this.btnA2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA2.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnA2.Location = new System.Drawing.Point(376, 210);
            this.btnA2.Name = "btnA2";
            this.btnA2.Size = new System.Drawing.Size(92, 94);
            this.btnA2.TabIndex = 27;
            this.btnA2.Tag = "?";
            this.btnA2.UseVisualStyleBackColor = true;
            this.btnA2.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnC1
            // 
            this.btnC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnC1.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnC1.Location = new System.Drawing.Point(618, 96);
            this.btnC1.Name = "btnC1";
            this.btnC1.Size = new System.Drawing.Size(92, 100);
            this.btnC1.TabIndex = 26;
            this.btnC1.Tag = "?";
            this.btnC1.UseVisualStyleBackColor = true;
            this.btnC1.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnB1
            // 
            this.btnB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB1.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnB1.Location = new System.Drawing.Point(498, 96);
            this.btnB1.Name = "btnB1";
            this.btnB1.Size = new System.Drawing.Size(92, 100);
            this.btnB1.TabIndex = 25;
            this.btnB1.Tag = "?";
            this.btnB1.UseVisualStyleBackColor = true;
            this.btnB1.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnA1
            // 
            this.btnA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA1.Image = global::Tic_Tac_Toe_Game.Properties.Resources.question_mark_96;
            this.btnA1.Location = new System.Drawing.Point(376, 96);
            this.btnA1.Name = "btnA1";
            this.btnA1.Size = new System.Drawing.Size(92, 100);
            this.btnA1.TabIndex = 24;
            this.btnA1.Tag = "?";
            this.btnA1.UseVisualStyleBackColor = true;
            this.btnA1.Click += new System.EventHandler(this.Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(890, 510);
            this.Controls.Add(this.btnC3);
            this.Controls.Add(this.btnB3);
            this.Controls.Add(this.btnA3);
            this.Controls.Add(this.btnC2);
            this.Controls.Add(this.btnB2);
            this.Controls.Add(this.btnA2);
            this.Controls.Add(this.btnC1);
            this.Controls.Add(this.btnB1);
            this.Controls.Add(this.btnA1);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblTurn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Tic-Tac-Toe Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnC3;
        private System.Windows.Forms.Button btnB3;
        private System.Windows.Forms.Button btnA3;
        private System.Windows.Forms.Button btnC2;
        private System.Windows.Forms.Button btnB2;
        private System.Windows.Forms.Button btnA2;
        private System.Windows.Forms.Button btnC1;
        private System.Windows.Forms.Button btnB1;
        private System.Windows.Forms.Button btnA1;
    }
}

