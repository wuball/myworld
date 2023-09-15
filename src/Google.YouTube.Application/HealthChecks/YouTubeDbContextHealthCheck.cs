using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Google.YouTube.EntityFrameworkCore;

namespace Google.YouTube.HealthChecks
{
    public class YouTubeDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public YouTubeDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("YouTubeDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("YouTubeDbContext could not connect to database"));
        }
    }
}
