using A13ConsumeWebAPIsDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace A13ConsumeWebAPIsDotNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public List<EndPoint> endPoints = new List<EndPoint>
            {
                new EndPoint
                {
                    Name = "Albums",
                    Controller = "Album",
                },
                new EndPoint
                {
                    Name = "Comments",
                    Controller = "Comment",
                },
                new EndPoint
                {
                    Name = "Photos",
                    Controller = "Photo",
                },
                new EndPoint
                {
                    Name = "Posts",
                    Controller = "Post",
                },
                new EndPoint
                {
                    Name = "Todos",
                    Controller = "Todo",
                },
                new EndPoint
                {
                    Name = "Users",
                    Controller = "User",
                }
            };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {            
            return View(endPoints);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
