using Abp.Auditing;
using Google.YouTube.Configuration.Dto;

namespace Google.YouTube.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}