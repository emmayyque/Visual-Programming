using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCDotNETWebApp.Models;
using MVCDotNETWebApp.Models.AddModels;
using MVCDotNETWebApp.Models.Entities;

namespace MVCDotNETWebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        public ProductController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var Products = db.Products.ToList();
            return View(Products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProduct addProduct)
        {
            try
            {
                Product product = new Product()
                {
                    Name = addProduct.Name,
                    Description = addProduct.Description,
                    Quantity = addProduct.Quantity
                };

                db.Products.Add(product);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(addProduct);
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var ProductFromDb = db.Products.SingleOrDefault(x => x.Id == id);
            if (ProductFromDb == null)
            {
                return NotFound("Product Not Found");
            }
            return View(ProductFromDb);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                var ProductFromDb = db.Products.SingleOrDefault(x => x.Id == id);
                if (ProductFromDb == null)
                {
                    return NotFound("Product Not Found");
                }

                ProductFromDb.Name = product.Name;
                ProductFromDb.Description = product.Description;
                ProductFromDb.Quantity = product.Quantity;

                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(product);
            }
        }

        //// GET: ProductController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                var ProductFromDb = db.Products.SingleOrDefault(x => x.Id == product.Id);
                if (ProductFromDb == null)
                {
                    return NotFound("Product Not Found");
                }

                db.Remove(ProductFromDb);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
