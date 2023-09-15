using System.ComponentModel.DataAnnotations;

namespace Google.YouTube.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}