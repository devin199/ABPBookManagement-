using System.ComponentModel.DataAnnotations;
using Book.Book.Students.Dtos.LTMAutoMapper;
using Book.Books.Students;
using Abp.Application.Services.Dto;

namespace Book.Book.Students.Dtos
{
    public class StudentEditDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public int? Id { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public int StudentAge { get; set; }
        public StudentSex StudentSex { get; set; }
    }
}