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
    public partial class Student5 : Form
    {
        public Student5(String username)
        {
            InitializeComponent();
            usertxt.Text = username;
            setUserName(username);
        }

        private void Student5_Load(object sender, EventArgs e)
        {
            SetValue();

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

        private void button4_Click(object sender, EventArgs e)
        {
            Student4 S4 = new Student4(getUserName());
            S4.Show();
            this.Hide();
        }

        private void round_button1_Click(object sender, EventArgs e)
        {
            Login F = new Login();
            F.Show();
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
        //-----------set getters and setters------------------------------------------
        private String username;
        public void setUserName(String uname)
        { username = uname; }
        public String getUserName()
        { return username; }
        //-----------------Method to setValues from DataBase---------------------------
        public void SetValue()
        {


            Connection con = new Connection();
            String selectQuery = "SELECT Department ,E_mail,mobile,NIC,Index_No,Address FROM AUTH  WHERE username='" + getUserName() + "'";
            SqlCommand cmd = new SqlCommand(selectQuery, con.ActiveCon());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                deparmenttxt.Text = dr.GetValue(0).ToString();
                Emailtxt.Text = dr.GetValue(1).ToString();
                mobiletxt.Text = dr.GetValue(2).ToString();
                nictxt.Text = dr.GetValue(3).ToString(); ;
                indextxt.Text = dr.GetValue(4).ToString();
                addresstxt.Text = dr.GetValue(5).ToString();
            }

            con.DEActiveCon();
        }
        //------------
    }
}
