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
            this.teachCheckBox = new System.Windows.Forms.CheckedListBox();
            this.monthCb = new System.Windows.Forms.ComboBox();
            this.yearTb = new System.Windows.Forms.TextBox();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // teachCheckBox
            // 
            this.teachCheckBox.FormattingEnabled = true;
            this.teachCheckBox.Location = new System.Drawing.Point(76, 88);
            this.teachCheckBox.Name = "teachCheckBox";
            this.teachCheckBox.Size = new System.Drawing.Size(244, 354);
            this.teachCheckBox.TabIndex = 0;
            // 
            // monthCb
            // 
            this.monthCb.FormattingEnabled = true;
            this.monthCb.Items.AddRange(new object[] {
            "All",
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.monthCb.Location = new System.Drawing.Point(424, 53);
            this.monthCb.Name = "monthCb";
            this.monthCb.Size = new System.Drawing.Size(121, 33);
            this.monthCb.TabIndex = 1;
            // 
            // yearTb
            // 
            this.yearTb.Location = new System.Drawing.Point(636, 53);
            this.yearTb.Name = "yearTb";
            this.yearTb.Size = new System.Drawing.Size(100, 30);
            this.yearTb.TabIndex = 2;
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Location = new System.Drawing.Point(76, 53);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(56, 29);
            this.checkAll.TabIndex = 3;
            this.checkAll.Text = "All";
            this.checkAll.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(768, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 47);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show Report";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PrintReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.yearTb);
            this.Controls.Add(this.monthCb);
            this.Controls.Add(this.teachCheckBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PrintReport";
            this.Text = "PrintReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox teachCheckBox;
        private System.Windows.Forms.ComboBox monthCb;
        private System.Windows.Forms.TextBox yearTb;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.Button button1;
    }
}