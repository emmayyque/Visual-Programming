using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A4WebForms
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentForm.aspx");
        }

        protected void BtnTeacher_Click(object sender, EventArgs e)
        {
            Response.Redirect("TeacherForm.aspx");
        }

        protected void BtnCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("CourseForm.aspx");
        }
    }
}