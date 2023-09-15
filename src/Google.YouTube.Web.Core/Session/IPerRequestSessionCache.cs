using System.Threading.Tasks;
using Google.YouTube.Sessions.Dto;

namespace Google.YouTube.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
