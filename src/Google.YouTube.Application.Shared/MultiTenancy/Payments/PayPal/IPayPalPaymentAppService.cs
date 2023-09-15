using System.Threading.Tasks;
using Abp.Application.Services;
using Google.YouTube.MultiTenancy.Payments.PayPal.Dto;

namespace Google.YouTube.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
