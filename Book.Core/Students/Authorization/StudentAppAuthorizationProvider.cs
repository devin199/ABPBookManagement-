using System.Linq;
using Abp.Authorization;
using Abp.Localization;
using Book.Authorization;
using Book.Books.Students;

namespace Book.Students.Authorization
{
    /// <summary>
    /// 权限配置都在这里。
    /// 给权限默认设置服务
    /// See <see cref="StudentAppPermissions"/> for all permission names.
    /// </summary>
    public class StudentAppAuthorizationProvider : AuthorizationProvider
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //在这里配置了Student 的权限。
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"));

            var administration = pages.Children.FirstOrDefault(p => p.Name == PermissionNames.Pages_Administration)
                            ?? pages.CreateChildPermission(PermissionNames.Pages_Administration, L("Administration"));

            var student = administration.CreateChildPermission(StudentAppPermissions.Student, L("Student"));
            student.CreateChildPermission(StudentAppPermissions.Student_CreateStudent, L("CreateStudent"));
            student.CreateChildPermission(StudentAppPermissions.Student_EditStudent, L("EditStudent"));
            student.CreateChildPermission(StudentAppPermissions.Student_DeleteStudent, L("DeleteStudent"));
            student.CreateChildPermission(StudentAppPermissions.Student_BatchDeleteStudents, L("BatchDeleteStudents"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BookConsts.LocalizationSourceName);
        }
    }

}