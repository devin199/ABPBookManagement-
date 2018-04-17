using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Book.Books.BorrowBooks;

namespace Book.Books.BorrowBooks.Dtos
{
    public class CreateOrUpdateBorrowBookInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public BorrowBookEditDto BorrowBook { get; set; }

}
}