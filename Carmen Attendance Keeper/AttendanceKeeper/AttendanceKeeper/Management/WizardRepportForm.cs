using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendanceKeeper.Classes;
using AttendanceKeeper.Data;

namespace AttendanceKeeper.Management
{
    public partial class WizardRepportForm : Form
    {
        public WizardRepportForm()
        {
            InitializeComponent();
        }

        private void WizardRepportForm_Load(object sender, EventArgs e)
        {

            
        }

        public void LoadData(List<JDTR> listDTR)
        {
            
            JDTRBindingSource.DataSource = listDTR;
            this.reportViewer1.RefreshReport();
        }
    }
}
