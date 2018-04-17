using Book.Books.Students;

namespace Book.Students.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="StudentAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class StudentAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// Student管理权限_自带查询授权
        /// </summary>
        public const string Student = "Pages.Student";

        /// <summary>
        /// Student创建权限
        /// </summary>
        public const string Student_CreateStudent = "Pages.Student.CreateStudent";
        /// <summary>
        /// Student修改权限
        /// </summary>
        public const string Student_EditStudent = "Pages.Student.EditStudent";
        /// <summary>
        /// Student删除权限
        /// </summary>
        public const string Student_DeleteStudent = "Pages.Student.DeleteStudent";

        /// <summary>
        /// Student批量删除权限
        /// </summary>
        public const string Student_BatchDeleteStudents = "Pages.Student.BatchDeleteStudents";

    }

}

