namespace InterviewTask.Services
{
    public class TwitterOptions
    {
        public static string SectionName = "TwitterOptions";
        public string Token { get; set; }

        public FeedSettings[] Feeds { get; set; }
    }

    public class FeedSettings
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}