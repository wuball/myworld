using Abp.Application.Services.Dto;
using System;

namespace Google.YouTube.Qing.Dtos
{
    public class GetAllCountriesForExcelInput
    {
        public string Filter { get; set; }

        public string NameFilter { get; set; }

        public string RegionFilter { get; set; }

        public string SubRegionFilter { get; set; }

        public int? EnglishFilter { get; set; }

        public double? MaxLatitudeFilter { get; set; }
        public double? MinLatitudeFilter { get; set; }

        public double? MaxLongitudeFilter { get; set; }
        public double? MinLongitudeFilter { get; set; }

        public int? MaxAreaFilter { get; set; }
        public int? MinAreaFilter { get; set; }

        public string CallingCodesFilter { get; set; }

        public int? LandlockedFilter { get; set; }

        public string CapitalFilter { get; set; }

        public string FlagFilter { get; set; }

        public int? IndependentFilter { get; set; }

        public string OrganizationFilter { get; set; }

        public string VisaFilter { get; set; }

        public string ExtraditionFilter { get; set; }

        public string RepatriateFilter { get; set; }

        public string WorkingVisaFilter { get; set; }

        public int? ProAmericanFilter { get; set; }

        public int? BirthrightFilter { get; set; }

    }
}