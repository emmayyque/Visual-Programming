using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A5WebFormsThreeTier
{
    public partial class CourseForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        private void ClearFields()
        {
            TxtCourseCode.Text = "";
            TxtCourseName.Text = "";
            TxtCreditHours.Text = "";
            TxtDuration.Text = "";
            DdlCourseLevel.Text = "";
            TxtPrerequisites.Text = "";
            TxtCourseFee.Text = "";
            TxtInstructorName.Text = "";
        }

        private void LoadCourses()
        {
            DataTable dt = new CourseBLL().GetAllCoursesBLL();
            GridCourses.DataSource = dt;
            GridCourses.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                CourseCode = TxtCourseCode.Text,
                CourseName = TxtCourseName.Text,
                CreditHours = TxtCreditHours.Text,
                Duration = TxtDuration.Text,
                CourseLevel = DdlCourseLevel.Text,
                Prerequisites = TxtPrerequisites.Text,
                CourseFee = TxtCourseFee.Text,
                InstructorName = TxtInstructorName.Text,
            };

            if (new CourseBLL().InsertCourseBLL(course))
            {
                LabMessage.Text = "Course Record Inserted Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadCourses();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nInserting Course Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                CourseCode = TxtCourseCode.Text
            };

            DataTable dt = new CourseBLL().GetCourseBLL(course);

            if (dt.Rows.Count > 0)
            {
                TxtCourseCode.Text = dt.Rows[0]["course_code"].ToString();
                TxtCourseName.Text = dt.Rows[0]["course_name"].ToString();
                TxtCreditHours.Text = dt.Rows[0]["credit_hours"].ToString();
                TxtDuration.Text = dt.Rows[0]["duration"].ToString();
                DdlCourseLevel.Text = dt.Rows[0]["course_level"].ToString();
                TxtPrerequisites.Text = dt.Rows[0]["prerequisites"].ToString();
                TxtCourseFee.Text = dt.Rows[0]["course_fee"].ToString();
                TxtInstructorName.Text = dt.Rows[0]["instructor_name"].ToString();
            }
            else
            {
                LabMessage.Text = "Invalid Course Code";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                CourseCode = TxtCourseCode.Text,
                CourseName = TxtCourseName.Text,
                CreditHours = TxtCreditHours.Text,
                Duration = TxtDuration.Text,
                CourseLevel = DdlCourseLevel.Text,
                Prerequisites = TxtPrerequisites.Text,
                CourseFee = TxtCourseFee.Text,
                InstructorName = TxtInstructorName.Text,
            };

            if (new CourseBLL().UpdateCourseBLL(course))
            {
                LabMessage.Text = "Course Record Updated Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadCourses();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nUpdating Course Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Course course = new Course()
            {
                CourseCode = TxtCourseCode.Text
            };

            if (new CourseBLL().DeleteCourseBLL(course))
            {
                LabMessage.Text = "Course Record Deleted Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadCourses();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nDeleting Course Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}