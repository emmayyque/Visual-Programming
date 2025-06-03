using ConsumeWebAPIsDotNetMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeWebAPIsDotNetMVC.Controllers
{
    public class PostController : Controller
    {
        private static String Url = "https://jsonplaceholder.typicode.com/posts";
        private Uri uri = new Uri(Url);
        private HttpClient _httpClient;

        public PostController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = uri;
        }

        // GET: PostController
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                String json = response.Content.ReadAsStringAsync().Result;
                List<Post> post = JsonConvert.DeserializeObject<List<Post>>(json);
                return View(post);
            }

            return View(null);
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
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

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
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

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
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
