using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterviewTask.Models;
using InterviewTask.Services;
using Microsoft.Extensions.Options;

namespace InterviewTask.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITwitterApi _twitterApi;

        public HomeController(ILogger<HomeController> logger, ITwitterApi twitterApi, IOptions<TwitterOptions> options) : base(options)
        {
            _logger = logger;
            _twitterApi = twitterApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TwitterFeed()
        {
            var tweets = await _twitterApi.GetUserTimeline();

            return View(tweets);
        }

        public async Task<IActionResult> Tweet(long id)
        {
            var tweet = await _twitterApi.GetTweet(id);

            if (tweet != null)
            {
                return View(tweet);

            }

            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
