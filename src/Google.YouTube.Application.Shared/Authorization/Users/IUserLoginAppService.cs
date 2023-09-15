using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Google.YouTube.Authorization.Users.Dto;

namespace Google.YouTube.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<PagedResultDto<UserLoginAttemptDto>> GetUserLoginAttempts(GetLoginAttemptsInput input);
    }
}
