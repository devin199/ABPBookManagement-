using System.Collections.Generic;
using Book.Roles.Dto;
using Book.Users.Dto;

namespace Book.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}