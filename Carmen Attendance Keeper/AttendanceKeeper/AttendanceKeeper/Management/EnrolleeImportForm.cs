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
using Microsoft.ReportingServices.ReportRendering;

namespace AttendanceKeeper.Management
{
    public partial class EnrolleeImportForm : Form
    {
        List<Enrollee> listEnrollees = new List<Enrollee>();
        public EnrolleeImportForm()
        {
            InitializeComponent();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
                                     {
                                         Filter = @"Excel Files (*.xls) | *.xls",
                                         DefaultExt = ".xls",
                                         RestoreDirectory = true
                                     };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    listEnrollees = UtilityClass.ImportEnrollees(openFileDialog.FileName);
                    var jList = new JSortingListClass<Enrollee>(listEnrollees);
                    enrolleeBindingSource.DataSource = jList;
                    Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(@"Error - " + ex.Message);
                    //throw;
                }
            }
            toolStripStatusLabel1.Text = String.Format("({0}) - records loaded.", enrolleeBindingSource.Count);
        }

        private void enrolleeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (enrolleeBindingSource.Count > 0)
            {
                Cursor = Cursors.WaitCursor;
                var iResult = ActionClass.SaveEnrollee(listEnrollees);
                Cursor = Cursors.Default;
                if (iResult > 0)
                {
                    MessageBox.Show(@"Import record(s) successfull. Click OK button to close the form.", @"Import Employee Data",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

        }

        private void EnrolleeImportForm_Load(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("({0}) - records loaded.", enrolleeBindingSource.Count);
        }

        private void enrolleeDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void enrolleeDataGridView_AlternatingRowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            
        }

        private void enrolleeDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void enrolleeDataGridView_DataMemberChanged(object sender, EventArgs e)
        {
           
        }

        private void enrolleeDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //MessageBox.Show(((Enrollee) enrolleeBindingSource.Current).LastName);
        }
    }
}
