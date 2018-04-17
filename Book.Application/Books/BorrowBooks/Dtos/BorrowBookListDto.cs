using System;
using Abp.Application.Services.Dto;
using Book.Books.BorrowBooks.Dtos.LTMAutoMapper;
using Book.Books.BorrowBooks;

namespace Book.Books.BorrowBooks.Dtos
{
    public class BorrowBookListDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string BookInfoId { get; set; }
        public string StudentId { get; set; }
        public BorrowBookStatus BorrowBookStatus { get; set; }
        public DateTime BorrowTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}