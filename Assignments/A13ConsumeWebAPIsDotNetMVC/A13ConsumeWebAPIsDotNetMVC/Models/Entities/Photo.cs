using Newtonsoft.Json;

namespace A13ConsumeWebAPIsDotNetMVC.Models.Entities
{
    public class Photo
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public String Title { get; set; }
        [JsonProperty("url")]
        public String Url { get; set; }
        [JsonProperty("thumbnailUrl")]
        public String ThumbnailUrl { get; set; }
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }

    }
}