using System.Threading.Tasks;
using Abp.Application.Services;
using Google.YouTube.Sessions.Dto;

namespace Google.YouTube.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
