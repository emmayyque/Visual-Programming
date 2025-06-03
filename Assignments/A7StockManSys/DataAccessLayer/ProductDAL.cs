using AppProps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAL
    {
        DbConn db = new DbConn();

        public bool InsertProductDAL(Product product)
        {
            String Qry = "INSERT INTO Products (id, name, brand, price, quantity) VALUES ('" + product.Id + "', '" + product.Name + "', '" + product.Brand + "', '" + product.Price + "', '" + product.Quantity + "')";
            return db.UDI(Qry);
        }

        public bool UpdateProductDAL(Product product)
        {
            String Qry = "UPDATE Products SET name = '" + product.Name + "', brand = '" + product.Brand + "', price = '" + product.Price + "', quantity = '" + product.Quantity + "' WHERE id = '" + product.Id + "'";
            return db.UDI(Qry);
        }

        public bool DeleteProductDAL(Product product)
        {
            String Qry = "DELETE FROM Products WHERE id = '" + product.Id + "'";
            return db.UDI(Qry);
        }

        public DataTable GetProducts()
        {
            String Qry = "SELECT * FROM Products";
            return db.Search(Qry);
        }

        public DataTable GetProduct(Product product)
        {
            String Qry = "SELECT * FROM Products WHERE id = '" + product.Id + "'";
            return db.Search(Qry);
        }
    }
}
