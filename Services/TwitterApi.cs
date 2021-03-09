using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InterviewTask.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InterviewTask.Services
{
    public class TwitterApi : ITwitterApi
    {
        private readonly TwitterOptions _twitterOptions;
        public TwitterApi(IOptions<TwitterOptions> twitterOptions)
        {
            _twitterOptions = twitterOptions.Value;
        }
        public async Task<TimelineResponse> GetUserTimeline(int? userId = null, string paginationToken = null)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {_twitterOptions.Token}");

            string uri = $"https://api.twitter.com/2/users/{userId ?? _twitterOptions.Feeds[0].UserId}/tweets?tweet.fields=id,text,created_at";
            if (!string.IsNullOrEmpty(paginationToken))
            {
                uri += $"&pagination_token={paginationToken}";
            }

            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var twitterResponse = JsonConvert.DeserializeObject<TimelineResponse>(responseString);

            return twitterResponse;
        }

        public async Task<Tweet> GetTweet(long tweetId)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {_twitterOptions.Token}");
            string uri = $"https://api.twitter.com/2/tweets/{tweetId}";
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var twitterResponse = JsonConvert.DeserializeObject<TweetsResponse>(responseString);

            return twitterResponse.Data;
        }
    }
}