using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Google.YouTube.MultiTenancy.Accounting.Dto;

namespace Google.YouTube.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
