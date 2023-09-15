using System.Threading.Tasks;

namespace Google.YouTube.Net.Sms
{
    public interface ISmsSender
    {
        Task SendAsync(string number, string message);
    }
}