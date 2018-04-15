using Book.Books.BookInfos;

namespace Book.BookInfos.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="BookInfoAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class BookInfoAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// BookInfo管理权限_自带查询授权
        /// </summary>
        public const string BookInfo = "Pages.BookInfo";

        /// <summary>
        /// BookInfo创建权限
        /// </summary>
        public const string BookInfo_CreateBookInfo = "Pages.BookInfo.CreateBookInfo";
        /// <summary>
        /// BookInfo修改权限
        /// </summary>
        public const string BookInfo_EditBookInfo = "Pages.BookInfo.EditBookInfo";
        /// <summary>
        /// BookInfo删除权限
        /// </summary>
        public const string BookInfo_DeleteBookInfo = "Pages.BookInfo.DeleteBookInfo";

        /// <summary>
        /// BookInfo批量删除权限
        /// </summary>
        public const string BookInfo_BatchDeleteBookInfos = "Pages.BookInfo.BatchDeleteBookInfos";

    }

}

