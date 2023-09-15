using Abp.AutoMapper;
using Google.YouTube.MultiTenancy;
using Google.YouTube.MultiTenancy.Dto;
using Google.YouTube.Web.Areas.App.Models.Common;

namespace Google.YouTube.Web.Areas.App.Models.Tenants
{
    [AutoMapFrom(typeof (GetTenantFeaturesEditOutput))]
    public class TenantFeaturesEditViewModel : GetTenantFeaturesEditOutput, IFeatureEditViewModel
    {
        public Tenant Tenant { get; set; }
    }
}