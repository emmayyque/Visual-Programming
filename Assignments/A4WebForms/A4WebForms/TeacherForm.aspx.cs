using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A4WebForms
{
    public partial class TeacherForm : System.Web.UI.Page
    {
        DbConn db = new DbConn();
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
            String Qry = "SELECT * FROM Teachers";
            DataTable dt = db.Search(Qry);
            GridTeachers.DataSource = dt;
            GridTeachers.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            String Id = TxtId.Text;
            String FirstName = TxtFirstName.Text;
            String LastName = TxtLastName.Text;
            String Experience = TxtExperience.Text;
            String Type = DdlType.Text;
            String Address = TxtAddress.Text;
            String DOB = TxtDOB.Text;
            String DOJ = TxtDOJ.Text;

            String Qry = "INSERT INTO Teachers (id, first_name, last_name, experience, type, address, date_of_birth, date_of_joining) VALUES ('" + Id + "', '" + FirstName + "', '" + LastName + "', '" + Experience + "', '" + Type + "', '" + Address + "', '" + DOB + "', '" + DOJ + "')";

            if (db.UDI(Qry))
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
            String Id = TxtId.Text;

            String Qry = "SELECT * FROM Teachers WHERE id = '"+ Id +"'";
            DataTable dt = db.Search(Qry);
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
            String Id = TxtId.Text;
            String FirstName = TxtFirstName.Text;
            String LastName = TxtLastName.Text;
            String Experience = TxtExperience.Text;
            String Type = DdlType.Text;
            String Address = TxtAddress.Text;
            String DOB = TxtDOB.Text;
            String DOJ = TxtDOJ.Text;

            String Qry = "UPDATE Teachers SET first_name = '"+ FirstName +"', last_name = '"+ LastName +"', experience = '"+ Experience +"', type = '"+ Type +"', address = '"+ Address +"', date_of_birth = '"+ DOB +"', date_of_joining = '"+ DOJ +"' WHERE id = '"+ Id +"'";

            if (db.UDI(Qry))
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
            String Id = TxtId.Text;
            String Qry = "DELETE FROM Teachers WHERE id = '"+ Id +"'";

            if (db.UDI(Qry))
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