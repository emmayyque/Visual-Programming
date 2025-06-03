using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace A10LinqToXML
{
    public partial class DepartmentForm : System.Web.UI.Page
    {
        XDocument xDoc;
        String FilePath = "C:\\Users\\Muhammad Ali Khalil\\source\\repos\\BSVP\\A10LinqToXML\\A10LinqToXML\\Departments.xml";
        protected void Page_Load(object sender, EventArgs e)
        {
            xDoc = XDocument.Load(FilePath);
            if (!IsPostBack)
            {
                LoadDataGrid();
                LoadDropDownList();
            }
        }

        protected void LoadDataGrid()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            DataGridDepts.DataSource = ds;
            DataGridDepts.DataBind();
        }

        protected void LoadDropDownList()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            DdlDepts.DataSource = ds;
            DdlDepts.DataBind();
            DdlDepts.DataTextField = "Name";
            DdlDepts.DataValueField = "Id";
            DdlDepts.DataBind();
        }

        protected void ClearFields()
        {
            TxtId.Text = "";
            TxtName.Text = "";
            TxtNoOfEmp.Text = "";
            TxtLocation.Text = "";
            TxtId.Enabled = true;
            DdlDepts.Enabled = true;
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            String Id = TxtId.Text;
            String Name = TxtName.Text;
            String NoOfEmp = TxtNoOfEmp.Text;
            String Location = TxtLocation.Text;
            
            if (ID == "" || Name == "" || NoOfEmp == "" || Location == "")
            {
                LabResult.Text = "Error!! Some fields were empty";
                LabResult.CssClass = "text-danger";
            }
            else
            {
                xDoc.Element("Departments").Add(
                    new XElement("Department", 
                        new XAttribute("Id", Id),
                        new XElement("Name", Name),
                        new XElement("NoOfEmployees", NoOfEmp),
                        new XElement("Location", Location)
                    )
                );
                xDoc.Save(FilePath);
                LabResult.Text = "Department added successfully!!!";
                LabResult.CssClass = "text-success";
                ClearFields();
            }

            LoadDataGrid();
            LoadDropDownList();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
            LabResult.Text = "";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            String Id = DdlDepts.SelectedValue.ToString();
            var DeptFromXml = xDoc.Descendants("Department").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            if (DeptFromXml != null)
            {
                TxtId.Text = Id;
                TxtName.Text = DeptFromXml.Element("Name").Value;
                TxtNoOfEmp.Text = DeptFromXml.Element("NoOfEmployees").Value;
                TxtLocation.Text = DeptFromXml.Element("Location").Value;
                TxtId.Enabled = false;
                DdlDepts.Enabled = false;
            }
            else
            {
                LabResult.Text = "No Department exists with this ID!!!";
                LabResult.CssClass = "text-danger";
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            String Id = DdlDepts.SelectedValue.ToString();
            String Name = TxtName.Text;
            String NoOfEmp = TxtNoOfEmp.Text;
            String Location = TxtLocation.Text;

            if (Name == "" || NoOfEmp == "" || Location == "")
            {
                LabResult.Text = "Error!! Some fields were empty";
                LabResult.CssClass = "text-danger";
            }
            else
            {
                var DeptFromXml = xDoc.Descendants("Department").SingleOrDefault(x => x.Attribute("Id").Value == Id);
                if (DeptFromXml != null)
                {
                    DeptFromXml.Element("Name").Value = Name;
                    DeptFromXml.Element("NoOfEmployees").Value = NoOfEmp;
                    DeptFromXml.Element("Location").Value = Location;
                    
                    xDoc.Save(FilePath);
                    LabResult.Text = "Department updated successfully!!!";
                    LabResult.CssClass = "text-success";
                    ClearFields();
                }
                else
                {
                    LabResult.Text = "No Department exists with this ID!!!";
                    LabResult.CssClass = "text-danger";
                }
            }

            LoadDataGrid();
            LoadDropDownList();                
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            String Id = DdlDepts.SelectedValue.ToString();
            var DeptFromXml = xDoc.Descendants("Department").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            if (DeptFromXml != null)
            {
                DeptFromXml.Remove();
                xDoc.Save(FilePath);
                LabResult.Text = "Department deleted successfully!!!";
                LabResult.CssClass = "text-success";
                ClearFields();
            }
            else
            {
                LabResult.Text = "No Department exists with this ID!!!";
                LabResult.CssClass = "text-danger";
            }

            LoadDataGrid();
            LoadDropDownList();
        }
    }
}