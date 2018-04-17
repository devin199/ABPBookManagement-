using Abp.Domain.Entities.Auditing;
using Book.Books.BookInfos;
using Book.Books.Students;
using System;
using System.ComponentModel.DataAnnotations;
namespace Book.Books.BorrowBooks
{
   public class BorrowBook : FullAuditedEntity
    {
        [Required]
        public virtual int BookInfoId { get; set; }

        [Required]
        public virtual int StudentId { get; set; }

        [Required]
        public BorrowBookStatus BorrowBookStatus { get; set; }

        public DateTime BorrowTime { get; set; }

        public DateTime ReturnTime { get; set; }

        public Student Student { get; set; }

        public BookInfo BookInfo { get; set; }

    }
}
