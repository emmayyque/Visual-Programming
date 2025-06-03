
using Newtonsoft.Json;

namespace ConsumeWebAPIsByLinqToJson.Models.Entities
{
    public class Todo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
