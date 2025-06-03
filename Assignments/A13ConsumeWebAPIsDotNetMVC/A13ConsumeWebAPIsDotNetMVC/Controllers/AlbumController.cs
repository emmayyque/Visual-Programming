using A13ConsumeWebAPIsDotNetMVC.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace A13ConsumeWebAPIsDotNetMVC.Controllers
{
    public class AlbumController : Controller
    {
        private static String Url = "https://jsonplaceholder.typicode.com/albums";
        private Uri uri = new Uri(Url);
        private HttpClient _httpClient;

        public AlbumController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = uri;
        }

        // GET: AlbumController
        public ActionResult Index()
        {
            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (response.IsSuccessStatusCode)
            {
                String json = response.Content.ReadAsStringAsync().Result;
                List<Album> albums = JsonConvert.DeserializeObject<List<Album>>(json);
                return View(albums);
            }
            return View(null);
        }

        // GET: AlbumController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlbumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlbumController/Create
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

        // GET: AlbumController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AlbumController/Edit/5
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

        // GET: AlbumController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlbumController/Delete/5
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
