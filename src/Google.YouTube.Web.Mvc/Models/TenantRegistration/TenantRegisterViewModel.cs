using Google.YouTube.Editions;
using Google.YouTube.Editions.Dto;
using Google.YouTube.MultiTenancy.Payments;
using Google.YouTube.Security;
using Google.YouTube.MultiTenancy.Payments.Dto;

namespace Google.YouTube.Web.Models.TenantRegistration
{
    public class TenantRegisterViewModel
    {
        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public int? EditionId { get; set; }

        public SubscriptionStartType? SubscriptionStartType { get; set; }

        public EditionSelectDto Edition { get; set; }

        public EditionPaymentType EditionPaymentType { get; set; }
    }
}
