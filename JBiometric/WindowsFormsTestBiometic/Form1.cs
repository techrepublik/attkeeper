using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using JBiometric;
using JBiometric.Data;
using JBiometric.Entities;
using JBiometric.Manage;
using DeviceInfoClass=JBiometric.Manage.DeviceInfoClass;
using System.Text;

namespace WindowsFormsTestBiometic
{
    public partial class Form1 : Form
    {
        BindingSource bs = new BindingSource();
        private List<AttLog> lLogs;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPowerOff_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string sError = string.Empty;
            if (DeviceControlClass.TurnOffDevice(1, ref sError, 2, "192.168.1.201", 4370) == true)
            {
                MessageBox.Show(@"Powering Off Device...", @"Device Shutdown.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sError.ToString());
            }
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            string sError = string.Empty;
            if (DeviceControlClass.RestartDevice(1, ref sError, 2, "192.168.1.201", 4370) == true)
            {
                MessageBox.Show(@"Restarting Device...",@"Device Shutdown.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(sError.ToString(), @"Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetRecords_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            dataGridView1.DataSource = null;
            int iError = 0;
            int iRecord = AccessDataClass.GetRecordOnDevice(1, 6, ref iError, 2, "192.168.1.201", 4370);
            Application.DoEvents();
            labelInfo.Text = @"Device Logs (" + iRecord.ToString() + ")";
            Cursor.Current = Cursors.Default;
        }

        private void buttonEnrollOnline_Click(object sender, EventArgs e)
        {
            var f = new EnrollForm {StartPosition = FormStartPosition.CenterScreen, 
                                    MinimizeBox = false, MaximizeBox = false};

            f.ShowDialog();
            
        }

        
        private void buttonGetEnrollees_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            labelInfo.Text = "Device Enrollees...";
            dataGridView1.DataSource = null;
            var lEnrollee = EnrolleeDataClass.GetEnrollData(1,2);
            bs.DataSource = lEnrollee;
            dataGridView1.DataSource = bs;
            Cursor.Current = Cursors.Default;
            
            //foreach (var list in lEnrollee)
            //{
            //    MessageBox.Show(list.IEnrollNumber.ToString() + " - " + list.SName + " - " +
            //                    list.IFingerPrint.ToString() + " - " + list.STmpData.ToString());
            //}
        }

        private void buttonDownLoadLogs_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            //List<Enrollee>lEnrollees = new List<Enrollee>();
            var en1 = new Enrollee();
            en1.SEnrollNumber = 1.ToString();
            en1.IEnrollNumber = 1;
            //lEnrollees.Add(en1);

            //var en2 = new Enrollee();
            //en2.SEnrollNumber = 2.ToString();
            //en2.IEnrollNumber = 2;
            //lEnrollees.Add(en2);

            labelInfo.Text = @"Device Logs...";
            string sError = string.Empty;
            lLogs = AccessDataClass.GetAttlog(1, ref sError, 2, "192.168.1.201", 4370);
            if (sError.Length > 0)
            {
                MessageBox.Show(sError, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.DataSource = null;
                bs.DataSource = ProcessLogClass.LoadEnrolleeAttendance(en1, lLogs.FindAll(l => l.SEnrollNumber == "1"));
                //bs.DataSource = lLogs;
                dataGridView1.DataSource = bs;
               
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            dataGridView1.DataSource = null;
            int iError = 0;
            if (AccessDataClass.ClearDeviceLogs(1, ref iError, 2, "192.168.1.201", 4370))
            {
                labelInfo.Text = @"Device Logs Clear";
                MessageBox.Show(@"Device Logs Cleared", @"Clear Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(iError.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor.Current = Cursors.Default;
             
        }

        private void buttonGetSN_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int iError = 0;
            string sSN = JBiometric.Manage.DeviceInfoClass.GetDeviceSN(1, ref iError, 2, "192.168.1.201", 4370);
            dataGridView1.DataSource = null;
            labelInfo.Text = @"Device SN: " + sSN;
            Cursor.Current = Cursors.Default;
            
        }

        private void buttonCheckConnection_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var con = new ConnectionClass();
            if (con.ConnectViaNet())
            {
                dataGridView1.DataSource = null;
                labelInfo.Text = @"Connection: OK (Connected)";
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            DeviceInfoClass.DDevice().Disconnect();
            dataGridView1.DataSource = null;
            labelInfo.Text = @"Connection: Disconnected";
        }

        private void buttonDeleteEnrollee_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DialogResult dResult = MessageBox.Show(@"You are about to DELETE and ENROLLEE, Continue?", "Delete",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int iUserId = ((Enrollee) bs.Current).IEnrollNumber;

                    int iError = 0;
                    bool bResult = OnlineEnrollClass.DeleteUserData(1, iUserId, 12, ref iError, 2, "192.168.1.201", 4370);
                    if (bResult)
                    {
                        if (dataGridView1.CurrentRow != null) dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        MessageBox.Show(@"Success!");
                    }
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void buttonImportToTextFile_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var sBox = new SaveFileDialog();
            sBox.Filter = @"CSV Files (*.csv)|*.csv|Text File (*.txt)|*.txt";
            sBox.FileName = "Carmen Data " + DateTime.Today.ToString("MM-dd-yyy");
            if (sBox.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = sBox.FileName.Trim();
                try
                {
                    if (sFilePath.Length > 0)
                    {
                        TextWriter tw = new StreamWriter(@"" + sFilePath);
                        string sError = string.Empty;
                        lLogs = AccessDataClass.GetAttlog(1, ref sError, 2, "192.168.1.201", 4370);
                        foreach (var logs in lLogs)
                        {
                            tw.WriteLine(logs.Index.ToString() + ", " + logs.EMachineNumber.ToString() + ", " +
                                         logs.EnrollNumber.ToString() + ", " +
                                         logs.TMachineNumnber + ", " + logs.SEnrollNumber + ", " + logs.IYear.ToString() +
                                         ", " +
                                         logs.IMonth.ToString() + ", " + logs.IDay + ", " + logs.IHour.ToString() + ", " +
                                         logs.IMinute + ", " + logs.ISecond + ", " +
                                         logs.InOutCode.ToString() + ", " + logs.IWorkCode.ToString() + ", " +
                                         logs.VerifyCode.ToString() +", " + logs.GetDate().ToString() + ", " + logs.GetTime(1) + ", " + logs.GetTime(2));
                        }
                        tw.Close();
                        Cursor.Current = Cursors.Default;
                        if (sError.Equals(""))
                        {
                            MessageBox.Show(@"Data Access Successfull");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }

        }

        private void buttonSetTime_Click(object sender, EventArgs e)
        {
            if (DeviceControlClass.SetDeviceTime(1, 2, "192.168.1.201", 4370))
            {
                MessageBox.Show(@"Device time sync with the PC");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string sOutput = string.Empty;
            int iDays = DateTime.DaysInMonth(2011, 1);
            for (int i = 1; i <= iDays; i++)
            {
                string sdt = "1/" + i + "/2010";
                sOutput = Convert.ToDateTime(sdt).ToString() + " - " + VerifyDay(Convert.ToDateTime(sdt)) +  ".\n\r";
                stringBuilder.Append(sOutput);
            }
            MessageBox.Show(stringBuilder.ToString());
        }

        private string VerifyDay(DateTime dt)
        {
            DayOfWeek day = dt.DayOfWeek;
            return day.ToString();
        }
    }
}
