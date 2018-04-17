
using Abp;
using Abp.Domain.Entities.Auditing;
using Book.Books.BorrowBooks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Book.Books.BookInfos
{
   public class BookInfo:FullAuditedEntity
    {
        /// <summary>
        /// 书名
        /// </summary>
        [MaxLength(BookConsts.MaxBookNameLength)]
        [Required]
        public string BookName { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        [MaxLength(BookConsts.MaxAuthorLength)]
        public string Author { get; set; }

        /// <summary>
        /// 书籍数量
        /// </summary>
        [Range(1,100)]
        public int BookNumber { get; set; }

        public virtual ICollection<BorrowBook> BorrowBooks { get; set; }
    }
}
