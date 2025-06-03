using DotNetCoreWebAPIs.Models;
using DotNetCoreWebAPIs.Models.Entities;
using DotNetCoreWebAPIs.Repository;

namespace DotNetCoreWebAPIs.Data
{
    public class ProductDataManager : IDataRepository<Product>
    {
        private readonly ApplicationDbContext db;
        public ProductDataManager(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(Product entity)
        {
            db.Products.Add(entity);
            db.SaveChanges();
        }

        public void Delete(Product entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            var Products = db.Products.ToList();
            return Products;
        }

        public Product GetById(int id)
        {
            var Product = db.Products.SingleOrDefault(x => x.Id == id);
            return Product;
        }

        public void Update(Product dbEntity, Product entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Description = entity.Description;
            dbEntity.Quantity = entity.Quantity;

            db.SaveChanges();
        }
    }
}
