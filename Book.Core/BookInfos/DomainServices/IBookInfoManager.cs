using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using Book.Books.BookInfos;

namespace Book.BookInfos.DomainServices
{
    public interface IBookInfoManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        /// </summary>
        void InitBookInfo();

    }
}
