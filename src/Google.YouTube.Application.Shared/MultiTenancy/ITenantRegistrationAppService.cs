using System.Threading.Tasks;
using Abp.Application.Services;
using Google.YouTube.Editions.Dto;
using Google.YouTube.MultiTenancy.Dto;

namespace Google.YouTube.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}