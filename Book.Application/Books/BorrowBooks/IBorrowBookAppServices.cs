using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Book.Books.BorrowBooks.Dtos;
using Book.Books.BorrowBooks;

namespace Book.BorrowBooks
{
    /// <summary>
    /// BorrowBook应用层服务的接口方法
    /// </summary>
    public interface IBorrowBookAppService : IApplicationService
    {
        /// <summary>
        /// 获取BorrowBook的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<BorrowBookListDto>> GetPagedBorrowBooks(GetBorrowBooksInput input);

        /// <summary>
        /// 通过指定id获取BorrowBookListDto信息
        /// </summary>
        Task<BorrowBookListDto> GetBorrowBookByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出BorrowBook为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetBorrowBooksToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetBorrowBookForEditOutput> GetBorrowBookForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetBorrowBookForEditOutput
        /// <summary>
        /// 添加或者修改BorrowBook的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateBorrowBook(CreateOrUpdateBorrowBookInput input);

        /// <summary>
        /// 删除BorrowBook信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteBorrowBook(EntityDto<int> input);

        /// <summary>
        /// 批量删除BorrowBook
        /// </summary>
        Task BatchDeleteBorrowBooksAsync(List<int> input);
    }
}
