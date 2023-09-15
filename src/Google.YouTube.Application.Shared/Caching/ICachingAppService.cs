using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Google.YouTube.Caching.Dto;

namespace Google.YouTube.Caching
{
    public interface ICachingAppService : IApplicationService
    {
        ListResultDto<CacheDto> GetAllCaches();

        Task ClearCache(EntityDto<string> input);

        Task ClearAllCaches();
    }
}
