namespace SeuntjieBotExample
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
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRainTime = new System.Windows.Forms.NumericUpDown();
            this.nudRainPerc = new System.Windows.Forms.NumericUpDown();
            this.nudMinRain = new System.Windows.Forms.NumericUpDown();
            this.btnRain = new System.Windows.Forms.Button();
            this.lbEligible = new System.Windows.Forms.ListBox();
            this.lbActive = new System.Windows.Forms.ListBox();
            this.clbCommands = new System.Windows.Forms.CheckedListBox();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRainTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRainPerc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinRain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(335, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start Bot";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(64, 13);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(229, 13);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '.';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 44);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblBalance);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.nudRainTime);
            this.panel2.Controls.Add(this.nudRainPerc);
            this.panel2.Controls.Add(this.nudMinRain);
            this.panel2.Controls.Add(this.btnRain);
            this.panel2.Controls.Add(this.lbEligible);
            this.panel2.Controls.Add(this.lbActive);
            this.panel2.Controls.Add(this.clbCommands);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(694, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(277, 625);
            this.panel2.TabIndex = 6;
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(199, 47);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(13, 13);
            this.lblBalance.TabIndex = 11;
            this.lblBalance.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Balance:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rain %:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Rain Time (min):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Min Rain:";
            // 
            // nudRainTime
            // 
            this.nudRainTime.DecimalPlaces = 3;
            this.nudRainTime.Location = new System.Drawing.Point(144, 338);
            this.nudRainTime.Name = "nudRainTime";
            this.nudRainTime.Size = new System.Drawing.Size(120, 20);
            this.nudRainTime.TabIndex = 6;
            // 
            // nudRainPerc
            // 
            this.nudRainPerc.DecimalPlaces = 4;
            this.nudRainPerc.Location = new System.Drawing.Point(144, 312);
            this.nudRainPerc.Name = "nudRainPerc";
            this.nudRainPerc.Size = new System.Drawing.Size(120, 20);
            this.nudRainPerc.TabIndex = 5;
            // 
            // nudMinRain
            // 
            this.nudMinRain.DecimalPlaces = 8;
            this.nudMinRain.Location = new System.Drawing.Point(144, 286);
            this.nudMinRain.Name = "nudMinRain";
            this.nudMinRain.Size = new System.Drawing.Size(120, 20);
            this.nudMinRain.TabIndex = 4;
            // 
            // btnRain
            // 
            this.btnRain.Location = new System.Drawing.Point(144, 21);
            this.btnRain.Name = "btnRain";
            this.btnRain.Size = new System.Drawing.Size(75, 23);
            this.btnRain.TabIndex = 3;
            this.btnRain.Text = "Rain";
            this.btnRain.UseVisualStyleBackColor = true;
            // 
            // lbEligible
            // 
            this.lbEligible.FormattingEnabled = true;
            this.lbEligible.Location = new System.Drawing.Point(144, 158);
            this.lbEligible.Name = "lbEligible";
            this.lbEligible.Size = new System.Drawing.Size(120, 95);
            this.lbEligible.TabIndex = 2;
            // 
            // lbActive
            // 
            this.lbActive.FormattingEnabled = true;
            this.lbActive.Location = new System.Drawing.Point(18, 158);
            this.lbActive.Name = "lbActive";
            this.lbActive.Size = new System.Drawing.Size(120, 95);
            this.lbActive.TabIndex = 1;
            // 
            // clbCommands
            // 
            this.clbCommands.FormattingEnabled = true;
            this.clbCommands.Location = new System.Drawing.Point(18, 21);
            this.clbCommands.Name = "clbCommands";
            this.clbCommands.Size = new System.Drawing.Size(120, 124);
            this.clbCommands.TabIndex = 0;
            // 
            // lstChat
            // 
            this.lstChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChat.FormattingEnabled = true;
            this.lstChat.Location = new System.Drawing.Point(0, 44);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(694, 625);
            this.lstChat.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 669);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRainTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRainPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinRain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nudRainTime;
        private System.Windows.Forms.NumericUpDown nudRainPerc;
        private System.Windows.Forms.NumericUpDown nudMinRain;
        private System.Windows.Forms.Button btnRain;
        private System.Windows.Forms.ListBox lbEligible;
        private System.Windows.Forms.ListBox lbActive;
        private System.Windows.Forms.CheckedListBox clbCommands;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstChat;
    }
}

