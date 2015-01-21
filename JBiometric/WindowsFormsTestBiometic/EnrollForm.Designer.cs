namespace WindowsFormsTestBiometic
{
    partial class EnrollForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.textBoxFingerPrintIndex = new System.Windows.Forms.TextBox();
            this.buttonStartEnroll = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fingerprint Index:";
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(120, 23);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(154, 20);
            this.textBoxUserId.TabIndex = 2;
            // 
            // textBoxFingerPrintIndex
            // 
            this.textBoxFingerPrintIndex.Location = new System.Drawing.Point(120, 49);
            this.textBoxFingerPrintIndex.Name = "textBoxFingerPrintIndex";
            this.textBoxFingerPrintIndex.Size = new System.Drawing.Size(154, 20);
            this.textBoxFingerPrintIndex.TabIndex = 3;
            // 
            // buttonStartEnroll
            // 
            this.buttonStartEnroll.Location = new System.Drawing.Point(67, 75);
            this.buttonStartEnroll.Name = "buttonStartEnroll";
            this.buttonStartEnroll.Size = new System.Drawing.Size(126, 23);
            this.buttonStartEnroll.TabIndex = 4;
            this.buttonStartEnroll.Text = "&Start Enroll";
            this.buttonStartEnroll.UseVisualStyleBackColor = true;
            this.buttonStartEnroll.Click += new System.EventHandler(this.buttonStartEnroll_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(199, 75);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "&Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // EnrollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 113);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonStartEnroll);
            this.Controls.Add(this.textBoxFingerPrintIndex);
            this.Controls.Add(this.textBoxUserId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EnrollForm";
            this.Text = "Enroll Form";
            this.Load += new System.EventHandler(this.EnrollForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.TextBox textBoxFingerPrintIndex;
        private System.Windows.Forms.Button buttonStartEnroll;
        private System.Windows.Forms.Button buttonOk;
    }
}