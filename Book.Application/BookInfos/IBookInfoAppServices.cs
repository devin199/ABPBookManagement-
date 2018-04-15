using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Book.BookInfos.Dtos;
using Book.Books.BookInfos;

namespace Book.BookInfos
{
    /// <summary>
    /// BookInfo应用层服务的接口方法
    /// </summary>
    public interface IBookInfoAppService : IApplicationService
    {
        /// <summary>
        /// 获取BookInfo的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BookInfoListDto>> GetPagedBookInfos(GetBookInfosInput input);

        /// <summary>
        /// 通过指定id获取BookInfoListDto信息
        /// </summary>
        Task<BookInfoListDto> GetBookInfoByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出BookInfo为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetBookInfosToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBookInfoForEditOutput> GetBookInfoForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetBookInfoForEditOutput
        /// <summary>
        /// 添加或者修改BookInfo的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateBookInfo(CreateOrUpdateBookInfoInput input);

        /// <summary>
        /// 删除BookInfo信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteBookInfo(EntityDto<int> input);

        /// <summary>
        /// 批量删除BookInfo
        /// </summary>
        Task BatchDeleteBookInfosAsync(List<int> input);
    }
}
