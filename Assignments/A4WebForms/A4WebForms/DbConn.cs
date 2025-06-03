using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace A4WebForms
{
    public class DbConn
    {
        private SqlConnection Conn;
        private String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public DbConn()
        {
            Conn = new SqlConnection(ConnectionString);
        }

        public bool UDI(String Qry)
        {
            Conn.Open();
            bool check = new SqlCommand(Qry, Conn).ExecuteNonQuery() > 0;
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