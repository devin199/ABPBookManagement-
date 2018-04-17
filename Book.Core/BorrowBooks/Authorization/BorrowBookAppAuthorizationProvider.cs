using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Book.Authorization;
using Book.Books.BorrowBooks;

namespace Book.BorrowBooks.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="BorrowBookAppPermissions"/> for all permission names.
    /// </summary>
    public class BorrowBookAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了BorrowBook 的权限。
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == PermissionNames.Pages_Administration)
                            ?? pages.CreateChildPermission(PermissionNames.Pages_Administration, L("Administration"));

            var borrowbook = administration.CreateChildPermission(BorrowBookAppPermissions.BorrowBook, L("BorrowBook"));
            borrowbook.CreateChildPermission(BorrowBookAppPermissions.BorrowBook_CreateBorrowBook, L("CreateBorrowBook"));
            borrowbook.CreateChildPermission(BorrowBookAppPermissions.BorrowBook_EditBorrowBook, L("EditBorrowBook"));
            borrowbook.CreateChildPermission(BorrowBookAppPermissions.BorrowBook_DeleteBorrowBook, L("DeleteBorrowBook"));
            borrowbook.CreateChildPermission(BorrowBookAppPermissions.BorrowBook_BatchDeleteBorrowBooks, L("BatchDeleteBorrowBooks"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BookConsts.LocalizationSourceName);
        }
    }

}