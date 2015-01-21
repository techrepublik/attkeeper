using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Threading;

namespace AttendanceKeeper.Management
{
    public partial class BackupRestoreFileForm : Form
    {
        public string SCompanyName { get; set; }
        public BackupRestoreFileForm()
        {
            InitializeComponent();
        }

        
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButtonBack.Checked)
            {
                var saveDialog = new SaveFileDialog
                                     {
                                         Filter = @"BAK Files (*.bak)|*.bak",
                                         FilterIndex = 0,
                                         FileName = "DTRDbase" + DateTime.Today.ToString("MM-dd-yyyy"),
                                         RestoreDirectory = true
                                     };
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = saveDialog.FileName;
                }
            }
            else
            {
                var openDialog = new OpenFileDialog();
                openDialog.Filter = @"BAK Files (*.bak)|*.bak";
                openDialog.FilterIndex = 0;
                openDialog.RestoreDirectory = true;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openDialog.FileName;
                }
            }
        }

        private void BackupRestoreFileForm_Load(object sender, EventArgs e)
        {
            textBox2.Text = Application.StartupPath + "\\";
            labelCompanyName.Text = SCompanyName;
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            if (radioButtonBack.Checked)
            {
                BackupDatabase(textBox2.Text);
            }
            else
            {
                RestoreBackup(textBox2.Text);
            }
        }

        public void BackupDatabase(string sFilePath)
        {
            string sConnect = Properties.Settings.Default.DTRDbaseConnectionString;

            try
            {
                using (SqlConnection cnn = new SqlConnection(sConnect))
                {
                    cnn.Open();
                    string dbName = cnn.Database.ToString();
                    labelStatus.Text = "Connecting to database...";
                    Application.DoEvents();
                    Thread.Sleep(200);

                    ServerConnection sc = new ServerConnection(cnn);
                    Server sv = new Server(sc);

                    // Check that I'm connected to the user instance
                    Console.WriteLine(sv.InstanceName.ToString());

                    // Create backup device item for the backup
                    BackupDeviceItem bdi = new BackupDeviceItem(sFilePath, DeviceType.File);
                    labelStatus.Text = "Saving to " + sFilePath;
                    Application.DoEvents();
                    Thread.Sleep(200);

                    // Create the backup informaton
                    Backup bk = new Backup();
                    bk.Devices.Add(bdi);
                    bk.Action = BackupActionType.Database;
                    bk.BackupSetDescription = "Attendance Keeper Backup";
                    bk.BackupSetName = "DTRBackup";
                    bk.Database = dbName;
                    //bk.ExpirationDate = new DateTime(2007, 5, 1);
                    bk.LogTruncation = BackupTruncateLogType.Truncate;

                    // Run the backup
                    bk.SqlBackup(sv);
                    //Console.WriteLine("Your backup is complete.");
                    MessageBox.Show("Backup Completed Successfully.", "Backup", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    labelStatus.Text = "Backup Complete.";
                    Application.DoEvents();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error during backup process.", "Backup Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                //throw;
            }
            
        }

        public void RestoreBackup(string sFileName)
        {
            string sConnect = Properties.Settings.Default.DTRDbaseConnectionString;

            try
            {
                using (SqlConnection cnn = new SqlConnection(sConnect))
                {
                    cnn.Open();
                    string dbName = cnn.Database.ToString();
                    
                    labelStatus.Text = "Connecting to database...";
                    Application.DoEvents();
                    Thread.Sleep(200);

                    ServerConnection sc = new ServerConnection(cnn);
                    Server sv = new Server(sc);

                    // Check that I'm connected to the user instance
                    Console.WriteLine(sv.InstanceName.ToString());

                    // Create backup device item for the backup
                    BackupDeviceItem bdi = new BackupDeviceItem(sFileName, DeviceType.File);
                    labelStatus.Text = "Restoring...";
                    Application.DoEvents();
                    Thread.Sleep(200);

                    // Create the restore object
                    Restore resDB = new Restore();
                    resDB.Devices.Add(bdi);
                    resDB.NoRecovery = false;
                    resDB.ReplaceDatabase = true;
                    resDB.Database = dbName;
                    cnn.ChangeDatabase("master");

                    // Restore the database
                    resDB.SqlRestore(sv);
                    //Console.WriteLine("Your database has been restored.");
                    MessageBox.Show("Backup Completed Successfully.", "Backup", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    labelStatus.Text = "Restore Complete.";
                    Application.DoEvents();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during restore process." + ex.Message, "Restore Error", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                //throw;
            }
        }

    }
}
