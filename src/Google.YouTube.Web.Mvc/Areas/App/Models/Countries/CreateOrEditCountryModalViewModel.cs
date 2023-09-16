using Google.YouTube.Qing.Dtos;

using Abp.Extensions;

namespace Google.YouTube.Web.Areas.App.Models.Countries
{
    public class CreateOrEditCountryModalViewModel
    {
        public CreateOrEditCountryDto Country { get; set; }

        public bool IsEditMode => Country.Id.HasValue;
    }
}