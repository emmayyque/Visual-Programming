using InventoryManagementSystem.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventoryManagementSystem.Controllers
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
    }
}
