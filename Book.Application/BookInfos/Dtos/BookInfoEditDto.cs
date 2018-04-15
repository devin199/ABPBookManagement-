using System.ComponentModel.DataAnnotations;
using Book.BookInfos.Dtos.LTMAutoMapper;
using Book.Books.BookInfos;

namespace Book.BookInfos.Dtos
{
    public class BookInfoEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int BookNumber { get; set; }
    }
}