using System.Threading.Tasks;
using Abp.Authorization.Users;
using Google.YouTube.Authorization.Users;

namespace Google.YouTube.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
