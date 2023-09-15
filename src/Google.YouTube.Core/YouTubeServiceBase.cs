using Abp;

namespace Google.YouTube
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="YouTubeDomainServiceBase"/>.
    /// For application services inherit YouTubeAppServiceBase.
    /// </summary>
    public abstract class YouTubeServiceBase : AbpServiceBase
    {
        protected YouTubeServiceBase()
        {
            LocalizationSourceName = YouTubeConsts.LocalizationSourceName;
        }
    }
}