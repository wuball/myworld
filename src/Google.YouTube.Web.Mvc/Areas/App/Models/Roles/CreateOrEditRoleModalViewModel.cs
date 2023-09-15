using Abp.AutoMapper;
using Google.YouTube.Authorization.Roles.Dto;
using Google.YouTube.Web.Areas.App.Models.Common;

namespace Google.YouTube.Web.Areas.App.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode => Role.Id.HasValue;
    }
}