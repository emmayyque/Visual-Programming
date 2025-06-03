using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace LINQToXML
{
    public partial class EmployeesForm : System.Web.UI.Page
    {
        private String FilePath = "C:\\Users\\Muhammad Ali Khalil\\source\\repos\\BSVP\\LINQToXML\\LinqToXML\\Employees.xml";
        private XDocument xDoc;
        protected void Page_Load(object sender, EventArgs e)
        {
            xDoc = XDocument.Load(FilePath);

            if (!IsPostBack)
            {
                LoadEmployeesGrid();
                LoadEmployeesDdl();
            }
        }

        protected void ClearFields()
        {
            TxtID.Text = ""; 
            TxtFullName.Text = "";
            TxtEmail.Text = "";
            TxtAge.Text = "";            
        }

        protected void LoadEmployeesGrid()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            GridEmployees.DataSource = ds;
            GridEmployees.DataBind();
        }

        protected void LoadEmployeesDdl()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            DdlEmployees.DataSource = ds;
            DdlEmployees.DataBind();

            DdlEmployees.DataTextField = "FullName";
            DdlEmployees.DataValueField = "Id";
            DdlEmployees.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            xDoc.Element("Employees").Add(
                new XElement("Employee",
                    new XAttribute("Id", TxtID.Text),
                    new XElement("FullName", TxtFullName.Text),
                    new XElement("Email", TxtEmail.Text),
                    new XElement("Age", TxtAge.Text)
                )
            );

            xDoc.Save(FilePath);

            LoadEmployeesGrid();
            LoadEmployeesDdl();
            ClearFields();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            String Id = DdlEmployees.SelectedValue;
            var empFromXml = xDoc.Descendants("Employee").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            if (empFromXml != null )
            {
                TxtID.Text = empFromXml.Attribute("Id").Value;
                TxtFullName.Text = empFromXml.Element("FullName").Value;
                TxtEmail.Text = empFromXml.Element("Email").Value;
                TxtAge.Text = empFromXml.Element("Age").Value;
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            String Id = DdlEmployees.SelectedValue;
            var empFromXml = xDoc.Descendants("Employee").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            if (empFromXml != null )
            {
                empFromXml.Element("FullName").Value = TxtFullName.Text;
                empFromXml.Element("Email").Value = TxtEmail.Text;
                empFromXml.Element("Age").Value = TxtAge.Text;

                xDoc.Save(FilePath);
            }

            LoadEmployeesGrid();
            LoadEmployeesDdl();
            ClearFields();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            String Id = DdlEmployees.SelectedValue;
            var empFromXml = xDoc.Descendants("Employee").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            if (empFromXml != null)
            {
                empFromXml.Remove();
                xDoc.Save(FilePath);
            }

            LoadEmployeesGrid();
            LoadEmployeesDdl();
            ClearFields();
        }
    }
}