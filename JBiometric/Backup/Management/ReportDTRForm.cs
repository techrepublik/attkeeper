using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendanceKeeper.Data;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace AttendanceKeeper.Management
{
    public partial class ReportDTRForm : Form
    {
        public bool IsUser { get; set; }
        public string SUserName { get; set; }
        public string  SCompanyName { get; set; }

        public List<DTR> LDTR { get; set; }
        public string SName { get; set; }
        public string SDuration { get; set; }

        public ReportDTRForm()
        {
            InitializeComponent();
        }

        private void ReportDTRForm_Load(object sender, EventArgs e)
        {
            var p1 = new ReportParameter("EnrolleeName", SName);
            var p2 = new ReportParameter("DurationLabel", SDuration);
            var p3 = new ReportParameter("CompanyNamez", SCompanyName);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] {p1, p2, p3});
            DTRBindingSource.DataSource = LDTR;
            this.reportViewer1.RefreshReport();
        }

        
    }
}
