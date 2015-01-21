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
    public partial class DTRBatchForm : Form
    {
        int iDepartmentId = 0;

        public DTRBatchForm()
        {
            InitializeComponent();
        }

        private void DTRBatchForm_Load(object sender, EventArgs e)
        {
            InitComponents();
            LoadEnrollees(false);
            LoadDepartments();
        }

        private void InitComponents()
        {

        }

        private void LoadEnrollees(bool bDepartment)
        {
            List<JEnrollee> listEnrollee = bDepartment ? DataManagementClass.LoadEnrollees(true, iDepartmentId) : DataManagementClass.LoadEnrollees();
            //checkedListBox1.Items.Clear();
            checkedListBox1.DataSource = listEnrollee;
            checkedListBox1.DisplayMember = "GetFullName";
            checkedListBox1.ValueMember = "EnrolleeNo";
            //foreach (var enrollee in listEnrollee)
            //{
            //    checkedListBox1.DataSource = listEnrollee;
            //    checkedListBox1.Items.Add(String.Format("{0}, {1} {2}.", enrollee.LastName.Trim().ToUpper(),
            //                                            enrollee.FirstName.Trim(), enrollee.MiddleName.Substring(0, 1)));

            //}

        }

        private void LoadDepartments()
        {
            comboBoxDepartment.Items.Clear();
            List<Department> listDepartment = ActionClass.FillDepartments();
            foreach (var department in listDepartment)
            {
                comboBoxDepartment.Items.Add(department);
            }
            comboBoxDepartment.DisplayMember = "DepartmentName";
            comboBoxDepartment.ValueMember = "DepartmentId";
            comboBoxDepartment.Items.Insert(0,"--- All Depatments ---");
            comboBoxDepartment.SelectedIndex = 0;
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDepartment.SelectedIndex <= 0) return;
            iDepartmentId = ((Department) comboBoxDepartment.SelectedItem).DepartmentId;
            LoadEnrollees(true);
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAll.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void toolStripButtonLoadDTR_Click(object sender, EventArgs e)
        {
            var stringBuilder = new StringBuilder();
            foreach (JEnrollee oChecked in checkedListBox1.CheckedItems)
            {
                stringBuilder.Append(oChecked.EnrolleeNo.ToString() + "\n\r");

            }
            MessageBox.Show(stringBuilder.ToString());
        }

        private void LoadDTR()
        {
            //var en = ((Enrollee) checkedListBox1.SelectedItem);
            //int iMonth = toolStripComboBoxMonth.SelectedIndex + 1;
            //int iYear = Convert.ToInt32(toolStripComboBoxTo.Text);
            //int iFrom = Convert.ToInt32(toolStripComboBoxFrom.Text);
            //int iTo = Convert.ToInt32(toolStripComboBoxTo.Text);

            //dTRBindingSource.DataSource = DataManagementClass.LoadDTRViaDTR(en, iMonth, iYear, iFrom, iTo, ActionClass.FillDTRs(en.EnrolleeId));
        }

        

       
    }
}
