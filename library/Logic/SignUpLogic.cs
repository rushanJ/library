using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Logic
{
    class SignUpLogic
    {
        private String name, department, nic, address, email, password;
        private int index, mobile;
        public SignUpLogic(String name, int index, String department, String nic, int mobile, String address, String email, String password)
        {
            this.name = name;
            this.index = index;
            this.department = department;
            this.nic = nic;
            this.mobile = mobile;
            this.address = address;
            this.email = email;
            this.password = password;
            
        }

        public String AddtoDatabase()
        {

            try
            {
                Connection con = new Connection();
                SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO AUTH VALUES('" + name + "','" + password + "','" + department + "','" + email + "','" + mobile + "','" + nic + "','" + index + "','" + address + "')", con.ActiveCon());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
    }
}
