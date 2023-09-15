using Abp.Domain.Services;

namespace Google.YouTube
{
    public abstract class YouTubeDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected YouTubeDomainServiceBase()
        {
            LocalizationSourceName = YouTubeConsts.LocalizationSourceName;
        }
    }
}
