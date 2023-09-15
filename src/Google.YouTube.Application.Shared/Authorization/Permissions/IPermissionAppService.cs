using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Google.YouTube.Authorization.Permissions.Dto;

namespace Google.YouTube.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
