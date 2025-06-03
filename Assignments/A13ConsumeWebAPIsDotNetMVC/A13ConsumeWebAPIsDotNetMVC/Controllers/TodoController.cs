using A13ConsumeWebAPIsDotNetMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace A13ConsumeWebAPIsDotNetMVC.Controllers
{
    public class TodoController : Controller
    {
        private static String Url = "https://jsonplaceholder.typicode.com/todos";
        private Uri uri = new Uri(Url);
        private HttpClient _httpClient;

        public TodoController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = uri;
        }

        // GET: TodoController
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                String json = response.Content.ReadAsStringAsync().Result;
                List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(json);
                return View(todos);
            }
            return View(null);
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoController/Create
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

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoController/Edit/5
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

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoController/Delete/5
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
