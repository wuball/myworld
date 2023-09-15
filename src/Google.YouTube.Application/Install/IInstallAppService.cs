using System.Threading.Tasks;
using Abp.Application.Services;
using Google.YouTube.Install.Dto;

namespace Google.YouTube.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}