using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AttendanceKeeper.Data;
using AttendanceKeeper.Classes;

namespace AttendanceKeeper.Management
{
    public partial class DTRSettingDetailForm : Form
    {
        public string SUserName { get; set; }
        public string SCompanyName { get; set; }

        public SettingDetail OSetting { get; set; }

        private DTRSettingForm df;
        public DTRSettingDetailForm(DTRSettingForm f)
        {
            df = f;
            InitializeComponent();
        }

        private void DTRSettingDetailForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        public void InitComponents()
        {
            settingDetailsBindingSource.DataSource = OSetting;
            labelCompanyName.Text = SCompanyName;
            //string sTimeInAM = ((SettingDetail) settingDetailsBindingSource.Current).SettingDetailINAM.ToString();
            //string sTimeOutAM = ((SettingDetail) settingDetailsBindingSource.Current).SettingDetailOUTAM.ToString();
            //string sTimeInPM = ((SettingDetail) settingDetailsBindingSource.Current).SettingDetailINPM.ToString();
            //string sTimeOutPM = ((SettingDetail) settingDetailsBindingSource.Current).SettingDetailOUTPM.ToString();
            //string sTimeInOT = ((SettingDetail) settingDetailsBindingSource.Current).SettingDetailINOT.ToString();
            //string sTimeOutOT = ((SettingDetail) settingDetailsBindingSource.Current).SettingDetailOUTOT.ToString();

            //textBoxSetting.Text = String.Format("{0:t} - {1:t} (A.M.) | {2:t} - {3:t} (P.M.)", sTimeInAM, sTimeOutAM,
            //                                    sTimeInPM, sTimeOutPM);
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            settingDetailsBindingSource.EndEdit();
            int iResult = ActionClass.SaveSettingDetail((SettingDetail)settingDetailsBindingSource.Current);
            if (iResult > 0)
            {
                UtilityClass.GetMessageBox(1);
            }
        }
    }
}
