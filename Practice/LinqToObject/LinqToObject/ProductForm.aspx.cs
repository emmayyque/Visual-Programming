using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinqToObject
{
    public partial class ProductForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductsGrid();
                LoadProductsDDL();
            }
        }

        protected List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Zinger Burger",
                Description = "delicious burger",
                Quantity = 10
            },
            new Product()
            {
                Id = 2,
                Name = "Chicken Tikka Pizza",
                Description = "delicious pizza",
                Quantity = 25
            },
            new Product()
            {
                Id = 3,
                Name = "String Energy Drink",
                Description = "energy drink",
                Quantity = 35
            },
            new Product()
            {
                Id = 4,
                Name = "Coke Drink",
                Description = "fizzy drink",
                Quantity = 25
            }
        };

        protected void LoadProductsGrid()
        {
            GridProducts.DataSource = products;
            GridProducts.DataBind();
        }

        protected void LoadProductsDDL()
        {
            DdlProduct.DataSource = products;
            DdlProduct.DataBind();
            DdlProduct.DataTextField = "Name";
            DdlProduct.DataValueField = "Id";
            DdlProduct.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = Int32.Parse(TxtID.Text),
                Name = TxtName.Text,
                Description = TxtDescription.Text,
                Quantity = Int32.Parse(TxtQuantity.Text)
            };

            products.Add(product);

            LabResult.Text = "Product added successfully !!";
            LabResult.CssClass = "text-success";

            LoadProductsGrid();
            LoadProductsDDL();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlProduct.SelectedValue);
            Product productFromList = products.SingleOrDefault(x => x.Id == Id);
            
            if (productFromList != null)
            {
                TxtName.Text = productFromList.Name;
                TxtDescription.Text = productFromList.Description;
                TxtQuantity.Text = productFromList.Quantity.ToString();
            }

            LabResult.Text = "";
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlProduct.SelectedValue);
            Product productFromList = products.SingleOrDefault(x => x.Id == Id);

            if (productFromList != null)
            {
                productFromList.Name = TxtName.Text;
                productFromList.Description = TxtDescription.Text;
                productFromList.Quantity = Int32.Parse(TxtQuantity.Text);
            }

            LabResult.Text = "Product updated successfully !!";
            LabResult.CssClass = "text-success";

            LoadProductsGrid();
            LoadProductsDDL();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            int Id = Int32.Parse(DdlProduct.SelectedValue);
            Product productFromList = products.SingleOrDefault(x => x.Id == Id);

            if (productFromList != null)
            {
                products.Remove(productFromList);
            }

            LabResult.Text = "Product deleted successfully !!";
            LabResult.CssClass = "text-success";

            LoadProductsGrid();
            LoadProductsDDL();
        }
    }
}