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
    public partial class Student2 : Form
    {
        public Student2(String username)
        {
            InitializeComponent();
            comboData();
            comboDataIsbn();
            comboDataCategory();
            setUserName(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student S = new Student(getUserName());
            S.Show();
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

        private void Student2_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void isbnButton_Click(object sender, EventArgs e)
        {
            string a = isbncmb.Text;
            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1 WHERE ISBN='" + a + "'";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            DGV1.DataSource = source;
            con.DEActiveCon();
        }

        private void CatSerach_Click(object sender, EventArgs e)
        {

            string a = catcmb.Text;
            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1 WHERE Category='" + a + "'";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            DGV1.DataSource = source;
            con.DEActiveCon();
        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            string a = cmb1.Text;
            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1 WHERE Book_Title='" + a + "'";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            DGV1.DataSource = source;
            con.DEActiveCon();
        }
        public void comboData()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                String bookname = DR.GetString(1);
                cmb1.Items.Add(bookname);

            }
            while (DR.Read())
            {
                String isbn = DR.GetString(1);
                isbncmb.Items.Add(isbn);

            }
            con.DEActiveCon();
        }
        public void comboDataIsbn()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String isbn = DR.GetString(0);
                isbncmb.Items.Add(isbn);

            }
            con.DEActiveCon();
        }
        public void comboDataCategory()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String category = DR.GetString(2);
                catcmb.Items.Add(category);

            }
            con.DEActiveCon();
        }
        public void disp_data()
        {

            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select * from BorrowBook1 ", con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            DGV1.DataSource = source;
            con.DEActiveCon();

        }
        //------Set getters and Setters -------------------------
        private String username;
        public void setUserName(String uname)
        { username = uname; }
        public String getUserName()
        { return username; }

    }
}
