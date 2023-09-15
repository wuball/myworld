using System.ComponentModel.DataAnnotations;

namespace Google.YouTube.Authorization.Accounts.Dto
{
    public class SendEmailActivationLinkInput
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}