﻿namespace ExportForPostech
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
            this.chkSever = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdRunAll = new System.Windows.Forms.Button();
            this.dtpEDate = new System.Windows.Forms.DateTimePicker();
            this.cmdRun = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cboProc = new System.Windows.Forms.ComboBox();
            this.cmd_ExportExcel = new System.Windows.Forms.Button();
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
            this.panel1.Controls.Add(this.cmd_ExportExcel);
            this.panel1.Controls.Add(this.chkSever);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmdRunAll);
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
            // chkSever
            // 
            this.chkSever.AutoSize = true;
            this.chkSever.Location = new System.Drawing.Point(403, 42);
            this.chkSever.Name = "chkSever";
            this.chkSever.Size = new System.Drawing.Size(87, 17);
            this.chkSever.TabIndex = 10;
            this.chkSever.Text = "Export Sever";
            this.chkSever.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "~";
            // 
            // cmdRunAll
            // 
            this.cmdRunAll.Location = new System.Drawing.Point(570, 9);
            this.cmdRunAll.Name = "cmdRunAll";
            this.cmdRunAll.Size = new System.Drawing.Size(75, 23);
            this.cmdRunAll.TabIndex = 8;
            this.cmdRunAll.Text = "Run All";
            this.cmdRunAll.UseVisualStyleBackColor = true;
            this.cmdRunAll.Click += new System.EventHandler(this.cmdRunAll_Click);
            // 
            // dtpEDate
            // 
            this.dtpEDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEDate.Location = new System.Drawing.Point(117, 37);
            this.dtpEDate.Name = "dtpEDate";
            this.dtpEDate.Size = new System.Drawing.Size(90, 20);
            this.dtpEDate.TabIndex = 7;
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(489, 8);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(75, 23);
            this.cmdRun.TabIndex = 6;
            this.cmdRun.Text = "Run 1 Proc";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.cmdRun_Click);
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
            // cmd_ExportExcel
            // 
            this.cmd_ExportExcel.Location = new System.Drawing.Point(489, 36);
            this.cmd_ExportExcel.Name = "cmd_ExportExcel";
            this.cmd_ExportExcel.Size = new System.Drawing.Size(109, 23);
            this.cmd_ExportExcel.TabIndex = 11;
            this.cmd_ExportExcel.Text = "Export Excel";
            this.cmd_ExportExcel.UseVisualStyleBackColor = true;
            this.cmd_ExportExcel.Click += new System.EventHandler(this.cmd_ExportExcel_Click);
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
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button cmdRunAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSever;
        private System.Windows.Forms.Button cmd_ExportExcel;
    }
}

