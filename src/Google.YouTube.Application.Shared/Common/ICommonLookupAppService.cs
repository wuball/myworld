using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Google.YouTube.Common.Dto;
using Google.YouTube.Editions.Dto;

namespace Google.YouTube.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}