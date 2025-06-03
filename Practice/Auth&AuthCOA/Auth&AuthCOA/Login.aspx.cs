using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Auth_AuthCOA
{
    public partial class Login : System.Web.UI.Page
    {
        private SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=CompanyManSys_DB;Integrated Security=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Conn.Open();
            String Qry = "SELECT * FROM Users WHERE username = '" + TxtUsername.Text + "' AND password = '" + TxtPassword.Text + "' ";
            SqlCommand cmd = new SqlCommand(Qry, Conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                int Role = 0;
                if (reader.Read())
                {
                    Role = Int32.Parse(reader["role"].ToString());
                    Session["Username"] = reader["username"].ToString();
                    Session["UserRole"] = Role;
                    Session["UserId"] = reader["id"].ToString();
                }

                Conn.Close();

                switch (Role)
                {
                    case 1:
                        Response.Redirect("~/AdminPanel.aspx");
                        break;
                    case 2:
                        Response.Redirect("~/ManagerPanel.aspx");
                        break;
                    case 3:
                        Response.Redirect("~/EmployeePanel.aspx");
                        break;
                }
            }
            else
            {
                Conn.Close();
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}