﻿using System;
using Abp.Application.Services.Dto;

namespace Google.YouTube.Qing.Dtos
{
    public class CountryDto : EntityDto
    {
        public string Name { get; set; }

        public string Region { get; set; }

        public string SubRegion { get; set; }

        public bool English { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Area { get; set; }

        public string CallingCodes { get; set; }

        public bool Landlocked { get; set; }

        public string Capital { get; set; }

        public string Flag { get; set; }

        public bool Independent { get; set; }

        public string Organization { get; set; }

        public string Visa { get; set; }

        public string Extradition { get; set; }

        public string Repatriate { get; set; }

        public string WorkingVisa { get; set; }

        public bool ProAmerican { get; set; }

        public bool Birthright { get; set; }

    }

    public class CountryImportDto : CountryDto { }
}