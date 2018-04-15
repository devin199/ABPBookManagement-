using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Book.Configuration.Dto;

namespace Book.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BookAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
