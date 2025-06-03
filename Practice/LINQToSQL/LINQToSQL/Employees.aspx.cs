using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LINQToSQL
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridView();
                LoadDropDownList();
            }
        }

        private void ClearFields()
        {
            TxtFullName.Text = "";
            TxtEmail.Text = "";
            TxtUsername.Text = "";
            TxtPassword.Text = "";
            TxtRole.Text = "";
        }

        private void LoadGridView()
        {
            OfficeDB db = new OfficeDB();
            GridUsers.DataSource = db.Users.ToList();
            GridUsers.DataBind();
        }

        private void LoadDropDownList()
        {
            OfficeDB db = new OfficeDB();
            DdlUsers.DataSource = db.Users.ToList();
            DdlUsers.DataBind();
            DdlUsers.DataTextField = "full_name";
            DdlUsers.DataValueField = "id";
            DdlUsers.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            OfficeDB db = new OfficeDB();
            User user = new User()
            {
                full_name = TxtFullName.Text,
                email = TxtEmail.Text,
                username = TxtUsername.Text,
                password = TxtPassword.Text,
                role = TxtRole.Text
            };
            db.Users.Add(user);
            db.SaveChanges();
            LoadGridView();
            LoadDropDownList();
            ClearFields();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            OfficeDB db = new OfficeDB();
            int ID = Int32.Parse(DdlUsers.SelectedValue.ToString());
            User user = db.Users.SingleOrDefault(x => x.id == ID);
            user.full_name = TxtFullName.Text;
            user.email = TxtEmail.Text;
            user.username = TxtUsername.Text;
            user.password = TxtPassword.Text;
            user.role = TxtRole.Text;
            db.SaveChanges();
            LoadGridView();
            LoadDropDownList();
            ClearFields();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            OfficeDB db = new OfficeDB();
            int ID = Int32.Parse(DdlUsers.SelectedValue.ToString());
            User user = db.Users.SingleOrDefault(x => x.id == ID);
            db.Users.Remove(user);
            db.SaveChanges();
            LoadGridView();
            LoadDropDownList();
            ClearFields();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            OfficeDB db = new OfficeDB();
            int ID = Int32.Parse(DdlUsers.SelectedValue.ToString());
            User user = db.Users.SingleOrDefault(x => x.id == ID);
            TxtFullName.Text = user.full_name.ToString();
            TxtEmail.Text = user.email.ToString();
            TxtUsername.Text = user.username.ToString();
            TxtPassword.Text = user.password.ToString();
            TxtRole.Text = user.role.ToString();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}