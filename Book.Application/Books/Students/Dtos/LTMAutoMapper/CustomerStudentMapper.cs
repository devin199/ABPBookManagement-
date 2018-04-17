using AutoMapper;
using Book.Books.Students;

namespace Book.Book.Students.Dtos.LTMAutoMapper
{
    /// <summary>
    /// 配置Student的AutoMapper
    /// </summary>
    internal static class CustomerStudentMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <Student, StudentDto>();
            configuration.CreateMap<Student, StudentListDto>();
            configuration.CreateMap<StudentEditDto, Student>();
            // configuration.CreateMap<CreateStudentInput, Student>();
            //        configuration.CreateMap<Student, GetStudentForEditOutput>();
        }
    }
}