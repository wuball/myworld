using Abp.AutoMapper;
using Google.YouTube.MultiTenancy.Dto;

namespace Google.YouTube.Web.Models.TenantRegistration
{
    [AutoMapFrom(typeof(EditionsSelectOutput))]
    public class EditionsSelectViewModel : EditionsSelectOutput
    {
    }
}
