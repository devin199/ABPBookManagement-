using System.Threading.Tasks;
using Abp.Application.Services;
using Book.Sessions.Dto;

namespace Book.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
