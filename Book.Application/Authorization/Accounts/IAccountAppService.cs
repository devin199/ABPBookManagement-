using System.Threading.Tasks;
using Abp.Application.Services;
using Book.Authorization.Accounts.Dto;

namespace Book.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
