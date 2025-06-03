using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auth_AuthCLA
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
            SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

            if (dt.Rows.Count > 0)
            {
                int Role = Int32.Parse(dt.Rows[0]["role"].ToString());
                Session["Username"] = dt.Rows[0]["username"].ToString();
                Session["UserRole"] = Role;
                Session["UserId"] = dt.Rows[0]["id"].ToString();

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
        }
    }
}