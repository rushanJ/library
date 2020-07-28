using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace library.Logic
{
    class SignUp
    {
        private String name, index, department, nic, address, email, password,Category;
        private int mobile;
        public SignUp(String name, String index, String department, String nic, int mobile, String address, String email, String password,String Category) {
            this.name = name;
            this.index = index;
            this.department = department;
            this.nic = nic;
            this.mobile = mobile;
            this.address = address;
            this.email = email;
            this.Category = Category;
            this.password = password;
        }

        public String AddtoDatabase() {

            try
            {
                Connection con = new Connection();
                SqlDataAdapter sda = new SqlDataAdapter("INSERT INTO AUTH VALUES('" + name + "','" + password + "','" + department + "','" + email + "','" + mobile + "','" + nic + "','" + index + "','" + address + "','"+Category+"')", con.ActiveCon());
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return "Success";
            }
            catch (Exception ex) {
                return ex.Message.ToString();
            }
            

        }
    }
}
