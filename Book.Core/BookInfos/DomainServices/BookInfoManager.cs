using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Book.Books.BookInfos;

namespace Book.BookInfos.DomainServices
{
    /// <summary>
    /// BookInfo领域层的业务管理
    /// </summary>
    public class BookInfoManager : BookDomainServiceBase, IBookInfoManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<BookInfo, int> _bookinfoRepository;
        /// <summary>
        /// BookInfo的构造方法
        /// </summary>
        public BookInfoManager(IRepository<BookInfo, int> bookinfoRepository)
        {
            _bookinfoRepository = bookinfoRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitBookInfo()
        {
            throw new NotImplementedException();
        }

    }

}
