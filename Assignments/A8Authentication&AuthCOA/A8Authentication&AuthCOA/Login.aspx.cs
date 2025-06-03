using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A8Authentication_AuthCOA
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=CompanyManSys_DB;Integrated Security=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Conn.Open();
            String Qry = "SELECT * FROM Users WHERE username = '" + TxtUsername.Text + "' AND password = '" + TxtPassword.Text + "'";
            SqlCommand cmd = new SqlCommand(Qry, Conn);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    Session["UserId"] = reader["id"].ToString();
                    Session["Username"] = reader["username"].ToString();
                    Session["UserRole"] = reader["role"].ToString();
                }
                Conn.Close();

                int Role = Int32.Parse(Session["UserRole"].ToString());

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