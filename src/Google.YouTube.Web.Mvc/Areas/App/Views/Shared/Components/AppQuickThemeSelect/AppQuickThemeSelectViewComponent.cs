using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Web.Areas.App.Models.Layout;
using Google.YouTube.Web.Views;

namespace Google.YouTube.Web.Areas.App.Views.Shared.Components.
    AppQuickThemeSelect
{
    public class AppQuickThemeSelectViewComponent : YouTubeViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass, string iconClass = "flaticon-interface-7 fs-2")
        {
            return Task.FromResult<IViewComponentResult>(View(new QuickThemeSelectionViewModel
            {
                CssClass = cssClass,
                IconClass = iconClass
            }));
        }
    }
}
