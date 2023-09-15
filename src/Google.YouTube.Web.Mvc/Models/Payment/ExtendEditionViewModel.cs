using System.Collections.Generic;
using Google.YouTube.Editions.Dto;
using Google.YouTube.MultiTenancy.Payments;

namespace Google.YouTube.Web.Models.Payment
{
    public class ExtendEditionViewModel
    {
        public EditionSelectDto Edition { get; set; }

        public List<PaymentGatewayModel> PaymentGateways { get; set; }
    }
}