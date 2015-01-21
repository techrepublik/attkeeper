namespace AttendanceKeeper
{
    partial class MianForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MianForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataAccessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machineLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dTRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dTRSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.administrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.holidaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overtimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.onLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonEnrollees = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDTR = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMacLogs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPreferences = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDTRSetting = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 344);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabel1.Text = "Ready...";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(675, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.Text = "...";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel3.Text = "Date/Time:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.managementToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(804, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceToolStripMenuItem,
            this.recordsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.administrationToolStripMenuItem});
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.managementToolStripMenuItem.Text = "&Management";
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.dataAccessToolStripMenuItem,
            this.machineLogsToolStripMenuItem});
            this.deviceToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.General_Options;
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deviceToolStripMenuItem.Text = "&Device";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.General_Options;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.settingsToolStripMenuItem.Text = "&Settings and Control";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(190, 6);
            // 
            // dataAccessToolStripMenuItem
            // 
            this.dataAccessToolStripMenuItem.Name = "dataAccessToolStripMenuItem";
            this.dataAccessToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.dataAccessToolStripMenuItem.Text = "&Data Access";
            this.dataAccessToolStripMenuItem.Click += new System.EventHandler(this.dataAccessToolStripMenuItem_Click);
            // 
            // machineLogsToolStripMenuItem
            // 
            this.machineLogsToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.New_Doc;
            this.machineLogsToolStripMenuItem.Name = "machineLogsToolStripMenuItem";
            this.machineLogsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.machineLogsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.machineLogsToolStripMenuItem.Text = "&Machine Logs";
            this.machineLogsToolStripMenuItem.Click += new System.EventHandler(this.machineLogsToolStripMenuItem_Click);
            // 
            // recordsToolStripMenuItem
            // 
            this.recordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem,
            this.toolStripMenuItem5,
            this.toolStripSeparator1,
            this.dTRToolStripMenuItem,
            this.dTRSettingsToolStripMenuItem,
            this.toolStripMenuItem4,
            this.preferencesToolStripMenuItem});
            this.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            this.recordsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.recordsToolStripMenuItem.Text = "&Records";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.List;
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.employeesToolStripMenuItem.Text = "&Employees";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItem5.Text = "&Import Employees (Excel)";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
            // 
            // dTRToolStripMenuItem
            // 
            this.dTRToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.Contacts;
            this.dTRToolStripMenuItem.Name = "dTRToolStripMenuItem";
            this.dTRToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.dTRToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.dTRToolStripMenuItem.Text = "&DTR";
            this.dTRToolStripMenuItem.Click += new System.EventHandler(this.dTRToolStripMenuItem_Click);
            // 
            // dTRSettingsToolStripMenuItem
            // 
            this.dTRSettingsToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.Calendar_Multiweek;
            this.dTRSettingsToolStripMenuItem.Name = "dTRSettingsToolStripMenuItem";
            this.dTRSettingsToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.dTRSettingsToolStripMenuItem.Text = "DT&R Settings";
            this.dTRSettingsToolStripMenuItem.Click += new System.EventHandler(this.dTRSettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(204, 6);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.Advanced_Options;
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 6);
            // 
            // administrationToolStripMenuItem
            // 
            this.administrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.backupToolStripMenuItem});
            this.administrationToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.Control_Panel;
            this.administrationToolStripMenuItem.Name = "administrationToolStripMenuItem";
            this.administrationToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.administrationToolStripMenuItem.Text = "&Administration";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::AttendanceKeeper.Properties.Resources.Group;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.usersToolStripMenuItem.Text = "&Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.logsToolStripMenuItem.Text = "&Logs";
            this.logsToolStripMenuItem.Click += new System.EventHandler(this.logsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.backupToolStripMenuItem.Text = "&Backup/Restore Database";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.holidaysToolStripMenuItem,
            this.overtimeToolStripMenuItem,
            this.toolStripMenuItemLeave,
            this.onLeaveToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "&Report";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItem6.Text = "&Enrollees List";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // holidaysToolStripMenuItem
            // 
            this.holidaysToolStripMenuItem.Name = "holidaysToolStripMenuItem";
            this.holidaysToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.holidaysToolStripMenuItem.Text = "&Holiday";
            this.holidaysToolStripMenuItem.Click += new System.EventHandler(this.holidaysToolStripMenuItem_Click);
            // 
            // overtimeToolStripMenuItem
            // 
            this.overtimeToolStripMenuItem.Name = "overtimeToolStripMenuItem";
            this.overtimeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.overtimeToolStripMenuItem.Text = "&Overtime/Undertime";
            this.overtimeToolStripMenuItem.Click += new System.EventHandler(this.overtimeToolStripMenuItem_Click);
            // 
            // toolStripMenuItemLeave
            // 
            this.toolStripMenuItemLeave.Name = "toolStripMenuItemLeave";
            this.toolStripMenuItemLeave.Size = new System.Drawing.Size(184, 22);
            this.toolStripMenuItemLeave.Text = "&Leaves";
            this.toolStripMenuItemLeave.Click += new System.EventHandler(this.toolStripMenuItemLeave_Click);
            // 
            // onLeaveToolStripMenuItem
            // 
            this.onLeaveToolStripMenuItem.Name = "onLeaveToolStripMenuItem";
            this.onLeaveToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.onLeaveToolStripMenuItem.Text = "On &Leave";
            this.onLeaveToolStripMenuItem.Visible = false;
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeViewToolStripMenuItem,
            this.tileViewToolStripMenuItem,
            this.tileVerticalToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // cascadeViewToolStripMenuItem
            // 
            this.cascadeViewToolStripMenuItem.Name = "cascadeViewToolStripMenuItem";
            this.cascadeViewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeViewToolStripMenuItem.Text = "&Cascade";
            this.cascadeViewToolStripMenuItem.Click += new System.EventHandler(this.cascadeViewToolStripMenuItem_Click);
            // 
            // tileViewToolStripMenuItem
            // 
            this.tileViewToolStripMenuItem.Name = "tileViewToolStripMenuItem";
            this.tileViewToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileViewToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileViewToolStripMenuItem.Click += new System.EventHandler(this.tileViewToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationInfoToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // applicationInfoToolStripMenuItem
            // 
            this.applicationInfoToolStripMenuItem.Name = "applicationInfoToolStripMenuItem";
            this.applicationInfoToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.applicationInfoToolStripMenuItem.Text = "&App Info";
            this.applicationInfoToolStripMenuItem.Click += new System.EventHandler(this.applicationInfoToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonEnrollees,
            this.toolStripButtonDTR,
            this.toolStripButtonMacLogs,
            this.toolStripSeparator2,
            this.toolStripButtonDevice,
            this.toolStripButtonPreferences,
            this.toolStripButtonDTRSetting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(804, 41);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonEnrollees
            // 
            this.toolStripButtonEnrollees.Image = global::AttendanceKeeper.Properties.Resources.List;
            this.toolStripButtonEnrollees.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEnrollees.Name = "toolStripButtonEnrollees";
            this.toolStripButtonEnrollees.Size = new System.Drawing.Size(74, 38);
            this.toolStripButtonEnrollees.Text = "&Enrollees";
            this.toolStripButtonEnrollees.Click += new System.EventHandler(this.toolStripButtonEnrollees_Click);
            // 
            // toolStripButtonDTR
            // 
            this.toolStripButtonDTR.Image = global::AttendanceKeeper.Properties.Resources.Contacts;
            this.toolStripButtonDTR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDTR.Name = "toolStripButtonDTR";
            this.toolStripButtonDTR.Size = new System.Drawing.Size(49, 38);
            this.toolStripButtonDTR.Text = "&DTR";
            this.toolStripButtonDTR.Click += new System.EventHandler(this.toolStripButtonDTR_Click);
            // 
            // toolStripButtonMacLogs
            // 
            this.toolStripButtonMacLogs.Image = global::AttendanceKeeper.Properties.Resources.New_Doc;
            this.toolStripButtonMacLogs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMacLogs.Name = "toolStripButtonMacLogs";
            this.toolStripButtonMacLogs.Size = new System.Drawing.Size(101, 38);
            this.toolStripButtonMacLogs.Text = "&Machine Logs";
            this.toolStripButtonMacLogs.Click += new System.EventHandler(this.toolStripButtonMacLogs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButtonDevice
            // 
            this.toolStripButtonDevice.Image = global::AttendanceKeeper.Properties.Resources.General_Options1;
            this.toolStripButtonDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDevice.Name = "toolStripButtonDevice";
            this.toolStripButtonDevice.Size = new System.Drawing.Size(105, 38);
            this.toolStripButtonDevice.Text = "&Device Control";
            this.toolStripButtonDevice.Click += new System.EventHandler(this.toolStripButtonDevice_Click);
            // 
            // toolStripButtonPreferences
            // 
            this.toolStripButtonPreferences.Image = global::AttendanceKeeper.Properties.Resources.Advanced_Options;
            this.toolStripButtonPreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPreferences.Name = "toolStripButtonPreferences";
            this.toolStripButtonPreferences.Size = new System.Drawing.Size(88, 38);
            this.toolStripButtonPreferences.Text = "&Preferences";
            this.toolStripButtonPreferences.Click += new System.EventHandler(this.toolStripButtonPreferences_Click);
            // 
            // toolStripButtonDTRSetting
            // 
            this.toolStripButtonDTRSetting.Image = global::AttendanceKeeper.Properties.Resources.Calendar_Multiweek;
            this.toolStripButtonDTRSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDTRSetting.Name = "toolStripButtonDTRSetting";
            this.toolStripButtonDTRSetting.Size = new System.Drawing.Size(89, 38);
            this.toolStripButtonDTRSetting.Text = "DTR Setting";
            this.toolStripButtonDTRSetting.Click += new System.EventHandler(this.toolStripButtonDTRSetting_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MianForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(804, 366);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MianForm";
            this.Text = "Attendance Keeper v1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MianForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MianForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem managementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem administrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataAccessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dTRSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem holidaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overtimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onLeaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem machineLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonDevice;
        private System.Windows.Forms.ToolStripButton toolStripButtonPreferences;
        private System.Windows.Forms.ToolStripButton toolStripButtonDTRSetting;
        private System.Windows.Forms.ToolStripButton toolStripButtonEnrollees;
        private System.Windows.Forms.ToolStripButton toolStripButtonDTR;
        private System.Windows.Forms.ToolStripButton toolStripButtonMacLogs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cascadeViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemLeave;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem applicationInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.Timer timer1;
    }
}

