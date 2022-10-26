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
using TeacherAttendance;

namespace Lecturer
{
    public partial class Teacher : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=BETELGEUSE\\SQLEXPRESS;Initial Catalog=UniversityDB;Persist Security Info=True;User ID=sa;Password=12345678");
        OpenFileDialog opnfd;

        public Teacher()
        {
            InitializeComponent();
        }

        void BindData()
        {   
            var cmd = new SqlCommand("SELECT * FROM Tbl_Teacher", clsCon.cn);
            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            sd.Fill(dt);
            view.DataSource = dt;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            var sql = "INSERT INTO Tbl_Teacher(FirstName, LastName, Sex, DOB, Address, Phone, Email, Photo, EmployeeCode) " +
                      "VALUES(@FirstName, @LastName, @Sex, @DOB, @Address, @Phone, @Email, @Photo, @EmployeeCode)";

            using(SqlCommand cmd = new SqlCommand(sql, clsCon.cn))
            {
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstnameTb.Text;
                cmd.Parameters.AddWithValue("@LastName", lastnameTb.Text);
                cmd.Parameters.AddWithValue("@Sex", sexSelect.Text);
                cmd.Parameters.AddWithValue("@DOB", dobDtp.Value);
                cmd.Parameters.AddWithValue("@Address", addressTb.Text);
                cmd.Parameters.AddWithValue("@Phone", phoneTb.Text);
                cmd.Parameters.AddWithValue("@Email", emailTb.Text);
                cmd.Parameters.AddWithValue("@EmployeeCode", empCodeTb.Text);

                if (imagePreview.Image == null)
                    cmd.Parameters.AddWithValue("@Photo", System.Data.SqlTypes.SqlBinary.Null);
                else
                {
                    ImageConverter converter = new ImageConverter();
                    var bytes = (byte[])converter.ConvertTo(imagePreview.Image, typeof(byte[]));
                    cmd.Parameters.AddWithValue("@Photo", bytes);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully inserted!", "Success");
            }
            BindData();
        }

        private void photoBtn_Click(object sender, EventArgs e)
        {
            opnfd = new OpenFileDialog
            {
                Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif"
            };
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                imagePreview.Image = new Bitmap(opnfd.FileName);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var sql = "UPDATE Tbl_Teacher SET FirstName = @FirstName, LastName = @LastName, Sex = @Sex, " +
                      "DOB = @DOB, Address = @Address, Phone = @Phone, Email = @Email, Photo = @Photo, " +
                      "EmployeeCode = @EmployeeCode " +
                      "WHERE TeacherID = @ID;";

            using (SqlCommand cmd = new SqlCommand(sql, clsCon.cn))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstnameTb.Text);
                cmd.Parameters.AddWithValue("@LastName", lastnameTb.Text);
                cmd.Parameters.AddWithValue("@Sex", sexSelect.Text);
                cmd.Parameters.AddWithValue("@DOB", dobDtp.Value);
                cmd.Parameters.AddWithValue("@Address", addressTb.Text);
                cmd.Parameters.AddWithValue("@Phone", phoneTb.Text);
                cmd.Parameters.AddWithValue("@Email", emailTb.Text);
                cmd.Parameters.AddWithValue("@EmployeeCode", empCodeTb.Text);

                if (imagePreview.Image == null)
                    cmd.Parameters.AddWithValue("@Photo", System.Data.SqlTypes.SqlBinary.Null);
                else
                {
                    ImageConverter converter = new ImageConverter();
                    var bytes = (byte[])converter.ConvertTo(imagePreview.Image, typeof(byte[]));
                    cmd.Parameters.AddWithValue("@Photo", bytes);
                }

                cmd.Parameters.AddWithValue("@ID", int.Parse(idTb.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully updated!", "Success");
            }
            BindData();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (idTb.Text != "")
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    var sql = "DELETE Tbl_Teacher WHERE TeacherID = @ID;";

                    using (SqlCommand cmd = new SqlCommand(sql, clsCon.cn))
                    {
                        cmd.Parameters.AddWithValue("@ID", int.Parse(idTb.Text));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successfully deleted!", "Success");
                    }
                    BindData();
                }
            }
            else
            {
                MessageBox.Show("Please choose an ID to delete!", "No Lecturer ID", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /*
        private void searchIdBtn_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand("SELECT * FROM Tbl_Teacher WHERE TeacherID = @ID", clsCon.cn);
            cmd.Parameters.AddWithValue("@ID", int.Parse(idTb.Text));

            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            sd.Fill(dt);
            view.DataSource = dt;
        }
        */
        private void searchIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cmd = new SqlCommand("SELECT * FROM Tbl_Teacher WHERE TeacherID = @ID", clsCon.cn);
            cmd.Parameters.AddWithValue("@ID", int.Parse(idTb.Text));

            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            sd.Fill(dt);
            view.DataSource = dt;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.view.Rows[e.RowIndex];
                idTb.Text = row.Cells["TeacherID"].Value.ToString();
                lastnameTb.Text = row.Cells["LastName"].Value.ToString();
                firstnameTb.Text = row.Cells["FirstName"].Value.ToString();
                sexSelect.Text = row.Cells["Sex"].Value.ToString();

                if (row.Cells["DOB"].Value.ToString() != "")
                    dobDtp.Value = DateTime.Parse(row.Cells["DOB"].Value.ToString());
                else
                    dobDtp.Value = DateTime.Today;

                addressTb.Text = row.Cells["Address"].Value.ToString();
                phoneTb.Text = row.Cells["Phone"].Value.ToString();
                emailTb.Text = row.Cells["Email"].Value.ToString();
                empCodeTb.Text = row.Cells["EmployeeCode"].Value.ToString();

                if (!DBNull.Value.Equals(row.Cells["Photo"].Value))
                {
                    byte[] bytes = (byte[])row.Cells["Photo"].Value;
                    imagePreview.Image = Image.FromStream(new MemoryStream(bytes));
                }
                else
                    imagePreview.Image = null;
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to clear all textboxes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                idTb.Text = "";
                lastnameTb.Text = "";
                firstnameTb.Text = "";
                sexSelect.Text = "";
                dobDtp.Value = DateTime.Today;
                addressTb.Text = "";
                phoneTb.Text = "";
                emailTb.Text = "";
                empCodeTb.Text = "";

                imagePreview.Image = null;
                opnfd = null;
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            var cmd = new SqlCommand("SELECT * FROM Tbl_Teacher " +
                                     "WHERE FirstName LIKE Concat('%',@Query,'%') OR LastName LIKE Concat('%',@Query,'%')", clsCon.cn);
            cmd.Parameters.AddWithValue("@Query", searchTb.Text);
            var sd = new SqlDataAdapter(cmd);
            var dt = new DataTable();

            sd.Fill(dt);
            view.DataSource = dt;
        }
    }
}
