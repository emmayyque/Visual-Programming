using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ConsumeWebAPIsDotNetMVC.Models
{
    public class Todo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public String Title { get; set; }
        [JsonProperty("complete")]
        public bool Completed { get; set; }
        [JsonProperty("userId")]
        public int UserId { get; set; }
    }
}
