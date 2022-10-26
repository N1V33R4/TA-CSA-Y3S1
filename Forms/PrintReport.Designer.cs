namespace TeacherAttendance
{
    partial class PrintReport
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
            this.monthCb = new System.Windows.Forms.ComboBox();
            this.yearTb = new System.Windows.Forms.TextBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.showReportBtn = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label9 = new System.Windows.Forms.Label();
            this.teachList = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCb
            // 
            this.monthCb.Font = new System.Drawing.Font("Chenla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCb.FormattingEnabled = true;
            this.monthCb.Items.AddRange(new object[] {
            "ទាំងអស់",
            "មករា",
            "កុម្ភៈ",
            "មិនា",
            "មេសា",
            "ឧសភា",
            "មិថុនា",
            "កក្កដា",
            "សីហា",
            "កញ្ញា",
            "តុលា",
            "វិច្ចិកា",
            "ធ្នូ"});
            this.monthCb.Location = new System.Drawing.Point(399, 87);
            this.monthCb.Name = "monthCb";
            this.monthCb.Size = new System.Drawing.Size(121, 44);
            this.monthCb.TabIndex = 1;
            // 
            // yearTb
            // 
            this.yearTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearTb.Location = new System.Drawing.Point(595, 91);
            this.yearTb.Name = "yearTb";
            this.yearTb.Size = new System.Drawing.Size(100, 34);
            this.yearTb.TabIndex = 2;
            this.yearTb.Text = "2022";
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(27, 93);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(56, 29);
            this.checkAll.TabIndex = 3;
            this.checkAll.Text = "All";
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // showReportBtn
            // 
            this.showReportBtn.Location = new System.Drawing.Point(725, 84);
            this.showReportBtn.Name = "showReportBtn";
            this.showReportBtn.Size = new System.Drawing.Size(147, 47);
            this.showReportBtn.TabIndex = 4;
            this.showReportBtn.Text = "Show Report";
            this.showReportBtn.UseVisualStyleBackColor = true;
            this.showReportBtn.Click += new System.EventHandler(this.showReportBtn_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TeacherAttendance.AttendanceReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(290, 152);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(911, 551);
            this.reportViewer1.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Khmer OS Muol Light", 20F);
            this.label9.Location = new System.Drawing.Point(383, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(422, 62);
            this.label9.TabIndex = 45;
            this.label9.Text = "បញ្ជីវត្តមានសាស្រ្តាចារ្យ";
            // 
            // teachList
            // 
            this.teachList.Font = new System.Drawing.Font("Chenla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teachList.FormattingEnabled = true;
            this.teachList.Location = new System.Drawing.Point(27, 128);
            this.teachList.Name = "teachList";
            this.teachList.Size = new System.Drawing.Size(236, 394);
            this.teachList.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Chenla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(292, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 36);
            this.label2.TabIndex = 47;
            this.label2.Text = "សម្រាប់ខែ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Chenla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(547, 93);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 36);
            this.label1.TabIndex = 48;
            this.label1.Text = "ឆ្នាំ:";
            // 
            // PrintReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.teachList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.showReportBtn);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.yearTb);
            this.Controls.Add(this.monthCb);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PrintReport";
            this.Text = "PrintReport";
            this.Load += new System.EventHandler(this.PrintReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox monthCb;
        private System.Windows.Forms.TextBox yearTb;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.Button showReportBtn;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox teachList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}