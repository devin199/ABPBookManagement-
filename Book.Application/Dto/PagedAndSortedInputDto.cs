using Abp.Application.Services.Dto;
using Book.Books.BookInfos;

namespace Book.Dto
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        public string Sorting { get; set; }

        public PagedAndSortedInputDto()
        {
            MaxResultCount = BookConsts.DefaultPageSize;
        }
    }
}