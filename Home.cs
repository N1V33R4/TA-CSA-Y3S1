using Lecturer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherAttendance
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void ករមទនញToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void បងកតToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            clsCon.cn.ConnectionString = "Data Source=BETELGEUSE\\ENTERPRISE; Database=CsaProject; UID=sa; PWD=123;";
            try
            {
                clsCon.cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed! " + ex);
            }
        }

        private void គរបគរងគរToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckActiveMDI();

            var frm = new Teacher();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            this.WindowState = frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void ចកចញToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void បដរអនកបរបរសToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CheckActiveMDI()
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void វតតមនគរToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckActiveMDI();


        }
    }
}
