namespace AttendanceKeeper.Management
{
    partial class MachineSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineSettingForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.buttonSetTime02 = new System.Windows.Forms.Button();
            this.buttonSetTime = new System.Windows.Forms.Button();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.buttonOff = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxNew = new System.Windows.Forms.TextBox();
            this.textBoxCurrent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.comboBoxSec = new System.Windows.Forms.ComboBox();
            this.comboBoxMin = new System.Windows.Forms.ComboBox();
            this.comboBoxHour = new System.Windows.Forms.ComboBox();
            this.comboBoxDay = new System.Windows.Forms.ComboBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.labelCompanyName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 45);
            this.panel1.TabIndex = 2;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyName.ForeColor = System.Drawing.Color.White;
            this.labelCompanyName.Location = new System.Drawing.Point(1, 1);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(461, 24);
            this.labelCompanyName.TabIndex = 7;
            this.labelCompanyName.Text = "COMPANY NAME";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(526, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Attendance Keeper v1.0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 376);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(652, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Ready...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.buttonClearLogs);
            this.groupBox1.Controls.Add(this.buttonSetTime02);
            this.groupBox1.Controls.Add(this.buttonSetTime);
            this.groupBox1.Controls.Add(this.buttonTestConnection);
            this.groupBox1.Controls.Add(this.buttonOff);
            this.groupBox1.Controls.Add(this.buttonRestart);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 308);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 225);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "&Check Logs";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Location = new System.Drawing.Point(6, 274);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(162, 23);
            this.buttonClearLogs.TabIndex = 5;
            this.buttonClearLogs.Text = "&Clear Logs";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.buttonClearLogs_Click);
            // 
            // buttonSetTime02
            // 
            this.buttonSetTime02.Location = new System.Drawing.Point(6, 174);
            this.buttonSetTime02.Name = "buttonSetTime02";
            this.buttonSetTime02.Size = new System.Drawing.Size(162, 23);
            this.buttonSetTime02.TabIndex = 4;
            this.buttonSetTime02.Text = "&Set Time";
            this.buttonSetTime02.UseVisualStyleBackColor = true;
            this.buttonSetTime02.Click += new System.EventHandler(this.buttonSetTime02_Click);
            // 
            // buttonSetTime
            // 
            this.buttonSetTime.Location = new System.Drawing.Point(6, 145);
            this.buttonSetTime.Name = "buttonSetTime";
            this.buttonSetTime.Size = new System.Drawing.Size(162, 23);
            this.buttonSetTime.TabIndex = 3;
            this.buttonSetTime.Text = "&Set Time According to PC";
            this.buttonSetTime.UseVisualStyleBackColor = true;
            this.buttonSetTime.Click += new System.EventHandler(this.buttonSetTime_Click);
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(6, 116);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(162, 23);
            this.buttonTestConnection.TabIndex = 2;
            this.buttonTestConnection.Text = "&Test Connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click);
            // 
            // buttonOff
            // 
            this.buttonOff.Location = new System.Drawing.Point(6, 59);
            this.buttonOff.Name = "buttonOff";
            this.buttonOff.Size = new System.Drawing.Size(162, 23);
            this.buttonOff.TabIndex = 1;
            this.buttonOff.Text = "&Power Off";
            this.buttonOff.UseVisualStyleBackColor = true;
            this.buttonOff.Click += new System.EventHandler(this.buttonOff_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(6, 30);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(162, 23);
            this.buttonRestart.TabIndex = 0;
            this.buttonRestart.Text = "&Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxNew);
            this.groupBox2.Controls.Add(this.textBoxCurrent);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.buttonExecute);
            this.groupBox2.Controls.Add(this.comboBoxSec);
            this.groupBox2.Controls.Add(this.comboBoxMin);
            this.groupBox2.Controls.Add(this.comboBoxHour);
            this.groupBox2.Controls.Add(this.comboBoxDay);
            this.groupBox2.Controls.Add(this.comboBoxMonth);
            this.groupBox2.Controls.Add(this.comboBoxYear);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(197, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 134);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set Time: ";
            // 
            // textBoxNew
            // 
            this.textBoxNew.ForeColor = System.Drawing.Color.Blue;
            this.textBoxNew.Location = new System.Drawing.Point(89, 108);
            this.textBoxNew.Name = "textBoxNew";
            this.textBoxNew.ReadOnly = true;
            this.textBoxNew.Size = new System.Drawing.Size(149, 20);
            this.textBoxNew.TabIndex = 11;
            // 
            // textBoxCurrent
            // 
            this.textBoxCurrent.ForeColor = System.Drawing.Color.Red;
            this.textBoxCurrent.Location = new System.Drawing.Point(89, 83);
            this.textBoxCurrent.Name = "textBoxCurrent";
            this.textBoxCurrent.ReadOnly = true;
            this.textBoxCurrent.Size = new System.Drawing.Size(149, 20);
            this.textBoxCurrent.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "New Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Current Time:";
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(275, 105);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(162, 23);
            this.buttonExecute.TabIndex = 7;
            this.buttonExecute.Text = "&Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // comboBoxSec
            // 
            this.comboBoxSec.FormattingEnabled = true;
            this.comboBoxSec.Location = new System.Drawing.Point(384, 51);
            this.comboBoxSec.Name = "comboBoxSec";
            this.comboBoxSec.Size = new System.Drawing.Size(53, 21);
            this.comboBoxSec.TabIndex = 6;
            // 
            // comboBoxMin
            // 
            this.comboBoxMin.FormattingEnabled = true;
            this.comboBoxMin.Location = new System.Drawing.Point(325, 51);
            this.comboBoxMin.Name = "comboBoxMin";
            this.comboBoxMin.Size = new System.Drawing.Size(53, 21);
            this.comboBoxMin.TabIndex = 5;
            // 
            // comboBoxHour
            // 
            this.comboBoxHour.FormattingEnabled = true;
            this.comboBoxHour.Location = new System.Drawing.Point(266, 51);
            this.comboBoxHour.Name = "comboBoxHour";
            this.comboBoxHour.Size = new System.Drawing.Size(53, 21);
            this.comboBoxHour.TabIndex = 4;
            // 
            // comboBoxDay
            // 
            this.comboBoxDay.FormattingEnabled = true;
            this.comboBoxDay.Location = new System.Drawing.Point(196, 51);
            this.comboBoxDay.Name = "comboBoxDay";
            this.comboBoxDay.Size = new System.Drawing.Size(53, 21);
            this.comboBoxDay.TabIndex = 3;
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(86, 51);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(104, 21);
            this.comboBoxMonth.TabIndex = 2;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(12, 51);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(68, 21);
            this.comboBoxYear.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Format: Year-Month-Day Hour-Min-Sec";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AttendanceKeeper.Properties.Resources.iface302;
            this.pictureBox1.Location = new System.Drawing.Point(197, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(443, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MachineSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 398);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MachineSettingForm";
            this.Text = "Machine Setting Form";
            this.Load += new System.EventHandler(this.MachineSettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonOff;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.Button buttonSetTime;
        private System.Windows.Forms.Button buttonSetTime02;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonClearLogs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDay;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.ComboBox comboBoxSec;
        private System.Windows.Forms.ComboBox comboBoxMin;
        private System.Windows.Forms.ComboBox comboBoxHour;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNew;
        private System.Windows.Forms.TextBox textBoxCurrent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label label4;
    }
}