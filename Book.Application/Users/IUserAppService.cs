using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Book.Roles.Dto;
using Book.Users.Dto;

namespace Book.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}