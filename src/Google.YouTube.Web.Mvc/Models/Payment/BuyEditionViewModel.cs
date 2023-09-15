using System.Collections.Generic;
using Google.YouTube.Editions;
using Google.YouTube.Editions.Dto;
using Google.YouTube.MultiTenancy.Payments;
using Google.YouTube.MultiTenancy.Payments.Dto;

namespace Google.YouTube.Web.Models.Payment
{
    public class BuyEditionViewModel
    {
        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public decimal? AdditionalPrice { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}
