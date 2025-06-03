using AppProps;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A7StockManSys
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            LoadProductsGrid();
            LoadProductsCB();
        }

        public void ClearFields()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtBrand.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
        }

        public void LoadProductsGrid()
        {
            DataTable dt = new ProductBLL().GetProducts();
            GridProducts.DataSource = dt;
        }

        public void LoadProductsCB()
        {
            DataTable dt = new ProductBLL().GetProducts();
            cbProducts.DataSource = dt;
            cbProducts.DisplayMember = "name";
            cbProducts.ValueMember = "id";
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = Int32.Parse(txtId.Text),
                Name = txtName.Text,
                Brand = txtBrand.Text,
                Price = Int32.Parse(txtPrice.Text),
                Quantity = Int32.Parse(txtQuantity.Text)
            };

            if (new ProductBLL().InsertProductBLL(product))
            {
                MessageBox.Show("Product Inserted Successfully!!!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Error!!\nInserting Product!!!");
            }
            LoadProductsCB();
            LoadProductsGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = Int32.Parse(txtId.Text),
                Name = txtName.Text,
                Brand = txtBrand.Text,
                Price = Int32.Parse(txtPrice.Text),
                Quantity = Int32.Parse(txtQuantity.Text)
            };

            if (new ProductBLL().UpdateProductBLL(product))
            {
                MessageBox.Show("Product Updated Successfully!!!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Error!!\nUpdating Product!!!");
            }
            LoadProductsCB();
            LoadProductsGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = Int32.Parse(cbProducts.SelectedValue.ToString())
            };

            if (new ProductBLL().DeleteProductBLL(product))
            {
                MessageBox.Show("Product Deleted Successfully!!!");
                ClearFields();
            }
            else
            {
                MessageBox.Show("Error!!\nDeleting Product!!!");
            }
            LoadProductsCB();
            LoadProductsGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = Int32.Parse(cbProducts.SelectedValue.ToString())
            };

            DataTable dt = new ProductBLL().GetProduct(product);
            if (dt.Rows.Count > 0)
            {
                txtId.Text = dt.Rows[0]["id"].ToString();
                txtName.Text = dt.Rows[0]["name"].ToString();
                txtBrand.Text = dt.Rows[0]["brand"].ToString();
                txtPrice.Text = dt.Rows[0]["price"].ToString();
                txtQuantity.Text = dt.Rows[0]["quantity"].ToString();
            }
            else
            {
                MessageBox.Show("Invalid Product Id");
            }
        }
    }
}
