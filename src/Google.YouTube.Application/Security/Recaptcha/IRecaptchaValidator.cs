using System.Threading.Tasks;

namespace Google.YouTube.Security.Recaptcha
{
    public interface IRecaptchaValidator
    {
        Task ValidateAsync(string captchaResponse);
    }
}