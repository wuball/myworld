using System.ComponentModel.DataAnnotations;

namespace Google.YouTube.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}