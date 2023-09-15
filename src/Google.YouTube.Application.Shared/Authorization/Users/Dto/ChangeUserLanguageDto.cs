using System.ComponentModel.DataAnnotations;

namespace Google.YouTube.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
