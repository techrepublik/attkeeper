using System;
using System.Threading;
using System.Windows.Forms;
using AttendanceKeeper.Data;
using AttendanceKeeper.Classes;

namespace AttendanceKeeper.Management
{
    public partial class LeaveForm : Form
    {
        public bool IsUser { get; set; }
        public string SUserName { get; set; }
        public string SCompanyName { get; set; }
        public Enrollee  OEnrollee { get; set; }

        public LeaveForm()
        {
            InitializeComponent();
        }

        private void LeaveForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            labelCompanyName.Text = SCompanyName;
            leaveBindingSource.DataSource = ActionClass.FillLeaves(OEnrollee.EnrolleeId);
            this.Text = "Leave/O.B. Form - [ " + OEnrollee.EnrolleeNo.ToString() + "  " + OEnrollee.LastName.Trim().ToUpper() + ", " + OEnrollee.FirstName.Trim() +
                        " " + OEnrollee.MiddleName.Substring(0, 1) + ". ]";
        }

        private void leaveDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (leaveDataGridView.Rows.Count > 0)
            {
                if (leaveDataGridView.IsCurrentRowDirty)
                {
                    this.Validate();
                    ((Data.Leave) leaveBindingSource.Current).EditedBy = SUserName;
                    ((Data.Leave) leaveBindingSource.Current).EditedOn = DateTime.Now;
                    leaveBindingSource.EndEdit();
                    ((Leave) leaveBindingSource.Current).EnrolleeId = OEnrollee.EnrolleeId;
                    int iResult = ActionClass.SaveLeave((Data.Leave) leaveBindingSource.Current);
                    if (iResult > 0)
                    {
                        Console.WriteLine(iResult.ToString());
                        toolStripStatusLabel1.Text = "Saved.";
                        Thread.Sleep(200);
                    }
                }
            }
            toolStripStatusLabel1.Text = "Ready...";
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (IsUser)
            {
                if (leaveBindingSource != null)
                {
                    DialogResult dResult = UtilityClass.GetDeleteDialog("Leave/O.B.");
                    if (dResult == DialogResult.Yes)
                    {
                        if (ActionClass.DeleteLeave((Leave) leaveBindingSource.Current))
                        {
                            MessageBox.Show("Record was successfully deleted.", "Delete", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            leaveBindingSource.Remove(leaveBindingSource.Current);
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

        private void leaveDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (leaveBindingSource.Current != null)
            {
                if (leaveDataGridView.IsCurrentCellInEditMode)
                {
                    if ((e.ColumnIndex == 1) || (e.ColumnIndex == 2))
                    {
                        int iStart = Convert.ToDateTime(leaveDataGridView.CurrentRow.Cells[1].Value).Day;
                        int iEnd = Convert.ToDateTime(leaveDataGridView.CurrentRow.Cells[2].Value).Day;
                        int iDuration = iEnd - iStart;
                        leaveDataGridView.Rows[e.RowIndex].Cells[4].Value = iDuration > 0 ? iDuration.ToString() : "1";
                    }
                }
            }
        }

        private void leaveDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
