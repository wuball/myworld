using Abp.AspNetCore.Mvc.ViewComponents;

namespace Google.YouTube.Web.Views
{
    public abstract class YouTubeViewComponent : AbpViewComponent
    {
        protected YouTubeViewComponent()
        {
            LocalizationSourceName = YouTubeConsts.LocalizationSourceName;
        }
    }
}