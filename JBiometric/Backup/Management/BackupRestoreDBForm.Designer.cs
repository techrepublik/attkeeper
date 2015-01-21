namespace AttendanceKeeper.Management
{
    partial class BackupRestoreDBForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupRestoreDBForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chkWindowsAuthentication = new System.Windows.Forms.CheckBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnBackupLog = new System.Windows.Forms.Button();
            this.btnBackupDB = new System.Windows.Forms.Button();
            this.chkIncremental = new System.Windows.Forms.CheckBox();
            this.lblBackupFile = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblDatabse = new System.Windows.Forms.Label();
            this.ddlDatabase = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tabServers = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstLocalInstances = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstNetworkInstances = new System.Windows.Forms.ListBox();
            this.radioButtonBackup = new System.Windows.Forms.RadioButton();
            this.radioButtonRestore = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabServers.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Location = new System.Drawing.Point(10, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(620, 150);
            this.dataGridView1.TabIndex = 37;
            this.dataGridView1.Text = "dataGridView1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 411);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(621, 23);
            this.progressBar1.TabIndex = 36;
            // 
            // chkWindowsAuthentication
            // 
            this.chkWindowsAuthentication.AutoSize = true;
            this.chkWindowsAuthentication.Location = new System.Drawing.Point(312, 127);
            this.chkWindowsAuthentication.Name = "chkWindowsAuthentication";
            this.chkWindowsAuthentication.Size = new System.Drawing.Size(163, 17);
            this.chkWindowsAuthentication.TabIndex = 3;
            this.chkWindowsAuthentication.Text = "Use Windows Authentication";
            this.chkWindowsAuthentication.UseVisualStyleBackColor = true;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(474, 226);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 11;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(555, 226);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 12;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnBackupLog
            // 
            this.btnBackupLog.Location = new System.Drawing.Point(393, 226);
            this.btnBackupLog.Name = "btnBackupLog";
            this.btnBackupLog.Size = new System.Drawing.Size(75, 23);
            this.btnBackupLog.TabIndex = 10;
            this.btnBackupLog.Text = "Backup Log";
            this.btnBackupLog.UseVisualStyleBackColor = true;
            this.btnBackupLog.Click += new System.EventHandler(this.btnBackupLog_Click);
            // 
            // btnBackupDB
            // 
            this.btnBackupDB.Location = new System.Drawing.Point(312, 226);
            this.btnBackupDB.Name = "btnBackupDB";
            this.btnBackupDB.Size = new System.Drawing.Size(75, 23);
            this.btnBackupDB.TabIndex = 9;
            this.btnBackupDB.Text = "Backup DB";
            this.btnBackupDB.UseVisualStyleBackColor = true;
            this.btnBackupDB.Click += new System.EventHandler(this.btnBackupDB_Click);
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.Location = new System.Drawing.Point(312, 177);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Size = new System.Drawing.Size(81, 17);
            this.chkIncremental.TabIndex = 5;
            this.chkIncremental.Text = "Incremental";
            this.chkIncremental.UseVisualStyleBackColor = true;
            // 
            // lblBackupFile
            // 
            this.lblBackupFile.AutoSize = true;
            this.lblBackupFile.Location = new System.Drawing.Point(309, 201);
            this.lblBackupFile.Name = "lblBackupFile";
            this.lblBackupFile.Size = new System.Drawing.Size(66, 13);
            this.lblBackupFile.TabIndex = 29;
            this.lblBackupFile.Text = "Backup File:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(602, 196);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(28, 23);
            this.btnBrowse.TabIndex = 28;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(373, 198);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(226, 20);
            this.txtFileName.TabIndex = 8;
            // 
            // lblDatabse
            // 
            this.lblDatabse.AutoSize = true;
            this.lblDatabse.Location = new System.Drawing.Point(309, 153);
            this.lblDatabse.Name = "lblDatabse";
            this.lblDatabse.Size = new System.Drawing.Size(56, 13);
            this.lblDatabse.TabIndex = 26;
            this.lblDatabse.Text = "Database:";
            // 
            // ddlDatabase
            // 
            this.ddlDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDatabase.FormattingEnabled = true;
            this.ddlDatabase.Location = new System.Drawing.Point(373, 150);
            this.ddlDatabase.Name = "ddlDatabase";
            this.ddlDatabase.Size = new System.Drawing.Size(257, 21);
            this.ddlDatabase.TabIndex = 4;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(558, 99);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(72, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(373, 101);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(179, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(373, 75);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(179, 20);
            this.txtLogin.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(309, 104);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "Password:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(309, 78);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 20;
            this.lblLogin.Text = "Login:";
            // 
            // tabServers
            // 
            this.tabServers.Controls.Add(this.tabPage1);
            this.tabServers.Controls.Add(this.tabPage2);
            this.tabServers.Location = new System.Drawing.Point(10, 53);
            this.tabServers.Name = "tabServers";
            this.tabServers.SelectedIndex = 0;
            this.tabServers.Size = new System.Drawing.Size(283, 196);
            this.tabServers.TabIndex = 19;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstLocalInstances);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(275, 170);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local Instances";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstLocalInstances
            // 
            this.lstLocalInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLocalInstances.FormattingEnabled = true;
            this.lstLocalInstances.Location = new System.Drawing.Point(3, 3);
            this.lstLocalInstances.Name = "lstLocalInstances";
            this.lstLocalInstances.Size = new System.Drawing.Size(269, 160);
            this.lstLocalInstances.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstNetworkInstances);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(275, 170);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Network Instances";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstNetworkInstances
            // 
            this.lstNetworkInstances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNetworkInstances.FormattingEnabled = true;
            this.lstNetworkInstances.Location = new System.Drawing.Point(3, 3);
            this.lstNetworkInstances.Name = "lstNetworkInstances";
            this.lstNetworkInstances.Size = new System.Drawing.Size(269, 160);
            this.lstNetworkInstances.TabIndex = 0;
            // 
            // radioButtonBackup
            // 
            this.radioButtonBackup.AutoSize = true;
            this.radioButtonBackup.Location = new System.Drawing.Point(413, 176);
            this.radioButtonBackup.Name = "radioButtonBackup";
            this.radioButtonBackup.Size = new System.Drawing.Size(62, 17);
            this.radioButtonBackup.TabIndex = 6;
            this.radioButtonBackup.TabStop = true;
            this.radioButtonBackup.Text = "&Backup";
            this.radioButtonBackup.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestore
            // 
            this.radioButtonRestore.AutoSize = true;
            this.radioButtonRestore.Location = new System.Drawing.Point(493, 176);
            this.radioButtonRestore.Name = "radioButtonRestore";
            this.radioButtonRestore.Size = new System.Drawing.Size(62, 17);
            this.radioButtonRestore.TabIndex = 7;
            this.radioButtonRestore.TabStop = true;
            this.radioButtonRestore.Text = "&Restore";
            this.radioButtonRestore.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 45);
            this.panel1.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(516, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Attendance Keeper v1.0";
            // 
            // BackupRestoreDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioButtonRestore);
            this.Controls.Add(this.radioButtonBackup);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.chkWindowsAuthentication);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnBackupLog);
            this.Controls.Add(this.btnBackupDB);
            this.Controls.Add(this.chkIncremental);
            this.Controls.Add(this.lblBackupFile);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblDatabse);
            this.Controls.Add(this.ddlDatabase);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.tabServers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackupRestoreDBForm";
            this.Text = "Backup Restore DB Form";
            this.Load += new System.EventHandler(this.BackupRestoreDBForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabServers.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox chkWindowsAuthentication;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnBackupLog;
        private System.Windows.Forms.Button btnBackupDB;
        private System.Windows.Forms.CheckBox chkIncremental;
        private System.Windows.Forms.Label lblBackupFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblDatabse;
        private System.Windows.Forms.ComboBox ddlDatabase;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TabControl tabServers;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lstLocalInstances;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstNetworkInstances;
        private System.Windows.Forms.RadioButton radioButtonBackup;
        private System.Windows.Forms.RadioButton radioButtonRestore;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}