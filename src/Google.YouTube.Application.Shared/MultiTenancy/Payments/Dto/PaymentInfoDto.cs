using Google.YouTube.Editions.Dto;

namespace Google.YouTube.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }

        public bool IsLessThanMinimumUpgradePaymentAmount()
        {
            return AdditionalPrice < YouTubeConsts.MinimumUpgradePaymentAmount;
        }
    }
}
