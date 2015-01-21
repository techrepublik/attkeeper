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
    public partial class DTRLogForm : Form
    {
        public string SCompanyName { get; set; }

        public DTRLogForm()
        {
            InitializeComponent();
        }

        private void DTRLogForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            toolStripComboBoxMonth.Items.Clear();
            foreach (var list in UtilityClass.FillMonth())
            {
                toolStripComboBoxMonth.Items.Add(list);
            }

            toolStripComboBoxMonth.SelectedIndex = DateTime.Today.Month - 1;

            toolStripComboBoxYear.Items.Clear();
            foreach (var i in UtilityClass.FillYear())
            {
                toolStripComboBoxYear.Items.Add(i.ToString());
            }
            toolStripComboBoxYear.SelectedIndex = 0;

            toolStripComboBox1.SelectedIndex = 0;

            labelCompanyName.Text = SCompanyName;
        }

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int iMonth = toolStripComboBoxMonth.SelectedIndex + 1;
            int iYear = int.Parse(toolStripComboBoxYear.Text);
            bool bSource = toolStripComboBox1.SelectedIndex == 0 ? false : true;
            var listJDTR = new JSortingListClass<JDTRClass>(DataManagementClass.LoadDTRUpdated(iYear, iMonth, bSource)); 
            jDTRClassBindingSource.DataSource = listJDTR;
            Cursor = Cursors.Default;
        }
    }
}
