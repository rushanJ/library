using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace library
{
    public partial class Student : Form
    {
        public Student(String username)
        {
            InitializeComponent();
            nametxt.Text = username;
            setUserName(username);
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void normal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void round_button1_Click(object sender, EventArgs e)
        {
            Login F = new Login();
            F.Show();
            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student2 S2 = new Student2(getUserName());
            S2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student3 S3 = new Student3(getUserName());
            S3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student4 S4 = new Student4(getUserName());
            S4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student5 S5 = new Student5(getUserName());
            S5.Show();
            this.Hide();
        }
        //------------Data DisPlay Method---------------------
        public void DisPlayData()
        {
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select * from BorrowBook1 where UserName='" + getUserName() + "'", con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            DGV1.DataSource = source;


        }
        //------Set getters and Setters -------------------------
        private String username;
        public void setUserName(String uname)
        { username = uname; }
        public String getUserName()
        { return username; }

        private void Student_Load(object sender, EventArgs e)
        {
            DisPlayData();
        }
    }
}
