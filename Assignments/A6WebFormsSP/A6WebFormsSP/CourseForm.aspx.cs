using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A6WebFormsSP
{
    public partial class CourseForm : System.Web.UI.Page
    {
        private SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
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
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCourses";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

            GridCourses.DataSource = dt;
            GridCourses.DataBind();
        }


        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertCourse";

            cmd.Parameters.AddWithValue("@courseCode", SqlDbType.NVarChar).Value = TxtCourseCode.Text;
            cmd.Parameters.AddWithValue("@courseName", SqlDbType.NVarChar).Value = TxtCourseName.Text;
            cmd.Parameters.AddWithValue("@creditHours", SqlDbType.NVarChar).Value = TxtCreditHours.Text;
            cmd.Parameters.AddWithValue("@duration", SqlDbType.NVarChar).Value = TxtDuration.Text;
            cmd.Parameters.AddWithValue("@courseLevel", SqlDbType.NVarChar).Value = DdlCourseLevel.Text;
            cmd.Parameters.AddWithValue("@prerequisites", SqlDbType.NVarChar).Value = TxtPrerequisites.Text;
            cmd.Parameters.AddWithValue("@courseFee", SqlDbType.NVarChar).Value = TxtCourseFee.Text;
            cmd.Parameters.AddWithValue("@instructorName", SqlDbType.NVarChar).Value = TxtInstructorName.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
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
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCourse";

            cmd.Parameters.AddWithValue("@courseCode", SqlDbType.NVarChar).Value = TxtCourseCode.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

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
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateCourse";

            cmd.Parameters.AddWithValue("@courseCode", SqlDbType.NVarChar).Value = TxtCourseCode.Text;
            cmd.Parameters.AddWithValue("@courseName", SqlDbType.NVarChar).Value = TxtCourseName.Text;
            cmd.Parameters.AddWithValue("@creditHours", SqlDbType.NVarChar).Value = TxtCreditHours.Text;
            cmd.Parameters.AddWithValue("@duration", SqlDbType.NVarChar).Value = TxtDuration.Text;
            cmd.Parameters.AddWithValue("@courseLevel", SqlDbType.NVarChar).Value = DdlCourseLevel.Text;
            cmd.Parameters.AddWithValue("@prerequisites", SqlDbType.NVarChar).Value = TxtPrerequisites.Text;
            cmd.Parameters.AddWithValue("@courseFee", SqlDbType.NVarChar).Value = TxtCourseFee.Text;
            cmd.Parameters.AddWithValue("@instructorName", SqlDbType.NVarChar).Value = TxtInstructorName.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
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
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteCourse";

            cmd.Parameters.AddWithValue("@courseCode", SqlDbType.NVarChar).Value = TxtCourseCode.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
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