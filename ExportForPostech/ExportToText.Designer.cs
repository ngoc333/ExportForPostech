namespace ExportForPostech
{
    partial class ExportToText
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboProc = new System.Windows.Forms.ComboBox();
            this.cmdRun = new System.Windows.Forms.Button();
            this.dtpEDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.75342F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.24657F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 438);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 71);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(648, 364);
            this.txtLog.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpEDate);
            this.panel1.Controls.Add(this.cmdRun);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.cboType);
            this.panel1.Controls.Add(this.cboProc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 62);
            this.panel1.TabIndex = 2;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(9, 36);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(90, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(396, 9);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(87, 21);
            this.cboType.TabIndex = 1;
            // 
            // cboProc
            // 
            this.cboProc.FormattingEnabled = true;
            this.cboProc.Location = new System.Drawing.Point(9, 9);
            this.cboProc.Name = "cboProc";
            this.cboProc.Size = new System.Drawing.Size(381, 21);
            this.cboProc.TabIndex = 0;
            this.cboProc.SelectionChangeCommitted += new System.EventHandler(this.cboProc_SelectionChangeCommitted);
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(532, 9);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 6;
            this.cmdRun.Text = "button1";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
            // 
            // dtpEDate
            // 
            this.dtpEDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEDate.Location = new System.Drawing.Point(119, 36);
            this.dtpEDate.Name = "dtpEDate";
            this.dtpEDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEDate.TabIndex = 7;
            // 
            // ExportToText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 438);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExportToText";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExportToText_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.ComboBox cboProc;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.DateTimePicker dtpEDate;
    }
}

