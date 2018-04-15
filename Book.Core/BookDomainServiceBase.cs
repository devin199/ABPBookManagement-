using Abp.Domain.Services;
using Book.Books.BookInfos;

namespace Book
{
    public abstract class BookDomainServiceBase : DomainService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        /* Add your common members for all your domain services. */
        /*在领域服务中添加你的自定义公共方法*/
        protected BookDomainServiceBase()
        {
            LocalizationSourceName = BookConsts.LocalizationSourceName;
        }
    }
}
