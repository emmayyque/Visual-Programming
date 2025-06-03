using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StrProThreeTier
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
            DataTable dt = new UserBLL().GetUsersBLL();

            if (dt.Rows.Count > 0)
            {
                GridUser.DataSource = dt;
                GridUser.DataBind();
            }
        }

        protected void LoadUserDropDown()
        {
            DataTable dt = new UserBLL().GetUsersBLL();

            if (dt.Rows.Count > 0)
            {
                DdlUsers.DataSource = dt;
                DdlUsers.DataBind();
                DdlUsers.DataTextField = "full_name";
                DdlUsers.DataValueField = "id";
                DdlUsers.DataBind();
            }
        }

        protected void ClearFields()
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtEmail.Text = "";
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = TxtId.Text,
                Name = TxtName.Text,
                Email = TxtEmail.Text
            };


            if (new UserBLL().UserInsertBLL(user))
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
            User user = new User()
            {
                Id = TxtId.Text,
                Name = TxtName.Text,
                Email = TxtEmail.Text
            };

            if (new UserBLL().UserUpdateBLL(user))
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
            User user = new User()
            {
                Id = TxtId.Text
            };


            if (new UserBLL().UserDeleteBLL(user))
            {
                con.Close();
                ResultMsg.Text = "User Deleted Successfully!!";
                ResultMsg.CssClass = "text-success";
                LoadUsers();
                //LoadUserDropDown();
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
            User user = new User()
            {
                Id = TxtId.Text
            };

            DataTable dt = new UserBLL().GetUserByIDBLL(user);

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