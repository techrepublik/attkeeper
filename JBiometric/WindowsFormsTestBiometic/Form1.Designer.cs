namespace WindowsFormsTestBiometic
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSetTime = new System.Windows.Forms.Button();
            this.buttonImportToTextFile = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonCheckConnection = new System.Windows.Forms.Button();
            this.buttonGetSN = new System.Windows.Forms.Button();
            this.buttonEnrollOnline = new System.Windows.Forms.Button();
            this.buttonDeleteEnrollee = new System.Windows.Forms.Button();
            this.buttonGetEnrollees = new System.Windows.Forms.Button();
            this.buttonGetRecords = new System.Windows.Forms.Button();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.buttonDownLoadLogs = new System.Windows.Forms.Button();
            this.buttonPowerOff = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(789, 40);
            this.panel1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(789, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 17);
            this.statusLabel.Text = "...";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.buttonSetTime);
            this.panel2.Controls.Add(this.buttonImportToTextFile);
            this.panel2.Controls.Add(this.buttonDisconnect);
            this.panel2.Controls.Add(this.buttonCheckConnection);
            this.panel2.Controls.Add(this.buttonGetSN);
            this.panel2.Controls.Add(this.buttonEnrollOnline);
            this.panel2.Controls.Add(this.buttonDeleteEnrollee);
            this.panel2.Controls.Add(this.buttonGetEnrollees);
            this.panel2.Controls.Add(this.buttonGetRecords);
            this.panel2.Controls.Add(this.buttonClearLogs);
            this.panel2.Controls.Add(this.buttonDownLoadLogs);
            this.panel2.Controls.Add(this.buttonPowerOff);
            this.panel2.Controls.Add(this.buttonRestart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(151, 510);
            this.panel2.TabIndex = 2;
            // 
            // buttonSetTime
            // 
            this.buttonSetTime.Location = new System.Drawing.Point(22, 423);
            this.buttonSetTime.Name = "buttonSetTime";
            this.buttonSetTime.Size = new System.Drawing.Size(108, 23);
            this.buttonSetTime.TabIndex = 12;
            this.buttonSetTime.Text = "Set Time";
            this.buttonSetTime.UseVisualStyleBackColor = true;
            this.buttonSetTime.Click += new System.EventHandler(this.buttonSetTime_Click);
            // 
            // buttonImportToTextFile
            // 
            this.buttonImportToTextFile.Location = new System.Drawing.Point(22, 171);
            this.buttonImportToTextFile.Name = "buttonImportToTextFile";
            this.buttonImportToTextFile.Size = new System.Drawing.Size(108, 23);
            this.buttonImportToTextFile.TabIndex = 11;
            this.buttonImportToTextFile.Text = "&Export Logs";
            this.buttonImportToTextFile.UseVisualStyleBackColor = true;
            this.buttonImportToTextFile.Click += new System.EventHandler(this.buttonImportToTextFile_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(22, 384);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(108, 23);
            this.buttonDisconnect.TabIndex = 10;
            this.buttonDisconnect.Text = "Disconnec&t";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonCheckConnection
            // 
            this.buttonCheckConnection.Location = new System.Drawing.Point(22, 355);
            this.buttonCheckConnection.Name = "buttonCheckConnection";
            this.buttonCheckConnection.Size = new System.Drawing.Size(108, 23);
            this.buttonCheckConnection.TabIndex = 9;
            this.buttonCheckConnection.Text = "Chec&k Connection";
            this.buttonCheckConnection.UseVisualStyleBackColor = true;
            this.buttonCheckConnection.Click += new System.EventHandler(this.buttonCheckConnection_Click);
            // 
            // buttonGetSN
            // 
            this.buttonGetSN.Location = new System.Drawing.Point(22, 326);
            this.buttonGetSN.Name = "buttonGetSN";
            this.buttonGetSN.Size = new System.Drawing.Size(108, 23);
            this.buttonGetSN.TabIndex = 8;
            this.buttonGetSN.Text = "Get &Serial #";
            this.buttonGetSN.UseVisualStyleBackColor = true;
            this.buttonGetSN.Click += new System.EventHandler(this.buttonGetSN_Click);
            // 
            // buttonEnrollOnline
            // 
            this.buttonEnrollOnline.Location = new System.Drawing.Point(22, 218);
            this.buttonEnrollOnline.Name = "buttonEnrollOnline";
            this.buttonEnrollOnline.Size = new System.Drawing.Size(108, 23);
            this.buttonEnrollOnline.TabIndex = 7;
            this.buttonEnrollOnline.Text = "&Online Enroll";
            this.buttonEnrollOnline.UseVisualStyleBackColor = true;
            this.buttonEnrollOnline.Click += new System.EventHandler(this.buttonEnrollOnline_Click);
            // 
            // buttonDeleteEnrollee
            // 
            this.buttonDeleteEnrollee.Location = new System.Drawing.Point(22, 276);
            this.buttonDeleteEnrollee.Name = "buttonDeleteEnrollee";
            this.buttonDeleteEnrollee.Size = new System.Drawing.Size(108, 23);
            this.buttonDeleteEnrollee.TabIndex = 6;
            this.buttonDeleteEnrollee.Text = "Delete E&nrollee";
            this.buttonDeleteEnrollee.UseVisualStyleBackColor = true;
            this.buttonDeleteEnrollee.Click += new System.EventHandler(this.buttonDeleteEnrollee_Click);
            // 
            // buttonGetEnrollees
            // 
            this.buttonGetEnrollees.Location = new System.Drawing.Point(22, 247);
            this.buttonGetEnrollees.Name = "buttonGetEnrollees";
            this.buttonGetEnrollees.Size = new System.Drawing.Size(108, 23);
            this.buttonGetEnrollees.TabIndex = 5;
            this.buttonGetEnrollees.Text = "Get &Enrollees";
            this.buttonGetEnrollees.UseVisualStyleBackColor = true;
            this.buttonGetEnrollees.Click += new System.EventHandler(this.buttonGetEnrollees_Click);
            // 
            // buttonGetRecords
            // 
            this.buttonGetRecords.Location = new System.Drawing.Point(22, 142);
            this.buttonGetRecords.Name = "buttonGetRecords";
            this.buttonGetRecords.Size = new System.Drawing.Size(108, 23);
            this.buttonGetRecords.TabIndex = 4;
            this.buttonGetRecords.Text = "&Get Records";
            this.buttonGetRecords.UseVisualStyleBackColor = true;
            this.buttonGetRecords.Click += new System.EventHandler(this.buttonGetRecords_Click);
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Location = new System.Drawing.Point(22, 113);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(108, 23);
            this.buttonClearLogs.TabIndex = 3;
            this.buttonClearLogs.Text = "&Clear Logs";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.buttonClearLogs_Click);
            // 
            // buttonDownLoadLogs
            // 
            this.buttonDownLoadLogs.Location = new System.Drawing.Point(22, 84);
            this.buttonDownLoadLogs.Name = "buttonDownLoadLogs";
            this.buttonDownLoadLogs.Size = new System.Drawing.Size(108, 23);
            this.buttonDownLoadLogs.TabIndex = 2;
            this.buttonDownLoadLogs.Text = "&Download Logs";
            this.buttonDownLoadLogs.UseVisualStyleBackColor = true;
            this.buttonDownLoadLogs.Click += new System.EventHandler(this.buttonDownLoadLogs_Click);
            // 
            // buttonPowerOff
            // 
            this.buttonPowerOff.Location = new System.Drawing.Point(22, 45);
            this.buttonPowerOff.Name = "buttonPowerOff";
            this.buttonPowerOff.Size = new System.Drawing.Size(108, 23);
            this.buttonPowerOff.TabIndex = 1;
            this.buttonPowerOff.Text = "&Power Off";
            this.buttonPowerOff.UseVisualStyleBackColor = true;
            this.buttonPowerOff.Click += new System.EventHandler(this.buttonPowerOff_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(22, 16);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(108, 23);
            this.buttonRestart.TabIndex = 0;
            this.buttonRestart.Text = "&Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelInfo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(151, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(638, 50);
            this.panel3.TabIndex = 3;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(6, 3);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(51, 42);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "...";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(151, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(638, 460);
            this.panel4.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(638, 460);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 572);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Device Administration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonPowerOff;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonClearLogs;
        private System.Windows.Forms.Button buttonDownLoadLogs;
        private System.Windows.Forms.Button buttonGetRecords;
        private System.Windows.Forms.Button buttonGetEnrollees;
        private System.Windows.Forms.Button buttonDeleteEnrollee;
        private System.Windows.Forms.Button buttonEnrollOnline;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonCheckConnection;
        private System.Windows.Forms.Button buttonGetSN;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button buttonImportToTextFile;
        private System.Windows.Forms.Button buttonSetTime;
        private System.Windows.Forms.Button button1;

    }
}

