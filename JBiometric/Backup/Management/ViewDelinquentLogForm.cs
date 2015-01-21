using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendanceKeeper.Data;
using AttendanceKeeper.Classes;

namespace AttendanceKeeper.Management
{
    public partial class ViewDelinquentLogForm : Form
    {
        public Enrollee OENrollee  { get; set; }

        public ViewDelinquentLogForm()
        {
            InitializeComponent();
        }

        private void ViewDelinquentLogForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        public void InitComponents()
        {
            macDumpLogBindingSource.DataSource = DTRImportForm.LoadDumpLogs();
            toolStripStatusLabel1.Text = "(" + macDumpLogBindingSource.Count.ToString() + ") logs loaded.";
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonSaveLogs_Click(object sender, EventArgs e)
        {
            if (macDumpLogBindingSource != null)
            {
                List<MacDumpLog> lMacs1 = DTRImportForm.LoadDumpLogs();
                List<MacDumpLog> lMacs2 = ActionClass.FillMacDumpLogEnrollee(OENrollee.EnrolleeId);
                List<MacDumpLog> lMacs3 = new List<MacDumpLog>();
                
                foreach (var log in lMacs1)
                {
                    MacDumpLog m =
                        lMacs2.FirstOrDefault(
                            ma => ((ma.MacDumpDate.Trim() == log.MacDumpDate.Trim()) && (ma.MacDumpTime.Trim() == log.MacDumpTime.Trim())));

                    if (m != null)
                    {
                        Console.WriteLine(m.MacDumpDate.ToString());
                    }
                    else
                    {
                        lMacs3.Add(log);
                    }
                }

                if (lMacs3.Count > 0)
                {
                    int iResult = ActionClass.SaveMacDumpLogAll(lMacs3);
                    if (iResult > 0)
                    {
                        toolStripStatusLabel1.Text = "Delinquent logs ported successfully.";
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
        }
    }
}
