using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Authorization;
using Google.YouTube.DashboardCustomization;
using System.Threading.Tasks;
using Google.YouTube.Web.Areas.App.Startup;

namespace Google.YouTube.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Host_Dashboard)]
    public class HostDashboardController : CustomizableDashboardControllerBase
    {
        public HostDashboardController(
            DashboardViewConfiguration dashboardViewConfiguration,
            IDashboardCustomizationAppService dashboardCustomizationAppService)
            : base(dashboardViewConfiguration, dashboardCustomizationAppService)
        {

        }

        public async Task<ActionResult> Index()
        {
            return await GetView(YouTubeDashboardCustomizationConsts.DashboardNames.DefaultHostDashboard);
        }
    }
}