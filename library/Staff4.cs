using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library
{
    public partial class Staff4 : Form
    {
        public Staff4(String username)
        {
            InitializeComponent();
            setUserName(username);
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
            Staff2 St2 = new Staff2(getUserName());
            St2.Show();
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
        //------Set getters and Setters -------------------------
        private String username;
        public void setUserName(String uname)
        { username = uname; }
        public String getUserName()
        { return username; }
    }
}
