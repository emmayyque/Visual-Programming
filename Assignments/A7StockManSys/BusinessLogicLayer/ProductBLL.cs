using AppProps;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ProductBLL
    {
        ProductDAL productDAL = new ProductDAL();

        public bool InsertProductBLL(Product product)
        {
            return productDAL.InsertProductDAL(product);
        }

        public bool UpdateProductBLL(Product product)
        {
            return productDAL.UpdateProductDAL(product);
        }

        public bool DeleteProductBLL(Product product)
        {
            return productDAL.DeleteProductDAL(product);
        }

        public DataTable GetProducts()
        {
            return productDAL.GetProducts();
        }

        public DataTable GetProduct(Product product)
        {
            return productDAL.GetProduct(product);
        }
    }
}
