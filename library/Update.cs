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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
            comboBook_title();
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
            Admin3 A3 = new Admin3();
            A3.Show();
            this.Hide();
            update();
        }
        //-----------------------Combox data Add------------------------------------------


        public void comboBook_title()
        {

            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM Book1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                String isbn = DR.GetString(1);
                booktitlecmb.Items.Add(isbn);

            }
            con.DEActiveCon();
        }

        public void SerachwithBookTiitle()
        {
            string a = booktitlecmb.Text;
            Connection con = new Connection();
           
            SqlDataAdapter Serach = new SqlDataAdapter("SELECT *FROM Book1 WHERE ISBN='" + a + "'", con.ActiveCon());
            DataTable dt = new DataTable();
            Serach.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                auth.Text = dt.Rows[0]["Author"].ToString();
               
            }

            con.DEActiveCon();
        }

        private void search_Click(object sender, EventArgs e)
        {
           
            Connection con = new Connection();
            string a = booktitlecmb.Text;
            if (booktitlecmb.Text != "")
           { 
                string selectQuery = "SELECT ISBN ,Category ,Author,Status,Quantity FROM Book1 WHERE Book_Title='" + a + "'";
                SqlCommand cmd = new SqlCommand(selectQuery, con.ActiveCon());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    isbn.Text = dr.GetValue(0).ToString();
                    cat.Text = dr.GetValue(1).ToString();
                    auth.Text = dr.GetValue(2).ToString();
                    status.Text = dr.GetValue(3).ToString();
                    quanttiy.Text = dr.GetValue(4).ToString();

                } 
            }
        }
        public void update()
        {
            Connection con = new Connection();
  
            string selectQuery = "update Book1 set Book_Title='"+upname.Text+ "',Category='"+upcat.Text+ "',Author='"+upauth.Text+ "',Status='"+upsta.Text+ "',Quantity='"+upqu.Text+ "' where  IBN='" + isbn.Text+"'" ;
            SqlCommand cmd = new SqlCommand(selectQuery, con.ActiveCon());
            SqlDataReader dr = cmd.ExecuteReader();
            MessageBox.Show("Data update Successfully");
        }


    }
    
}
