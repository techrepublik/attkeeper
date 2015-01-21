using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendanceKeeper.Classes;

namespace AttendanceKeeper.Management
{
    public partial class LeaveListForm : Form
    {
        public string SCompanyName { get; set; }
        public LeaveListForm()
        {
            InitializeComponent();
        }

        private void LeaveListForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            jLeaveClassBindingSource.DataSource = DataManagementClass.LoadLeaves();
            labelCompanyName.Text = SCompanyName;
        }
    }
}
