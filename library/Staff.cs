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
    public partial class Staff : Form
    {
        public Staff(String username)
        {
            InitializeComponent();
            nametxt.Text = username;
            setUserName(username);          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();

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

        private void round_button1_Click(object sender, EventArgs e)
        {
            Login F = new Login();
            F.Show();
            this.Hide();
        }

        private void Staff_Load(object sender, EventArgs e)
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT COUNT( [ISBN]) FROM  BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                int count = DR.GetInt32(0);
                if (count != 0)
                    DisPlayData();
            }
            con.DEActiveCon();

            //DisPlayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff2 St2 = new Staff2(getUserName());
            St2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Staff3 St3 = new Staff3(getUserName());
            St3.Show();
            this.Hide();
        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            String A = nametxt.Text;
            Staff5 St5 = new Staff5(A);
            St5.Show();
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
            DGAV1.DataSource = source;


        }
        //------Set getters and Setters -------------------------
        private String username;
        public void setUserName(String uname)
        { username = uname; }
        public String getUserName()
        { return username;}

    }
}
