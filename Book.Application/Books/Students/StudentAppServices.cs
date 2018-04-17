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
using Book.Students.Authorization;
using Book.Students.DomainServices;
using Book.Books.Students;
using Book.Book.Students.Dtos;
using System.Linq.Dynamic.Core;

namespace Book.Students
{
    /// <summary>
    /// Student应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(StudentAppPermissions.Student)]
    public class StudentAppService : BookAppServiceBase, IStudentAppService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Student, int> _studentRepository;
        private readonly IStudentManager _studentManager;

        /// <summary>
        /// 构造函数
        /// </summary>
        public StudentAppService(IRepository<Student, int> studentRepository
      , IStudentManager studentManager
        )
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
        }

        /// <summary>
        /// 获取Student的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<StudentListDto>> GetPagedStudents(GetStudentsInput input)
        {

            var query = _studentRepository.GetAll();
            //TODO:根据传入的参数添加过滤条件
            var studentCount = await query.CountAsync();

            var students = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var studentListDtos = ObjectMapper.Map<List <StudentListDto>>(students);
            var studentListDtos = students.MapTo<List<StudentListDto>>();

            return new PagedResultDto<StudentListDto>(
                studentCount,
                studentListDtos
                );

        }

        /// <summary>
        /// 通过指定id获取StudentListDto信息
        /// </summary>
        public async Task<StudentListDto> GetStudentByIdAsync(EntityDto<int> input)
        {
            var entity = await _studentRepository.GetAsync(input.Id);

            return entity.MapTo<StudentListDto>();
        }

        /// <summary>
        /// 导出Student为excel表
        /// </summary>
        /// <returns></returns>
        //public async Task<FileDto> GetStudentsToExcel(){
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
        public async Task<GetStudentForEditOutput> GetStudentForEdit(NullableIdDto<int> input)
        {
            var output = new GetStudentForEditOutput();
            StudentEditDto studentEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _studentRepository.GetAsync(input.Id.Value);

                studentEditDto = entity.MapTo<StudentEditDto>();

                //studentEditDto = ObjectMapper.Map<List <studentEditDto>>(entity);
            }
            else
            {
                studentEditDto = new StudentEditDto();
            }

            output.Student = studentEditDto;
            return output;

        }

        /// <summary>
        /// 添加或者修改Student的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdateStudent(CreateOrUpdateStudentInput input)
        {

            if (input.Student.Id.HasValue)
            {
                await UpdateStudentAsync(input.Student);
            }
            else
            {
                await CreateStudentAsync(input.Student);
            }
        }

        /// <summary>
        /// 新增Student
        /// </summary>
        [AbpAuthorize(StudentAppPermissions.Student_CreateStudent)]
        protected virtual async Task<StudentEditDto> CreateStudentAsync(StudentEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<Student>(input);

            entity = await _studentRepository.InsertAsync(entity);
            return entity.MapTo<StudentEditDto>();
        }

        /// <summary>
        /// 编辑Student
        /// </summary>
        [AbpAuthorize(StudentAppPermissions.Student_EditStudent)]
        protected virtual async Task UpdateStudentAsync(StudentEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _studentRepository.GetAsync(input.Id.Value);
            input.MapTo(entity);

            // ObjectMapper.Map(input, entity);
            await _studentRepository.UpdateAsync(entity);
        }

        /// <summary>
        /// 删除Student信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(StudentAppPermissions.Student_DeleteStudent)]
        public async Task DeleteStudent(EntityDto<int> input)
        {

            //TODO:删除前的逻辑判断，是否允许删除
            await _studentRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        /// 批量删除Student的方法
        /// </summary>
        [AbpAuthorize(StudentAppPermissions.Student_BatchDeleteStudents)]
        public async Task BatchDeleteStudentsAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _studentRepository.DeleteAsync(s => input.Contains(s.Id));
        }

    }
}

