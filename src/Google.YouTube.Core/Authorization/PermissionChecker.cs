using Abp.Authorization;
using Google.YouTube.Authorization.Roles;
using Google.YouTube.Authorization.Users;

namespace Google.YouTube.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
