using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A9aLinqToObject
{
    public partial class DepartmentForm : System.Web.UI.Page
    {
        EntitiesList entitiesList = new EntitiesList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDeptGrid();
                LoadDeptDDL();
            }
        }

        protected void ClearFields()
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtNoOfEmp.Text = "";
            TxtLocation.Text = "";
            LabResult.Text = "";
            DdlDepts.Enabled = true;
        }

        protected void LoadDeptGrid()
        {
            DataGridDepts.DataSource = entitiesList.deptList;
            DataGridDepts.DataBind();
        }

        protected void LoadDeptDDL()
        {
            DdlDepts.DataSource = entitiesList.deptList;
            DdlDepts.DataBind();
            DdlDepts.DataTextField = "name"; 
            DdlDepts.DataValueField = "id";
            DdlDepts.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Department department = new Department()
            {
                Id = Int32.Parse(TxtId.Text),
                Name = TxtName.Text,
                NoOfEmployees = Int32.Parse(TxtNoOfEmp.Text),
                Location = TxtLocation.Text,
            };

            entitiesList.deptList.Add(department);

            LabResult.Text = "Department Added Successfully!!";
            LabResult.CssClass = "text-success";

            LoadDeptGrid();
            LoadDeptDDL();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Department deptFromList = entitiesList.deptList.SingleOrDefault(x => x.Id == Int32.Parse(DdlDepts.SelectedValue));
            if (deptFromList != null)
            {
                deptFromList.Name = TxtName.Text;
                deptFromList.Location = TxtLocation.Text;
                deptFromList.NoOfEmployees = Int32.Parse(TxtNoOfEmp.Text);

                LabResult.Text = "Department Updated Successfully!!";
                LabResult.CssClass = "text-success";
            }
            LoadDeptGrid();
            LoadDeptDDL();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Department deptFromList = entitiesList.deptList.SingleOrDefault(x => x.Id == Int32.Parse(DdlDepts.SelectedValue));
            if (deptFromList != null)
            {
                DdlDepts.Enabled = false;
                TxtName.Text = deptFromList.Name.ToString();
                TxtNoOfEmp.Text = deptFromList.NoOfEmployees.ToString();
                TxtLocation.Text = deptFromList.Location.ToString();
            }

            LabResult.Text = "";
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Department deptFromList = entitiesList.deptList.SingleOrDefault(x => x.Id == Int32.Parse(DdlDepts.SelectedValue));
            if (deptFromList != null)
            {
                entitiesList.deptList.Remove(deptFromList);
                LabResult.Text = "Department Deleted Successfully!!";
                LabResult.CssClass = "text-success";
            }
            LoadDeptGrid();
            LoadDeptDDL();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}