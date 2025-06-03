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
    public partial class AdminPanel : System.Web.UI.Page
    {
        private SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=CompanyManSys_DB;Integrated Security=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Int32.Parse(Session["UserRole"].ToString()) == 1)
                {
                    LoadUsersGrid();
                    LoadUsersDDL();
                }
                else
                {
                    if (Session["UserId"] != null)
                    {
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

                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void LoadUsersGrid()
        {
            Conn.Open();
            String Qry = "SELECT * FROM Users WHERE role != 1";
            SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();
            GridUsers.DataSource = dt;
            GridUsers.DataBind();
        }

        protected void LoadUsersDDL()
        {
            Conn.Open();
            String Qry = "SELECT * FROM Users WHERE role != 1";
            SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();
            DdlUsers.DataSource = dt;
            DdlUsers.DataBind();
            DdlUsers.DataTextField = "full_name";
            DdlUsers.DataValueField = "id";
            DdlUsers.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Conn.Open();
            String Qry = "SELECT * FROM Users WHERE id = '" + DdlUsers.SelectedValue + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Qry, Conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

            DdlRole.SelectedValue = dt.Rows[0]["role"].ToString();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Conn.Open();
            String Qry = "UPDATE Users SET role = '" + DdlRole.SelectedValue + "' WHERE id = '" + DdlUsers.SelectedValue + "'";
            SqlCommand cmd = new SqlCommand(Qry, Conn);
            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();
            LoadUsersGrid();
            LoadUsersDDL();
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}