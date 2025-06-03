using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Auth_AuthCLA
{
    public partial class ManagerPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserId"] != null && Int32.Parse(Session["UserRole"].ToString()) == 2)
                {
                    LabUserIDVal.Text = Session["UserId"].ToString();
                    LabUsernameVal.Text = Session["Username"].ToString();
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

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/Login.aspx");
        }
    }
}