using System;
using System.Windows.Forms;
using JBiometric.Manage;

namespace WindowsFormsTestBiometic
{
    public partial class EnrollForm : Form
    {
        public EnrollForm()
        {
            InitializeComponent();
        }

        private void buttonStartEnroll_Click(object sender, EventArgs e)
        {
            int iError = 0;
            if (OnlineEnrollClass.EnrollUserFinger(1, int.Parse(textBoxUserId.Text), int.Parse(textBoxFingerPrintIndex.Text), 0, ref iError, 2, "192.168.1.201", 4370))
            {
                MessageBox.Show("Start Enrollment.");
                buttonOk.Enabled = true;
                buttonStartEnroll.Enabled = false;
            }
            else
            {
                MessageBox.Show("Cannot enroll." + iError, "Error");
                buttonOk.Enabled = true;
                buttonStartEnroll.Enabled = false;
            }
        }

        private void EnrollForm_Load(object sender, EventArgs e)
        {
            buttonOk.Enabled = false;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DeviceInfoClass.DDevice().Disconnect();
            Close();
        }
    }
}
