using Abp.AspNetCore.Mvc.ViewComponents;

namespace Google.YouTube.Web.Public.Views
{
    public abstract class YouTubeViewComponent : AbpViewComponent
    {
        protected YouTubeViewComponent()
        {
            LocalizationSourceName = YouTubeConsts.LocalizationSourceName;
        }
    }
}