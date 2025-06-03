using BusinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WFFirstProject
{
    public partial class UserForm : System.Web.UI.Page
    {
        DbConn db = new DbConn();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void ClearFields()
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

            UserBLL userBLL = new UserBLL();

            if (userBLL.InsertUserBLL(user))
            {
                LabMessage.Text = "User Registered Successfully !!";
                LabMessage.CssClass = "text-success text-center";

                LoadUsers();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "User Not Registered !!";
                LabMessage.CssClass = "text-danger text-center";
            }
        }

        private void LoadUsers()
        {
            DataTable dt = new UserBLL().GetUsers();
            GridUsers.DataSource = dt;
            GridUsers.DataBind();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = TxtId.Text
            };

            UserBLL userBLL = new UserBLL();
            DataTable dt = userBLL.GetUser(user);
            
            if (dt.Rows.Count > 0)
            {
                TxtName.Text = dt.Rows[0]["full_name"].ToString();
                TxtEmail.Text = dt.Rows[0]["email"].ToString();
            }
            else
            {
                LabMessage.Text = "Invalid User ID!!";
                LabMessage.CssClass = "text-danger text-center";
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

            UserBLL userBLL = new UserBLL();

            if (userBLL.UpdateUserBLL(user))
            {
                LabMessage.Text = "User Updated Successfully !!";
                LabMessage.CssClass = "text-success text-center";

                LoadUsers();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "User Not Updated !!";
                LabMessage.CssClass = "text-danger text-center";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Id = TxtId.Text
            };

            UserBLL userBLL = new UserBLL();

            if (userBLL.DeleteUserBLL(user))
            {
                LabMessage.Text = "User Deleted Successfully !!";
                LabMessage.CssClass = "text-success text-center";

                LoadUsers();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "User Not Deleted !!";
                LabMessage.CssClass = "text-danger text-center";
            }
        }
    }
}