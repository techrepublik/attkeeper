using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AttendanceKeeper.Data;
using AttendanceKeeper.Classes;
using Enrollee=AttendanceKeeper.Data.Enrollee;
using System.Threading;

namespace AttendanceKeeper.Management
{
    public partial class DTRImportForm : Form
    {
        public bool IsUser { get; set; }
        public string SUserName { get; set; }
        public string SCompanyName { get; set; }

        public Enrollee OEnrollee { get; set; }
        public int  IMonth { get; set; }
        public int  IYear { get; set; }

        private List<DTR> lDTR = new List<DTR>();
        private static List<MacDumpLog> lDumpLogs = new List<MacDumpLog>();

        
        public DTRImportForm()
        {
            InitializeComponent();
        }

        private void DTRImportForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            this.Text = "Import DTR Form - [ " + OEnrollee.LastName.Trim().ToUpper() + ", " + OEnrollee.FirstName.Trim() +
                        " " + OEnrollee.MiddleName.Substring(0, 1) + ". ]";

            toolStripButtonDelinquent.Enabled = false;
            dTRBindingNavigatorSaveItem.Enabled = false;

            labelCompanyName.Text = SCompanyName;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            lDTR = DataManagementClass.LoadDTRViaLogs(OEnrollee, IMonth, IYear, out lDumpLogs);
            var dtDate = new Comparison<DTR>(DataManagementClass.CompareDTRDate);
            lDTR.Sort(dtDate);
            dTRBindingSource.DataSource = lDTR;
            toolStripStatusLabel1.Text = "(" + dTRBindingSource.Count.ToString() + ") valid and " +
                                         lDumpLogs.Count.ToString() + " delinquent logs loaded.";
            
            toolStripButtonDelinquent.Enabled = lDumpLogs.Count > 0;
            dTRBindingNavigatorSaveItem.Enabled = lDTR.Count > 0;
        }

        private void dTRBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (dTRBindingSource != null)
            {
                this.Validate();
                dTRBindingSource.EndEdit();
                List<DTR> lDtr1 = ActionClass.FillDTRs(OEnrollee.EnrolleeId, IMonth, IYear);
                var lDtr2 = new List<DTR>();
                
                foreach (var dtr in lDTR)
                {
                    DTR d = lDtr1.FirstOrDefault(dt => (dt.DTRDate == dtr.DTRDate));
                    if (d == null)
                    {
                        dtr.IsSource = false;
                        dtr.EditedBy = SUserName;
                        dtr.EditedOn = DateTime.Now;
                        lDtr2.Add(dtr);
                    }
                    else
                    {
                        string tempTimeInAM = (d.TimeInAM != null) ? d.TimeInAM.Trim() : null;
                        string tempTimeOutAM = (d.TimeOutAM != null) ? d.TimeOutAM.Trim() : null;
                        string tempTimeInPM = (d.TimeInPM !=null) ? d.TimeInPM.Trim() : null;
                        string tempTimeOutPM = (d.TimeOutPM != null) ? d.TimeOutPM.Trim() : null;
                        string tempTimeInOT = (d.TimeInOT != null) ? d.TimeInOT.Trim() : null;
                        string tempTimeOutOT = (d.TimeOutOT != null) ? d.TimeOutOT.Trim() : null;

                        if ((tempTimeInAM != dtr.TimeInAM) || (tempTimeOutAM != dtr.TimeOutAM)
                           || (tempTimeInPM != dtr.TimeInPM) || (tempTimeOutPM != dtr.TimeOutPM)
                           || (tempTimeInOT != dtr.TimeInOT) || (tempTimeOutOT != dtr.TimeOutOT))
                        {
                            dtr.IsSource = false;
                            dtr.EditedBy = SUserName;
                            dtr.EditedOn = DateTime.Now;
                            dtr.DTRId = d.DTRId;

                            ActionClass.SaveDTR(dtr);
                        }
                    }
                }

                if (lDtr2.Count > 0)
                {
                    int iResult = ActionClass.SaveDTR(lDtr2);
                    if (iResult > 0)
                    {
                        toolStripStatusLabel1.Text = "Record successfully saved. (" + lDtr2.Count.ToString() +
                                                     " record)";
                        Thread.Sleep(200);
                        Application.DoEvents();
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Error Occured while saving data to database or duplicate record already exists.";
                    }
                }
                else
                {
                    toolStripStatusLabel1.Text = "Record already exists.";
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonDelinquent_Click(object sender, EventArgs e)
        {
            var vf = new ViewDelinquentLogForm();
            vf.MaximizeBox = false;
            vf.MinimizeBox = false;
            vf.StartPosition = FormStartPosition.CenterScreen;
            vf.FormBorderStyle = FormBorderStyle.FixedSingle;
            //vf.InitComponents(lDumpLogs);
            vf.OENrollee = OEnrollee;
            vf.ShowDialog();
        }

        public static List<MacDumpLog> LoadDumpLogs()
        {
            return lDumpLogs;
        }
    }
}
