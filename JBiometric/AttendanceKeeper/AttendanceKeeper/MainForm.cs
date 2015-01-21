using System;
using System.Windows.Forms;
using AttendanceKeeper.Management;
using AttendanceKeeper.Data;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace AttendanceKeeper
{
    public partial class MianForm : Form
    {
        public User OUser { get; set; }
        public Company OCompany { get; set; }

        public int IUserId { get; set; }
        public string SUserName { get; set; }
        public string  SLevel { get; set; }
        public bool IsUser { get; set; }

        private Timer t1;

        public MianForm()
        {
            InitializeComponent();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ef = new EmployeeForm {MdiParent = this, WindowState = FormWindowState.Maximized, IsUser = IsUser, SCompanyName = OCompany.CompanyName};
            ef.Show();
        }

        private void dTRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var df = new DTRForm {MdiParent = this, WindowState = FormWindowState.Maximized, SUserName = SUserName, SCompanyName = OCompany.CompanyName, IsUser = IsUser};
            df.Show();
        }

        private void dTRSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dtrSet = new DTRSettingForm {MdiParent = this, WindowState = FormWindowState.Maximized, IsUser = IsUser, SUserName = SUserName, SCompanyName = OCompany.CompanyName};
            dtrSet.Show();
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pf = new PreferenceForm {StartPosition = FormStartPosition.CenterScreen, MaximizeBox = false, 
                                         MinimizeBox = false, FormBorderStyle = FormBorderStyle.FixedSingle, IsUser = IsUser, SUserName = SUserName, SCompanyName = OCompany.CompanyName};
            pf.ShowDialog();
        }

        private void machineLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mlf = new MachineLogForm {MaximizeBox = false, MinimizeBox = false, FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle, StartPosition = FormStartPosition.CenterScreen, SUserName = SUserName, SCompanyName = OCompany.CompanyName};
            mlf.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var uf = new UserForm
                         {
                             MinimizeBox = false,
                             MaximizeBox = false,
                             FormBorderStyle = FormBorderStyle.FixedSingle,
                             StartPosition = FormStartPosition.CenterScreen,
                             SUserName = SUserName,
                             SCompanyName = OCompany.CompanyName
                         };
            uf.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var mf = new MachineSettingForm
                         {
                             MaximizeBox = false,
                             MinimizeBox = false,
                             FormBorderStyle = FormBorderStyle.FixedSingle,
                             StartPosition = FormStartPosition.CenterScreen,
                             SCompanyName = OCompany.CompanyName
                         };
            mf.ShowDialog();
        }

        private void toolStripButtonEnrollees_Click(object sender, EventArgs e)
        {
            var ef = new EmployeeForm { MdiParent = this, WindowState = FormWindowState.Maximized, IsUser = IsUser, SCompanyName = OCompany.CompanyName};
            ef.Show();
        }

        private void toolStripButtonDTR_Click(object sender, EventArgs e)
        {
            var df = new DTRForm { MdiParent = this, WindowState = FormWindowState.Maximized, SUserName = SUserName, SCompanyName = OCompany.CompanyName, IsUser = IsUser};
            df.Show();
        }

        private void toolStripButtonMacLogs_Click(object sender, EventArgs e)
        {
            var mlf = new MachineLogForm { MaximizeBox = false, MinimizeBox = false, FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle, StartPosition = FormStartPosition.CenterScreen, SUserName = SUserName, SCompanyName = OCompany.CompanyName};
            mlf.ShowDialog();
        }

        private void toolStripButtonDevice_Click(object sender, EventArgs e)
        {
            var mf = new MachineSettingForm
            {
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                SCompanyName = OCompany.CompanyName
            };
            mf.ShowDialog();
        }

        private void toolStripButtonPreferences_Click(object sender, EventArgs e)
        {
            var pf = new PreferenceForm
            {
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                IsUser = IsUser,
                SUserName = SUserName,
                SCompanyName = OCompany.CompanyName
            };
            pf.ShowDialog();
        }

        private void toolStripButtonDTRSetting_Click(object sender, EventArgs e)
        {
            var dtrSet = new DTRSettingForm { MdiParent = this, WindowState = FormWindowState.Maximized, SUserName = SUserName, IsUser = IsUser, SCompanyName = OCompany.CompanyName};
            dtrSet.Show();
        }

        private void toolStripMenuItemLeave_Click(object sender, EventArgs e)
        {
            var lf = new LeaveListForm {MdiParent = this, WindowState = FormWindowState.Maximized, SCompanyName = OCompany.CompanyName};
            lf.Show();
        }

        private void cascadeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void tileViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void holidaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rf = new ReportHolidayForm {MdiParent = this, WindowState = FormWindowState.Maximized, SCompanyName = OCompany.CompanyName};
            rf.Show();
        }

        private void overtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var of = new DTROverUnderTimeForm {WindowState = FormWindowState.Maximized, SCompanyName = OCompany.CompanyName, MdiParent = this};
            of.Show();
        }

        private void MianForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            SetDateAndTime();
            InitComponents();
        }

        private void InitComponents()
        {
            IUserId = OUser.UserId;
            SUserName = OUser.UserName.Trim();
            SLevel = OUser.Level.Trim();
            toolStripStatusLabel2.Text = String.Format("{0} - {1} ({2})", IUserId, SUserName, SLevel);

            if (SLevel == "Admin")
            {
                administrationToolStripMenuItem.Enabled = true;
                settingsToolStripMenuItem.Enabled = true;
                toolStripButtonDevice.Enabled = true;
                usersToolStripMenuItem.Enabled = true;
                backupToolStripMenuItem.Enabled = true;
                logsToolStripMenuItem.Enabled = true;
                IsUser = true;
            }
            else
            {
                administrationToolStripMenuItem.Enabled = false;
                settingsToolStripMenuItem.Enabled = false;
                toolStripButtonDevice.Enabled = false;
                usersToolStripMenuItem.Enabled = false;
                backupToolStripMenuItem.Enabled = false;
                logsToolStripMenuItem.Enabled = false;
                IsUser = false;
            }

            this.Text = "Attendance Keeper v1.0: " + OCompany.CompanyName.Trim();
        }

        private void GetDateAndTime()
        {
            toolStripStatusLabel3.Text = String.Format("Date/Time: {0:d} @ {1:T}", DateTime.Today, DateTime.Now);
        }

        private void DisplayDateTimeTicks()
        {
            t1 = new Timer();
            t1.Interval = 1000;
            t1.Enabled = true;
            t1.Start();
            t1.Tick += new EventHandler(Timer_Tick);
            GetDateAndTime();
        }

        private void Timer_Tick(object myObject, EventArgs eventArgs)
        {
            if (myObject == t1) GetDateAndTime();
        }

        private void SetDateAndTime()
        {
            Thread t = new Thread(GetDateAndTime);
            t.IsBackground = true;
            t.Start();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            var ef = new ReportEnrolleeForm { MdiParent = this, WindowState = FormWindowState.Maximized, SCompanyName = OCompany.CompanyName };
            ef.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Close();
        }

       private void backupToolStripMenuItem_Click(object sender, EventArgs e)
       {
           var bf = new BackupRestoreFileForm
                        {
                            MinimizeBox = false,
                            MaximizeBox = false,
                            FormBorderStyle = FormBorderStyle.FixedSingle,
                            StartPosition = FormStartPosition.CenterScreen,
                            SCompanyName = OCompany.CompanyName
                        };
           bf.ShowDialog();
       }

       private void dataAccessToolStripMenuItem_Click(object sender, EventArgs e)
       {
           var df = new DataAccessForm {WindowState = FormWindowState.Maximized, MdiParent = this, IsUser =  IsUser};
           df.Show();
       }

       private void MianForm_FormClosing(object sender, FormClosingEventArgs e)
       {
           if (e.CloseReason == CloseReason.UserClosing)
           {
               DialogResult d = MessageBox.Show(@"You are about to close the application, Continue?", @"Exit Application",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (d == DialogResult.Yes)
               {
                   if (Application.MessageLoop)
                   {
                       Application.Exit();
                   }
               }
               else
               {
                   e.Cancel = true;
               }
           }
           else
           {
               e.Cancel = true;
           }

       }

       private void logsToolStripMenuItem_Click(object sender, EventArgs e)
       {
           var df = new DTRLogForm {WindowState = FormWindowState.Maximized, MdiParent = this, SCompanyName = OCompany.CompanyName};
           df.Show();
       }

       private void applicationInfoToolStripMenuItem_Click(object sender, EventArgs e)
       {
           var af = new AboutBoxA();
           af.StartPosition = FormStartPosition.CenterScreen;
           af.ShowDialog();
       }

       private void toolStripMenuItem5_Click(object sender, EventArgs e)
       {
           var f = new EnrolleeImportForm {MaximizeBox = false, MinimizeBox = false, StartPosition = FormStartPosition.CenterScreen};
           f.ShowDialog();
       }

       private void timer1_Tick(object sender, EventArgs e)
       {
           SetDateAndTime();
       }
    }
}
