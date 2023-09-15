using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Web.Controllers;

namespace Google.YouTube.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize]
    public class WelcomeController : YouTubeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}