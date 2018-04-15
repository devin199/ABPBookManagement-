
using Abp;
using Abp.Domain.Entities.Auditing;

namespace Book.Books.BookInfos
{
   public class BookInfo:FullAuditedEntity
    {
        public string BookName { get; set; }

        public string Author { get; set; }

        public int BookNumber { get; set; }
    }
}
