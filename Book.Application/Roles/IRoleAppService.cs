using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Book.Roles.Dto;

namespace Book.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
    }
}
