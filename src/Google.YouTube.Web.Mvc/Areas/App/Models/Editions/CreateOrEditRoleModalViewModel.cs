using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Google.YouTube.Editions.Dto;
using Google.YouTube.Web.Areas.App.Models.Common;

namespace Google.YouTube.Web.Areas.App.Models.Editions
{
    [AutoMapFrom(typeof(GetEditionEditOutput))]
    public class CreateEditionModalViewModel : GetEditionEditOutput, IFeatureEditViewModel
    {
        public IReadOnlyList<ComboboxItemDto> EditionItems { get; set; }

        public IReadOnlyList<ComboboxItemDto> FreeEditionItems { get; set; }
    }
}