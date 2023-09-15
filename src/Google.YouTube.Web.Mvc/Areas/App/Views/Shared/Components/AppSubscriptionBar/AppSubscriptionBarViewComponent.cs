using System.Threading.Tasks;
using Abp.Configuration;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Configuration;
using Google.YouTube.Web.Areas.App.Models.Layout;
using Google.YouTube.Web.Session;
using Google.YouTube.Web.Views;

namespace Google.YouTube.Web.Areas.App.Views.Shared.Components.AppSubscriptionBar
{
    public class AppSubscriptionBarViewComponent : YouTubeViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppSubscriptionBarViewComponent(
            IPerRequestSessionCache sessionCache)
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string cssClass = "btn btn-icon btn-active-light-primary position-relative w-30px h-30px w-md-40px h-md-40px me-2")
        {
            var model = new SubscriptionBarViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                SubscriptionExpireNotifyDayCount = SettingManager.GetSettingValue<int>(AppSettings.TenantManagement.SubscriptionExpireNotifyDayCount),
                CssClass = cssClass
            };

            return View(model);
        }

    }
}
