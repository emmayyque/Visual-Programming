using Newtonsoft.Json;
using System.Text.Json;

namespace ConsumeWebAPIsDotNetMVC.Models
{
    public class Post
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
        [JsonProperty("title")]
        public String Title { get; set; }
        [JsonProperty("body")]
        public String Body { get; set; }
    }
}
