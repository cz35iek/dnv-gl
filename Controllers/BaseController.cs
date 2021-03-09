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
using Microsoft.AspNetCore.Mvc.Filters;

namespace InterviewTask.Controllers
{
    public class BaseController : Controller
    {
        private readonly TwitterOptions _twitterOptions;

        public BaseController(IOptions<TwitterOptions> twitterOptions)
        {

            if (twitterOptions is null)
            {
                throw new ArgumentNullException(nameof(twitterOptions));
            }

            _twitterOptions = twitterOptions.Value;

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext is null)
            {
                throw new ArgumentNullException(nameof(filterContext));
            }

            ViewBag.Feeds = _twitterOptions.Feeds;
            base.OnActionExecuting(filterContext);
        }
    }
}
