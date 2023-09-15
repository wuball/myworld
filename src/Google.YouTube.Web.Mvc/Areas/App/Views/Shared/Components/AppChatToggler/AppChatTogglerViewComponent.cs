using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Web.Areas.App.Models.Layout;
using Google.YouTube.Web.Views;

namespace Google.YouTube.Web.Areas.App.Views.Shared.Components.AppChatToggler
{
    public class AppChatTogglerViewComponent : YouTubeViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(string cssClass, string iconClass = "flaticon-chat-2 fs-2")
        {
            return Task.FromResult<IViewComponentResult>(View(new ChatTogglerViewModel
            {
                CssClass = cssClass,
                IconClass = iconClass
            }));
        }
    }
}
