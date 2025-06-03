using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A6WebFormsSP
{
    public partial class StudentForm : System.Web.UI.Page
    {
        private SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=Mange_Sys_DB;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
            }
        }

        private void ClearFields()
        {
            TxtRollNo.Text = "";
            TxtFirstName.Text = "";
            TxtLastName.Text = "";
            TxtFatherName.Text = "";
            TxtSysId.Text = "";
            TxtAddress.Text = "";
            TxtDOB.Text = "";
            TxtDOA.Text = "";
        }

        private void LoadStudents()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetStudents";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridStudents.DataSource = dt;
            GridStudents.DataBind();
            Conn.Close();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertStudent";
            
            cmd.Parameters.AddWithValue("@rollNo", SqlDbType.NVarChar).Value = TxtRollNo.Text;
            cmd.Parameters.AddWithValue("@firstName", SqlDbType.NVarChar).Value = TxtFirstName.Text;
            cmd.Parameters.AddWithValue("@lastName", SqlDbType.NVarChar).Value = TxtLastName.Text;
            cmd.Parameters.AddWithValue("@fatherName", SqlDbType.NVarChar).Value = TxtFatherName.Text;
            cmd.Parameters.AddWithValue("@sysId", SqlDbType.NVarChar).Value = TxtSysId.Text;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = TxtAddress.Text;
            cmd.Parameters.AddWithValue("@dob", SqlDbType.NVarChar).Value = TxtDOB.Text;
            cmd.Parameters.AddWithValue("@doa", SqlDbType.NVarChar).Value = TxtDOA.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();
            if (check)
            {
                LabMessage.Text = "Student Record Inserted Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadStudents();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nInserting Student Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetStudent";
            cmd.Parameters.AddWithValue("@rollNo", SqlDbType.NVarChar).Value = TxtRollNo.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();
            if (dt.Rows.Count > 0)
            {
                TxtRollNo.Text = dt.Rows[0]["roll_no"].ToString();
                TxtFirstName.Text = dt.Rows[0]["first_name"].ToString();
                TxtLastName.Text = dt.Rows[0]["last_name"].ToString();
                TxtFatherName.Text = dt.Rows[0]["father_name"].ToString();
                TxtSysId.Text = dt.Rows[0]["sys_id"].ToString();
                TxtAddress.Text = dt.Rows[0]["address"].ToString();
                TxtDOB.Text = dt.Rows[0]["date_of_birth"].ToString();
                TxtDOA.Text = dt.Rows[0]["date_of_admission"].ToString();
            }
            else
            {
                LabMessage.Text = "Invalid Student Roll No!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateStudent";

            cmd.Parameters.AddWithValue("@rollNo", SqlDbType.NVarChar).Value = TxtRollNo.Text;
            cmd.Parameters.AddWithValue("@firstName", SqlDbType.NVarChar).Value = TxtFirstName.Text;
            cmd.Parameters.AddWithValue("@lastName", SqlDbType.NVarChar).Value = TxtLastName.Text;
            cmd.Parameters.AddWithValue("@fatherName", SqlDbType.NVarChar).Value = TxtFatherName.Text;
            cmd.Parameters.AddWithValue("@sysId", SqlDbType.NVarChar).Value = TxtSysId.Text;
            cmd.Parameters.AddWithValue("@address", SqlDbType.NVarChar).Value = TxtAddress.Text;
            cmd.Parameters.AddWithValue("@dob", SqlDbType.NVarChar).Value = TxtDOB.Text;
            cmd.Parameters.AddWithValue("@doa", SqlDbType.NVarChar).Value = TxtDOA.Text;

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();
            if (check)
            {
                LabMessage.Text = "Student Record Updated Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadStudents();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nUpdating Student Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteStudent";

            cmd.Parameters.AddWithValue("@rollNo", SqlDbType.NVarChar).Value = TxtRollNo.Text;
            
            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();
            if (check)
            {
                LabMessage.Text = "Student Record Deleted Successfully !!";
                LabMessage.CssClass = "text-success";
                LoadStudents();
                ClearFields();
            }
            else
            {
                LabMessage.Text = "Error !!\nDeleting Student Record!!";
                LabMessage.CssClass = "text-danger";
            }
        }

        protected void BtnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}