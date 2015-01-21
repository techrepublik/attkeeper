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
    public partial class DTRWizardForm : Form
    {
        private int iDepartmentId = 0;
        List<JEnrollee> listEnrollee = new List<JEnrollee>();
        public DTRWizardForm()
        {
            InitializeComponent();
        }

        private void DTRWizardForm_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            InitComponents();
        }

        private void InitComponents()
        {
            comboBoxMonth.DataSource = UtilityClass.FillMonth();

            comboBoxYear.DataSource = UtilityClass.FillYear();

            comboBoxStartDay.Items.Clear();
            for (int i = 0; i < 31; i++)
            {
                comboBoxStartDay.Items.Add(i + 1);
            }
            comboBoxStartDay.SelectedIndex = 0;

            comboBoxEndDay.Items.Clear();
            for (int i = 0; i < 31; i++)
            {
                comboBoxEndDay.Items.Add(i + 1);
            }
            comboBoxEndDay.SelectedIndex = 0;

            buttonBack.Enabled = false;
            buttonNext.Enabled = true;
            buttonFinish.Enabled = false;
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

        private void buttonNext_Click(object sender, EventArgs e)
        {
            buttonBack.Enabled = true;
            buttonNext.Enabled = false;
            buttonFinish.Enabled = true;
            groupBoxEnrollees.Visible = true;
            //groupBoxDuration.Visible = false;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            buttonBack.Enabled = false;
            buttonNext.Enabled = true;
            buttonFinish.Enabled = false;
            groupBoxEnrollees.Visible = false;
            //groupBoxDuration.Visible = true;
        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDepartment.SelectedIndex > 0)
            {
                iDepartmentId = ((Department) comboBoxDepartment.SelectedItem).DepartmentId;
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
            jEnrolleeBindingSource1.DataSource = lEnrollee;
            //listBox2.DataSource = listEnrollee;
            //listBox2.DisplayMember = "GetFullName";
            //listBox2.ValueMember = "EnrolleeNo";
            toolStripStatusLabel1.Text = String.Format("{0} enrollee(s) loaded.", listEnrollee.Count);
            Cursor = Cursors.Default;
        }

        private void buttonGetOne_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Add(listBox2.SelectedItem);
            if (listBox2.Items.Count <= 0) return;
            listBox1.Items.Add(listBox2.Text);
            var en = (JEnrollee) jEnrolleeBindingSource1.Current;
            listEnrollee.Add(en);
            jEnrolleeBindingSource1.Remove(en);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count <= 0) return;
            var tempEnrollee = jEnrolleeBindingSource1.CurrencyManager.List.Cast<JEnrollee>().ToList();
            if (tempEnrollee.Count == 0) return;
            foreach (var item in tempEnrollee)
            {
                listBox1.Items.Add(item.GetFullName);
            }
            listEnrollee.AddRange(tempEnrollee);
            jEnrolleeBindingSource1.CurrencyManager.List.Clear();
            jEnrolleeBindingSource1.DataSource = null;
        }

        private void buttonRemoveOne_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0) return;
            if (listBox1.Text.Trim().Length == 0) return;
            var enrolee = listEnrollee.FirstOrDefault(en => en.GetFullName == listBox1.Text);
            jEnrolleeBindingSource1.CurrencyManager.List.Add(enrolee);
            listEnrollee.Remove(enrolee);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0) return;
            if (listEnrollee.Count == 0) return;
            foreach (var item in listEnrollee)
            {
                jEnrolleeBindingSource1.CurrencyManager.List.Add(item);
            }
            listEnrollee.Clear();
            listBox1.Items.Clear();
        }
    }
}
