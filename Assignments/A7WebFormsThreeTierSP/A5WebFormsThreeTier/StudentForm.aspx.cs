using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A5WebFormsThreeTier
{
    public partial class StudentForm : System.Web.UI.Page
    {
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
            DataTable dt = new StudentBLL().GetAllStudentsBLL();
            GridStudents.DataSource = dt;
            GridStudents.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                RollNo = TxtRollNo.Text,
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                FatherName = TxtFatherName.Text,
                SysId = TxtSysId.Text,
                Address = TxtAddress.Text,
                DateOfBirth = TxtDOB.Text,
                DateOfAdmission = TxtDOA.Text
            };

            if (new StudentBLL().InsertStudentBLL(student))
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
            Student student = new Student()
            {
                RollNo = TxtRollNo.Text
            };

            DataTable dt = new StudentBLL().GetStudentBLL(student);
            
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
            Student student = new Student()
            {
                RollNo = TxtRollNo.Text,
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                FatherName = TxtFatherName.Text,
                SysId = TxtSysId.Text,
                Address = TxtAddress.Text,
                DateOfBirth = TxtDOB.Text,
                DateOfAdmission = TxtDOA.Text
            };

            if (new StudentBLL().UpdateStudentBLL(student))
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
            Student student = new Student()
            {
                RollNo = TxtRollNo.Text
            };

            if (new StudentBLL().DeleteStudentBLL(student))
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