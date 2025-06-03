using A13ConsumeWebAPIsDotNetMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace A13ConsumeWebAPIsDotNetMVC.Controllers
{
    public class UserController : Controller
    {
        private static String Url = "https://jsonplaceholder.typicode.com/users";
        private readonly Uri uri = new Uri(Url);
        private HttpClient _httpClient;

        public UserController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = uri;
        }

        // GET: UserController
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                String json = response.Content.ReadAsStringAsync().Result;
                List<User> users = JsonConvert.DeserializeObject<List<User>>(json);
                return View(users);
            }

            return View(null);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
