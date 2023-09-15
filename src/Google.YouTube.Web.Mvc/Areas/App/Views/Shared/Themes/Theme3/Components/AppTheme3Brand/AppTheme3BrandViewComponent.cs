using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Web.Areas.App.Models.Layout;
using Google.YouTube.Web.Session;
using Google.YouTube.Web.Views;

namespace Google.YouTube.Web.Areas.App.Views.Shared.Themes.Theme3.Components.AppTheme3Brand
{
    public class AppTheme3BrandViewComponent : YouTubeViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme3BrandViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var headerModel = new HeaderViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(headerModel);
        }
    }
}
