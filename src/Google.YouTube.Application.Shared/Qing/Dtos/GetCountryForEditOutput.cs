using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Google.YouTube.Qing.Dtos
{
    public class GetCountryForEditOutput
    {
        public CreateOrEditCountryDto Country { get; set; }

    }
}