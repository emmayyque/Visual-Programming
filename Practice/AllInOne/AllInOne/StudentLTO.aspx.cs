using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AllInOne
{
    public partial class StudentLTO : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentsGrid();
                LoadStudentsDDL();
            }
        }

        protected void ClearFields()
        {
           TxtId.Text = "";
           TxtName.Text = "";
           TxtRollNo.Text = "";
        }

        List<Student> studentsList = new List<Student>()
        {
           new Student()
           {
               Id = 1,
               Name = "Ali",
               RollNo = 2745
           },
           new Student()
           {
               Id = 2,
               Name = "Samiullah",
               RollNo = 2746
           },
           new Student()
           {
               Id = 3,
               Name = "Adnan",
               RollNo = 2747
           }
        };

        protected void LoadStudentsGrid()
        {
           GridStudents.DataSource = studentsList;
           GridStudents.DataBind();
        }

        protected void LoadStudentsDDL()
        {
           DdlStudents.DataSource = studentsList;
           DdlStudents.DataBind();
           DdlStudents.DataTextField = "Name";
           DdlStudents.DataValueField = "Id";
           DdlStudents.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
           Student student = new Student()
           {
               Id = Int32.Parse(TxtId.Text),
               Name = TxtName.Text,
               RollNo = Int32.Parse(TxtRollNo.Text)
           };

           studentsList.Add(student);

           LabResult.Text = "Student Added Successfully!!!";
           LabResult.CssClass = "text-success";

           LoadStudentsGrid();
           LoadStudentsDDL();
           ClearFields();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
           Student stdFromList = studentsList.SingleOrDefault(x => x.Id == Int32.Parse(DdlStudents.SelectedValue));

           if (stdFromList != null)
           {
               TxtId.Text = stdFromList.Id.ToString();
               TxtName.Text = stdFromList.Name.ToString();
               TxtRollNo.Text = stdFromList.RollNo.ToString();
           }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
           Student stdFromList = studentsList.SingleOrDefault(x => x.Id == Int32.Parse(DdlStudents.SelectedValue));

           if (stdFromList != null)
           {
               stdFromList.Name = TxtName.Text;
               stdFromList.RollNo = Int32.Parse(TxtRollNo.Text);

               LabResult.Text = "Student Updated Successfully!!!";
               LabResult.CssClass = "text-success";
           }

           LoadStudentsGrid();
           LoadStudentsDDL();
           ClearFields();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
           Student stdFromList = studentsList.SingleOrDefault(x => x.Id == Int32.Parse(DdlStudents.SelectedValue));

           if (stdFromList != null)
           {
               studentsList.Remove(stdFromList);

               LabResult.Text = "Student Deleted Successfully!!!";
               LabResult.CssClass = "text-success";
           }

           LoadStudentsGrid();
           LoadStudentsDDL();
           ClearFields();
        }
    }
}