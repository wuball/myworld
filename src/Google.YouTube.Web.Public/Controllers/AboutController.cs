using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Web.Controllers;

namespace Google.YouTube.Web.Public.Controllers
{
    public class AboutController : YouTubeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}