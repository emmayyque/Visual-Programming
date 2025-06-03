using InventoryManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class StoreController : Controller
    {
        private readonly ApplicationDbContext db;

        public StoreController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: StoreController
        public ActionResult Index()
        {
            var products = db.Products.ToList();
            return View(products);
        }
    }
}
