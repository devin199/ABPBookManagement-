using Abp.Authorization;
using Book.Authorization.Roles;
using Book.Authorization.Users;

namespace Book.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
