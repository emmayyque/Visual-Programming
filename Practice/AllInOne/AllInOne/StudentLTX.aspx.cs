using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace AllInOne
{
    public partial class StudentLTX : System.Web.UI.Page
    {
        private String FilePath = "C:\\Users\\Muhammad Ali Khalil\\source\\repos\\BSVP\\AllInOne\\AllInOne\\Students.xml";
        private XDocument xDoc;
        protected void Page_Load(object sender, EventArgs e)
        {
            xDoc = XDocument.Load(FilePath);
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

        protected void LoadStudentsGrid()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            GridStudents.DataSource = ds;
            GridStudents.DataBind();
        }

        protected void LoadStudentsDDL()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            DdlStudents.DataSource = ds;
            DdlStudents.DataBind();
            DdlStudents.DataTextField = "Name";
            DdlStudents.DataValueField = "Id";
            DdlStudents.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            xDoc.Element("Students").Add(
                new XElement("Student",
                    new XAttribute("Id", TxtId.Text),
                    new XElement("Name", TxtName.Text),
                    new XElement("RollNo", TxtRollNo.Text)
                )
            );

            xDoc.Save(FilePath);
            LabResult.Text = "Student Added Successfully!!";
            LabResult.CssClass = "text-success";

            LoadStudentsDDL();
            LoadStudentsGrid();
            ClearFields();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            String Id = DdlStudents.SelectedValue;
            var stdFromXml = xDoc.Descendants("Student").SingleOrDefault(x => x.Attribute("Id").Value == Id);

            if (stdFromXml != null)
            {
                TxtId.Text = stdFromXml.Attribute("Id").Value;
                TxtName.Text = stdFromXml.Element("Name").Value;
                TxtRollNo.Text = stdFromXml.Element("RollNo").Value;
            }
        }
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            String Id = DdlStudents.SelectedValue;
            var stdFromXml = xDoc.Descendants("Student").SingleOrDefault(x => x.Attribute("Id").Value == Id);

            if (stdFromXml != null)
            {
                stdFromXml.Element("Name").Value = TxtName.Text;
                stdFromXml.Element("RollNo").Value = TxtRollNo.Text;

                xDoc.Save(FilePath);
                LabResult.Text = "Student Updated Successfully!!";
                LabResult.CssClass = "text-success";
            }

            LoadStudentsDDL();
            LoadStudentsGrid();
            ClearFields();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            String Id = DdlStudents.SelectedValue;
            var stdFromXml = xDoc.Descendants("Student").SingleOrDefault(x => x.Attribute("Id").Value == Id);

            if (stdFromXml != null)
            {
                stdFromXml.Remove();
                xDoc.Save(FilePath);
                LabResult.Text = "Student Deleted Successfully!!";
                LabResult.CssClass = "text-success";
            }

            LoadStudentsDDL();
            LoadStudentsGrid();
            ClearFields();
        }
    }
}