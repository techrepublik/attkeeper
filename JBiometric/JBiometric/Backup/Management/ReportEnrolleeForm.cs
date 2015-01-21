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
    public partial class ReportEnrolleeForm : Form
    {
        public string SCompanyName { get; set; }
        public ReportEnrolleeForm()
        {
            InitializeComponent();
        }

        private void ReportEnrolleeForm_Load(object sender, EventArgs e)
        {
            ReportParameter p1 = new ReportParameter("CompanyNamez", SCompanyName);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {p1});

            JEnrolleeBindingSource.DataSource = DataManagementClass.LoadEnrolleesAll();
            this.reportViewer1.RefreshReport();
        }
    }
}
