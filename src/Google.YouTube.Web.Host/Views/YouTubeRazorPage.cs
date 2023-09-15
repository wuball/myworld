using Abp.AspNetCore.Mvc.Views;

namespace Google.YouTube.Web.Views
{
    public abstract class YouTubeRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected YouTubeRazorPage()
        {
            LocalizationSourceName = YouTubeConsts.LocalizationSourceName;
        }
    }
}
