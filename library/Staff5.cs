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
    public partial class Staff5 : Form
    {
        public Staff5(String username)
        {
            InitializeComponent();
            usertxt.Text = username;
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

        private void button4_Click(object sender, EventArgs e)
        {
            Staff4 St4 = new Staff4(getUserName());
            St4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Staff5 St5 = new Staff5(getUserName());
            St5.Show();
            this.Hide();
            SetValue();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Staff St = new Staff("");
            St.Show();
            this.Hide();
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
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM AUTH  WHERE username='" + getUserName() + "'", con.ActiveCon());

            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                deparmenttxt.Text = dt.Rows[0]["Department"].ToString();
                Emailtxt.Text = dt.Rows[0]["E_mail"].ToString();
                mobiletxt.Text = dt.Rows[0]["mobile"].ToString();
                nictxt.Text = dt.Rows[0]["NIC"].ToString();
                indextxt.Text = dt.Rows[0]["Index_No"].ToString();
                addresstxt.Text = dt.Rows[0]["Address"].ToString();
            }

            con.DEActiveCon();
        }
    //---------------------------------------------------------------------------------------------
        private void Staff5_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT *FROM AUTH  WHERE username='" + getUserName() + "'", con.ActiveCon());

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                deparmenttxt.Text = dt.Rows[0]["Department"].ToString();
                Emailtxt.Text = dt.Rows[0]["E_mail"].ToString();
                mobiletxt.Text = dt.Rows[0]["mobile"].ToString();
                nictxt.Text = dt.Rows[0]["NIC"].ToString();
                indextxt.Text = dt.Rows[0]["Index_No"].ToString();
                addresstxt.Text = dt.Rows[0]["Address"].ToString();
            }

            con.DEActiveCon();

        }
    
    }
}
