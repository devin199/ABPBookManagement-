using System;
using Abp.Application.Services.Dto;
using Book.BookInfos.Dtos.LTMAutoMapper;
using Book.Books.BookInfos;

namespace Book.BookInfos.Dtos
{
    public class BookInfoListDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string BookName { get; set; }
        public string Author { get; set; }
        public int BookNumber { get; set; }
    }
}