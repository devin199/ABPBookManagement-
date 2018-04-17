using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Book.Books.BorrowBooks;

namespace Book.Books.BorrowBooks.Dtos
{
    public class GetBorrowBookForEditOutput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        public BorrowBookEditDto BorrowBook { get; set; }

}
}