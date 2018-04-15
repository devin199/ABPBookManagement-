using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Book.Authorization;
using Book.Books.BookInfos;

namespace Book.BookInfos.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BookInfoAppPermissions"/> for all permission names.
    /// </summary>
    public class BookInfoAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了BookInfo 的权限。
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == PermissionNames.Pages_Administration)
                            ?? pages.CreateChildPermission(PermissionNames.Pages_Administration, L("Administration"));

            var bookinfo = administration.CreateChildPermission(BookInfoAppPermissions.BookInfo, L("BookInfo"));
            bookinfo.CreateChildPermission(BookInfoAppPermissions.BookInfo_CreateBookInfo, L("CreateBookInfo"));
            bookinfo.CreateChildPermission(BookInfoAppPermissions.BookInfo_EditBookInfo, L("EditBookInfo"));
            bookinfo.CreateChildPermission(BookInfoAppPermissions.BookInfo_DeleteBookInfo, L("DeleteBookInfo"));
            bookinfo.CreateChildPermission(BookInfoAppPermissions.BookInfo_BatchDeleteBookInfos, L("BatchDeleteBookInfos"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BookConsts.LocalizationSourceName);
        }
    }

}