using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Google.YouTube.Web.Public.Views
{
    public abstract class YouTubeRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected YouTubeRazorPage()
        {
            LocalizationSourceName = YouTubeConsts.LocalizationSourceName;
        }
    }
}
