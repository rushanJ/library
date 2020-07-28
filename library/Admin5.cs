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
    public partial class Admin5 : Form
    {
        

        public Admin5()
        {
            InitializeComponent();
            comboDataUser();
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
            Admin2 A2 = new Admin2();
            A2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin3 A3 = new Admin3();
            A3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin4 A4 = new Admin4();
            A4.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin A = new Admin();
            A.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Admin6 A6 = new Admin6();
            A6.Show();
            this.Hide();
        }

        private void dGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void Admin5_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        public void disp_data()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM AUTH";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            dGV6.DataSource = source;
            con.DEActiveCon();
        }
        public void comboDataUser()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM AUTH";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String username = DR.GetString(0);
                UserNamecmb.Items.Add(username);

            }
            con.DEActiveCon();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();

            String insertQuery = "delete from AUTH where username='" + UserNamecmb.Text + "'";
            SqlCommand cmd = new SqlCommand(insertQuery, con.ActiveCon());
            cmd.ExecuteReader();
            disp_data();


            MessageBox.Show("recode deleted successfully");
            con.DEActiveCon();
        }
    }

}
