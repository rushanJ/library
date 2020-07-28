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
    public partial class Admin2 : Form
    {
        public Admin2()
        {
            InitializeComponent();
            comboData();
            comboDataIsbn();
            comboDataCategory();
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

        private void button7_Click(object sender, EventArgs e)
        {
            Admin6 A6 = new Admin6();
            A6.Show();
            this.Hide();
        }

        private void isbnButton_Click(object sender, EventArgs e)
        {
            string a = isbncmb.Text;
            Connection con = new Connection();
            if (isbncmb.Text != "")
            {
                string SelectQuery = "SELECT *FROM Book1 WHERE ISBN='" + a + "'";
                SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
                SqlDataReader DR = cmd.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = DR;
                DGV1.DataSource = source;
            }
            else MessageBox.Show("Please Enter ISBN");
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
            string a = cmb1.Text;
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

            //  checkQuantity();
            Boolean InsertCheck = true;
            //----Check Fileds -------------------------------------------------------------
            if (usercmb.Text != "")
                setUserName((usercmb.Text).ToString());
            else
            {
                MessageBox.Show("Please Enter User name ");
                InsertCheck = false;
            }

            if (isbn.Text != "")
                setISBN((isbn.Text).ToString());
            else
                MessageBox.Show("Please Enter ISBN");

            if (book_title.Text != "")
                setBook_Title((book_title.Text).ToString());
            else
                MessageBox.Show("Please Enter Book_Title");

            if (category.Text != "")
                setCategory((category.Text).ToString());
            else
                MessageBox.Show("Please Enter Category");




            //--------------------------------------------------------------------------------------
            if (InsertCheck)
            {
                DateTime timeStamp = DateTime.Now;
                Connection con = new Connection();
                var insertQuery = "INSERT into BorrowBook1 (UserName,ISBN,Book_Title,Category,Time,Status) " +
                       " VALUES ('" + getUserName() + "','" + getISBN() + "', '" + getBook_Title() + "', '" + getCategory() + "', '" + timeStamp.ToString() + "','Not Returned');";
                SqlCommand cmd = new SqlCommand(insertQuery, con.ActiveCon());
                cmd.ExecuteReader();
                MessageBox.Show("Data Stored Successfully");
            }
        }
             //---------------------Getters And Setters---------------------------------------
        private String userName, ISBN, Book_Title, Category;
        private int ID;
        public String getUserName()
        { return userName; }
        public void setUserName(String data)
        { userName = data; }
        public String getISBN()
        { return ISBN; }
        public void setISBN(String isbn)
        { ISBN = isbn; }
        public String getBook_Title()
        { return Book_Title; }
        public void setBook_Title(String bkt)
        { Book_Title = bkt; }
        public String getCategory()
        { return Category; }
        public void setCategory(String cat)
        { Category = cat; }
        //cell click and get Value ----------------------------------------------
       
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

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.DGV1.Rows[e.RowIndex];

                isbn.Text = row.Cells["ISBN"].Value.ToString();
                book_title.Text = row.Cells["Book_Title"].Value.ToString();
                category.Text = row.Cells["Category"].Value.ToString();
            }
        }

        private void Admin2_Load(object sender, EventArgs e)
        {

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
            string SelectQuery = "SELECT Quantity FROM Book1 WHERE ISBN='" + getISBN() + "'";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            int Quantity = Convert.ToInt32(SelectQuery);
            if (Quantity > 0)
            {
                int a = Quantity - 1;
                string update = "UPDATE Book1 SET Quantity = " + Convert.ToString(a) + "WHERE ISBN = " + getISBN();

            }
        }
    }
}
