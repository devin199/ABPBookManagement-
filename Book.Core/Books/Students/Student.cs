using Abp.Domain.Entities.Auditing;
using Book.Books.BorrowBooks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Book.Books.Students
{
   public class Student: FullAuditedEntity
    {
        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [MaxLength(BookConsts.MaxStudentNameLength)]
        public string StudentName { get; set; }

        /// <summary>
        /// 学生证号码
        /// </summary>
        [Required]
        [MaxLength(BookConsts.MaxStudentNumberLength)]
        public string StudentNumber { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Range(0,100)]
        public int StudentAge { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public StudentSex StudentSex { get; set; }

        public virtual ICollection<BorrowBook> BorrowBooks { get; set; }

    }
}
