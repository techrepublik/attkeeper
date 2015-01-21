using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using JBiometric.Entities;
using JBiometric.Data;
using AttendanceKeeper.Classes;
using System.Threading;

namespace AttendanceKeeper.Management
{
    public partial class MachineLogForm : Form
    {
        public string  SUserName { get; set; }
        public string  SCompanyName { get; set; }

        private string sIP = UtilityClass.GetIPAddress();
        private int iPort = UtilityClass.GetIPort();

        private enum VChoice
        {
            Machine, Excel, Database
        }

        private List<AttLog> lLogs = null;

        private VChoice MyView;
        private int[] ArrIIndex = new int[15000];

        public MachineLogForm()
        {
            InitializeComponent();
        }

        private void MachineLogForm_Load(object sender, EventArgs e)
        {
            toolStripComboBoxView.SelectedIndex = 0;
            toolStripButtonExport.Enabled = false;
            toolStripButtonToDBase.Enabled = false;
            labelCompanyName.Text = SCompanyName;
        }

        private void LoadLogFromDevice()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                toolStripStatusLabel1.Text = @"Machine logs loading...";
                Application.DoEvents();
                string sError = string.Empty;
                
                lLogs = (UtilityClass.GetScreenType() == "CO") ? AccessDataClass.GetAttlog(1, ref sError, 2, sIP, iPort) : AccessDataClass.GetAttlog(1, ref sError, 2, false, sIP, iPort);
                
                if (sError.Length > 0)
                {
                    MessageBox.Show(sError, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    machineBindingSource.DataSource = lLogs;
                    toolStripStatusLabel1.Text = @"Machine logs loaded successfull (" + lLogs.Count.ToString() + ")";
                    //if (lLogs.Count > 0)
                    //{
                        toolStripButtonExport.Enabled = true;
                        toolStripButtonToDBase.Enabled = true;
                    //}
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Please make sure to connect the device before downloading any data", @"Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //throw;
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            switch (MyView)
            {
                case VChoice.Machine:
                    toolStripStatusLabel1.Text = @"Connecting to the device...";
                    Application.DoEvents();
                    Thread.Sleep(200);
                    //(GetSerrial()
                    if ((GetSerrial() == UtilityClass.GetMachineSN()) && (UtilityClass.GetMacKeyFinal() == UtilityClass.GetMacKeyTemp()))
                    {
                        toolStripStatusLabel1.Text = @"Status: Connected. Downloading logs...";
                        Application.DoEvents();
                        Thread.Sleep(200);
                        machineBindingSource.DataSource = null;
                        toolStripButtonExport.Enabled = false;
                        toolStripButtonToDBase.Enabled = false;
                        LoadLogFromDevice();
                        //toolStripStatusLabel1.Text = "Download Successfull.";
                        Thread.Sleep(100);
                        Application.DoEvents();
                    }
                    else
                    {
                        MessageBox.Show(@"Wrong device Serial Number.", "Wrong Device", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                    }
                    break;
                case VChoice.Excel:
                    var openFileDialog = new OpenFileDialog
                    {
                        Filter = @"Excel Files (*.xls) | *.xls",
                        DefaultExt = ".xls",
                        RestoreDirectory = true
                    };
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            if (lLogs != null) lLogs.Clear();
                            toolStripStatusLabel1.Text = @"Status: Downloading logs from Excel File...";
                            Application.DoEvents();
                            Thread.Sleep(200);
                            lLogs = UtilityClass.ImportLogsFromExcel(openFileDialog.FileName);
                            machineBindingSource.DataSource = null;
                            machineBindingSource.DataSource = lLogs;
                            if (lLogs.Count > 0) toolStripButtonToDBase.Enabled = true;
                            toolStripStatusLabel1.Text = String.Format("({0:N0}) - logs loaded.", lLogs.Count);
                            Cursor = Cursors.Default;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(@"Error - " + ex.Message);
                            //throw;
                        }
                    }
                    break;
                case VChoice.Database:
                    machineBindingSource.DataSource = null;
                    toolStripButtonExport.Enabled = false;
                    toolStripButtonToDBase.Enabled = false;
                    toolStripStatusLabel1.Text = @"Ready...";
                    break;
                default:
                    MessageBox.Show(@"Please select view type.", @"View Type", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    break;
            }
        }

        private void toolStripComboBoxView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxView.SelectedIndex == 0)
                MyView = VChoice.Machine;
            else if (toolStripComboBoxView.SelectedIndex == 1)
                MyView = VChoice.Excel;
            else
            {
                MyView = VChoice.Database;
                LoadMachineInstanceToCombo();
                toolStripComboBoxInstance.Items.Insert(0, "--- Select a Log Set ---");
                toolStripComboBoxInstance.SelectedIndex = 0;
            }
                
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var sBox = new SaveFileDialog();
            sBox.Filter = @"CSV Files (*.csv)|*.csv|Text File (*.txt)|*.txt";
            sBox.FileName = "Data " + DateTime.Now.ToString("MM-dd-yyy @ HHmm");
            if (sBox.ShowDialog() == DialogResult.OK)
            {
                string sFilePath = sBox.FileName.Trim();
                try
                {
                    if (sFilePath.Length > 0)
                    {
                        TextWriter tw = new StreamWriter(@"" + sFilePath);
                        string sError = string.Empty;
                        //lLogs = AccessDataClass.GetAttlog(1, ref sError, 2);
                        if (lLogs.Count > 0)
                        {
                            foreach (var logs in lLogs)
                            {
                                tw.WriteLine(logs.Index.ToString() + ", " + logs.EMachineNumber.ToString() + ", " +
                                             logs.SEnrollNumber + ", " +
                                             logs.IYear.ToString() +
                                             ", " +
                                             logs.IMonth.ToString() + ", " + logs.IDay + ", " + logs.IHour.ToString() +
                                             ", " +
                                             logs.IMinute + ", " + logs.ISecond + ", " +
                                             logs.InOutCode.ToString() + ", " + logs.IWorkCode.ToString() + ", " +
                                             logs.VerifyCode.ToString() + ", " + logs.GetDate().ToString() + ", " +
                                             logs.GetTime(1) + ", " + logs.GetTime(2));
                            }
                            tw.Close();
                            Cursor.Current = Cursors.Default;
                            if (sError.Equals(""))
                            {
                                MessageBox.Show("Data Access Successfull");
                            }
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

        private void toolStripButtonToDBase_Click(object sender, EventArgs e)
        {
            if (lLogs != null)
            {
                var mf = new MachineInstanceForm
                {
                    lLogs = lLogs,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedSingle,
                    StartPosition = FormStartPosition.CenterScreen
                };
                mf.ShowDialog();    
            }
            

            //toolStripStatusLabel1.Text = "Preparing to port data to database...";
            //Thread.Sleep(100);
            //Application.DoEvents();
            //if (lLogs != null)
            //{
            //    try
            //    {
            //        var lMac = new List<Machine>();
            //        foreach (var log in lLogs)
            //        {
            //            var m = new Machine();
            //            m.EnrolleeNo = log.EnrolleeNo;
            //            m.MachineNo = log.MachineNo;
            //            m.IYear = log.IYear;
            //            m.IMonth = log.IMonth;
            //            m.IDay = log.IDay;
            //            m.IHour = log.IHour;
            //            m.IMin = log.IMin;
            //            m.ISecond = log.ISecond;
            //            m.InOutCode = log.InOutCode;
            //            m.VerifyCode = log.VerifyCode;
            //            lMac.Add(m);
            //        }

            //        toolStripStatusLabel1.Text = "Saving data to database...";
            //        int iResult = ActionClass.SaveMachine(lMac);
            //        if (iResult > 0)
            //        {
            //            toolStripStatusLabel1.Text = "Saving data to database successfull. (" + lMac.Count.ToString() + " logs ported)" ;
            //        }
            //        else
            //        {
            //            toolStripStatusLabel1.Text = "Error encountered.";
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Error - " + ex.Message);
            //        //throw;
            //    }
            //}
        }

        private void LoadMachineInstanceToCombo()
        {
            Cursor.Current = Cursors.WaitCursor;
            int iCounter = 1;
            var lMacIns = ActionClass.FillMachineInstances();
            toolStripComboBoxInstance.Items.Clear();
            foreach (var item in lMacIns)
            {
                toolStripComboBoxInstance.Items.Add(item.MachineInstanceName);
                ArrIIndex[iCounter] = item.MachineInsId;
                iCounter += 1;
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripComboBoxInstance_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (toolStripComboBoxInstance.Items.Count > 0)
            {
                int iIndex = toolStripComboBoxInstance.SelectedIndex;
                if (iIndex > -1)
                {
                    machineBindingSource.DataSource = null;
                    machineBindingSource.DataSource = ActionClass.FillMachinesViaEnrollMachineInstance(ArrIIndex[iIndex]);
                    toolStripStatusLabel1.Text = toolStripComboBoxInstance.Text.Trim() + " (" + machineBindingSource.Count.ToString() + ") items loaded.";
                    if (machineBindingSource.Count > 0)
                    {
                        toolStripButtonExport.Enabled = true;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private string GetSerrial()
        {
            Cursor.Current = Cursors.WaitCursor;
            string sSN = string.Empty;
            try
            {
                int iError = 0;
                sSN = JBiometric.Manage.DeviceInfoClass.GetDeviceSN(1, ref iError, 2, sIP, iPort);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Please connect to the device.", @"Device Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                //throw;
            }
            
            Cursor.Current = Cursors.Default;
            return sSN;
        }
    }
}
