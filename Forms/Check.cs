using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherAttendance
{
    public partial class Check : Form
    {
        private int TeacherID;

        public Check()
        {
            InitializeComponent();
        }

        private void Check_Load(object sender, EventArgs e)
        {
            clsCon.cn.ConnectionString = "Data Source=BETELGEUSE\\ENTERPRISE; Database=CsaProject; UID=sa; PWD=123;";
            //clsCon.cn.ConnectionString = "Data Source=BETELGEUSE\\SQLEXPRESS;Initial Catalog=UniversityDB;Persist Security Info=True;User ID=sa;Password=12345678";

            try
            {
                clsCon.cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed! " + ex);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            codeTb.Text += 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            codeTb.Text += 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            codeTb.Text += 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            codeTb.Text += 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            codeTb.Text += 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            codeTb.Text += 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            codeTb.Text += 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            codeTb.Text += 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            codeTb.Text += 9;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            codeTb.Text += 0;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            codeTb.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (codeTb.Text == "") 
                return;

            int length = codeTb.Text.Length;
            codeTb.Text = codeTb.Text.Remove(length - 1);
        }

        private void codeTb_TextChanged(object sender, EventArgs e)
        {
            // Reset to initial
            isCheckedInLb.Visible = isCheckedInIcon.Visible = checkBtn.Enabled = welcomeLb.Visible = false;
            if (avatar.Image != null) 
                avatar.Image = null;

            if (codeTb.Text.Length < 3)
                return;

            var cmd = new SqlCommand("SELECT TeacherID, FirstName, LastName, Photo FROM Tbl_Teacher WHERE EmployeeCode = @EmployeeCode", clsCon.cn);
            cmd.Parameters.AddWithValue("@EmployeeCode", codeTb.Text);
            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            sd.Fill(dt);

            if (dt.Rows.Count == 0) // cannot find teacher
                return;

            // Change avatar to one from db
            TeacherID = (int)dt.Rows[0]["TeacherID"];
            string name = dt.Rows[0]["LastName"] + " " + dt.Rows[0]["FirstName"];
            if (!DBNull.Value.Equals(dt.Rows[0]["Photo"])) 
            {
                byte[] bytes = (byte[])dt.Rows[0]["Photo"];
                avatar.Image = Image.FromStream(new MemoryStream(bytes));
            }

            // Check if you checked in today
            cmd = new SqlCommand("SELECT AttendanceID FROM Tbl_TeacherAttendance WHERE TeacherID = @TeacherID AND CONVERT(DATE, AttendanceDate) = CONVERT(DATE, getdate())", clsCon.cn);
            cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
            sd = new SqlDataAdapter(cmd);
            dt.Clear();
            sd.Fill(dt);

            if (dt.Rows.Count == 0) // cannot find today's attendance
            {
                checkBtn.Enabled = true;
                welcomeLb.Text = "ស្វាគមន៍: " + name;
                welcomeLb.Visible = true;
            }
            else
            {
                isCheckedInLb.Visible = isCheckedInIcon.Visible = true;
            }
        }

        private void checkBtn_Click(object sender, EventArgs e)
        {
            var sql = "INSERT INTO Tbl_TeacherAttendance (AttendanceDate, StaffID, TeacherID, AttendanceTypeID, RoomID) " +
                      "VALUES (@AttendanceDate, @StaffID, @TeacherID, @AttendanceTypeID, @RoomID)";

            using (var cmd = new SqlCommand(sql, clsCon.cn))
            {
                cmd.Parameters.AddWithValue("@AttendanceDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@StaffID", 1); // admin id
                cmd.Parameters.AddWithValue("@TeacherID", TeacherID);
                cmd.Parameters.AddWithValue("@AttendanceTypeID", 1); // Present
                cmd.Parameters.AddWithValue("@RoomID", 1); // admin room

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully checked in!");
            }

            // Refresh
            codeTb_TextChanged(this, new EventArgs());
        }
    }
}
