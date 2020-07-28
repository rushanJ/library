using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace library
{
    class Connection
    {
        String connectionString = ConfigurationManager.AppSettings["connectionString"];
        

     
        public SqlConnection ActiveCon()
        {
            //Console.WriteLine(title);
            SqlConnection ConnectionString = new SqlConnection(@""+ connectionString);
            if (ConnectionString.State == System.Data.ConnectionState.Closed)
            {
                ConnectionString.Open();
            }
            return ConnectionString;
        }
        public void DEActiveCon()
        {
            SqlConnection ConnectionString = new SqlConnection(connectionString);
            ConnectionString.Close();
        }
    }
}