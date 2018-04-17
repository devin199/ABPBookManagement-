using AutoMapper;
using Book.Books.BookInfos;
namespace Book.BookInfos.Dtos.LTMAutoMapper
{


    /// <summary>
    /// 配置BookInfo的AutoMapper
    /// </summary>
    internal static class CustomerBookInfoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //    configuration.CreateMap <BookInfo, BookInfoDto>();
            configuration.CreateMap<BookInfo, BookInfoListDto>();
            configuration.CreateMap<BookInfoEditDto, BookInfo>();
            // configuration.CreateMap<CreateBookInfoInput, BookInfo>();
            //        configuration.CreateMap<BookInfo, GetBookInfoForEditOutput>();
        }
    }
}