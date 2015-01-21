namespace AttendanceKeeper.Management
{
    partial class MachineInstanceForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label machineInstanceNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MachineInstanceForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.machineInstanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.machineInstanceNameTextBox = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            machineInstanceNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.machineInstanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // machineInstanceNameLabel
            // 
            machineInstanceNameLabel.AutoSize = true;
            machineInstanceNameLabel.Location = new System.Drawing.Point(19, 68);
            machineInstanceNameLabel.Name = "machineInstanceNameLabel";
            machineInstanceNameLabel.Size = new System.Drawing.Size(81, 13);
            machineInstanceNameLabel.TabIndex = 4;
            machineInstanceNameLabel.Text = "Set Log Name :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 45);
            this.panel1.TabIndex = 3;
            // 
            // machineInstanceBindingSource
            // 
            this.machineInstanceBindingSource.DataSource = typeof(AttendanceKeeper.Data.MachineInstance);
            // 
            // machineInstanceNameTextBox
            // 
            this.machineInstanceNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.machineInstanceBindingSource, "MachineInstanceName", true));
            this.machineInstanceNameTextBox.Location = new System.Drawing.Point(106, 66);
            this.machineInstanceNameTextBox.Name = "machineInstanceNameTextBox";
            this.machineInstanceNameTextBox.Size = new System.Drawing.Size(306, 20);
            this.machineInstanceNameTextBox.TabIndex = 5;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(337, 121);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "&Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(236, 121);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(95, 23);
            this.buttonOk.TabIndex = 7;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "...";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(298, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Attendance Keeper v1.0";
            // 
            // MachineInstanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 163);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(machineInstanceNameLabel);
            this.Controls.Add(this.machineInstanceNameTextBox);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MachineInstanceForm";
            this.Text = "Machine Instance Form";
            this.Load += new System.EventHandler(this.MachineInstanceForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.machineInstanceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource machineInstanceBindingSource;
        private System.Windows.Forms.TextBox machineInstanceNameTextBox;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}