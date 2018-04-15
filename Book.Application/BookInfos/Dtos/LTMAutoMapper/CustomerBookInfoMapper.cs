using AutoMapper;

namespace Book.BookInfos.Dtos.LTMAutoMapper
{
    using Book.Books.BookInfos;

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