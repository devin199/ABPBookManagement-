using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Book.MultiTenancy.Dto;

namespace Book.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
