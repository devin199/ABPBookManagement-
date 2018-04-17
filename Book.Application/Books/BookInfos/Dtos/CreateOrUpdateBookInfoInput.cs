using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Book.Books.BookInfos;

namespace Book.BookInfos.Dtos
{
    public class CreateOrUpdateBookInfoInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public BookInfoEditDto BookInfo { get; set; }

}
}