using System.Threading.Tasks;
using Google.YouTube.Authorization.Users;

namespace Google.YouTube.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
