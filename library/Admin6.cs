using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.Logic;
using System.Data.SqlClient;

namespace library
{
    public partial class Admin6 : Form
    {
        public object HidetxtPassword { get; private set; }


        String cat;
        public Admin6()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {

            Admin A = new Admin();
            A.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            Admin5 A5 = new Admin5();
            A5.Show();
            this.Hide();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {

          
                cat = "Staff";
          

            SignUp s = new SignUp(txtName.Text, txtIndex.Text, txtDepartment.Text, txtNic.Text, int.Parse(txtMobile.Text), txtAddress.Text, txtEmail.Text, txtPassword.Text, cat);
            String r = s.AddtoDatabase();

            if (r == "Success")

            {
                MessageBox.Show("Success");
               
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
