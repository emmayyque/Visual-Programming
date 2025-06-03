using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A4WebForms
{
    public partial class StudentForm : System.Web.UI.Page
    {
        DbConn db = new DbConn();
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
            String Qry = "SELECT * FROM Students";
            DataTable dt = db.Search(Qry);
            GridStudents.DataSource = dt;
            GridStudents.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            String RollNo = TxtRollNo.Text;
            String FirstName = TxtFirstName.Text;
            String LastName = TxtLastName.Text;
            String FatherName = TxtFatherName.Text;
            String SystemId = TxtSysId.Text;
            String Address = TxtAddress.Text;
            String DOB = TxtDOB.Text;
            String DOA = TxtDOA.Text;

            String Qry = "INSERT INTO Students (roll_no, first_name, last_name, father_name, sys_id, address, date_of_birth, date_of_admission) VALUES ('"+RollNo+"', '"+FirstName+"', '"+LastName+"', '"+FatherName+"', '"+SystemId+"', '"+Address+"', '"+DOB+"', '"+DOA+"')";
            
            if (db.UDI(Qry))
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
            String RollNo = TxtRollNo.Text;
            String Qry = "SELECT * FROM Students WHERE roll_no = '"+ RollNo +"'";
            DataTable dt = db.Search(Qry);
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
            String RollNo = TxtRollNo.Text;
            String FirstName = TxtFirstName.Text;
            String LastName = TxtLastName.Text;
            String FatherName = TxtFatherName.Text;
            String SystemId = TxtSysId.Text;
            String Address = TxtAddress.Text;
            String DOB = TxtDOB.Text;
            String DOA = TxtDOA.Text;

            String Qry = "UPDATE Students SET first_name='"+FirstName+"', last_name='"+LastName+"', father_name='"+FatherName+"', sys_id='"+SystemId+"', address='"+Address+"', date_of_birth='"+DOB+"', date_of_admission='"+DOA+"' WHERE roll_no = '"+RollNo+"'";

            if (db.UDI(Qry))
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
            String RollNo = TxtRollNo.Text;
            String Qry = "DELETE FROM Students WHERE roll_no = '" + RollNo + "'";

            if (db.UDI(Qry))
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