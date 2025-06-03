using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbConn
    {
        String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=StockManSys_DB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection Conn;

        public DbConn()
        {
            Conn = new SqlConnection(ConnectionString);
        }

        public bool UDI(String Qry)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand(Qry, Conn);
            bool check = cmd.ExecuteNonQuery() > 0;
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
