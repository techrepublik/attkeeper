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
    public partial class ReportHolidayForm : Form
    {
        public string SCompanyName { get; set; }

        public ReportHolidayForm()
        {
            InitializeComponent();
        }

        private void ReportHolidayForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            comboBoxMonth.DataSource = UtilityClass.FillMonth();
            comboBoxYear.DataSource = UtilityClass.FillYear();
            comboBoxMonth.SelectedIndex = 0;
            comboBoxYear.SelectedIndex = 0;
            labelCompanyName.Text = SCompanyName;
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            int iMonth = comboBoxMonth.SelectedIndex + 1;
            int iYear = Convert.ToInt16(comboBoxYear.Text);
            ReportParameter p1 = new ReportParameter("CompanyNamez", SCompanyName);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
            HolidayBindingSource.DataSource = ActionClass.FillHolidays(iMonth, iYear);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportParameter p1 = new ReportParameter("CompanyNamez", SCompanyName);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {p1});
            HolidayBindingSource.DataSource = ActionClass.FillHolidays();
            this.reportViewer1.RefreshReport();
        }
    }
}
