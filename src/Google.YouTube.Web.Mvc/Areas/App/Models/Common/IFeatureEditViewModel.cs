using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Google.YouTube.Editions.Dto;

namespace Google.YouTube.Web.Areas.App.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}