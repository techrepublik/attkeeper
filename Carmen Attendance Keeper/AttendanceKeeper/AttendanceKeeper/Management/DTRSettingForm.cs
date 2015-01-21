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
    public partial class DTRSettingForm : Form
    {
        public bool IsUser { get; set; }
        public string  SUserName { get; set; }
        public string SCompanyName { get; set; }

        private bool isActive = false;

        DTRSettingDetailForm ddf;
        public DTRSettingForm()
        {
            ddf = new DTRSettingDetailForm(this);
            InitializeComponent();
        }

        private void DTRSettingForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            settingBindingSource.DataSource = ActionClass.FillSettings();
            labelCompanyName.Text = SCompanyName;
        }

        private void settingDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (settingDataGridView.Rows.Count > 0)
            {
                if (settingDataGridView.IsCurrentRowDirty == true)
                {
                    this.Validate();
                    ((Setting) settingBindingSource.Current).EditedBy = SUserName;
                    ((Setting) settingBindingSource.Current).EdtiedOn = DateTime.Now;
                    settingBindingSource.EndEdit();
                    int iResult = ActionClass.SaveSetting((Setting) settingBindingSource.Current);
                    if (iResult > 0)
                    {
                        settingBindingSource.DataSource = ActionClass.FillSettings();
                        Console.WriteLine(iResult.ToString());
                    }
                }
            }
        }

        private void settingDetailsDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (settingDetailsDataGridView.Rows.Count > 0)
            {
                if (settingDetailsDataGridView.IsCurrentRowDirty == true)
                {
                    this.Validate();
                    ((SettingDetail) settingDetailsBindingSource.Current).EditedBy = SUserName;
                    ((SettingDetail) settingDetailsBindingSource.Current).EditedOn = DateTime.Now;
                    settingDetailsBindingSource.EndEdit();
                    ((SettingDetail) settingDetailsBindingSource.Current).SettingId = ((Setting) settingBindingSource.Current).SettingId;
                    int iResult = ActionClass.SaveSettingDetail((SettingDetail) settingDetailsBindingSource.Current);
                    if (iResult > 0)
                    {
                        Console.WriteLine(iResult.ToString());
                    }
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            ddf.MaximizeBox = false;
            ddf.MinimizeBox = false;
            ddf.FormBorderStyle = FormBorderStyle.FixedSingle;
            ddf.StartPosition = FormStartPosition.CenterScreen;
            ddf.OSetting = (SettingDetail) settingDetailsBindingSource.Current;
            ddf.SCompanyName = SCompanyName;
            ddf.ShowDialog();
        }

        private void settingDataGridView_Click(object sender, EventArgs e)
        {
            isActive = false;
        }

        private void settingDetailsDataGridView_Click(object sender, EventArgs e)
        {
            isActive = true;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (IsUser)
            {
                if (isActive == false)
                {
                    if (settingBindingSource != null)
                    {
                        DialogResult dResult = UtilityClass.GetDeleteDialog("Settings");
                        if (dResult == DialogResult.Yes)
                        {
                            if (ActionClass.DeleteSetting((Setting) settingBindingSource.Current))
                                settingBindingSource.Remove(settingBindingSource.Current);
                        }
                    }
                }
                else
                {
                    if (settingDetailsBindingSource != null)
                    {
                        DialogResult dResult = UtilityClass.GetDeleteDialog("Settings Detail");
                        if (dResult == DialogResult.Yes)
                        {
                            if (ActionClass.DeleteSettingDetail((SettingDetail) settingDetailsBindingSource.Current))
                                settingDetailsBindingSource.Remove(settingDetailsBindingSource.Current);
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

    }
}
