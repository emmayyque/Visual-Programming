using Newtonsoft.Json;

namespace ConsumeWebAPIsDotNetMVC.Models
{
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("postId")]
        public int PostId { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("email")]
        public String Email { get; set; }
        [JsonProperty("body")]
        public String Body { get; set; }

        
    }
}
