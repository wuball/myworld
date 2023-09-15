using System.Threading.Tasks;
using Abp.Application.Services;
using Google.YouTube.Configuration.Tenants.Dto;

namespace Google.YouTube.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
