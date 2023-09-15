using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Web.Areas.App.Models.Layout;
using Google.YouTube.Web.Session;
using Google.YouTube.Web.Views;

namespace Google.YouTube.Web.Areas.App.Views.Shared.Themes.Theme12.Components.AppTheme12Footer
{
    public class AppTheme12FooterViewComponent : YouTubeViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppTheme12FooterViewComponent(IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerModel = new FooterViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync()
            };

            return View(footerModel);
        }
    }
}
