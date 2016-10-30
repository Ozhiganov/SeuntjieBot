namespace SeuntjieBot
{
    partial class Ui
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbRedList = new System.Windows.Forms.ListBox();
            this.lbBlackList = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblBalance = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbEligible = new System.Windows.Forms.ListBox();
            this.lbActive = new System.Windows.Forms.ListBox();
            this.clbCommands = new System.Windows.Forms.CheckedListBox();
            this.lstChat = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblTimeNext = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chkLogOnly = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRain = new System.Windows.Forms.Button();
            this.rdbComb = new System.Windows.Forms.RadioButton();
            this.rdbNat = new System.Windows.Forms.RadioButton();
            this.rdbUser = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudRainTime = new System.Windows.Forms.NumericUpDown();
            this.nudRainPerc = new System.Windows.Forms.NumericUpDown();
            this.nudMinRain = new System.Windows.Forms.NumericUpDown();
            this.tmrRainTime = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lbRedList);
            this.panel2.Controls.Add(this.lbBlackList);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblBalance);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbEligible);
            this.panel2.Controls.Add(this.lbActive);
            this.panel2.Controls.Add(this.clbCommands);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 593);
            this.panel2.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(141, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "RedList:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 268);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "BlackList:";
            // 
            // lbRedList
            // 
            this.lbRedList.FormattingEnabled = true;
            this.lbRedList.Location = new System.Drawing.Point(144, 284);
            this.lbRedList.Name = "lbRedList";
            this.lbRedList.Size = new System.Drawing.Size(120, 95);
            this.lbRedList.TabIndex = 16;
            // 
            // lbBlackList
            // 
            this.lbBlackList.FormattingEnabled = true;
            this.lbBlackList.Location = new System.Drawing.Point(18, 284);
            this.lbBlackList.Name = "lbBlackList";
            this.lbBlackList.Size = new System.Drawing.Size(120, 95);
            this.lbBlackList.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Eligible Users:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Active Users:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Commands:";
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(199, 21);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(13, 13);
            this.lblBalance.TabIndex = 11;
            this.lblBalance.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Balance:";
            // 
            // lbEligible
            // 
            this.lbEligible.FormattingEnabled = true;
            this.lbEligible.HorizontalScrollbar = true;
            this.lbEligible.Location = new System.Drawing.Point(144, 168);
            this.lbEligible.Name = "lbEligible";
            this.lbEligible.Size = new System.Drawing.Size(120, 95);
            this.lbEligible.TabIndex = 2;
            // 
            // lbActive
            // 
            this.lbActive.FormattingEnabled = true;
            this.lbActive.HorizontalScrollbar = true;
            this.lbActive.Location = new System.Drawing.Point(18, 168);
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
            this.clbCommands.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCommands_ItemCheck);
            // 
            // lstChat
            // 
            this.lstChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChat.FormattingEnabled = true;
            this.lstChat.Location = new System.Drawing.Point(0, 44);
            this.lstChat.Name = "lstChat";
            this.lstChat.Size = new System.Drawing.Size(971, 625);
            this.lstChat.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl1.Location = new System.Drawing.Point(683, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(288, 625);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(280, 599);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblTimeNext);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.chkLogOnly);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.btnRain);
            this.tabPage2.Controls.Add(this.rdbComb);
            this.tabPage2.Controls.Add(this.rdbNat);
            this.tabPage2.Controls.Add(this.rdbUser);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.nudRainTime);
            this.tabPage2.Controls.Add(this.nudRainPerc);
            this.tabPage2.Controls.Add(this.nudMinRain);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(280, 599);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblTimeNext
            // 
            this.lblTimeNext.AutoSize = true;
            this.lblTimeNext.Location = new System.Drawing.Point(92, 26);
            this.lblTimeNext.Name = "lblTimeNext";
            this.lblTimeNext.Size = new System.Drawing.Size(13, 13);
            this.lblTimeNext.TabIndex = 37;
            this.lblTimeNext.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Time to next rain:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 123);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Min Rain Score:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(95, 121);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(83, 20);
            this.numericUpDown1.TabIndex = 34;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // chkLogOnly
            // 
            this.chkLogOnly.AutoSize = true;
            this.chkLogOnly.Location = new System.Drawing.Point(40, 6);
            this.chkLogOnly.Name = "chkLogOnly";
            this.chkLogOnly.Size = new System.Drawing.Size(68, 17);
            this.chkLogOnly.TabIndex = 33;
            this.chkLogOnly.Text = "Log Only";
            this.chkLogOnly.UseVisualStyleBackColor = true;
            this.chkLogOnly.CheckedChanged += new System.EventHandler(this.chkLogOnly_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 149);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Rain Mode:";
            // 
            // btnRain
            // 
            this.btnRain.Location = new System.Drawing.Point(197, 40);
            this.btnRain.Name = "btnRain";
            this.btnRain.Size = new System.Drawing.Size(75, 23);
            this.btnRain.TabIndex = 31;
            this.btnRain.Text = "Rain";
            this.btnRain.UseVisualStyleBackColor = true;
            this.btnRain.Click += new System.EventHandler(this.btnRain_Click);
            // 
            // rdbComb
            // 
            this.rdbComb.AutoSize = true;
            this.rdbComb.Checked = true;
            this.rdbComb.Location = new System.Drawing.Point(95, 193);
            this.rdbComb.Name = "rdbComb";
            this.rdbComb.Size = new System.Drawing.Size(83, 17);
            this.rdbComb.TabIndex = 30;
            this.rdbComb.TabStop = true;
            this.rdbComb.Text = "Combination";
            this.rdbComb.UseVisualStyleBackColor = true;
            this.rdbComb.CheckedChanged += new System.EventHandler(this.rdbComb_CheckedChanged);
            // 
            // rdbNat
            // 
            this.rdbNat.AutoSize = true;
            this.rdbNat.Location = new System.Drawing.Point(95, 170);
            this.rdbNat.Name = "rdbNat";
            this.rdbNat.Size = new System.Drawing.Size(59, 17);
            this.rdbNat.TabIndex = 29;
            this.rdbNat.Text = "Natural";
            this.rdbNat.UseVisualStyleBackColor = true;
            this.rdbNat.CheckedChanged += new System.EventHandler(this.rdbComb_CheckedChanged);
            // 
            // rdbUser
            // 
            this.rdbUser.AutoSize = true;
            this.rdbUser.Location = new System.Drawing.Point(95, 147);
            this.rdbUser.Name = "rdbUser";
            this.rdbUser.Size = new System.Drawing.Size(47, 17);
            this.rdbUser.TabIndex = 28;
            this.rdbUser.Text = "User";
            this.rdbUser.UseVisualStyleBackColor = true;
            this.rdbUser.CheckedChanged += new System.EventHandler(this.rdbComb_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Rain %:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Rain Time (min):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Min Rain:";
            // 
            // nudRainTime
            // 
            this.nudRainTime.DecimalPlaces = 3;
            this.nudRainTime.Location = new System.Drawing.Point(95, 95);
            this.nudRainTime.Name = "nudRainTime";
            this.nudRainTime.Size = new System.Drawing.Size(83, 20);
            this.nudRainTime.TabIndex = 24;
            this.nudRainTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRainTime.ValueChanged += new System.EventHandler(this.nudRainTime_ValueChanged_1);
            // 
            // nudRainPerc
            // 
            this.nudRainPerc.DecimalPlaces = 4;
            this.nudRainPerc.Location = new System.Drawing.Point(95, 69);
            this.nudRainPerc.Name = "nudRainPerc";
            this.nudRainPerc.Size = new System.Drawing.Size(83, 20);
            this.nudRainPerc.TabIndex = 23;
            this.nudRainPerc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRainPerc.ValueChanged += new System.EventHandler(this.nudRainPerc_ValueChanged_1);
            // 
            // nudMinRain
            // 
            this.nudMinRain.DecimalPlaces = 8;
            this.nudMinRain.Location = new System.Drawing.Point(95, 43);
            this.nudMinRain.Name = "nudMinRain";
            this.nudMinRain.Size = new System.Drawing.Size(83, 20);
            this.nudMinRain.TabIndex = 22;
            this.nudMinRain.Value = new decimal(new int[] {
            5,
            0,
            0,
            262144});
            // 
            // tmrRainTime
            // 
            this.tmrRainTime.Enabled = true;
            this.tmrRainTime.Interval = 1000;
            this.tmrRainTime.Tick += new System.EventHandler(this.tmrRainTime_Tick);
            // 
            // Ui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lstChat);
            this.Controls.Add(this.panel1);
            this.Name = "Ui";
            this.Size = new System.Drawing.Size(971, 669);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRainTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRainPerc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinRain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstChat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        protected System.Windows.Forms.ListBox lbEligible;
        protected System.Windows.Forms.ListBox lbActive;
        protected System.Windows.Forms.CheckedListBox clbCommands;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Label label10;
        protected System.Windows.Forms.ListBox lbRedList;
        protected System.Windows.Forms.ListBox lbBlackList;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label7;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Button btnRain;
        protected System.Windows.Forms.RadioButton rdbComb;
        protected System.Windows.Forms.RadioButton rdbNat;
        protected System.Windows.Forms.RadioButton rdbUser;
        protected System.Windows.Forms.Label label5;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.NumericUpDown nudRainTime;
        protected System.Windows.Forms.NumericUpDown nudRainPerc;
        protected System.Windows.Forms.NumericUpDown nudMinRain;
        protected System.Windows.Forms.CheckBox chkLogOnly;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.NumericUpDown numericUpDown1;
        protected System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.Label lblTimeNext;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Timer tmrRainTime;
    }
}

