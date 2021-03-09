using System.Threading.Tasks;
using InterviewTask.Models;

namespace InterviewTask.Services
{
    public interface ITwitterApi
    {
        Task<TimelineResponse> GetUserTimeline(int? userId = null, string paginationToken = null);

        Task<Tweet> GetTweet(long tweetId);
    }
}