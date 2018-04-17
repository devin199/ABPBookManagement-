using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using Book.Authorization.Roles;
using Book.Authorization.Users;
using Book.Book.Students.Dtos.LTMAutoMapper;
using Book.BookInfos.Authorization;
using Book.BookInfos.Dtos.LTMAutoMapper;
using Book.Books.BorrowBooks.Dtos.LTMAutoMapper;
using Book.BorrowBooks.Authorization;
using Book.Roles.Dto;
using Book.Students.Authorization;
using Book.Users.Dto;

namespace Book
{
    [DependsOn(typeof(BookCoreModule), typeof(AbpAutoMapperModule))]
    public class BookApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerStudentMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerBookInfoMapper.CreateMappings);
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerBorrowBookMapper.CreateMappings);
            Configuration.Authorization.Providers.Add<BookInfoAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<StudentAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<BorrowBookAppAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            });
        }
    }
}
