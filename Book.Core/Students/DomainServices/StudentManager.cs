using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Book.Books.Students;

namespace Book.Students.DomainServices
{
    /// <summary>
    /// Student领域层的业务管理
    /// </summary>
    public class StudentManager : BookDomainServiceBase, IStudentManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Student, int> _studentRepository;
        /// <summary>
        /// Student的构造方法
        /// </summary>
        public StudentManager(IRepository<Student, int> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitStudent()
        {
            throw new NotImplementedException();
        }

    }

}
