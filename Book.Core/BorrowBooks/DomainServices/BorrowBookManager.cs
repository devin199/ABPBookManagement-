using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Book.Books.BorrowBooks;

namespace Book.BorrowBooks.DomainServices
{
    /// <summary>
    /// BorrowBook领域层的业务管理
    /// </summary>
    public class BorrowBookManager : BookDomainServiceBase, IBorrowBookManager
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<BorrowBook, int> _borrowbookRepository;
        /// <summary>
        /// BorrowBook的构造方法
        /// </summary>
        public BorrowBookManager(IRepository<BorrowBook, int> borrowbookRepository)
        {
            _borrowbookRepository = borrowbookRepository;
        }

        //TODO:编写领域业务代码
        /// <summary>
        ///     初始化
        /// </summary>
        public void InitBorrowBook()
        {
            throw new NotImplementedException();
        }

    }

}
