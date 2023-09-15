using Abp.Application.Services.Dto;
using Abp.Webhooks;
using Google.YouTube.WebHooks.Dto;

namespace Google.YouTube.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
