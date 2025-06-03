using AppProps;
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
        private SqlConnection Con;
        private String ConnectionString = "Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Student_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        public DbConn()
        {
            Con = new SqlConnection(ConnectionString);
        }

        public bool UDI(String Proc, User user)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Proc;

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = user.Id;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = user.Name;
            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = user.Email;

            bool check = false;
            if (cmd.ExecuteNonQuery() > 0)
            {
                check = true;
            }
            Con.Close();
            return check;
        }

        public DataTable Search(String Proc, User user)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Proc;

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = user.Id;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Con.Close();
            return dt;
        }
    }
}
