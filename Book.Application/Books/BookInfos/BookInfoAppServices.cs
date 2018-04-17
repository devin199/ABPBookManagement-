using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using System.Data.Entity;

using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;

using Book.BookInfos.Authorization;
using Book.BookInfos.Dtos;
using Book.BookInfos.DomainServices;
using Book.Books.BookInfos;

namespace Book.BookInfos
{
    /// <summary>
    /// BookInfo应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(BookInfoAppPermissions.BookInfo)]
    public class BookInfoAppService : BookAppServiceBase, IBookInfoAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<BookInfo, int> _bookinfoRepository;
        private readonly IBookInfoManager _bookinfoManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public BookInfoAppService(IRepository<BookInfo, int> bookinfoRepository
      , IBookInfoManager bookinfoManager
        )
        {
            _bookinfoRepository = bookinfoRepository;
            _bookinfoManager = bookinfoManager;
        }

        /// <summary>
        /// 获取BookInfo的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<BookInfoListDto>> GetPagedBookInfos(GetBookInfosInput input)
        {

            var query = _bookinfoRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var bookinfoCount = await query.CountAsync();

            var bookinfos = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var bookinfoListDtos = ObjectMapper.Map<List <BookInfoListDto>>(bookinfos);
            var bookinfoListDtos = bookinfos.MapTo<List<BookInfoListDto>>();

            return new PagedResultDto<BookInfoListDto>(
                bookinfoCount,
                bookinfoListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取BookInfoListDto信息
        /// </summary>
        public async Task<BookInfoListDto> GetBookInfoByIdAsync(EntityDto<int> input)
        {
            var entity = await _bookinfoRepository.GetAsync(input.Id);

            return entity.MapTo<BookInfoListDto>();
        }

        /// <summary>
        /// 导出BookInfo为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetBookInfosToExcel(){
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
        public async Task<GetBookInfoForEditOutput> GetBookInfoForEdit(NullableIdDto<int> input)
        {
            var output = new GetBookInfoForEditOutput();
            BookInfoEditDto bookinfoEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _bookinfoRepository.GetAsync(input.Id.Value);

                bookinfoEditDto = entity.MapTo<BookInfoEditDto>();

                //bookinfoEditDto = ObjectMapper.Map<List <bookinfoEditDto>>(entity);
            }
            else
            {
                bookinfoEditDto = new BookInfoEditDto();
            }

            output.BookInfo = bookinfoEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改BookInfo的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateBookInfo(CreateOrUpdateBookInfoInput input)
        {

            if (input.BookInfo.Id.HasValue)
            {
                await UpdateBookInfoAsync(input.BookInfo);
            }
            else
            {
                await CreateBookInfoAsync(input.BookInfo);
            }
        }

        /// <summary>
        /// 新增BookInfo
        /// </summary>
        [AbpAuthorize(BookInfoAppPermissions.BookInfo_CreateBookInfo)]
        protected virtual async Task<BookInfoEditDto> CreateBookInfoAsync(BookInfoEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<BookInfo>(input);

            entity = await _bookinfoRepository.InsertAsync(entity);
            return entity.MapTo<BookInfoEditDto>();
        }

        /// <summary>
        /// 编辑BookInfo
        /// </summary>
        [AbpAuthorize(BookInfoAppPermissions.BookInfo_EditBookInfo)]
        protected virtual async Task UpdateBookInfoAsync(BookInfoEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _bookinfoRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _bookinfoRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除BookInfo信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(BookInfoAppPermissions.BookInfo_DeleteBookInfo)]
        public async Task DeleteBookInfo(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _bookinfoRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除BookInfo的方法
        /// </summary>
        [AbpAuthorize(BookInfoAppPermissions.BookInfo_BatchDeleteBookInfos)]
        public async Task BatchDeleteBookInfosAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _bookinfoRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

