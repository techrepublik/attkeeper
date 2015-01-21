using System;
using System.Windows.Forms;
using AttendanceKeeper.Data;
using AttendanceKeeper.Classes;

namespace AttendanceKeeper.Management
{
    public partial class DTRUpdateForm : Form
    {
        public DTR ODtr { get; set; }
        public int IEnrolleeId { get; set; }
        public int  IEnrolleeNo { get; set; }
        public string SDate { get; set; }

        public DTRUpdateForm()
        {
            InitializeComponent();
        }

        private void DTRUpdateForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            macDumpLogBindingSource.DataSource = ActionClass.FillMacDumpLogEnrollee(IEnrolleeNo, SDate);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if ((macDumpLogBindingSource != null) && (macDumpLogBindingSource.Count > 0))
                DTRForm.STime = ((MacDumpLog) macDumpLogBindingSource.Current).MacDumpTime;

            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
