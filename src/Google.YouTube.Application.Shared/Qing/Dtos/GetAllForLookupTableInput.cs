using Abp.Application.Services.Dto;

namespace Google.YouTube.Qing.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}