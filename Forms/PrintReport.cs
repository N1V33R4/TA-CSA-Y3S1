using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherAttendance
{
    public partial class PrintReport : Form
    {
        string query = @"select TeacherID, FullName, [1] as Present, [2] as Absent, [3] as [Permission Leave]
                        from
                        (
                          select Tbl_TeacherAttendance.TeacherID, LastName + ' ' + FirstName as FullName, AttendanceTypeID
                          from Tbl_TeacherAttendance INNER JOIN
                               Tbl_Teacher ON Tbl_TeacherAttendance.TeacherID = Tbl_Teacher.TeacherID

                          where month(AttendanceDate) = @Month and year(AttendanceDate) = @Year
                                and Tbl_TeacherAttendance.TeacherID in (SELECT [value] FROM STRING_SPLIT(@TeacherIDs, ','))
                        ) src
                        pivot
                        (
                          count(AttendanceTypeID)
                          for AttendanceTypeID in ([1], [2], [3])
                        ) piv
                        order by TeacherID";
        string query_wout_month = @"select TeacherID, FullName, [1] as Present, [2] as Absent, [3] as [Permission Leave]
                        from
                        (
                          select Tbl_TeacherAttendance.TeacherID, LastName + ' ' + FirstName as FullName, AttendanceTypeID
                          from Tbl_TeacherAttendance INNER JOIN
                               Tbl_Teacher ON Tbl_TeacherAttendance.TeacherID = Tbl_Teacher.TeacherID

                          where year(AttendanceDate) = @Year and Tbl_TeacherAttendance.TeacherID in (SELECT [value] FROM STRING_SPLIT(@TeacherIDs, ','))
                        ) src
                        pivot
                        (
                          count(AttendanceTypeID)
                          for AttendanceTypeID in ([1], [2], [3])
                        ) piv
                        order by TeacherID";
        public PrintReport()
        {
            InitializeComponent();
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {
            FillCheckListBox();
            monthCb.SelectedIndex = 0;
            showReportBtn_Click(this, new EventArgs());
        }

        private void FillCheckListBox()
        {
            var cmd = new SqlCommand("SELECT TeacherID, LastName + ' ' + FirstName as FullName FROM Tbl_Teacher", clsCon.cn);
            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            teachList.DataSource = dt;
            teachList.DisplayMember = "FullName";
            teachList.ValueMember = "TeacherID";

            checkAll.Checked = true;
            checkAll_CheckedChanged(this, new EventArgs());
        }

        private void showReportBtn_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand("", clsCon.cn);
            if (monthCb.SelectedIndex == 0)
                cmd.CommandText = query_wout_month;
            else
            {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@Month", monthCb.SelectedIndex.ToString());
            }

            cmd.Parameters.AddWithValue("@Year", yearTb.Text);

            if (!AddIDs(cmd))
                return;

            var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            try
            {
            }
            catch
            {
                MessageBox.Show("Please make sure you entered year correctly!", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ReportParameter[] para = new ReportParameter[]
            {
                new ReportParameter("CreatedDate", DateTime.Now.ToString("dd/MM/yyyy h:mm:ss tt")),
                new ReportParameter("Month", monthCb.SelectedItem.ToString()),
                new ReportParameter("Year", yearTb.Text)
            };
            ReportDataSource ds = new ReportDataSource("TeacherAttendance", dt);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }

        private bool AddIDs(SqlCommand cmd)
        {
            // Prevent user not selecting any one teacher
            try
            {
                string ids = "";
                foreach (var item in teachList.CheckedItems)
                {
                    DataRowView castedItem = item as DataRowView;
                    ids += castedItem["TeacherID"] + ", ";
                }
                ids = ids.Remove(ids.Length - 2);
                cmd.Parameters.AddWithValue("@TeacherIDs", ids);
                return true;
            }
            catch
            {
                MessageBox.Show("Please select at least one teacher!", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void checkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAll.Checked)
            {
                for (int i = 0; i < teachList.Items.Count; i++)
                    teachList.SetItemChecked(i, true);
            }
            else
            {
                for (int i = 0; i < teachList.Items.Count; i++)
                    teachList.SetItemChecked(i, false);
            }
        }
    }
}
