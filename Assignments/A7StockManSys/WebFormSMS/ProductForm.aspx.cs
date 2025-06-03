using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormSMS
{
    public partial class ProductForm : System.Web.UI.Page
    {
        SqlConnection Conn = new SqlConnection("Data Source=DESKTOP-NFEHLPT\\SQLEXPRESS;Initial Catalog=StockManSys_DB;Integrated Security=True;TrustServerCertificate=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductsGrid();
                LoadProductsDDL();
            }
        }

        protected void ClearFields()
        {
            TxtID.Text = "";
            TxtName.Text = "";
            TxtBrand.Text = "";
            TxtPrice.Text = "";
            TxtQuantity.Text = "";            
        }

        protected void LoadProductsGrid()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetProducts";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

            GridProducts.DataSource = dt;
            GridProducts.DataBind();
        }

        protected void LoadProductsDDL()
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetProducts";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

            DdlProducts.DataSource = dt;
            DdlProducts.DataBind();
            DdlProducts.DataValueField = "id";
            DdlProducts.DataTextField = "name";
            DdlProducts.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertProduct";

            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Int32.Parse(TxtID.Text);
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = TxtName.Text;
            cmd.Parameters.AddWithValue("@brand", SqlDbType.NVarChar).Value = TxtBrand.Text;
            cmd.Parameters.AddWithValue("@price", SqlDbType.Int).Value = Int32.Parse(TxtPrice.Text);
            cmd.Parameters.AddWithValue("@quantity", SqlDbType.Int).Value = Int32.Parse(TxtQuantity.Text);

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
            {
                LabResult.Text = "Product Inserted Successfully!!!";
                LabResult.CssClass = "text-success";
                ClearFields();
            }
            else
            {
                LabResult.Text = "Error, Inserting Product!!!";
                LabResult.CssClass = "text-danger";
            }

            LoadProductsGrid();
            LoadProductsDDL();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProduct";

            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Int32.Parse(TxtID.Text);
            cmd.Parameters.AddWithValue("@name", SqlDbType.NVarChar).Value = TxtName.Text;
            cmd.Parameters.AddWithValue("@brand", SqlDbType.NVarChar).Value = TxtBrand.Text;
            cmd.Parameters.AddWithValue("@price", SqlDbType.Int).Value = Int32.Parse(TxtPrice.Text);
            cmd.Parameters.AddWithValue("@quantity", SqlDbType.Int).Value = Int32.Parse(TxtQuantity.Text);

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
            {
                LabResult.Text = "Product Updated Successfully!!!";
                LabResult.CssClass = "text-success";
                ClearFields();
            }
            else
            {
                LabResult.Text = "Error, Updating Product!!!";
                LabResult.CssClass = "text-danger";
            }

            LoadProductsGrid();
            LoadProductsDDL();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteProduct";

            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Int32.Parse(DdlProducts.SelectedValue.ToString());

            bool check = cmd.ExecuteNonQuery() > 0;
            Conn.Close();

            if (check)
            {
                LabResult.Text = "Product Deleted Successfully!!!";
                LabResult.CssClass = "text-success";
                ClearFields();
            }
            else
            {
                LabResult.Text = "Error, Deleting Product!!!";
                LabResult.CssClass = "text-danger";
            }

            LoadProductsGrid();
            LoadProductsDDL();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetProduct";

            cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = Int32.Parse(DdlProducts.SelectedValue.ToString());

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Conn.Close();

            if (dt.Rows.Count > 0)
            {
                TxtID.Text = dt.Rows[0]["id"].ToString();
                TxtName.Text = dt.Rows[0]["name"].ToString();
                TxtBrand.Text = dt.Rows[0]["brand"].ToString();
                TxtPrice.Text = dt.Rows[0]["price"].ToString();
                TxtQuantity.Text = dt.Rows[0]["quantity"].ToString();
            }
            else
            {
                LabResult.Text = "Error, Invalid Product !!!";
                LabResult.CssClass = "text-danger";
            }
        }
    }
}