using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AttendanceKeeper.Classes;
using AttendanceKeeper.Data;
using Microsoft.Reporting.WinForms;
using System.Threading;
using System.Drawing;

namespace AttendanceKeeper.Management
{
    public partial class DTRForm : Form
    {
        public bool IsUser { get; set; }
        public string SUserName { get; set; }
        public string SCompanyName { get; set; }

        public static string STime { get; set; }
        private int iDepartmentId = 0;

        private int iMonth = 0;
        private int iYear = 0;
        private int iColl;

        List<DTR> lDTRSource = new List<DTR>();

        public DTRForm()
        {
            InitializeComponent();
        }

        private void DTRForm_Load(object sender, EventArgs e)
        {
            InitComponents();
            LoadDepartments();
        }

        private void InitComponents()
        {
            var lDates = UtilityClass.FillMonth();
            toolStripComboBoxMonth.Items.Clear();
            foreach (var list in lDates)
            {
                toolStripComboBoxMonth.Items.Add(list);
            }

            var lYears = UtilityClass.FillYear();
            toolStripComboBoxDuration.Items.Clear();
            foreach (var year in lYears)
            {
                toolStripComboBoxDuration.Items.Add(year);
            }

            toolStripComboBoxMonth.SelectedIndex = DateTime.Today.Month - 1;
            toolStripComboBoxDuration.SelectedIndex = 0;
            listBoxEnrollees.DataSource = DataManagementClass.LoadEnrollees();
            toolStripStatusLabel1.Text = jEnrolleeBindingSource.Count.ToString() + " enrollees loaded.";
            labelCompanyName.Text = SCompanyName;
        }

        private void listBoxEnrollees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            var df = new DTRImportForm
                         {
                             MinimizeBox = false,
                             MaximizeBox = false,
                             FormBorderStyle = FormBorderStyle.FixedSingle,
                             StartPosition = FormStartPosition.CenterScreen,
                             IMonth = toolStripComboBoxMonth.SelectedIndex + 1,
                             IYear = int.Parse(toolStripComboBoxDuration.Text),
                             SUserName = SUserName,
                             SCompanyName = SCompanyName
                         };
            Enrollee enrollee = ActionClass.GetEnrollee(((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeId);
            df.OEnrollee = enrollee;
            df.ShowDialog();
        }

        private void listBoxEnrollees_DoubleClick(object sender, EventArgs e)
        {
            LoadDRTEnrolleeId();
        }

        private void LoadDRTEnrolleeId()
        {
            Cursor = Cursors.WaitCursor;
            if (listBoxEnrollees.Items.Count > 0)
            {
                textBoxName.Text = listBoxEnrollees.Text;
                iMonth = toolStripComboBoxMonth.SelectedIndex + 1;
                iYear = int.Parse(toolStripComboBoxDuration.Text);

                textBoxDepartment.Text = GetEnrolleeDepartment();
                textBoxPosition.Text = GetEnrolleePosition();
                Miscellaneous misc = ActionClass.FillMiscellaneous().FirstOrDefault(mi => mi.MiscActive == true);

                int iEnrolleeId = ((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeId;
                Enrollee enrollee = ActionClass.GetEnrollee(iEnrolleeId);
                               
                lDTRSource = DataManagementClass.LoadDTRViaDTR(enrollee, iMonth, iYear, ActionClass.FillDTRs(iEnrolleeId), misc);
                dTRsBindingSource.DataSource = lDTRSource;

                ExecuteSaveDTRThread(); // loop to save dtr.

                MarkUnderOverTimeHours();
            }
            Cursor = Cursors.Default;
        }

        private void toolStripComboBoxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxMonth.Items.Count > 0)
            {
                iMonth = toolStripComboBoxMonth.SelectedIndex + 1;
            }
        }

        private void toolStripComboBoxDuration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxDuration.Items.Count > 0)
            {
                iYear = int.Parse(toolStripComboBoxDuration.Text);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GetToUpdateValue(e.ColumnIndex);
        }

        private void GetToUpdateValue(int iColl)
        {
            DTRUpdateForm df = new DTRUpdateForm();
            df.MinimizeBox = false;
            df.MaximizeBox = false;
            df.FormBorderStyle = FormBorderStyle.FixedSingle;
            df.StartPosition = FormStartPosition.CenterScreen;
            DialogResult dResult = DialogResult.None;
            df.IEnrolleeId = ((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeId;
            switch (iColl)
            {
                case 2:
                    df.SDate = ((DTR)dTRsBindingSource.Current).DTRDate.Value.ToString("M/d/yyyy");
                    df.IEnrolleeNo = Convert.ToInt32(((JEnrollee) listBoxEnrollees.SelectedItem).EnrolleeNo);
                    dResult = df.ShowDialog();
                    if (DialogResult.OK == dResult)
                    {
                        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[iColl].Value = STime;
                    }
                    break;
                case 3:
                    df.SDate = ((DTR)dTRsBindingSource.Current).DTRDate.Value.ToString("M/d/yyyy");
                    df.IEnrolleeNo = Convert.ToInt32(((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeNo);
                    dResult = df.ShowDialog();
                    if (DialogResult.OK == dResult)
                    {
                        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[iColl].Value = STime;
                    }
                    break;
                case 4:
                    df.SDate = ((DTR)dTRsBindingSource.Current).DTRDate.Value.ToString("M/d/yyyy");
                    df.IEnrolleeNo = Convert.ToInt32(((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeNo);
                    dResult = df.ShowDialog();
                    if (DialogResult.OK == dResult)
                    {
                        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[iColl].Value = STime;
                    }
                    break;
                case 5:
                    df.SDate = ((DTR)dTRsBindingSource.Current).DTRDate.Value.ToString("M/d/yyyy");
                    df.IEnrolleeNo = Convert.ToInt32(((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeNo);
                    dResult = df.ShowDialog();
                    if (DialogResult.OK == dResult)
                    {
                        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[iColl].Value = STime;
                    }
                    break;
                case 6:
                    df.SDate = ((DTR)dTRsBindingSource.Current).DTRDate.Value.ToString("M/dd/yyyy");
                    df.IEnrolleeNo = Convert.ToInt32(((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeNo);
                    dResult = df.ShowDialog();
                    if (DialogResult.OK == dResult)
                    {
                        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[iColl].Value = STime;
                    }
                    break;
                case 7:
                    df.SDate = ((DTR)dTRsBindingSource.Current).DTRDate.Value.ToString("M/dd/yyyy");
                    df.IEnrolleeNo = Convert.ToInt32(((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeNo);
                    dResult = df.ShowDialog();
                    if (DialogResult.OK == dResult)
                    {
                        if (dataGridView1.CurrentRow != null) dataGridView1.CurrentRow.Cells[iColl].Value = STime;
                    }
                    break;
                default:
                    break;
            }

        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.IsCurrentRowDirty)
                {
                    this.Validate();
                    ((DTR)dTRsBindingSource.Current).IsSource = true;
                    ((DTR) dTRsBindingSource.Current).EditedBy = SUserName;
                    ((DTR)dTRsBindingSource.Current).EditedOn = DateTime.Now;
                    ((DTR)dTRsBindingSource.Current).EnrolleeId = ((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeId;
                    ((DTR)dTRsBindingSource.Current).EnrolleeNo = ((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeNo;
                    dTRsBindingSource.EndEdit();
                    int iResult = ActionClass.SaveDTR((DTR)dTRsBindingSource.Current);
                    if (iResult > 0)
                    {
                        Console.WriteLine(@"Save DTR.");
                    }
                    else
                    {
                        Console.WriteLine(@"Error DTR.");
                    }
                }
            }
        }

       private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            Thread.Sleep(200);
            Application.DoEvents();
            string SDuration = toolStripComboBoxMonth.Text.Trim() + " " + toolStripComboBoxDuration.Text.Trim();
            ReportParameter p1 = new ReportParameter("EnrolleeName", textBoxName.Text.Trim());
            ReportParameter p2 = new ReportParameter("DurationLabel", SDuration);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            if (System.Configuration.ConfigurationManager.AppSettings["PrintAll"] == "True")
                DTRBindingSource.DataSource = lDTRSource;
            else
            {
                var tempDTRSource = new List<DTR>();
                foreach (var dtr in lDTRSource)
                {
                    DTR d = dtr;
                    d.TotalHour = null;
                    d.TotalMinute = null;
                    tempDTRSource.Add(d);
                }
                DTRBindingSource.DataSource = tempDTRSource;
            }
            this.reportViewer1.RefreshReport();
        }

        private string GetEnrolleeDepartment()
        {
            string tempDepartment = string.Empty;
            int iDepartmentId = ((JEnrollee)listBoxEnrollees.SelectedItem).DepartmentId;
            Department d = ActionClass.GetDepartment(iDepartmentId);
            if (d != null)
            {
                tempDepartment = d.DepartmentName;
            }
            return tempDepartment;
        }

        private string GetEnrolleePosition()
        {
            string tempPosition = string.Empty;
            int iPositionId = ((JEnrollee)listBoxEnrollees.SelectedItem).PositionId;
            Position d = ActionClass.GetPosition(iPositionId);
            if (d != null)
            {
                tempPosition = d.PositionName;
            }
            return tempPosition;
        }

        private void listBoxEnrollees_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadDRTEnrolleeId();
            }
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {

        }

        private void SaveDTR()
        {
            foreach (var dtr in lDTRSource)
            {
                if (dtr.DTRId > 0)
                {
                    int iResult = ActionClass.SaveDTR(dtr);
                    if (iResult > 0)
                    {
                        Console.WriteLine(dtr.DTRId.ToString() + " " + dtr.DTRDay);
                    }
                }
            }
        }

        private void ExecuteSaveDTRThread()
        {
            Thread t = new Thread(new ThreadStart(SaveDTR));
            t.IsBackground = true;
            t.Start();
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            LoadDRTEnrolleeId();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void delinquentLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetToUpdateValue(iColl);
        }

        private void updateCellTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDRTEnrolleeId();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iColl = e.ColumnIndex;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var df = new DTRImportForm();
            df.MinimizeBox = false;
            df.MaximizeBox = false;
            df.FormBorderStyle = FormBorderStyle.FixedSingle;
            df.StartPosition = FormStartPosition.CenterScreen;
            Enrollee enrollee = ActionClass.GetEnrollee(((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeId);
            df.OEnrollee = enrollee;
            df.IMonth = toolStripComboBoxMonth.SelectedIndex + 1;
            df.IYear = int.Parse(toolStripComboBoxDuration.Text);
            df.ShowDialog();
        }

        private void printPreviewDTRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            Thread.Sleep(200);
            Application.DoEvents();
            string SDuration = toolStripComboBoxMonth.Text.Trim() + " " + toolStripComboBoxDuration.Text.Trim();
            ReportParameter p1 = new ReportParameter("EnrolleeName", textBoxName.Text.Trim());
            ReportParameter p2 = new ReportParameter("DurationLabel", SDuration);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            if (System.Configuration.ConfigurationManager.AppSettings["PrintAll"] == "True")
                DTRBindingSource.DataSource = lDTRSource;
            else
            {
                var tempDTRSource = new List<DTR>();
                foreach (var dtr in lDTRSource)
                {
                    DTR d = dtr;
                    d.TotalHour = null;
                    d.TotalMinute = null;
                    tempDTRSource.Add(d);
                }
                DTRBindingSource.DataSource = tempDTRSource;
            }
            this.reportViewer1.RefreshReport();
        }

        private void toolStripButtonDeleteDTR_Click(object sender, EventArgs e)
        {
            if (IsUser)
            {
                int iEnrolleeId = ((JEnrollee)listBoxEnrollees.SelectedItem).EnrolleeId;
                if (iEnrolleeId > 0)
                {
                    DialogResult dResult = UtilityClass.GetDeleteDialog("DTR");
                    if (dResult == DialogResult.Yes)
                    {
                        if (ActionClass.DeleteDTR(iEnrolleeId, iMonth, iYear))
                        {
                            MessageBox.Show("Record(s) were successfully deleted. Click OK buttong to load Blank DTR.", "Delete", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            LoadDRTEnrolleeId();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You have are not permitted to perform this operation.", "Delete", MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }
        }

        private void toolStripButtonBatchDTR_Click(object sender, EventArgs e)
        {
            var df = new DTRWizardForm {MaximizeBox = false, MinimizeBox = false, StartPosition =  FormStartPosition.CenterScreen};
            df.ShowDialog();

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void MarkUnderOverTimeHours()
        {
            foreach (DataGridViewRow dRow in dataGridView1.Rows)
            {
                if (dRow.Cells[10].Value == null) continue;
                var dValue = ((DTR) dRow.DataBoundItem).TotalHours;
                dRow.DefaultCellStyle.ForeColor = (dValue < 0) ? Color.Red : Color.Black;
            }
            
        }

        private void LoadDepartments()
        {
            Cursor = Cursors.WaitCursor;
            comboBoxDepartment.Items.Clear();
            List<Department> listDepartment = ActionClass.FillDepartments();
            foreach (var department in listDepartment)
            {
                comboBoxDepartment.Items.Add(department);
            }
            comboBoxDepartment.DisplayMember = "DepartmentName";
            comboBoxDepartment.ValueMember = "DepartmentId";
            comboBoxDepartment.Items.Insert(0, "--- All Depatments ---");
            comboBoxDepartment.SelectedIndex = 0;
            Cursor = Cursors.Default;
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDepartment.SelectedIndex > 0)
            {
                iDepartmentId = ((Department)comboBoxDepartment.SelectedItem).DepartmentId;
                LoadEnrollees(true);
            }
            else
            {
                LoadEnrollees(false);
            }
        }

        private void LoadEnrollees(bool bDepartment)
        {
            Cursor = Cursors.WaitCursor;
            List<JEnrollee> lEnrollee = bDepartment ? DataManagementClass.LoadEnrollees(true, iDepartmentId) : DataManagementClass.LoadEnrollees();
            jEnrolleeBindingSource.DataSource = lEnrollee;
            listBoxEnrollees.DataSource = lEnrollee;
            toolStripStatusLabel1.Text = String.Format("{0} enrollee(s) loaded.", lEnrollee.Count);
            Cursor = Cursors.Default;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Length > 0)
            {
                jEnrolleeBindingSource.DataSource = DataManagementClass.LoadEnrollees(textBoxSearch.Text.Trim());
                listBoxEnrollees.DataSource = jEnrolleeBindingSource;
                toolStripStatusLabel1.Text = jEnrolleeBindingSource.Count.ToString() + " enrollees loaded.";
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxSearch.Text.Length > 0)
                {
                    jEnrolleeBindingSource.DataSource = DataManagementClass.LoadEnrollees(textBoxSearch.Text.Trim());
                    listBoxEnrollees.DataSource = jEnrolleeBindingSource;
                    toolStripStatusLabel1.Text = jEnrolleeBindingSource.Count.ToString() + " enrollees loaded.";
                }
            }
        }
    }
}