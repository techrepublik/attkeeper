namespace AttendanceKeeper.Management
{
    partial class DTROverUnderTimeForm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.JDTRClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.toolStripComboBoxYear = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripComboBoxMonth = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonPrint = new System.Windows.Forms.ToolStripButton();
            this.jDTRClassBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.JDTRClassBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDTRClassBindingNavigator)).BeginInit();
            this.jDTRClassBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // JDTRClassBindingSource
            // 
            this.JDTRClassBindingSource.DataSource = typeof(AttendanceKeeper.Classes.JDTRClass);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.labelCompanyName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(799, 45);
            this.panel1.TabIndex = 3;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "AttendanceKeeper_Classes_JDTRClass";
            reportDataSource1.Value = this.JDTRClassBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AttendanceKeeper.Reports.ReportOverUnder.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 82);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(774, 303);
            this.reportViewer1.TabIndex = 5;
            // 
            // toolStripComboBoxYear
            // 
            this.toolStripComboBoxYear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxYear.Name = "toolStripComboBoxYear";
            this.toolStripComboBoxYear.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripComboBoxMonth
            // 
            this.toolStripComboBoxMonth.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripComboBoxMonth.Name = "toolStripComboBoxMonth";
            this.toolStripComboBoxMonth.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButtonPrint
            // 
            this.toolStripButtonPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonPrint.Image = global::AttendanceKeeper.Properties.Resources.Print;
            this.toolStripButtonPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPrint.Name = "toolStripButtonPrint";
            this.toolStripButtonPrint.Size = new System.Drawing.Size(96, 22);
            this.toolStripButtonPrint.Text = "&Print Preview";
            this.toolStripButtonPrint.Click += new System.EventHandler(this.toolStripButtonPrint_Click);
            // 
            // jDTRClassBindingNavigator
            // 
            this.jDTRClassBindingNavigator.AddNewItem = null;
            this.jDTRClassBindingNavigator.CountItem = null;
            this.jDTRClassBindingNavigator.DeleteItem = null;
            this.jDTRClassBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonPrint,
            this.toolStripComboBoxYear,
            this.toolStripComboBoxMonth});
            this.jDTRClassBindingNavigator.Location = new System.Drawing.Point(0, 45);
            this.jDTRClassBindingNavigator.MoveFirstItem = null;
            this.jDTRClassBindingNavigator.MoveLastItem = null;
            this.jDTRClassBindingNavigator.MoveNextItem = null;
            this.jDTRClassBindingNavigator.MovePreviousItem = null;
            this.jDTRClassBindingNavigator.Name = "jDTRClassBindingNavigator";
            this.jDTRClassBindingNavigator.PositionItem = null;
            this.jDTRClassBindingNavigator.Size = new System.Drawing.Size(799, 25);
            this.jDTRClassBindingNavigator.TabIndex = 4;
            this.jDTRClassBindingNavigator.Text = "bindingNavigator1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(673, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Attendance Keeper v1.0";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompanyName.ForeColor = System.Drawing.Color.White;
            this.labelCompanyName.Location = new System.Drawing.Point(3, 2);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(575, 24);
            this.labelCompanyName.TabIndex = 5;
            this.labelCompanyName.Text = "COMPANY NAME";
            // 
            // DTROverUnderTimeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 397);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.jDTRClassBindingNavigator);
            this.Controls.Add(this.panel1);
            this.Name = "DTROverUnderTimeForm";
            this.Text = "DTR Over/UnderTime Form";
            this.Load += new System.EventHandler(this.DTROverUnderTimeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.JDTRClassBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDTRClassBindingNavigator)).EndInit();
            this.jDTRClassBindingNavigator.ResumeLayout(false);
            this.jDTRClassBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxYear;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxMonth;
        private System.Windows.Forms.ToolStripButton toolStripButtonPrint;
        private System.Windows.Forms.BindingNavigator jDTRClassBindingNavigator;
        private System.Windows.Forms.BindingSource JDTRClassBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCompanyName;
    }
}