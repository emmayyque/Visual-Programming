using ConsumeWebAPIsDotNetMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumeWebAPIsDotNetMVC.Controllers
{
    public class PhotoController : Controller
    {
        private static String Url = "https://jsonplaceholder.typicode.com/photos";
        private Uri uri = new Uri(Url);
        private HttpClient _httpClient;

        public PhotoController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = uri;
        }

        // GET: PhotoController
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                String json = response.Content.ReadAsStringAsync().Result;
                List<Photo> todos = JsonConvert.DeserializeObject<List<Photo>>(json);
                return View(todos);
            }
            return View(null);
        }

        // GET: PhotoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhotoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhotoController/Create
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

        // GET: PhotoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhotoController/Edit/5
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

        // GET: PhotoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhotoController/Delete/5
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
