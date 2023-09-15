using Abp.Application.Services;
using Google.YouTube.Dto;
using Google.YouTube.Logging.Dto;

namespace Google.YouTube.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
