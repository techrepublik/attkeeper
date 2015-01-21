using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AttendanceKeeper.Classes;
using AttendanceKeeper.Data;

namespace AttendanceKeeper.Management
{
    public partial class UserForm : Form
    {
        public string SUserName { get; set; }
        public string SCompanyName { get; set; }

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            InitComponents();
        }

        private void InitComponents()
        {
            userBindingSource.DataSource = ActionClass.FillUsers();
            labelCompanyName.Text = SCompanyName;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            userNameTextBox.Focus();
        }

        private void userBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Equals(textBoxPassword.Text))
            {
                if (userBindingSource != null)
                {
                    errorProvider1.SetError(passwordTextBox, "");
                    errorProvider1.SetError(textBoxPassword, "");
                    this.Validate();
                    userBindingSource.EndEdit();
                    int iResult = ActionClass.SaveUser((User)userBindingSource.Current);
                    if (iResult > 0)
                    {
                        Console.WriteLine(iResult.ToString());
                        toolStripStatusLabel1.Text = "Saved.";
                        UtilityClass.GetMessageBox(1);
                        Thread.Sleep(200);
                    }
                }
            }
            else
            {
                errorProvider1.SetError(passwordTextBox, "Password not match.");
                errorProvider1.SetError(textBoxPassword, "Password not match.");
            }

            
            toolStripStatusLabel1.Text = "Ready...";
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Equals(textBoxPassword.Text))
            {
                errorProvider1.SetError(textBoxPassword, "");
                toolStripStatusLabel1.Text = "Ready...";
            }
            else
            {
                errorProvider1.SetError(textBoxPassword, "Password not match.");
                toolStripStatusLabel1.Text = "Error on password.";
            }
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Equals(passwordTextBox.Text))
            {
                errorProvider1.SetError(passwordTextBox, "");
                toolStripStatusLabel1.Text = "Ready...";
            }
            else
            {
                errorProvider1.SetError(passwordTextBox, "Password not match.");
                toolStripStatusLabel1.Text = "Error on password.";
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult d = UtilityClass.GetDeleteDialog("User");
            if (DialogResult.Yes == d)
            {
                if (ActionClass.DeleteUser((User)userBindingSource.Current))
                {
                    userBindingSource.RemoveCurrent();
                    MessageBox.Show("Delete record successfull.", "Delete", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        
    }
}
