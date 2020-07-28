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
    public partial class Admin3 : Form
    {

        

        public Admin3()
        {
            InitializeComponent();
            comboDataCategory();
            comboDataIsbn();
            comboTitle();
            comboAuthor();
            Statuscmb.Items.Add("Available");
            Statuscmb.Items.Add("Not Available");
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

        private void button4_Click(object sender, EventArgs e)
        {
            Admin4 A4 = new Admin4();
            A4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin5 A5 = new Admin5();
            A5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin A = new Admin();
            A.Show();
            this.Hide();
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            
            String insertQuery = "delete from Book1 where Book_Title='" + cmb1.Text + "'";
           SqlCommand cmd = new SqlCommand(insertQuery, con.ActiveCon());
            cmd.ExecuteReader();
            disp_data();
       

            MessageBox.Show("recode deleted successfully");

        }

        private void dGV5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            Connection con = new Connection();
            String insertQuery = "INSERT into Book1 (ISBN,Book_Title,Category,Author,Status,Quantity) " +
                                 " VALUES ('" + isbncmb.Text + "','" + cmb1.Text + "', '" + catcmb.Text + "', '" + authcmb.Text + "', '" + Statuscmb.Text + "','" + qutxt.Text + "');";
            SqlCommand cmd = new SqlCommand(insertQuery, con.ActiveCon());
            cmd.ExecuteReader();
            disp_data();
            MessageBox.Show("Record inserted successfully");

        }
        public void disp_data()
        {

            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select * from Book1 ", con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            dGV5.DataSource = source;
            con.DEActiveCon();

        }

        private void Admin3_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update u = new Update();
            u.Show();
            this.Hide();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmb1.Text != "")
            {
                Connection con = new Connection();
                string SelectQuery = "SELECT *FROM Book1 WHERE Book_Title='" + cmb1.Text + "'";
                SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
                SqlDataReader DR = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = DR;
                dGV5.DataSource = source;
            }
            else
            {
                MessageBox.Show("You must Fill Book_Title ");
            }
            //------------------------------------------------
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin6 A6 = new Admin6();
            A6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            disp_data();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Update Up = new library.Update();
            Up.Show();
        }
    //-----------------------Combox data Add------------------------------------------

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
        public void comboTitle()
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

        }
        public void comboAuthor()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                String Author = DR.GetString(3);
                authcmb.Items.Add(Author);

            }

        }

        private void dGV5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dGV5.Rows[e.RowIndex];

                isbncmb.Text = row.Cells["ISBN"].Value.ToString();
                cmb1.Text = row.Cells["Book_Title"].Value.ToString();
                catcmb.Text = row.Cells["Category"].Value.ToString();
                authcmb.Text = row.Cells["Author"].Value.ToString();
                Statuscmb.Text = row.Cells["Status"].Value.ToString();
                qutxt.Text = row.Cells["Quantity"].Value.ToString();
            }
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
