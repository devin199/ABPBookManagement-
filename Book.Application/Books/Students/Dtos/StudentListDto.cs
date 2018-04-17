using System;
using Abp.Application.Services.Dto;
using Book.Book.Students.Dtos.LTMAutoMapper;
using Book.Books.Students;

namespace Book.Book.Students.Dtos
{
    public class StudentListDto : FullAuditedEntityDto
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public int StudentAge { get; set; }
        public StudentSex StudentSex { get; set; }
    }
}