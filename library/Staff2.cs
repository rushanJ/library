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
    public partial class Staff2 : Form
    {
        public Staff2(String username)
        {
            InitializeComponent();
            comboData();
            comboDataIsbn();
            comboDataCategory();
            comboDataUser();
            setUserName(username);
        }

        private void Staff2_Load(object sender, EventArgs e)
        {

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
            Staff3 St3 = new Staff3(getUserName());
            St3.Show();
            this.Hide();
        }

      

        private void button5_Click(object sender, EventArgs e)
        {
            Staff5 St5 = new Staff5(getUserName());
            St5.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff St = new Staff(getUserName());
            St.Show();
            this.Hide();
        }

        private void isbnButton_Click(object sender, EventArgs e)
        {

            string a = isbncmb.Text;
            Connection con = new Connection();
            if (isbncmb.Text != "")
            {
                string SelectQuery = "SELECT *FROM Book1 WHERE ISBN='" + a + "' AND Quantity>0";
                SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
                SqlDataReader DR = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = DR;
                DGV1.DataSource = source;
            }
            con.DEActiveCon();
        }

        private void CatSerach_Click(object sender, EventArgs e)
        {
            string a = catcmb.Text;
            Connection con = new Connection();
            if (catcmb.Text != "")
            {
                string SelectQuery = "SELECT *FROM Book1 WHERE Category='" + a + "'";
                SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
                SqlDataReader DR = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = DR;
                DGV1.DataSource = source;
            }
            con.DEActiveCon();
        }

        private void BookButton_Click(object sender, EventArgs e)
        {
            string a =cmb1.Text;
            Connection con = new Connection();
            if (cmb1.Text != "")
            {
                string SelectQuery = "SELECT *FROM Book1 WHERE Book_Title='" + a + "'";
                SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
                SqlDataReader DR = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = DR;
                DGV1.DataSource = source;
        }
            con.DEActiveCon();
        }

        private void AuthSerach_Click(object sender, EventArgs e)
        {
            checkQuantity();




       //--------------------------------------------------------------------------------------

            DateTime timeStamp = DateTime.Now;
                Connection con = new Connection();
            if (usercmb.Text != "" && isbn.Text != "" && book_title.Text != "" && category.Text != "")
            {
                var insertQuery = "INSERT into BorrowBook1 (UserName,ISBN,Book_Title,Category,Time,Status) " +
                       " VALUES ('" + usercmb.Text + "','" + isbn.Text + "', '" + book_title.Text + "', '" + category.Text + "', '" + timeStamp.ToString() + "','Not Returned');";
                SqlCommand cmd = new SqlCommand(insertQuery, con.ActiveCon());
                cmd.ExecuteReader();
                MessageBox.Show("Data Stored Successfully");
            }
            else
            {
                MessageBox.Show("You Must fill this all Fields");
            }
          
            disp_data();
        }
      
        //cell click and get Value ----------------------------------------------
        private void DGV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGV1.Rows[e.RowIndex];
                
                isbn.Text = row.Cells["ISBN"].Value.ToString();
                book_title.Text = row.Cells["Book_Title"].Value.ToString();
                category.Text = row.Cells["Category"].Value.ToString();
            }

        }
        //-----------------------Combox data Add------------------------------------------

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
        public void comboDataUser()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM AUTH";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String username = DR.GetString(0);
                usercmb.Items.Add(username);

            }
            con.DEActiveCon();
        }
        //---------------------------Check Qunatity-----------------------------------------
        public void checkQuantity()
        {

            Connection con = new Connection();
            string SelectQuery = "update  Book1 set Quantity=Quantity-1 WHERE ISBN='" + isbn.Text + "'";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            con.DEActiveCon();

        }

        //------Set getters and Setters -----------------------------------------------------
        private String username;
        public void setUserName(String uname)
        { username = uname; }
        public String getUserName()
        { return username; }
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
       

    }
}
