using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2WinFormsWithDbConn
{
    internal class DbConn
    {
        private String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;TrustServerCertificate=True";
        private SqlConnection Conn;

        public DbConn()
        {
            this.Conn = new SqlConnection(ConnectionString);
        }

        public bool UDI(String Qry)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand(Qry, Conn);
            bool check = false;

            if (cmd.ExecuteNonQuery() > 0)
            {
                check = true;
            }

            Conn.Close();
            return check;
        }

        public DataTable Search(String Qry)
        {
            Conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();
            return dt;
        }
    }
}
