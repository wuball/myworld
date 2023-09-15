using System.Threading.Tasks;
using Abp.Application.Services;
using Google.YouTube.Configuration.Host.Dto;

namespace Google.YouTube.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
