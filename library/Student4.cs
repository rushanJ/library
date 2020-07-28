using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    public partial class Student4 : Form
    {
        public Student4(String username)
        {
            InitializeComponent();
            setUserName(username);
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            Student S = new Student(getUserName());
            S.Show();
            this.Hide();
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

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void normal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void round_button1_Click(object sender, EventArgs e)
        {
            Login F = new Login();
            F.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student5 S5 = new Student5(getUserName());
            S5.Show();
            this.Hide();
        }
        //------Set getters and Setters -------------------------
        private String username;
        public void setUserName(String uname)
        { username = uname; }
        public String getUserName()
        { return username; }
    }
}
