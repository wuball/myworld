using System.Threading.Tasks;
using Abp.Webhooks;

namespace Google.YouTube.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
