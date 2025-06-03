using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AllInOne
{
    public partial class StudentLTS : System.Web.UI.Page
    {
        UniDBEntities db = new UniDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudentsGrid();
                LoadStudentsDDL();
            }
        }

        protected void ClearField()
        {
            TxtName.Text = "";
            TxtRollNo.Text = "";
        }

        protected void LoadStudentsGrid()
        {
            GridStudents.DataSource = db.Students.ToList();
            GridStudents.DataBind();
        }

        protected void LoadStudentsDDL()
        {
            DdlStudents.DataSource = db.Students.ToList();
            DdlStudents.DataBind();
            DdlStudents.DataTextField = "name";
            DdlStudents.DataValueField = "id";
            DdlStudents.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Student student = new Student()
            {
                name = TxtName.Text,
                roll_no = Int32.Parse(TxtRollNo.Text)
            };

            db.Students.Add(student);
            db.SaveChanges();

            LabResult.Text = "Student Added Successfully!!";
            LabResult.CssClass = "text-success";

            LoadStudentsDDL();
            LoadStudentsGrid();
            ClearField();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlStudents.SelectedValue);
            Student stdFromDb = db.Students.SingleOrDefault(x => x.id == Id);

            if (stdFromDb != null)
            {
                stdFromDb.name = TxtName.Text;
                stdFromDb.roll_no = Int32.Parse(TxtRollNo.Text);

                LabResult.Text = "Student Updated Successfully!!";
                LabResult.CssClass = "text-success";
            }

            LoadStudentsDDL();
            LoadStudentsGrid();
            ClearField();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlStudents.SelectedValue);
            Student stdFromDb = db.Students.SingleOrDefault(x => x.id == Id);

            if (stdFromDb != null)
            {
                db.Students.Remove(stdFromDb);
                db.SaveChanges();

                LabResult.Text = "Student Deleted Successfully!!";
                LabResult.CssClass = "text-success";
            }

            LoadStudentsDDL();
            LoadStudentsGrid();
            ClearField();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlStudents.SelectedValue);
            Student stdFromDb = db.Students.SingleOrDefault(x => x.id == Id);

            if (stdFromDb != null)
            {
                TxtName.Text = stdFromDb.name.ToString();
                TxtRollNo.Text = stdFromDb.roll_no.ToString();
            }
        }
    }
}