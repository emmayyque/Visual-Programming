using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace LinqToSQL_Exam_
{
    public partial class FurnitureForm : System.Web.UI.Page
    {
        HomeDBEntities db = new HomeDBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadFurnituresGrid();
                LoadFurnituresDDL();
            }
        }

        protected void ClearFields()
        {
            TxtColor.Text = "";
            TxtSeatingCapacity.Text = "";
            TxtTypeOfFurniture.Text = "";
        }

        protected void LoadFurnituresGrid()
        {
            GridFurnitures.DataSource = db.Furnitures.ToList();
            GridFurnitures.DataBind();
        }

        protected void LoadFurnituresDDL()
        {
            DdlFurniture.DataSource = db.Furnitures.ToList();
            DdlFurniture.DataBind();
            DdlFurniture.DataTextField = "type_of_furniture";
            DdlFurniture.DataValueField = "id";
            DdlFurniture.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            String TypeOfFurniture = TxtTypeOfFurniture.Text;
            String Color = TxtColor.Text;
            int SeatingCapacity = Int32.Parse(TxtSeatingCapacity.Text);

            if (TypeOfFurniture == "" || Color == "" || SeatingCapacity == 0)
            {
                LabResult.Text = "Some fields are empty";
                LabResult.CssClass = "text-danger";
            }

            else
            {
                Furniture furniture = new Furniture()
                {
                    type_of_furniture = TypeOfFurniture,
                    color = Color,
                    seating_capacity = SeatingCapacity
                };

                db.Furnitures.Add(furniture);
                db.SaveChanges();

                LabResult.Text = "Furniture added successfully";
                LabResult.CssClass = "text-success";

                LoadFurnituresDDL();
                LoadFurnituresGrid();
                ClearFields();
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlFurniture.SelectedValue);
            Furniture furnitureFromDb = db.Furnitures.SingleOrDefault(x => x.id == Id);
            
            if (furnitureFromDb != null)
            {
                TxtTypeOfFurniture.Text = furnitureFromDb.type_of_furniture;
                TxtColor.Text = furnitureFromDb.color; 
                TxtSeatingCapacity.Text = furnitureFromDb.seating_capacity.ToString();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlFurniture.SelectedValue);
            String TypeOfFurniture = TxtTypeOfFurniture.Text;
            String Color = TxtTypeOfFurniture.Text;
            int SeatingCapacity = Int32.Parse(TxtSeatingCapacity.Text);

            if (TypeOfFurniture == "" || Color == "" || SeatingCapacity == 0)
            {
                LabResult.Text = "Some fields are empty";
                LabResult.CssClass = "text-danger";
            }
            else
            {
                Furniture furnitureFromDb = db.Furnitures.SingleOrDefault(x => x.id == Id);
                if (furnitureFromDb != null)
                {
                    furnitureFromDb.type_of_furniture = TxtTypeOfFurniture.Text;
                    furnitureFromDb.color = TxtColor.Text;
                    furnitureFromDb.seating_capacity = Int32.Parse(TxtSeatingCapacity.Text);

                    db.SaveChanges();
                    LabResult.Text = "Furniture updated successfully";
                    LabResult.CssClass = "text-success";
                }

                LoadFurnituresDDL();
                LoadFurnituresGrid();
                ClearFields();
            }            
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlFurniture.SelectedValue);
            Furniture furnitureFromDb = db.Furnitures.SingleOrDefault(x => x.id == Id);
            if (furnitureFromDb != null)
            {
                db.Furnitures.Remove(furnitureFromDb);
                db.SaveChanges();

                LabResult.Text = "Furniture deleted successfully";
                LabResult.CssClass = "text-success";
            }

            LoadFurnituresDDL();
            LoadFurnituresGrid();
            ClearFields();
        }
    }
}