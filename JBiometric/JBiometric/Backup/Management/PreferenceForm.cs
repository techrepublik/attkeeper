using System;
using System.Configuration;
using System.Windows.Forms;
using AttendanceKeeper.Classes;
using AttendanceKeeper.Data;
using System.Threading;
using JBiometric.Manage;

namespace AttendanceKeeper.Management
{
    public partial class PreferenceForm : Form
    {
        public bool IsUser { get; set; }
        public string  SUserName { get; set; }
        public string SCompanyName { get; set; }

        System.Configuration.Configuration config =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        private enum Choice
        {
            EDepartment, EPosition, EMisc, Holiday, Company
        } ;

        private Choice myChoice;

        public PreferenceForm()
        {
            InitializeComponent();
        }

        private void PreferenceForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        public void InitComponents()
        {
            departmentBindingSource.DataSource = ActionClass.FillDepartments();
            miscellaneousBindingSource.DataSource = ActionClass.FillMiscellaneous();
            holidayBindingSource.DataSource = ActionClass.FillHolidays();
            companyBindingSource.DataSource = ActionClass.FillCompanies();
            checkBoxShowHourMinDTRPrint.Checked =
                Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["PrintAll"]);
            textBoxIPAddress.Text = System.Configuration.ConfigurationManager.AppSettings["IPAddress"];
            textBoxPortNo.Text = System.Configuration.ConfigurationManager.AppSettings["IPort"];
            textBoxSerialNo.Text = ConfigurationManager.AppSettings["MachineSN"];
            textBoxKey.Text = ConfigurationManager.AppSettings["MacKeyTemp"];

            if (System.Configuration.ConfigurationManager.AppSettings["ScreenType"] == "CO")
                radioButtonColored.Checked = true;
            else
                radioButtonBW.Checked = true;

            labelCompanyName.Text = SCompanyName;
        }

        private void departmentDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (departmentDataGridView.Rows.Count > 0)
                {
                    if (departmentDataGridView.IsCurrentRowDirty == true)
                    {
                        this.Validate();
                        ((Department)departmentBindingSource.Current).EditedBy = SUserName;
                        ((Department)departmentBindingSource.Current).EditedOn = DateTime.Now;
                        departmentBindingSource.EndEdit();
                        int iResult = ActionClass.SaveDepartment((Department)departmentBindingSource.Current);
                        if (iResult > 0)
                        {
                            Console.WriteLine(iResult.ToString());
                            toolStripStatusLabel1.Text = "Saved.";
                            departmentBindingSource.DataSource = ActionClass.FillDepartments();
                            Thread.Sleep(500);
                        }
                    }

                }
                toolStripStatusLabel1.Text = "Ready...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error - " + ex.Message + ". Please refer to system administrator.";
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void positionsDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (positionsDataGridView.Rows.Count > 0)
                {
                    if (positionsDataGridView.IsCurrentRowDirty == true)
                    {
                        this.Validate();
                        ((Position)positionsBindingSource.Current).EditedOn = DateTime.Now;
                        ((Position)positionsBindingSource.Current).EditedBy = SUserName;
                        positionsBindingSource.EndEdit();
                        ((Position)positionsBindingSource.Current).DepartmentId =
                            ((Department)departmentBindingSource.Current).DepartmentId;
                        int iResult = ActionClass.SavePosition((Position)positionsBindingSource.Current);
                        if (iResult > 0)
                        {
                            Console.WriteLine(iResult.ToString());
                            toolStripStatusLabel1.Text = "Saved.";
                            Thread.Sleep(500);

                        }
                    }
                }
                toolStripStatusLabel1.Text = "Ready...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error - " + ex.Message + ". Please refer to system administrator.";
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void departmentBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                if (departmentBindingSource.Current != null)
                {
                    positionsBindingSource.DataSource = ActionClass.FillPostions(((Department)departmentBindingSource.Current).DepartmentId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw;
            }
        }

        private void miscellaneousDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (miscellaneousDataGridView.Rows.Count > 0)
                {
                    if (miscellaneousDataGridView.IsCurrentRowDirty == true)
                    {
                        this.Validate();
                        ((Miscellaneous)miscellaneousBindingSource.Current).EditedBy = SUserName;
                        ((Miscellaneous)miscellaneousBindingSource.Current).EditedOn = DateTime.Now;
                        miscellaneousBindingSource.EndEdit();
                        int iResult = ActionClass.SaveMiscellaneous((Miscellaneous)miscellaneousBindingSource.Current);
                        if (iResult > 0)
                        {
                            Console.WriteLine(iResult.ToString());
                            toolStripStatusLabel1.Text = "Saved.";
                            Thread.Sleep(500);
                            miscellaneousBindingSource.DataSource = ActionClass.FillMiscellaneous();
                        }
                    }
                }
                toolStripStatusLabel1.Text = "Ready...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error - " + ex.Message + ". Please refer to system administrator.";
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void departmentDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            toolStripStatusLabel1.Text = "Editing...";
        }

        private void departmentDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            toolStripStatusLabel1.Text = "Done Editing...";
        }

        private void positionsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            toolStripStatusLabel1.Text = "Done Editing...";
        }

        private void positionsDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            toolStripStatusLabel1.Text = "Editing...";
        }

        private void departmentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            myChoice = Choice.EDepartment;
        }

        private void positionsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            myChoice = Choice.EPosition;
        }

        private void miscellaneousDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            myChoice = Choice.EMisc;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (IsUser)
            {
                DialogResult dResult = DialogResult.No;
                switch (myChoice)
                {
                    case Choice.EDepartment:
                        dResult = UtilityClass.GetDeleteDialog("Department");
                        if (dResult == DialogResult.Yes)
                        {
                            if (ActionClass.DeleteDepartment((Department) departmentBindingSource.Current))
                            {
                                if (departmentDataGridView.CurrentRow != null)
                                    departmentDataGridView.Rows.Remove(departmentDataGridView.CurrentRow);
                            }
                        }
                        break;
                    case Choice.EPosition:
                        dResult = UtilityClass.GetDeleteDialog("Position");
                        if (dResult == DialogResult.Yes)
                        {
                            if (ActionClass.DeletePosition((Position) positionsBindingSource.Current))
                            {
                                if (positionsDataGridView.CurrentRow != null)
                                    positionsDataGridView.Rows.Remove(positionsDataGridView.CurrentRow);
                            }
                        }
                        break;
                    case Choice.EMisc:
                        dResult = UtilityClass.GetDeleteDialog("Miscellaneous");
                        if (dResult == DialogResult.Yes)
                        {
                            if (ActionClass.DeleteMiscellaneous((Miscellaneous) miscellaneousBindingSource.Current))
                            {
                                if (miscellaneousDataGridView.CurrentRow != null)
                                    miscellaneousDataGridView.Rows.Remove(miscellaneousDataGridView.CurrentRow);
                            }
                        }
                        break;
                    case Choice.Holiday:
                        dResult = UtilityClass.GetDeleteDialog("Holiday");
                        if (dResult == DialogResult.Yes)
                        {
                            if (ActionClass.DeleteHoliday((Holiday)holidayBindingSource.Current))
                            {
                                if (holidayDataGridView.CurrentRow != null)
                                    holidayDataGridView.Rows.Remove(holidayDataGridView.CurrentRow);
                            }
                        }
                        break;
                    case Choice.Company:
                        if (companyBindingSource.Count > 1)
                        {
                            dResult = UtilityClass.GetDeleteDialog("Company");
                            if (dResult == DialogResult.Yes)
                            {
                                if (ActionClass.DeleteCompany((Company) companyBindingSource.Current))
                                {
                                    if (companyDataGridView.CurrentRow != null)
                                        companyDataGridView.Rows.Remove(companyDataGridView.CurrentRow);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cannot remove default company record.", "Delete", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        }
                        break;
                    default:
                        MessageBox.Show("Please select an item to delete.", "Delete", MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        break;
                }
            }
            else
            {
                MessageBox.Show("You have are not permitted to perform this operation.", "Delete", MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
            }

        }

        private void holidayDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (holidayDataGridView.Rows.Count > 0)
                {
                    if (holidayDataGridView.IsCurrentRowDirty)
                    {
                        this.Validate();
                        holidayBindingSource.EndEdit();
                        int iResult = ActionClass.SaveHoliday((Holiday)holidayBindingSource.Current);
                        if (iResult > 0)
                        {
                            Console.WriteLine(iResult.ToString());
                            toolStripStatusLabel1.Text = "Saved.";
                            Thread.Sleep(500);
                            holidayBindingSource.DataSource = ActionClass.FillHolidays();
                        }
                    }
                }
                toolStripStatusLabel1.Text = "Ready...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error - " + ex.Message + ". Please refer to system administrator.";
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void miscellaneousDataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 7)
            //{
            //    if (((Miscellaneous)miscellaneousBindingSource.Current).MiscActive == true)
            //    {
            //        if (!DataManagementClass.IsActiveMisc())
            //        {
            //            toolStripStatusLabel1.Text = "Ready...";
            //            isSave = true;
            //        }
            //        else
            //        {
            //            toolStripStatusLabel1.Text = "There should only be one (1) active misceallaneous setting.";
            //            MessageBox.Show("There is already an existing active miscellaneous setting.", "Active Setting",
            //                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            isSave = false;
            //            ((Miscellaneous)miscellaneousBindingSource.Current).MiscActive = false;
            //        }
            //    }
            //    else
            //    {
            //        isSave = true;
            //    }
            //}
        }

        private void miscellaneousBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
           
        }

        private void companyDataGridView_Leave(object sender, EventArgs e)
        {
            
        }

        private void holidayDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            myChoice = Choice.Holiday;
        }

        private void companyDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            myChoice = Choice.Company;
        }

        private void companyDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (companyDataGridView.Rows.Count > 0)
                {
                    if (companyDataGridView.IsCurrentRowDirty)
                    {
                        this.Validate();
                        companyBindingSource.EndEdit();
                        int iResult = ActionClass.SaveCompany((Company)companyBindingSource.Current);
                        if (iResult > 0)
                        {
                            Console.WriteLine(iResult.ToString());
                            toolStripStatusLabel1.Text = "Saved.";
                            Thread.Sleep(500);
                            companyBindingSource.DataSource = ActionClass.FillCompanies();
                        }
                    }
                }
                toolStripStatusLabel1.Text = "Ready...";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error - " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                toolStripStatusLabel1.Text = "Error - " + ex.Message + ". Please refer to system administrator.";
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void checkBoxShowHourMinDTRPrint_CheckedChanged(object sender, EventArgs e)
        {
            config.AppSettings.Settings["PrintAll"].Value = checkBoxShowHourMinDTRPrint.Checked ? "True" : "False";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            //MessageBox.Show(System.Configuration.ConfigurationManager.AppSettings["PrintAll"]);
        }

        private void textBoxPortNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), "\\d+"))
                e.Handled = true;
        }

        private void textBoxIPAddress_Leave(object sender, EventArgs e)
        {
            if (UtilityClass.IsValidIP(textBoxIPAddress.Text.Trim()))
            {
                config.AppSettings.Settings["IPAddress"].Value = textBoxIPAddress.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                MessageBox.Show(@"Please check/verify the I.P. Address.", @"I.P. Address", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBoxIPAddress.Text = System.Configuration.ConfigurationManager.AppSettings["IPAddress"];
            }
        }

        private void textBoxPortNo_Leave(object sender, EventArgs e)
        {
            config.AppSettings.Settings["IPort"].Value = textBoxPortNo.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void PreferenceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Validate();
        }

        private void textBoxIPAddress_Validated(object sender, EventArgs e)
        {

        }

        private void textBoxIPAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (UtilityClass.IsValidIP(textBoxIPAddress.Text.Trim()))
            {
                config.AppSettings.Settings["IPAddress"].Value = textBoxIPAddress.Text;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                MessageBox.Show(@"Please check/verify the I.P. Address.", @"I.P. Address", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                textBoxIPAddress.Text = System.Configuration.ConfigurationManager.AppSettings["IPAddress"];
            }
        }

        private void textBoxPortNo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            config.AppSettings.Settings["IPort"].Value = textBoxPortNo.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void radioButtonBW_CheckedChanged(object sender, EventArgs e)
        {
            config.AppSettings.Settings["ScreenType"].Value = "BW";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void radioButtonColored_CheckedChanged(object sender, EventArgs e)
        {
            config.AppSettings.Settings["ScreenType"].Value = "CO";
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void textBoxSerialNo_Leave(object sender, EventArgs e)
        {
            config.AppSettings.Settings["MachineSN"].Value = textBoxSerialNo.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void textBoxSerialNo_Validated(object sender, EventArgs e)
        {
            config.AppSettings.Settings["MachineSN"].Value = textBoxSerialNo.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void textBoxKey_Leave(object sender, EventArgs e)
        {
            config.AppSettings.Settings["MacKeyTemp"].Value = textBoxKey.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void textBoxKey_Validated(object sender, EventArgs e)
        {
            config.AppSettings.Settings["MacKeyTemp"].Value = textBoxKey.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int iError = -1;
            textBoxSerialNo.Text = DeviceInfoClass.GetDeviceSN(1, ref iError, 2, UtilityClass.GetIPAddress(),
                                                                  UtilityClass.GetIPort());
            if (iError > -1)
            {
                MessageBox.Show(@"Error Connecting to device.", @"Device Connection Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            Cursor = Cursors.Default;
        }

       
    }
}
