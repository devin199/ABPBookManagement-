using System.Threading.Tasks;
using Abp.Application.Services;
using Book.Configuration.Dto;

namespace Book.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}