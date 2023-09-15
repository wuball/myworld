using System.Threading.Tasks;
using Abp.Application.Services;
using Google.YouTube.MultiTenancy.Payments.Dto;
using Google.YouTube.MultiTenancy.Payments.Stripe.Dto;

namespace Google.YouTube.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}