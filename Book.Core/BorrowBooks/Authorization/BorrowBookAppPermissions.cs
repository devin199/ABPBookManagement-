using Book.Books.BorrowBooks;

namespace Book.BorrowBooks.Authorization
{
    /// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="BorrowBookAppAuthorizationProvider"/>中对权限的定义.
    /// </summary>
    public static class BorrowBookAppPermissions
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION

        /// <summary>
        /// BorrowBook管理权限_自带查询授权
        /// </summary>
        public const string BorrowBook = "Pages.BorrowBook";

        /// <summary>
        /// BorrowBook创建权限
        /// </summary>
        public const string BorrowBook_CreateBorrowBook = "Pages.BorrowBook.CreateBorrowBook";
        /// <summary>
        /// BorrowBook修改权限
        /// </summary>
        public const string BorrowBook_EditBorrowBook = "Pages.BorrowBook.EditBorrowBook";
        /// <summary>
        /// BorrowBook删除权限
        /// </summary>
        public const string BorrowBook_DeleteBorrowBook = "Pages.BorrowBook.DeleteBorrowBook";

        /// <summary>
        /// BorrowBook批量删除权限
        /// </summary>
        public const string BorrowBook_BatchDeleteBorrowBooks = "Pages.BorrowBook.BatchDeleteBorrowBooks";

    }

}

