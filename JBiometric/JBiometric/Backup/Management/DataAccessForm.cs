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
    public partial class DataAccessForm : Form
    {
        public bool IsUser { get; set; }

        public DataAccessForm()
        {
            InitializeComponent();
        }

        private void DataAccessForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            machineInstanceBindingSource.DataSource = ActionClass.FillMachineInstances();
        }

        private void machineInstanceBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (machineInstanceBindingSource.Current != null)
                machinesBindingSource.DataSource = ActionClass.FillMachinesViaEnrollMachineInstance(((MachineInstance)machineInstanceBindingSource.Current).MachineInsId);
        }

        private void machineInstanceDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (machineInstanceBindingSource.Current != null)
            {
                if (IsUser)
                {
                    DialogResult dResult = UtilityClass.GetDeleteDialog("Machine Log Instance");
                    if (dResult == DialogResult.Yes)
                    {
                        if (ActionClass.DeleteMachieneInstance((MachineInstance) machineInstanceBindingSource.Current))
                        {
                            machineInstanceBindingSource.RemoveCurrent();
                            machinesBindingSource.DataSource = null;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You have are not permitted to perform this operation.", "Delete", MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                }
            }
        }
    }
}
