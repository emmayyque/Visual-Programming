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
    public partial class TeacherForm : System.Web.UI.Page
    {
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
            DataTable dt = new TeacherBLL().GetAllTachersBLL();
            GridTeachers.DataSource = dt;
            GridTeachers.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher()
            {
                Id = TxtId.Text,
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                Experience = TxtExperience.Text,
                Type = DdlType.Text,
                Address = TxtAddress.Text,
                DateOfBirth = TxtDOB.Text,
                DateOfJoining = TxtDOJ.Text
            };

            if (new TeacherBLL().InsertTeacherBLL(teacher))
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
            Teacher teacher = new Teacher()
            {
                Id = TxtId.Text
            };

            DataTable dt = new TeacherBLL().GetTeacherBLL(teacher);

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
            Teacher teacher = new Teacher()
            {
                Id = TxtId.Text,
                FirstName = TxtFirstName.Text,
                LastName = TxtLastName.Text,
                Experience = TxtExperience.Text,
                Type = DdlType.Text,
                Address = TxtAddress.Text,
                DateOfBirth = TxtDOB.Text,
                DateOfJoining = TxtDOJ.Text
            };

            if (new TeacherBLL().UpdateTeacherBLL(teacher))
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
            Teacher teacher = new Teacher()
            {
                Id = TxtId.Text
            };

            if (new TeacherBLL().DeleteTeacherBLL(teacher))
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