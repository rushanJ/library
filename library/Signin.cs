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
using library.Logic;

namespace library
{
    public partial class Signin : Form
    {
        public object HidetxtPassword { get; private set; }


        String cat;
        public Signin()
        {
            InitializeComponent();
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Signin_Load(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {

            if (r1.Checked)
            {
                cat = "Student";
            }
            else
            {
                cat = "Staff";
            }

            SignUp s = new SignUp(txtName.Text, txtIndex.Text, txtDepartment.Text, txtNic.Text, int.Parse(txtMobile.Text), txtAddress.Text, txtEmail.Text, txtPassword.Text, cat);
            String r = s.AddtoDatabase();

            if (r == "Success")

            {
                MessageBox.Show("Success");
                Login F = new Login();
                F.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login F = new Login();
            F.Show();
            this.Hide();


        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void normal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIndex_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2_Checked.Checked)
            {
                txtPassword.UseSystemPasswordChar = true;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "View";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                var checkBox = (CheckBox)sender;
                checkBox.Text = "Hide";
            }
        }
             private class checkBox2_Checked
        {
            public static bool Checked { get; internal set; }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtName_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("insert username", txtName);
            toolTip2.OwnerDraw = true;
            toolTip2.ForeColor = Color.Black;
            
        }

        private void toolTip2_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
    }


