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
    public partial class TeacherForm : System.Web.UI.Page
    {
        private SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTeachers();
            }
        }
        private void ClearFields()
        {
            TxtId.Text = "";
            TxtFirstName.Text = "";
            TxtLastName.Text = "";
            TxtExperience.Text = "";
            DdlType.Text = "";
            TxtAddress.Text = "";
            TxtDOB.Text = "";
            TxtDOJ.Text = "";
        }

        private void LoadTeachers()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTeachers";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();
            GridTeachers.DataSource = dt;
            GridTeachers.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertTeacher";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = TxtId.Text;
            cmd.Parameters.AddWithValue("@firstName", SqlDbType.NVarChar).Value = TxtFirstName.Text;
            cmd.Parameters.AddWithValue("@lastName", SqlDbType.NVarChar).Value = TxtLastName.Text;
            cmd.Parameters.AddWithValue("@experience", SqlDbType.NVarChar).Value = TxtExperience.Text;
            cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = DdlType.Text;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = TxtAddress.Text;
            cmd.Parameters.AddWithValue("@dob", SqlDbType.NVarChar).Value = TxtDOB.Text;
            cmd.Parameters.AddWithValue("@doj", SqlDbType.NVarChar).Value = TxtDOJ.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
            {
                LabMessage.Text = "Teacher Record Inserted Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadTeachers();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nInserting Teacher Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTeacher";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = TxtId.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

            if (dt.Rows.Count > 0)
            {
                TxtId.Text = dt.Rows[0]["id"].ToString();
                TxtFirstName.Text = dt.Rows[0]["first_name"].ToString();
                TxtLastName.Text = dt.Rows[0]["last_name"].ToString();
                TxtExperience.Text = dt.Rows[0]["experience"].ToString();
                DdlType.Text = dt.Rows[0]["type"].ToString();
                TxtAddress.Text = dt.Rows[0]["address"].ToString();
                TxtDOB.Text = dt.Rows[0]["date_of_birth"].ToString();
                TxtDOJ.Text = dt.Rows[0]["date_of_joining"].ToString();
            }
            else
            {
                LabMessage.Text = "Invalid Teacher ID";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateTeacher";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = TxtId.Text;
            cmd.Parameters.AddWithValue("@firstName", SqlDbType.NVarChar).Value = TxtFirstName.Text;
            cmd.Parameters.AddWithValue("@lastName", SqlDbType.NVarChar).Value = TxtLastName.Text;
            cmd.Parameters.AddWithValue("@experience", SqlDbType.NVarChar).Value = TxtExperience.Text;
            cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = DdlType.Text;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = TxtAddress.Text;
            cmd.Parameters.AddWithValue("@dob", SqlDbType.NVarChar).Value = TxtDOB.Text;
            cmd.Parameters.AddWithValue("@doj", SqlDbType.NVarChar).Value = TxtDOJ.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
            {
                LabMessage.Text = "Teacher Record Updated Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadTeachers();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nUpdating Teacher Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteTeacher";

            cmd.Parameters.AddWithValue("@id", SqlDbType.NVarChar).Value = TxtId.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
            {
                LabMessage.Text = "Teacher Record Deleted Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadTeachers();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nDeleting Teacher Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}