using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Book.Books.Students;

namespace Book.Students.DomainServices
{
    public interface IStudentManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitStudent();

    }
}
