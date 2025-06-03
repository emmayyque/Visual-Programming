using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PracticeProject
{
    public partial class UserForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Student_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadUserDropDown();
            }
        }

        protected void LoadUsers()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUsers";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridUser.DataSource = dt;
            GridUser.DataBind();

            con.Close();
        }

        protected void LoadUserDropDown()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUsers";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DdlUsers.DataSource = dt;
            DdlUsers.DataBind();
            DdlUsers.DataTextField = "full_name";
            DdlUsers.DataValueField = "id";
            DdlUsers.DataBind();

            con.Close();
        }

        protected void ClearFields()
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtEmail.Text = "";
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUser";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = TxtId.Text;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = TxtName.Text;
            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = TxtEmail.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            con.Close();

            if (check)
            {
                ResultMsg.Text = "User Added Successfully!!";
                ResultMsg.CssClass = "text-success";                
                LoadUsers();
                LoadUserDropDown();
                ClearFields();
            }
            else
            {
                ResultMsg.Text = "Error!! In Adding User!!";
                ResultMsg.CssClass = "text-danger";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateUser";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = TxtId.Text;
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = TxtName.Text;
            cmd.Parameters.AddWithValue("@email", SqlDbType.NVarChar).Value = TxtEmail.Text;

            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                ResultMsg.Text = "User Updated Successfully!!";
                ResultMsg.CssClass = "text-success";
                
                LoadUsers();
                LoadUserDropDown();
                ClearFields();
            }
            else
            {
                ResultMsg.Text = "Error!! In Updating User!!";
                ResultMsg.CssClass = "text-danger";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteUser";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = TxtId.Text;

            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                ResultMsg.Text = "User Deleted Successfully!!";
                ResultMsg.CssClass = "text-success";
                LoadUsers();
                LoadUserDropDown();
                ClearFields();
            }
            else
            {
                ResultMsg.Text = "Error!! In Deleting User!!";
                ResultMsg.CssClass = "text-danger";
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUser";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = DdlUsers.SelectedValue.ToString();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0) 
            {
                TxtId.Text = dt.Rows[0]["id"].ToString();
                TxtName.Text = dt.Rows[0]["full_name"].ToString();
                TxtEmail.Text = dt.Rows[0]["email"].ToString();
            }

            con.Close();

        }
    }
}