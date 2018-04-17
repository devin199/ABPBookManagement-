using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Book.Book.Students.Dtos;
using Book.Books.Students;

namespace Book.Students
{
    /// <summary>
    /// Student应用层服务的接口方法
    /// </summary>
    public interface IStudentAppService : IApplicationService
    {
        /// <summary>
        /// 获取Student的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<StudentListDto>> GetPagedStudents(GetStudentsInput input);

        /// <summary>
        /// 通过指定id获取StudentListDto信息
        /// </summary>
        Task<StudentListDto> GetStudentByIdAsync(EntityDto<int> input);

        /// <summary>
        /// 导出Student为excel表
        /// </summary>
        /// <returns></returns>
        //  Task<FileDto> GetStudentsToExcel();
        /// <summary>
        /// MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetStudentForEditOutput> GetStudentForEdit(NullableIdDto<int> input);

        //todo:缺少Dto的生成GetStudentForEditOutput
        /// <summary>
        /// 添加或者修改Student的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdateStudent(CreateOrUpdateStudentInput input);

        /// <summary>
        /// 删除Student信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteStudent(EntityDto<int> input);

        /// <summary>
        /// 批量删除Student
        /// </summary>
        Task BatchDeleteStudentsAsync(List<int> input);
    }
}
