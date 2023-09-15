using Abp.AspNetCore.Mvc.Authorization;
using Google.YouTube.Authorization;
using Google.YouTube.Storage;
using Abp.BackgroundJobs;
using Abp.Authorization;

namespace Google.YouTube.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}