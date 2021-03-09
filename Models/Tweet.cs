using System;
using Newtonsoft.Json;

namespace InterviewTask.Models
{
    public class Tweet
    {
        public long Id { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        public string UserName { get; set; }

        public string ScreenName { get; set; }

        public string Text { get; set; }
    }
}