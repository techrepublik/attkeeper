using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AttendanceKeeper.Classes;
using AttendanceKeeper.Data;
using JBiometric.Entities;

namespace AttendanceKeeper.Management
{
    public partial class MachineInstanceForm : Form
    {
        public bool IsUser { get; set; }
        public string SUserName { get; set; }

        public List<AttLog> lLogs { get; set; }

        List<Machine> lMac = new List<Machine>();

        public MachineInstanceForm()
        {
            InitializeComponent();
        }

        private void MachineInstanceForm_Load(object sender, EventArgs e)
        {
            machineInstanceBindingSource.AddNew();
            machineInstanceNameTextBox.Text = "Imported on " + DateTime.Now.ToString("MM-dd-yyy @ HHmm");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            IsDuplicateList(); //check for duplicates on machine logs

            if (lMac.Count > 0)
            {
                this.Validate();
                ((MachineInstance) machineInstanceBindingSource.Current).EditedBy = SUserName;
                ((MachineInstance) machineInstanceBindingSource.Current).EditedOn = DateTime.Now;
                machineInstanceBindingSource.EndEdit();
                int iResult = ActionClass.SaveMachineInstance((MachineInstance) machineInstanceBindingSource.Current);
                if (iResult > 0)
                {
                    SaveLogsToDbase(iResult);
                    buttonOk.Enabled = false;
                }
                else
                    UtilityClass.GetMessageBox(0);
            }
            else
            {
                label1.Text = @"Record already exists.";
            }
            Cursor.Current = Cursors.Default;
        }       

        private void SaveLogsToDbase(int iMacInstanceId)
        {
            label1.Text = @"Preparing to port data to database...";
            Thread.Sleep(100);
            Application.DoEvents();
            if (lLogs != null)
            {
                try
                {
                    foreach (var mac in lMac)
                    {
                        mac.MachineInsId = iMacInstanceId;
                    }

                    Thread.Sleep(200);
                    label1.Text = @"Saving logs to database...";
                    Thread.Sleep(200);
                    Application.DoEvents();

                    if (lMac.Count > 0)
                    {
                        int iResult = ActionClass.SaveMachine(lMac);
                        if (iResult > 0)
                        {
                            label1.Text = @"Processing DTR for all enrollees.";
                            Thread.Sleep(200);
                            Application.DoEvents();
                            List<MacDumpLog> listMacDump;
                            List<DTR> listDTR =
                                DataManagementClass.LoadEnrolleeAttendanceDTRAll(ActionClass.FillEnrollees(true),
                                                                                 out listMacDump, SUserName);
                            if (listDTR.Count > 0)
                            {
                                try
                                {
                                    label1.Text = @"Saving DTR for all enrollees.";
                                    Thread.Sleep(200);
                                    Application.DoEvents();
                                    int iDTRResult = ActionClass.SaveDTR(listDTR);

                                    if (listMacDump.Count > 0)
                                    {
                                        foreach (var macDumpLog in listMacDump)
                                        {
                                            macDumpLog.MachineInsId = iMacInstanceId;
                                        }
                                        int iMacDumoLog = ActionClass.SaveMacDumpLogAll(listMacDump);
                                    }
                                    label1.Text = @"Saving data to database successfull.";
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(@"Error - " + ex.Message);
                                    label1.Text = @"An Error Occured while processing data.";
                                    //throw;
                                }
                            }
                        }
                        else
                        {
                            label1.Text = @"Error encountered.";
                        }
                        label1.Text = @"Saving data to database successfull.";
                    }
                    else
                    {
                        label1.Text = @"Record already exists.";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"Error - " + ex.Message);
                    //throw;
                }
            }
        }

        private void IsDuplicateList()
        {
            var lMacDB = ActionClass.FillMachinesAll();
            foreach (var log in lLogs)
            {
                var mac = lMacDB.FirstOrDefault(ma => (ma.IYear == log.IYear) && (ma.IMonth == log.IMonth)
                                                    && (ma.IDay == log.IDay) && (ma.IHour == log.IHour) &&
                                                    (ma.IMin == log.IMin) && (ma.ISecond == log.ISecond));

                if (mac == null)
                {
                    var m = new Machine();
                    //m.MachineInsId = iMacInstanceId;
                    m.EnrolleeNo = log.EnrolleeNo;
                    m.MachineNo = log.MachineNo;
                    m.IYear = log.IYear;
                    m.IMonth = log.IMonth;
                    m.IDay = log.IDay;
                    m.IHour = log.IHour;
                    m.IMin = log.IMin;
                    m.ISecond = log.ISecond;
                    m.InOutCode = log.InOutCode;
                    m.VerifyCode = log.VerifyCode;
                    lMac.Add(m);
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
