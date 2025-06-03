using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A4WebForms
{
    public partial class CourseForm : System.Web.UI.Page
    {
        DbConn db = new DbConn();
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
            String Qry = "SELECT * FROM Courses";
            DataTable dt = db.Search(Qry);
            GridCourses.DataSource = dt;
            GridCourses.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            String CourseCode = TxtCourseCode.Text;
            String CourseName = TxtCourseName.Text;
            String CreditHours = TxtCreditHours.Text;
            String Duration = TxtDuration.Text;
            String CourseLevel = DdlCourseLevel.Text;
            String Prerequisites = TxtPrerequisites.Text;
            String CourseFee = TxtCourseFee.Text;
            String InstructorName = TxtInstructorName.Text;

            String Qry = "INSERT INTO Courses (course_code, course_name, credit_hours, duration, course_level, prerequisites, course_fee, instructor_name) VALUES ('" + CourseCode + "', '" + CourseName + "', '" + CreditHours + "', '" + Duration + "', '" + CourseLevel + "', '" + Prerequisites + "', '" + CourseFee + "', '" + InstructorName + "')";

            if (db.UDI(Qry))
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
            String CourseCode = TxtCourseCode.Text;

            String Qry = "SELECT * FROM Courses WHERE course_code = '"+ CourseCode +"'";
            DataTable dt = db.Search(Qry);

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
            String CourseCode = TxtCourseCode.Text;
            String CourseName = TxtCourseName.Text;
            String CreditHours = TxtCreditHours.Text;
            String Duration = TxtDuration.Text;
            String CourseLevel = DdlCourseLevel.Text;
            String Prerequisites = TxtPrerequisites.Text;
            String CourseFee = TxtCourseFee.Text;
            String InstructorName = TxtInstructorName.Text;

            String Qry = "UPDATE Courses  SET course_code = '"+ CourseCode +"', course_name = '"+ CourseName +"', credit_hours = '"+ CreditHours +"', duration = '"+ Duration +"', course_level = '"+ CourseLevel +"', prerequisites = '"+ Prerequisites +"', course_fee = '"+ CourseFee +"', instructor_name = '"+ InstructorName +"' WHERE course_code = '"+ CourseCode +"'";

            if (db.UDI(Qry))
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
            String CourseCode = TxtCourseCode.Text;

            String Qry = "DELETE FROM Courses WHERE course_code = '" + CourseCode + "'";

            if (db.UDI(Qry))
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