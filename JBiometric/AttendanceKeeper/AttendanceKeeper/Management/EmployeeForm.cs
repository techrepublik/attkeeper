using System;
using System.Windows.Forms;
using AttendanceKeeper.Classes;
using AttendanceKeeper.Data;
using System.Threading;

namespace AttendanceKeeper.Management
{
    public partial class EmployeeForm : Form
    {
        public bool IsUser { get; set; }
        public string SUserName { get; set; }
        public string SCompanyName { get; set; }

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            ExecuteInitComponents();
        }

        private void InitComponents()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Invoke((MethodInvoker) delegate
                                            {
                                                departmentBindingSource.DataSource = ActionClass.FillDepartments();
                                                positionsBindingSource.DataSource = ActionClass.FillPostions();
                                                settingBindingSource.DataSource = ActionClass.FillSettings();

                                                //enrolleeBindingSource.DataSource = ActionClass.FillEnrollees();
                                            });

            if (labelCompanyName.InvokeRequired)
                labelCompanyName.BeginInvoke(new MethodInvoker(delegate() { labelCompanyName.Text = SCompanyName; }));
            Cursor.Current = Cursors.Default;
        }

        private void ExecuteInitComponents()
        {
            Thread t = new Thread(new ThreadStart(InitComponents));
            t.IsBackground = true;
            t.Start();
        }

        private void enrolleeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (enrolleeBindingSource.Current != null)
                {
                    this.Validate();
                    if (pictureBox1.Image != null)
                        ((Enrollee)enrolleeBindingSource.Current).Picture = UtilityClass.ImageToByte(pictureBox1.Image);
                    ((Enrollee)enrolleeBindingSource.Current).DepartmentId =
                        ((Department)departmentBindingSource.Current).DepartmentId;
                    ((Enrollee)enrolleeBindingSource.Current).PositionId =
                        ((Position)positionsBindingSource.Current).PositionId;
                    ((Enrollee)enrolleeBindingSource.Current).SettingId =
                        ((Setting)settingBindingSource.Current).SettingId;
                    ((Enrollee)enrolleeBindingSource.Current).EditedBy = SUserName;
                    ((Enrollee)enrolleeBindingSource.Current).EditedOn = DateTime.Now;
                    enrolleeBindingSource.EndEdit();
                    int iResult = ActionClass.SaveEnrollee((Enrollee)enrolleeBindingSource.Current);
                    if (iResult > 0)
                    {
                        MessageBox.Show("Record Save.", "Save.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Console.WriteLine(iResult.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured. Please contact system administrator.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine("Error - " + ex.Message);
                //throw;
            }
            Cursor.Current = Cursors.Default;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (departmentIdComboBox.Items.Count > 0)
                departmentIdComboBox.SelectedIndex = 0;

            if (positionIdComboBox.Items.Count > 0)
                positionIdComboBox.SelectedIndex = 0;

            if (settingIdComboBox.Items.Count > 0)
                settingIdComboBox.SelectedIndex = 0;
            
            enrolleeIdNoTextBox.Focus();
        }

        private void toolStripButtonLeave_Click(object sender, EventArgs e)
        {
            var lf = new LeaveForm
                         {
                             MinimizeBox = false,
                             MaximizeBox = false,
                             FormBorderStyle = FormBorderStyle.FixedSingle,
                             StartPosition = FormStartPosition.CenterScreen,
                             OEnrollee = (Enrollee) enrolleeBindingSource.Current,
                             IsUser = IsUser
                         };
            lf.ShowDialog();
        }

        private void enrolleeNoTextBox_Leave(object sender, EventArgs e)
        {
            if ((enrolleeNoTextBox.Text.Length > 0) && (enrolleeIdNoTextBox.Text.Length > 0))
            {
                string sTempName;
                if (IsDuplicate(out sTempName))
                {
                    errorProvider1.SetError(enrolleeNoTextBox,
                                            "This ID No belongs to " + sTempName);
                    //enrolleeNoTextBox.Focus();
                    //enrolleeBindingSource.CancelEdit();
                }
                else
                {
                    errorProvider1.SetError(enrolleeNoTextBox, "");
                    if (departmentIdComboBox.Items.Count > 0)
                        departmentIdComboBox.SelectedIndex = 0;

                    if (positionIdComboBox.Items.Count > 0)
                        positionIdComboBox.SelectedIndex = 0;

                    if (settingIdComboBox.Items.Count > 0)
                        settingIdComboBox.SelectedIndex = 0;
                }
            }
            UtilityClass.ChangeColor(enrolleeNoTextBox, false);
        }

        private void enrolleeIdNoTextBox_Leave(object sender, EventArgs e)
        {
            if ((enrolleeNoTextBox.Text.Length > 0) && (enrolleeIdNoTextBox.Text.Length > 0))
            {
                string sTempName;
                if (IsDuplicate(out sTempName))
                {
                    errorProvider1.SetError(enrolleeIdNoTextBox,
                                            "This ID No belongs to " + sTempName);
                    //enrolleeIdNoTextBox.Focus();
                    //enrolleeBindingSource.CancelEdit();
                }
                else
                {
                    errorProvider1.SetError(enrolleeIdNoTextBox, "");
                    if (departmentIdComboBox.Items.Count > 0)
                        departmentIdComboBox.SelectedIndex = 0;

                    if (positionIdComboBox.Items.Count > 0)
                        positionIdComboBox.SelectedIndex = 0;

                    if (settingIdComboBox.Items.Count > 0)
                        settingIdComboBox.SelectedIndex = 0;
                }
            }
            UtilityClass.ChangeColor(enrolleeIdNoTextBox, false);
        }

        private void enrolleeBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (enrolleeBindingSource.Current != null)
            {
                if (((Enrollee)enrolleeBindingSource.Current).Picture != null)
                {
                    pictureBox1.Image = UtilityClass.ByteToImage(((Enrollee) enrolleeBindingSource.Current).Picture.ToArray());
                }
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Jpeg (*.jpg)|*.jpg| Png (*.png) |*.png| Gif (*.gif) | *.gif";
            if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.ImageLocation = openDialog.FileName;
                byte[] tempBuffer = UtilityClass.ReadFile(openDialog.FileName);
                pictureBox1.Image = UtilityClass.ByteToImage(tempBuffer);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (IsUser)
            {
                if (enrolleeBindingSource.Current != null)
                {
                    DialogResult dResult = UtilityClass.GetDeleteDialog("Enrollee");
                    if (dResult == DialogResult.Yes)
                    {
                        if (ActionClass.DeleteEnrollee((Enrollee) enrolleeBindingSource.Current))
                        {
                            MessageBox.Show("Record was successfully deleted.", "Delete", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            enrolleeBindingSource.Remove(enrolleeBindingSource.Current);
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

        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (toolStripTextBox1.Text.Length > 0)
            {
                enrolleeBindingSource.DataSource = ActionClass.FillEnrollees(toolStripTextBox1.Text.Trim(), toolStripTextBox1.Text.Trim(), toolStripTextBox1.Text.Trim());
            }
            Cursor.Current = Cursors.Default;
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var listEnrollees = new JSortingListClass<Enrollee>(ActionClass.FillEnrollees());
            enrolleeBindingSource.DataSource = listEnrollees;
            Cursor.Current = Cursors.Default;
        }

        private void linkLabelSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var df = new DTRSettingForm { MaximizeBox = false, MinimizeBox = false, FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle, StartPosition = FormStartPosition.CenterScreen };
            df.ShowDialog();
        }

        private void linkLabelDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var pf = new PreferenceForm
                         {
                             MaximizeBox = false,
                             MinimizeBox = false,
                             FormBorderStyle = FormBorderStyle.FixedSingle,
                             StartPosition = FormStartPosition.CenterScreen
                         };
            pf.ShowDialog();
        }

        private bool IsDuplicate(out string sEName)
        {
            string sTempName = string.Empty;
            bool bResult = false;
            if (enrolleeBindingSource.Current != null)
            {
                try
                {
                    if ((enrolleeNoTextBox.Text.Trim().Length > 0) && (enrolleeIdNoTextBox.Text.Trim().Length > 0))
                    {
                        if (enrolleeBindingSource != null)
                        {
                            Enrollee e = ActionClass.GetEnrolleeViaEnrollNo(Convert.ToInt32(enrolleeNoTextBox.Text.Trim()),
                                                                            enrolleeIdNoTextBox.Text.Trim(),
                                                                            ((Enrollee)enrolleeBindingSource.Current).
                                                                                EnrolleeId);
                            if (e != null)
                            {
                                sTempName = e.LastName.Trim().ToUpper() + ", " + e.FirstName.Trim() + " " +
                                            e.MiddleName.Substring(0, 1) + ".";
                                bResult = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error - " + ex.Message);
                    //throw;
                }
            }
            sEName = sTempName;
            return bResult;
        }

        private void linkLabelPosition_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var pf = new PreferenceForm
            {
                MaximizeBox = false,
                MinimizeBox = false,
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen
            };
            pf.ShowDialog();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cursor.Current = Cursors.WaitCursor;
                if (toolStripTextBox1.Text.Length > 0)
                {
                    enrolleeBindingSource.DataSource = ActionClass.FillEnrollees(toolStripTextBox1.Text.Trim(), toolStripTextBox1.Text.Trim(), toolStripTextBox1.Text.Trim());
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            enrolleeBindingSource.EndEdit();
            enrolleeIdNoTextBox.Focus();
        }

        private void birthDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            birthDateDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void dateHiredDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dateHiredDateTimePicker.Format = DateTimePickerFormat.Short;
        }

        private void enrolleeIdNoTextBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(enrolleeIdNoTextBox, true);
        }

        private void enrolleeNoTextBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(enrolleeNoTextBox, true);
        }

        private void lastNameTextBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(lastNameTextBox, false);
            if (lastNameTextBox.Text.Length > 0)
            {
                errorProvider1.SetError(lastNameTextBox, "");
            }
            else
            {
                errorProvider1.SetError(lastNameTextBox, "Fill Last Name");
                lastNameTextBox.Focus();
            }
        }

        private void lastNameTextBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(lastNameTextBox, true);
        }

        private void firstNameTextBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(firstNameTextBox, true);
        }

        private void firstNameTextBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(firstNameTextBox, false);
            if (firstNameTextBox.Text.Length > 0)
            {
                errorProvider1.SetError(firstNameTextBox, "");
            }
            else
            {
                errorProvider1.SetError(firstNameTextBox, "Fill First Name");
                firstNameTextBox.Focus();
            }
        }

        private void middleNameTextBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(middleNameTextBox, false);
            if (middleNameTextBox.Text.Length > 0)
            {
                errorProvider1.SetError(middleNameTextBox, "");
            }
            else
            {
                errorProvider1.SetError(middleNameTextBox, "Fill Middle Name");
                middleNameTextBox.Focus();
            }
        }

        private void middleNameTextBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(middleNameTextBox, true);
        }

        private void addressTextBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(addressTextBox, true);
        }

        private void addressTextBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(addressTextBox, false);
        }

        private void sexComboBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(sexComboBox, false);
        }

        private void sexComboBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(sexComboBox, true);
        }

        private void departmentIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(departmentIdComboBox, true);
        }

        private void departmentIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(departmentIdComboBox, false);
        }

        private void positionIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(positionIdComboBox, false);
        }

        private void positionIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(positionIdComboBox, true);
        }

        private void settingIdComboBox_Enter(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(settingIdComboBox, true);
        }

        private void settingIdComboBox_Leave(object sender, EventArgs e)
        {
            UtilityClass.ChangeColor(settingIdComboBox, false);
        }
    }
}
