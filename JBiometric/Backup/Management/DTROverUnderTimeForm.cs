using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendanceKeeper.Classes;
using Microsoft.Reporting.WinForms;

namespace AttendanceKeeper.Management
{
    public partial class DTROverUnderTimeForm : Form
    {
        public bool IsUser { get; set; }
        public string SUserName { get; set; }
        public string SCompanyName { get; set; }

        private int iMonth = 0;
        private int iYear = 0;

        public DTROverUnderTimeForm()
        {
            InitializeComponent();
        }

        private void DTROverUnderTimeForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            toolStripComboBoxMonth.Items.Clear();
            foreach (var m in UtilityClass.FillMonth())
            {
                toolStripComboBoxMonth.Items.Add(m);
            }
            toolStripComboBoxMonth.SelectedIndex = DateTime.Today.Month - 1;

            toolStripComboBoxYear.Items.Clear();
            foreach (var y in UtilityClass.FillYear())
            {
                toolStripComboBoxYear.Items.Add(y);
            }
            toolStripComboBoxYear.SelectedIndex = 0;

            labelCompanyName.Text = SCompanyName;
            
        }

        private void LoadDTROverUnder()
        {
            iMonth = toolStripComboBoxMonth.SelectedIndex + 1;
            iYear = Convert.ToInt16(toolStripComboBoxYear.Text);

            var p1 = new ReportParameter("Duration", toolStripComboBoxMonth.Text + " " + toolStripComboBoxYear.Text);
            var p2 = new ReportParameter("CompanyNamez", SCompanyName);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {p1, p2});

            JDTRClassBindingSource.DataSource = DataManagementClass.LoadDTROverUnder(iYear, iMonth);
            this.reportViewer1.RefreshReport();
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            LoadDTROverUnder();
        }
    }
}
