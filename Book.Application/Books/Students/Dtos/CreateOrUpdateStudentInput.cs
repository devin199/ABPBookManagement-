using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Book.Books.Students;

namespace Book.Book.Students.Dtos
{
    public class CreateOrUpdateStudentInput
{
////BCC/ BEGIN CUSTOM CODE SECTION
////ECC/ END CUSTOM CODE SECTION
        [Required]
        public StudentEditDto Student { get; set; }

}
}