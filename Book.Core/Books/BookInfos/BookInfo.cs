
using Abp;
using Abp.Domain.Entities.Auditing;

namespace Book.Books.BookInfos
{
   public class BookInfo:FullAuditedEntity
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// 书籍数量
        /// </summary>
        public int BookNumberasd { get; set; }
    }
}
