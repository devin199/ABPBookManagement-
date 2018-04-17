using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using System.Linq;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System.Data.Entity;
using System.Linq.Dynamic;
using Book.BorrowBooks.Authorization;
using Book.BorrowBooks.DomainServices;
using Book.Books.BorrowBooks;
using Book.Books.BorrowBooks.Dtos;
using System.Linq.Dynamic.Core;

namespace Book.BorrowBooks
{
    /// <summary>
    /// BorrowBook应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(BorrowBookAppPermissions.BorrowBook)]
    public class BorrowBookAppService : BookAppServiceBase, IBorrowBookAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<BorrowBook, int> _borrowbookRepository;
        private readonly IBorrowBookManager _borrowbookManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BorrowBookAppService(IRepository<BorrowBook, int> borrowbookRepository
            , IBorrowBookManager borrowbookManager
        )
        {
            _borrowbookRepository = borrowbookRepository;
            _borrowbookManager = borrowbookManager;
        }

        /// <summary>
        /// 获取BorrowBook的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<BorrowBookListDto>> GetPagedBorrowBooks(GetBorrowBooksInput input)
        {

            var query = _borrowbookRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var borrowbookCount = await query.CountAsync();

            var borrowbooks = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var borrowbookListDtos = ObjectMapper.Map<List <BorrowBookListDto>>(borrowbooks);
            var borrowbookListDtos = borrowbooks.MapTo<List<BorrowBookListDto>>();

            return new PagedResultDto<BorrowBookListDto>(
                borrowbookCount,
                borrowbookListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取BorrowBookListDto信息
        /// </summary>
        public async Task<BorrowBookListDto> GetBorrowBookByIdAsync(EntityDto<int> input)
        {
            var entity = await _borrowbookRepository.GetAsync(input.Id);

            return entity.MapTo<BorrowBookListDto>();
        }

        /// <summary>
        /// 导出BorrowBook为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetBorrowBooksToExcel(){
        //var users = await UserManager.Users.ToListAsync();
        //var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
        //await FillRoleNames(userListDtos);
        //return _userListExcelExporter.ExportToFile(userListDtos);
        //}
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetBorrowBookForEditOutput> GetBorrowBookForEdit(NullableIdDto<int> input)
        {
            var output = new GetBorrowBookForEditOutput();
            BorrowBookEditDto borrowbookEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _borrowbookRepository.GetAsync(input.Id.Value);

                borrowbookEditDto = entity.MapTo<BorrowBookEditDto>();

                //borrowbookEditDto = ObjectMapper.Map<List <borrowbookEditDto>>(entity);
            }
            else
            {
                borrowbookEditDto = new BorrowBookEditDto();
            }

            output.BorrowBook = borrowbookEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改BorrowBook的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateBorrowBook(CreateOrUpdateBorrowBookInput input)
        {

            if (input.BorrowBook.Id.HasValue)
            {
                await UpdateBorrowBookAsync(input.BorrowBook);
            }
            else
            {
                await CreateBorrowBookAsync(input.BorrowBook);
            }
        }

        /// <summary>
        /// 新增BorrowBook
        /// </summary>
        [AbpAuthorize(BorrowBookAppPermissions.BorrowBook_CreateBorrowBook)]
        protected virtual async Task<BorrowBookEditDto> CreateBorrowBookAsync(BorrowBookEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<BorrowBook>(input);

            entity = await _borrowbookRepository.InsertAsync(entity);
            return entity.MapTo<BorrowBookEditDto>();
        }

        /// <summary>
        /// 编辑BorrowBook
        /// </summary>
        [AbpAuthorize(BorrowBookAppPermissions.BorrowBook_EditBorrowBook)]
        protected virtual async Task UpdateBorrowBookAsync(BorrowBookEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _borrowbookRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _borrowbookRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除BorrowBook信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(BorrowBookAppPermissions.BorrowBook_DeleteBorrowBook)]
        public async Task DeleteBorrowBook(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _borrowbookRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除BorrowBook的方法
        /// </summary>
        [AbpAuthorize(BorrowBookAppPermissions.BorrowBook_BatchDeleteBorrowBooks)]
        public async Task BatchDeleteBorrowBooksAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _borrowbookRepository.DeleteAsync(s => input.Contains(s.Id));
        }


        Task<BorrowBookListDto> IBorrowBookAppService.GetBorrowBookByIdAsync(EntityDto<int> input)
        {
            throw new System.NotImplementedException();
        }

        Task<GetBorrowBookForEditOutput> IBorrowBookAppService.GetBorrowBookForEdit(NullableIdDto<int> input)
        {
            throw new System.NotImplementedException();
        }
    }
}

