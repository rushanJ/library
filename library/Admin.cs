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
    public partial class Admin : Form
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DEMON-KILLER;Initial Catalog=user;Integrated Security=True");


        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            string SelectQuery = "SELECT COUNT( [ISBN]) FROM  Book1";
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();

            while (DR.Read())
            {
                int count = DR.GetInt32(0);
                if (count !=0)
                disp_data();
            }
            con.DEActiveCon();
           
        }
        public void disp_data()
        {

            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand("select * from Book1", con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            BindingSource source = new BindingSource();
            source.DataSource = DR;
            dGV2.DataSource = source;
            con.DEActiveCon();
        }
        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void normal_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            { 
            this.WindowState = FormWindowState.Normal;

                int CurActFoX = 0,CurCloPicLocX = 0, CurMaxPicLocX = 0,CurMinPicLocX = 0;

                CurActFoX = ActiveForm.Width;
                CurCloPicLocX = (CurActFoX - 32);
                CurMaxPicLocX = (CurActFoX - 64);
                CurMinPicLocX = (CurActFoX - 96);

                this.button6.Location = new Point(CurCloPicLocX, 0);
                this.normal.Location = new Point(CurMaxPicLocX, 0);
                this.minimize.Location = new Point(CurMinPicLocX, 0);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;

                int ActForX = 0, CloPicLocX = 0, MaxPicLocX = 0, MinPicLocX = 0;
                ActForX = ActiveForm.Width;
                CloPicLocX = (ActForX - 32);
                MaxPicLocX = (ActForX - 64);
                MinPicLocX = (ActForX - 96);

                this.button6.Location = new Point(CloPicLocX, 0);
                this.normal.Location = new Point(CloPicLocX, 0);
                this.minimize.Location = new Point(CloPicLocX, 0);
                }


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

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label11_Click(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            Admin5 A5 = new Admin5();
            A5.Show();
            this.Hide();
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            Admin6 A6 = new Admin6();
            A6.Show();
            this.Hide();
        }

        private void dGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            CompareTime();
        }
        public void sendEmail(String emailTo)
        {
            Console.WriteLine(emailTo);
            /* try
             {
                 MailMessage mail = new MailMessage();
                 SmtpClient SmtpServer = new SmtpClient("smtp.hostinger.com");

                 mail.From = new MailAddress("your_email_address@gmail.com");
                 mail.To.Add("to_address");
                 mail.Subject = "Test Mail";
                 mail.Body = "This is for testing SMTP mail from GMAIL";

                 SmtpServer.Port = 587;
                 SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                 SmtpServer.EnableSsl = true;

                 SmtpServer.Send(mail);
                 MessageBox.Show("mail Send");
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
              */
            try
            {
                 MailMessage mail = new MailMessage();
                 SmtpClient SmtpServer = new SmtpClient("smtp.hostinger.com");

                 mail.From = new MailAddress("kavindudissanayake@critssl.com");
                 mail.To.Add(emailTo);
                 mail.Subject = "--From-Library---";
                 mail.Body = "Please return your library Books";

                 SmtpServer.Port = 587;
                 SmtpServer.Credentials = new System.Net.NetworkCredential("kavindudissanayake@critssl.com", "0763726309Kk");
                 SmtpServer.EnableSsl = true;

                 SmtpServer.Send(mail);
                
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
            MessageBox.Show("Notifications Sent");

        }
        public void userEmail(String user)
        {
            //Console.WriteLine(user);
            // DateTime nownowtime = DateTime.Now;

             Connection con = new Connection();
             string SelectQuery = "SELECT *FROM AUTH WHERE username='"+user+"'";
             SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
             SqlDataReader DR = cmd.ExecuteReader();

             while (DR.Read())
             {
                 String email = DR.GetString(3);
               
                sendEmail(email);



            }
             con.DEActiveCon();
        }
        public void CompareTime()
        {
            Connection con = new Connection();
            string SelectQuery = "SELECT *FROM BorrowBook1 "; 
            SqlCommand cmd = new SqlCommand(SelectQuery, con.ActiveCon());
            SqlDataReader DR = cmd.ExecuteReader();
            while (DR.Read())
            {
                String timeS = DR.GetString(4);
              
                DateTime brrowdate = Convert.ToDateTime(timeS);
                String user = DR.GetString(0);
               
                DateTime dt = DateTime.Now;
                DateTime  compareTime = dt.AddDays(-14);
                if ( compareTime >= brrowdate)
                {
                  userEmail(user);
                }
               


            }

        }
    }
}
