using Newtonsoft.Json;

namespace A13ConsumeWebAPIsDotNetMVC.Models.Entities
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
