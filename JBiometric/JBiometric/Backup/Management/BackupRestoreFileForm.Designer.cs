namespace AttendanceKeeper.Management
{
    partial class BackupRestoreFileForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonBack = new System.Windows.Forms.RadioButton();
            this.radioButtonRestore = new System.Windows.Forms.RadioButton();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.labelCompanyName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 45);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(428, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Attendance Keeper v1.0";
            // 
            // radioButtonBack
            // 
            this.radioButtonBack.AutoSize = true;
            this.radioButtonBack.Location = new System.Drawing.Point(78, 70);
            this.radioButtonBack.Name = "radioButtonBack";
            this.radioButtonBack.Size = new System.Drawing.Size(111, 17);
            this.radioButtonBack.TabIndex = 2;
            this.radioButtonBack.TabStop = true;
            this.radioButtonBack.Text = "&Backup Database";
            this.radioButtonBack.UseVisualStyleBackColor = true;
            // 
            // radioButtonRestore
            // 
            this.radioButtonRestore.AutoSize = true;
            this.radioButtonRestore.Location = new System.Drawing.Point(230, 71);
            this.radioButtonRestore.Name = "radioButtonRestore";
            this.radioButtonRestore.Size = new System.Drawing.Size(111, 17);
            this.radioButtonRestore.TabIndex = 5;
            this.radioButtonRestore.TabStop = true;
            this.radioButtonRestore.Text = "&Restore Database";
            this.radioButtonRestore.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(9, 131);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(530, 14);
            this.labelStatus.TabIndex = 6;
            this.labelStatus.Text = "...";
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(342, 152);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(119, 23);
            this.buttonExecute.TabIndex = 7;
            this.buttonExecute.Text = "&Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(467, 152);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Location:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 98);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(384, 20);
            this.textBox2.TabIndex = 13;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyName.ForeColor = System.Drawing.Color.White;
            this.labelCompanyName.Location = new System.Drawing.Point(3, 2);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(419, 24);
            this.labelCompanyName.TabIndex = 5;
            this.labelCompanyName.Text = "COMPANY NAME";
            // 
            // BackupRestoreFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 197);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.radioButtonRestore);
            this.Controls.Add(this.radioButtonBack);
            this.Controls.Add(this.panel1);
            this.Name = "BackupRestoreFileForm";
            this.Text = "Backup Restore File Form";
            this.Load += new System.EventHandler(this.BackupRestoreFileForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonBack;
        private System.Windows.Forms.RadioButton radioButtonRestore;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelCompanyName;

    }
}