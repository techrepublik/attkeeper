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
using System.Threading;
using System.Configuration;

namespace AttendanceKeeper
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.CancelButton = this.buttonClose;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string sUserName = textBoxUserName.Text.Trim();
                string sPassword = textBoxPassword.Text.Trim();

                if ((sUserName.Length > 0) && (sPassword.Length > 0))
                {
                    User u = DataManagementClass.GetUserViaUserNamePass(sUserName, sPassword);
                    if ((u != null) && (u.Active == true))
                    {
                        Company company = ActionClass.GetCompanyActive();
                        labelCompany.Text = company.CompanyName.ToUpper();
                        Application.DoEvents();
                        Thread.Sleep(2000);
                        AttendanceKeeper.MianForm mf = new MianForm();
                        mf.OUser = u;
                        mf.OCompany = company;
                        mf.IUserId = u.UserId;
                        mf.SUserName = u.UserName;
                        mf.SLevel = u.Level;
                        mf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Access Denied. You need to have a valid account to access.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured, please contact system administrator.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error - " + ex.Message);
                //throw;
            }
            Cursor = Cursors.Default;
        }

        private void textBoxUserName_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(textBoxUserName, true);
        }

        private void textBoxUserName_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(textBoxUserName, false);
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(textBoxPassword, true);
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(textBoxPassword, false);
        }
    }
}
