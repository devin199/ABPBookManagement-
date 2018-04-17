using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Book.Books.BorrowBooks;

namespace Book.BorrowBooks.DomainServices
{
    public interface IBorrowBookManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitBorrowBook();

    }
}
