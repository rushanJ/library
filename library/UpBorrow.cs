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
    public partial class UpBorrow1 : Form
    {
        public UpBorrow1()
        {
            InitializeComponent();
            combousername();
        }

        private void Update_Load(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip3.Show("Save Changes", btnSave);
        }

        private void toolTip3_Popup(object sender, PopupEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Admin4 A4 = new Admin4();
            A4.Show();
            this.Hide();
            UpdateBorrow();
          
        }
        //-----------------------Combox data Add------------------------------------------


        public void combousername()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM BorrowBook1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String isbn = DR.GetString(0);
                usernamecmb.Items.Add(isbn);

            }
            con.DEActiveCon();
        }
        public void UpdateBorrow()
        {
            Connection con = new Connection();

            string selectQuery = "update BorrowBook1 set UserName='" + upname1.Text + "',ISBN= '"+ upisbn1.Text+ "',Category='" + upcat1.Text + "',Status='" + upsta1.Text + "' where  UserName='" + usernamecmb.Text + "' AND ISBN='"+isbn.Text+"' ";
            SqlCommand cmd = new SqlCommand(selectQuery, con.ActiveCon());
            SqlDataReader dr = cmd.ExecuteReader();
            MessageBox.Show("Data update Successfully");
        }



        private void search_Click(object sender, EventArgs e)
        {

            Connection con = new Connection();
            string a = usernamecmb.Text;
            if (usernamecmb.Text != "")
            {
                string Update = "SELECT ISBN ,Book_Title ,Status FROM BorrowBook1 WHERE UserName='" + a + "'";
                SqlCommand cmd = new SqlCommand(Update, con.ActiveCon());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    isbn.Text = dr.GetValue(0).ToString();
                    cat.Text = dr.GetValue(1).ToString();
                    status.Text = dr.GetValue(2).ToString();


                }
            }

            con.DEActiveCon();
        }
    }
  


 }
    

