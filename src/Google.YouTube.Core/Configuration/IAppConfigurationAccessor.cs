using Microsoft.Extensions.Configuration;

namespace Google.YouTube.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
