﻿using Newtonsoft.Json;

namespace ConsumeWebAPIsByLinqToJson.Models.Entities
{
    public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("email")]
        public String Email { get; set; }
        [JsonProperty("body")]
        public String Body { get; set; }
        [JsonProperty("postId")]
        public int PostId { get; set; }
    }
}
