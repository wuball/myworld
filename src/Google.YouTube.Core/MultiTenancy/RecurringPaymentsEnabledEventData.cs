using Abp.Events.Bus;

namespace Google.YouTube.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}