using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Google.YouTube.Authorization.Permissions.Dto;
using Google.YouTube.Web.Areas.App.Models.Common;

namespace Google.YouTube.Web.Areas.App.Models.Roles
{
    public class RoleListViewModel : IPermissionsEditViewModel
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}