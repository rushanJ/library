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
using System.Net;
using System.Net.Mail;

namespace library
{
    public partial class Admin4 : Form
    {
        public Admin4()
        {
            InitializeComponent();
            comboDataIsbn();
            comboDataCategory();
            userName();
            comboTitle();
            userEmail();
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

        private void button8_Click(object sender, EventArgs e)
        {
            Admin6 A6 = new Admin6();
            A6.Show();
            this.Hide();
        }
        //-----------------------------------combobox------------------------------
        
        public void userName()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                String username = DR.GetString(0);
              UserNamecmb.Items.Add(username);

            }

        }
        public void comboDataIsbn()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String isbn = DR.GetString(1);
                isbncmb.Items.Add(isbn);

            }
            con.DEActiveCon();
        }
        public void comboTitle()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM  BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                String bookname = DR.GetString(2);
                bookcmb.Items.Add(bookname);

            }

        }
        public void comboDataCategory()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String category = DR.GetString(3);
                catcmb.Items.Add(category);

            }
            con.DEActiveCon();
        }
        public void userEmail()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM AUTH";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String category = DR.GetString(3);
                usercmb.Items.Add(category);

            }
            con.DEActiveCon();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            checkQuantity();
            MessageBox.Show("UserNamecmb.Text");

            if (UserNamecmb.Text != "" && isbncmb.Text != "" && bookcmb.Text != "" && catcmb.Text != "")
            {
              DateTime timeStamp = DateTime.Now;
                Connection con = new Connection();
                var insertQuery = "INSERT into BorrowBook1 (UserName,ISBN,Book_Title,Category,Time,Status) " +
                       " VALUES ('" + UserNamecmb.Text + "','" + isbncmb.Text + "', '" + bookcmb.Text + "', '" + catcmb.Text + "', '" + timeStamp.ToString() + "','Not Returned');";
                SqlCommand cmd = new SqlCommand(insertQuery, con.ActiveCon());
                cmd.ExecuteReader();
                disp_data();
               // MessageBox.Show("Data insert Successfully");
            }
            else
            {
                MessageBox.Show("Please fill all fields correctly");
            }
        }

        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGV1.Rows[e.RowIndex];
                UserNamecmb.Text = row.Cells["UserName"].Value.ToString();
                isbncmb.Text = row.Cells["ISBN"].Value.ToString();
                bookcmb.Text = row.Cells["Book_Title"].Value.ToString();
                catcmb.Text = row.Cells["Category"].Value.ToString();
            }

        }
        public void disp_data()
        {

            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select * from  BorrowBook1 ", con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            DGV1.DataSource = source;
            con.DEActiveCon();

        }

        private void Admin4_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            string SelectQuery = "SELECT COUNT( [ISBN]) FROM  BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                int count = DR.GetInt32(0);
                if (count != 0)
                    disp_data();
            }
            con.DEActiveCon();

           // disp_data();
        }

        private void btn7_Click(object sender, EventArgs e)
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT COUNT( [ISBN]) FROM  BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                int count = DR.GetInt32(0);
                if (count != 0)
                    disp_data();
            }
            con.DEActiveCon();

            //disp_data();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            if (isbncmb.Text != "" && bookcmb.Text != "")
            {
                string Update = "update Book1 set Quantity=Quantity+1 where  ISBN='" + isbncmb.Text + "'AND Book_Title='" + bookcmb.Text + "'";
                SqlCommand cmd = new SqlCommand(Update, con.ActiveCon());
                cmd.ExecuteReader();
                con.DEActiveCon();
                con.ActiveCon();
                String insertQuery = "delete from BorrowBook1 where ISBN='" + isbncmb.Text + "' AND UserName='" + UserNamecmb.Text + "'";
                SqlCommand cmd1 = new SqlCommand(insertQuery, con.ActiveCon());
                cmd1.ExecuteReader();
                disp_data();

                MessageBox.Show("Book returned successfully");
                con.DEActiveCon();
            }
            else
            {
                MessageBox.Show("Please Fill ISBN and Book_title");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (UserNamecmb.Text != "")
            {
                Connection con = new Connection();
                string SelectQuery = "SELECT *FROM BorrowBook1 WHERE UserName='" + UserNamecmb.Text + "'";
                SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
                SqlDataReader DR = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = DR;
                DGV1.DataSource = source;
            }
            else
            {
                MessageBox.Show("You must Fill  UserName");
            
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpBorrow1 u = new UpBorrow1();
            u.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {

           

        }
        //---------------------------Check Qunatity-----------------------------------------
        public void checkQuantity()
        {

            Connection con = new Connection();
            string SelectQuery = "update  Book1 set Quantity=Quantity-1 WHERE ISBN='" + isbncmb.Text + "'";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            con.DEActiveCon();

        }
    }
}
