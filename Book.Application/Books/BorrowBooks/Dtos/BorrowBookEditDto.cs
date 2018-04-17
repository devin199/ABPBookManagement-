using System.ComponentModel.DataAnnotations;
using Book.Books.BorrowBooks.Dtos.LTMAutoMapper;
using Book.Books.BorrowBooks;
using Abp.Application.Services.Dto;
using System;

namespace Book.Books.BorrowBooks.Dtos
{
    public class BorrowBookEditDto 
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        public string BookInfoId { get; set; }
        public string StudentId { get; set; }
        public BorrowBookStatus BorrowBookStatus { get; set; }
        public DateTime BorrowTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}