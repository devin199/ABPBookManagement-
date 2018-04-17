using AutoMapper;
using Book.Books.BorrowBooks;
namespace Book.Books.BorrowBooks.Dtos.LTMAutoMapper
{
   

    /// <summary>
    /// 配置BorrowBook的AutoMapper
    /// </summary>
    internal static class CustomerBorrowBookMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <BorrowBook, BorrowBookDto>();
            configuration.CreateMap<BorrowBook, BorrowBookListDto>();
            configuration.CreateMap<BorrowBookEditDto, BorrowBook>();
            // configuration.CreateMap<CreateBorrowBookInput, BorrowBook>();
            //        configuration.CreateMap<BorrowBook, GetBorrowBookForEditOutput>();
        }
    }
}