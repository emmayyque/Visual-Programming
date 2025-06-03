using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A8Authentication_AuthCOA
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=CompanyManSys_DB;Integrated Security=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            Conn.Open();
            String Qry = "INSERT INTO Users (full_name, email, username, password, role) VALUES ('" + TxtFullName.Text + "', '" + TxtEmail.Text + "', '" + TxtUsername.Text + "', '" + TxtPassword.Text + "', 3)";
            SqlCommand cmd = new SqlCommand(Qry, Conn);
            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();
            if (check)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                Response.Redirect("~/Register.aspx");
            }
        }
    }
}