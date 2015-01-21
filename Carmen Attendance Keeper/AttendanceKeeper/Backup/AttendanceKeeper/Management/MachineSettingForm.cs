using System;
using System.Windows.Forms;
using JBiometric.Data;
using JBiometric.Manage;
using JBiometric;
using AttendanceKeeper.Classes;

namespace AttendanceKeeper.Management
{
    public partial class MachineSettingForm : Form
    {
        public string SCompanyName { get; set; }

        private string sIP = UtilityClass.GetIPAddress();
        private int iPort = UtilityClass.GetIPort();

        public MachineSettingForm()
        {
            InitializeComponent();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string sError = string.Empty;
                if (DeviceControlClass.RestartDevice(1, ref sError, 2, sIP, iPort))
                {
                    MessageBox.Show(@"Restarting Device...", @"Device Shutdown.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Cannot connect to the device. " + sError, @"Device Connection Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                groupBox2.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Please make sure the device is connected.", @"Device Connection", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void buttonOff_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string sError = string.Empty;
                if (DeviceControlClass.TurnOffDevice(1, ref sError, 2, sIP, iPort))
                {
                    MessageBox.Show(@"Power Off Device...", @"Device Shutdown.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Cannot connect to the device. " + sError, @"Device Connection Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                groupBox2.Enabled = false;
            }
            catch (Exception )
            {
                MessageBox.Show(@"Please make sure the device is connected.", @"Device Connection", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void buttonClearLogs_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show(@"You are about to clear machine logs, continue?", "Clear Logs",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                try
                {
                    int iError = 0;
                    if (AccessDataClass.ClearDeviceLogs(1, ref iError, 2, sIP, iPort))
                    {
                        MessageBox.Show(@"Device Logs Cleared", @"Clear Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(iError.ToString(), @"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    groupBox2.Enabled = false;

                }
                catch (Exception)
                {
                    MessageBox.Show(@"Please make sure the device is connected.", @"Device", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    //throw;
                }
                Cursor.Current = Cursors.Default;    
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int iError = 0;
                int iRecord = AccessDataClass.GetRecordOnDevice(1, 6, ref iError, 2, sIP, iPort);
                Application.DoEvents();
                MessageBox.Show(@"Device Logs (" + iRecord.ToString() + @")", @"Check Out Logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBox2.Enabled = false;
            }
            catch (Exception )
            {
                MessageBox.Show(@"Please make sure the device is connected.", @"Device", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                //throw;
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonTestConnection_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var con = new ConnectionClass();
                con.SIP = sIP;
                con.IPort = iPort;
                if (con.ConnectViaNet())
                {
                    MessageBox.Show(@"Connection: OK (Connected)", @"Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                groupBox2.Enabled = false;
            }
            catch (Exception )
            {
                MessageBox.Show(@"Please make sure the device is connected.", @"Device", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                //throw;
            }
            
            Cursor.Current = Cursors.Default;
        }

        private void buttonSetTime_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (DeviceControlClass.SetDeviceTime(1, 2, sIP, iPort))
                {
                    MessageBox.Show(@"Device time sync with PC's.", @"Time Sychronization", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                groupBox2.Enabled = false;
            }
            catch (Exception )
            {
                MessageBox.Show(@"Please make sure the device is connected.", @"Device", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                //throw;
            }
            
            Cursor = Cursors.Default;
        }

        private void buttonSetTime02_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                groupBox2.Enabled = true;
                comboBoxYear.DataSource = UtilityClass.FillYear();
                comboBoxMonth.DataSource = UtilityClass.FillMonth();
                comboBoxDay.DataSource = UtilityClass.FillDays();
                comboBoxHour.DataSource = UtilityClass.FillHours();
                comboBoxMin.DataSource = UtilityClass.FillMins();
                comboBoxSec.DataSource = UtilityClass.FillSecs();

                comboBoxYear.SelectedIndex = 0;
                comboBoxMonth.SelectedIndex = 0;
                comboBoxDay.SelectedIndex = 0;
                comboBoxHour.SelectedIndex = 0;
                comboBoxMin.SelectedIndex = 0;
                comboBoxSec.SelectedIndex = 0;

                string sCurrentTime;
                if (DeviceControlClass.GetDeviceTime(1, 2, out sCurrentTime, sIP, iPort))
                {
                    textBoxCurrent.Text = sCurrentTime;
                }
            }
            catch (Exception )
            {
                MessageBox.Show(@"Please make sure the device is connected.", @"Device", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                //throw;
            }
            
            Cursor = Cursors.Default;
        }

        private void MachineSettingForm_Load(object sender, EventArgs e)
        {
            labelCompanyName.Text = SCompanyName;
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int iYear = Convert.ToInt16(comboBoxYear.Text);
                int iMonth = comboBoxMonth.SelectedIndex + 1;
                int iDay = Convert.ToInt16(comboBoxDay.Text);
                int iHour = Convert.ToInt16(comboBoxHour.Text);
                int iMin = Convert.ToInt16(comboBoxMin.Text);
                int iSec = Convert.ToInt16(comboBoxSec.Text);

                if (DeviceControlClass.SetDeviceTime(1, 2, iYear, iMonth, iDay, iHour, iMin, iSec, sIP, iPort))
                {
                    string sCurrntTime = string.Empty;
                    if (DeviceControlClass.GetDeviceTime(1,2, out sCurrntTime,sIP, iPort))
                    {
                        textBoxNew.Text = sCurrntTime;
                        MessageBox.Show(@"Device time sync successfull.", @"Time Sychronization", MessageBoxButtons.OK, MessageBoxIcon.Information);    
                    }
                    else
                    {
                        textBoxNew.Text = @"No Time Set.";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Error - " + ex.Message);
                //throw;
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
