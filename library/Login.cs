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
    public partial class Login : Form
    {
        public object HidetxtPassword { get; private set; }
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            SqlDataAdapter sda = new SqlDataAdapter("select * From AUTH where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", con.ActiveCon());

            DataTable dt = new DataTable();
            sda.Fill(dt);


            if (dt.Rows.Count > 0)
            {
               
                if (dt.Rows[0][8].ToString().Trim().Equals("admin"))
                {
                    Admin A = new Admin();
                    A.Show();
                    this.Hide();
                
                }
                else if (dt.Rows[0][8].ToString().Trim().Equals("Student"))
                {
                    String A = txtUsername.Text;
                    Student s = new Student(A);
                    this.Hide();
                    s.Show();
                 

                }
                else if (dt.Rows[0][8].ToString().Trim().Equals("Staff"))
                {
                    String A = txtUsername.Text;
                    Staff st = new Staff(A);
                    this.Hide();
                    st.Show();

                }
                

            }
            else
            {
                MessageBox.Show("Your username or password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1_Checked.Checked)
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

        private class checkBox1_Checked
        {
            public static bool Checked { get; internal set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void normal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized; 
        }

        private void btnSignin_Click(object sender, EventArgs e)
        {
            Signin S = new Signin();
            S.Show();
            this.Hide();


        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Help Hp = new Help();
            Hp.Show();
        }

        private void txtUsername_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Type your username", txtUsername);
            toolTip1.OwnerDraw = true;
            toolTip1.ForeColor = Color.Black;
        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Type your password", txtPassword);
            
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Input your username and password to login.If you are new user please sign up.", label5);
            toolTip1.OwnerDraw = true;
            
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
    }

