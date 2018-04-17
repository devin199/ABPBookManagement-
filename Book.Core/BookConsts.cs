namespace Book
{
    public class BookConsts
    {
        public const string LocalizationSourceName = "Book-zh-CN";

        public const bool MultiTenancyEnabled = false;
        public const int MaxPageSize = 30;
        public const int DefaultPageSize = 10;

        #region 数据注解 
        public const int MaxBookNameLength = 50;
        public const int MaxAuthorLength = 50;

        public const int MaxStudentNameLength = 50;
        public const int MaxStudentNumberLength = 6;
        #endregion
    }
}