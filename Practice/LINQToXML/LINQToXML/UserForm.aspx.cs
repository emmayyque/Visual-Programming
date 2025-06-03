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
    public partial class UserForm : System.Web.UI.Page
    {
        XDocument xDoc;
        String FilePath = "C:\\Users\\Muhammad Ali Khalil\\source\\repos\\BSVP\\LinqToXML\\LinqToXML\\Users.xml";
        protected void Page_Load(object sender, EventArgs e)
        {
            xDoc = XDocument.Load(FilePath);
            if (!IsPostBack)
            {
                LoadGridView();
                LoadDropDownList();
            }
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            xDoc.Element("Users").Add(
                new XElement("User",
                    new XAttribute("Id", TxtID.Text),
                    new XElement("Name", TxtFullName.Text),
                    new XElement("Email", TxtEmail.Text),
                    new XElement("Username", TxtUsername.Text),
                    new XElement("Password", TxtPassword.Text),
                    new XElement("Role", TxtRole.Text)
                )
            );
            xDoc.Save(FilePath);
            LoadGridView();
            LoadDropDownList();
            ClearFields();
        }

        protected void ClearFields()
        {
            TxtID.Text = "";
            TxtFullName.Text = "";
            TxtEmail.Text = "";
            TxtUsername.Text = "";
            TxtPassword.Text = "";
            TxtRole.Text = "";
        }

        protected void LoadGridView()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            GridUsers.DataSource = ds;
            GridUsers.DataBind();
        }

        protected void LoadDropDownList()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(FilePath);
            DdlUsers.DataSource = ds;
            DdlUsers.DataBind();
            DdlUsers.DataTextField = "Name";
            DdlUsers.DataValueField = "Id";
            DdlUsers.DataBind();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            String Id = DdlUsers.SelectedValue.ToString();
            var User = xDoc.Descendants("User").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            User.Element("Name").Value = TxtFullName.Text;
            User.Element("Email").Value = TxtEmail.Text;
            User.Element("Username").Value = TxtUsername.Text;
            User.Element("Password").Value = TxtPassword.Text;
            User.Element("Role").Value = TxtRole.Text;
            xDoc.Save(FilePath);
            LoadGridView();
            LoadDropDownList();
            ClearFields();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            String Id = DdlUsers.SelectedValue.ToString();
            var User = xDoc.Descendants("User").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            User.Remove();
            xDoc.Save(FilePath);
            LoadGridView();
            LoadDropDownList();
            ClearFields();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            String Id = DdlUsers.SelectedValue.ToString();
            var User = xDoc.Descendants("User").SingleOrDefault(x => x.Attribute("Id").Value == Id);
            TxtID.Text = User.Attribute("Id").Value;
            TxtFullName.Text = User.Element("Name").Value;
            TxtEmail.Text = User.Element("Email").Value;
            TxtUsername.Text = User.Element("Username").Value;
            TxtPassword.Text = User.Element("Password").Value;
            TxtRole.Text = User.Element("Role").Value;
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}