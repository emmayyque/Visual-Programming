using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace A9LinqToSQL
{
    public partial class DepartmentForm : System.Web.UI.Page
    {

        UniversityDB uniDB = new UniversityDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDataGrid();
                LoadDropDownList();
            }
        }

        protected void ClearFields()
        {
            TxtName.Text = "";
            TxtNoOfEmp.Text = "";
            TxtLocation.Text = "";
            DdlDepts.Enabled = true;
        }

        protected void LoadDataGrid()
        {
            DataGridDepts.DataSource = uniDB.Departments.ToList();
            DataGridDepts.DataBind();
        }

        protected void LoadDropDownList()
        {
            DdlDepts.DataSource = uniDB.Departments.ToList();
            DdlDepts.DataBind();
            DdlDepts.DataTextField = "name";
            DdlDepts.DataValueField = "id";
            DdlDepts.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            String Name = TxtName.Text;
            int NoOfEmp = 0;
            String Location = TxtLocation.Text;
            if (Name == "" || TxtNoOfEmp.Text == "" || Location == "")
            {
                LabResult.Text = "Error!! Some fields were empty";
                LabResult.CssClass = "text-danger";
            }
            else
            {
                NoOfEmp = Int32.Parse(TxtNoOfEmp.Text);
                Department dept = new Department()
                {
                    name = Name,
                    no_of_emp = NoOfEmp,
                    location = Location
                };
                uniDB.Departments.Add(dept);
                uniDB.SaveChanges();

                LabResult.Text = "Department added successfully !!!";
                LabResult.CssClass = "text-success";
            }
            LoadDataGrid();
            LoadDropDownList();
            ClearFields();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlDepts.SelectedValue);
            Department deptFromDb = uniDB.Departments.SingleOrDefault(x => x.id == Id);
            if (deptFromDb != null)
            {
                TxtName.Text = deptFromDb.name;
                TxtNoOfEmp.Text = deptFromDb.no_of_emp.ToString();
                TxtLocation.Text = deptFromDb.location;
                DdlDepts.Enabled = false;
            }
            else
            {
                LabResult.Text = "No Department exists with this ID!!";
                LabResult.CssClass = "text-danger";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            String Name = TxtName.Text;
            int NoOfEmp = 0;
            String Location = TxtLocation.Text;
            if (Name == "" || TxtNoOfEmp.Text == "" || Location == "")
            {
                LabResult.Text = "Error!! Some fields were empty";
                LabResult.CssClass = "text-danger";
            }
            else
            {
                int Id = Int32.Parse(DdlDepts.SelectedValue.ToString());
                NoOfEmp = Int32.Parse(TxtNoOfEmp.Text);
                Department deptFromDb = uniDB.Departments.SingleOrDefault(x => x.id == Id);

                if (deptFromDb != null)
                {
                    deptFromDb.name = Name;
                    deptFromDb.no_of_emp = NoOfEmp;
                    deptFromDb.location = Location;

                    uniDB.SaveChanges();

                    LabResult.Text = "Department updated successfully !!!";
                    LabResult.CssClass = "text-success";
                }
                else
                {
                    LabResult.Text = "No Department exists with this ID!!";
                    LabResult.CssClass = "text-danger";
                }
            }

            LoadDataGrid();
            LoadDropDownList();
            ClearFields();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlDepts.SelectedValue.ToString());
            Department deptFromDb = uniDB.Departments.SingleOrDefault(x => x.id == Id);

            if (deptFromDb != null)
            {
                uniDB.Departments.Remove(deptFromDb);
                uniDB.SaveChanges();

                LabResult.Text = "Department deleted successfully !!!";
                LabResult.CssClass = "text-success";
            }
            else
            {
                LabResult.Text = "No Department exists with this ID!!";
                LabResult.CssClass = "text-danger";
            }

            LoadDataGrid();
            LoadDropDownList();
            ClearFields();
        }
    }
}