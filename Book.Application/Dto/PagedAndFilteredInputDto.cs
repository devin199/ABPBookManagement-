using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Book.Books.BookInfos;

namespace Book.Dto
{
    public class PagedAndFilteredInputDto : IPagedResultRequest
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        [Range(1, BookConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public string Filter { get; set; }

        public PagedAndFilteredInputDto()
        {
            MaxResultCount = BookConsts.DefaultPageSize;
        }
    }
}