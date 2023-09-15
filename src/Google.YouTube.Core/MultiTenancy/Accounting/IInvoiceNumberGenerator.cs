using System.Threading.Tasks;
using Abp.Dependency;

namespace Google.YouTube.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}