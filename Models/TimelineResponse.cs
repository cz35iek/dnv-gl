using Newtonsoft.Json;

namespace InterviewTask.Models
{
    public class TimelineResponse
    {
        public Tweet[] Data { get; set; }

        public Meta Meta { get; set; }
    }

    public class Meta
    {
        [JsonProperty("next_token")]
        public string NextToken { get; set; }

        [JsonProperty("previous_token")]
        public string PreviousToken { get; set; }

        [JsonProperty("result_token")]
        public int ResultCount { get; set; }
    }
}