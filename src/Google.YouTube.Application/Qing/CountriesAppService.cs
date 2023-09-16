using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Google.YouTube.Qing.Exporting;
using Google.YouTube.Qing.Dtos;
using Google.YouTube.Dto;
using Abp.Application.Services.Dto;
using Google.YouTube.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using Google.YouTube.Storage;

namespace Google.YouTube.Qing
{
    [AbpAuthorize(AppPermissions.Pages_Countries)]
    public class CountriesAppService : YouTubeAppServiceBase, ICountriesAppService
    {
        private readonly IRepository<Country> _countryRepository;
        private readonly ICountriesExcelExporter _countriesExcelExporter;

        public CountriesAppService(IRepository<Country> countryRepository, ICountriesExcelExporter countriesExcelExporter)
        {
            _countryRepository = countryRepository;
            _countriesExcelExporter = countriesExcelExporter;

        }

        public virtual async Task<PagedResultDto<GetCountryForViewDto>> GetAll(GetAllCountriesInput input)
        {

            var filteredCountries = _countryRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Region.Contains(input.Filter) || e.SubRegion.Contains(input.Filter) || e.CallingCodes.Contains(input.Filter) || e.Capital.Contains(input.Filter) || e.Flag.Contains(input.Filter) || e.Organization.Contains(input.Filter) || e.Visa.Contains(input.Filter) || e.Extradition.Contains(input.Filter) || e.Repatriate.Contains(input.Filter) || e.WorkingVisa.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RegionFilter), e => e.Region.Contains(input.RegionFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubRegionFilter), e => e.SubRegion.Contains(input.SubRegionFilter))
                        .WhereIf(input.EnglishFilter.HasValue && input.EnglishFilter > -1, e => (input.EnglishFilter == 1 && e.English) || (input.EnglishFilter == 0 && !e.English))
                        .WhereIf(input.MinLatitudeFilter != null, e => e.Latitude >= input.MinLatitudeFilter)
                        .WhereIf(input.MaxLatitudeFilter != null, e => e.Latitude <= input.MaxLatitudeFilter)
                        .WhereIf(input.MinLongitudeFilter != null, e => e.Longitude >= input.MinLongitudeFilter)
                        .WhereIf(input.MaxLongitudeFilter != null, e => e.Longitude <= input.MaxLongitudeFilter)
                        .WhereIf(input.MinAreaFilter != null, e => e.Area >= input.MinAreaFilter)
                        .WhereIf(input.MaxAreaFilter != null, e => e.Area <= input.MaxAreaFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CallingCodesFilter), e => e.CallingCodes.Contains(input.CallingCodesFilter))
                        .WhereIf(input.LandlockedFilter.HasValue && input.LandlockedFilter > -1, e => (input.LandlockedFilter == 1 && e.Landlocked) || (input.LandlockedFilter == 0 && !e.Landlocked))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CapitalFilter), e => e.Capital.Contains(input.CapitalFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FlagFilter), e => e.Flag.Contains(input.FlagFilter))
                        .WhereIf(input.IndependentFilter.HasValue && input.IndependentFilter > -1, e => (input.IndependentFilter == 1 && e.Independent) || (input.IndependentFilter == 0 && !e.Independent))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OrganizationFilter), e => e.Organization.Contains(input.OrganizationFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.VisaFilter), e => e.Visa.Contains(input.VisaFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ExtraditionFilter), e => e.Extradition.Contains(input.ExtraditionFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RepatriateFilter), e => e.Repatriate.Contains(input.RepatriateFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WorkingVisaFilter), e => e.WorkingVisa.Contains(input.WorkingVisaFilter))
                        .WhereIf(input.ProAmericanFilter.HasValue && input.ProAmericanFilter > -1, e => (input.ProAmericanFilter == 1 && e.ProAmerican) || (input.ProAmericanFilter == 0 && !e.ProAmerican))
                        .WhereIf(input.BirthrightFilter.HasValue && input.BirthrightFilter > -1, e => (input.BirthrightFilter == 1 && e.Birthright) || (input.BirthrightFilter == 0 && !e.Birthright));

            var pagedAndFilteredCountries = filteredCountries
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var countries = from o in pagedAndFilteredCountries
                            select new
                            {

                                o.Name,
                                o.Region,
                                o.SubRegion,
                                o.English,
                                o.Latitude,
                                o.Longitude,
                                o.Area,
                                o.CallingCodes,
                                o.Landlocked,
                                o.Capital,
                                o.Flag,
                                o.Independent,
                                o.Organization,
                                o.Visa,
                                o.Extradition,
                                o.Repatriate,
                                o.WorkingVisa,
                                o.ProAmerican,
                                o.Birthright,
                                Id = o.Id
                            };

            var totalCount = await filteredCountries.CountAsync();

            var dbList = await countries.ToListAsync();
            var results = new List<GetCountryForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetCountryForViewDto()
                {
                    Country = new CountryDto
                    {

                        Name = o.Name,
                        Region = o.Region,
                        SubRegion = o.SubRegion,
                        English = o.English,
                        Latitude = o.Latitude,
                        Longitude = o.Longitude,
                        Area = o.Area,
                        CallingCodes = o.CallingCodes,
                        Landlocked = o.Landlocked,
                        Capital = o.Capital,
                        Flag = o.Flag,
                        Independent = o.Independent,
                        Organization = o.Organization,
                        Visa = o.Visa,
                        Extradition = o.Extradition,
                        Repatriate = o.Repatriate,
                        WorkingVisa = o.WorkingVisa,
                        ProAmerican = o.ProAmerican,
                        Birthright = o.Birthright,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetCountryForViewDto>(
                totalCount,
                results
            );

        }

        public virtual async Task<GetCountryForViewDto> GetCountryForView(int id)
        {
            var country = await _countryRepository.GetAsync(id);

            var output = new GetCountryForViewDto { Country = ObjectMapper.Map<CountryDto>(country) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_Countries_Edit)]
        public virtual async Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto input)
        {
            var country = await _countryRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetCountryForEditOutput { Country = ObjectMapper.Map<CreateOrEditCountryDto>(country) };

            return output;
        }

        public virtual async Task CreateOrEdit(CreateOrEditCountryDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Countries_Create)]
        protected virtual async Task Create(CreateOrEditCountryDto input)
        {
            var country = ObjectMapper.Map<Country>(input);

            if (AbpSession.TenantId != null)
            {
                country.TenantId = (int?)AbpSession.TenantId;
            }

            await _countryRepository.InsertAsync(country);

        }

        [AbpAuthorize(AppPermissions.Pages_Countries_Edit)]
        protected virtual async Task Update(CreateOrEditCountryDto input)
        {
            var country = await _countryRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, country);

        }

        [AbpAuthorize(AppPermissions.Pages_Countries_Delete)]
        public virtual async Task Delete(EntityDto input)
        {
            await _countryRepository.DeleteAsync(input.Id);
        }

        public virtual async Task<FileDto> GetCountriesToExcel(GetAllCountriesForExcelInput input)
        {

            var filteredCountries = _countryRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Region.Contains(input.Filter) || e.SubRegion.Contains(input.Filter) || e.CallingCodes.Contains(input.Filter) || e.Capital.Contains(input.Filter) || e.Flag.Contains(input.Filter) || e.Organization.Contains(input.Filter) || e.Visa.Contains(input.Filter) || e.Extradition.Contains(input.Filter) || e.Repatriate.Contains(input.Filter) || e.WorkingVisa.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.Contains(input.NameFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RegionFilter), e => e.Region.Contains(input.RegionFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SubRegionFilter), e => e.SubRegion.Contains(input.SubRegionFilter))
                        .WhereIf(input.EnglishFilter.HasValue && input.EnglishFilter > -1, e => (input.EnglishFilter == 1 && e.English) || (input.EnglishFilter == 0 && !e.English))
                        .WhereIf(input.MinLatitudeFilter != null, e => e.Latitude >= input.MinLatitudeFilter)
                        .WhereIf(input.MaxLatitudeFilter != null, e => e.Latitude <= input.MaxLatitudeFilter)
                        .WhereIf(input.MinLongitudeFilter != null, e => e.Longitude >= input.MinLongitudeFilter)
                        .WhereIf(input.MaxLongitudeFilter != null, e => e.Longitude <= input.MaxLongitudeFilter)
                        .WhereIf(input.MinAreaFilter != null, e => e.Area >= input.MinAreaFilter)
                        .WhereIf(input.MaxAreaFilter != null, e => e.Area <= input.MaxAreaFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CallingCodesFilter), e => e.CallingCodes.Contains(input.CallingCodesFilter))
                        .WhereIf(input.LandlockedFilter.HasValue && input.LandlockedFilter > -1, e => (input.LandlockedFilter == 1 && e.Landlocked) || (input.LandlockedFilter == 0 && !e.Landlocked))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CapitalFilter), e => e.Capital.Contains(input.CapitalFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.FlagFilter), e => e.Flag.Contains(input.FlagFilter))
                        .WhereIf(input.IndependentFilter.HasValue && input.IndependentFilter > -1, e => (input.IndependentFilter == 1 && e.Independent) || (input.IndependentFilter == 0 && !e.Independent))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.OrganizationFilter), e => e.Organization.Contains(input.OrganizationFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.VisaFilter), e => e.Visa.Contains(input.VisaFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ExtraditionFilter), e => e.Extradition.Contains(input.ExtraditionFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.RepatriateFilter), e => e.Repatriate.Contains(input.RepatriateFilter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.WorkingVisaFilter), e => e.WorkingVisa.Contains(input.WorkingVisaFilter))
                        .WhereIf(input.ProAmericanFilter.HasValue && input.ProAmericanFilter > -1, e => (input.ProAmericanFilter == 1 && e.ProAmerican) || (input.ProAmericanFilter == 0 && !e.ProAmerican))
                        .WhereIf(input.BirthrightFilter.HasValue && input.BirthrightFilter > -1, e => (input.BirthrightFilter == 1 && e.Birthright) || (input.BirthrightFilter == 0 && !e.Birthright));

            var query = (from o in filteredCountries
                         select new GetCountryForViewDto()
                         {
                             Country = new CountryDto
                             {
                                 Name = o.Name,
                                 Region = o.Region,
                                 SubRegion = o.SubRegion,
                                 English = o.English,
                                 Latitude = o.Latitude,
                                 Longitude = o.Longitude,
                                 Area = o.Area,
                                 CallingCodes = o.CallingCodes,
                                 Landlocked = o.Landlocked,
                                 Capital = o.Capital,
                                 Flag = o.Flag,
                                 Independent = o.Independent,
                                 Organization = o.Organization,
                                 Visa = o.Visa,
                                 Extradition = o.Extradition,
                                 Repatriate = o.Repatriate,
                                 WorkingVisa = o.WorkingVisa,
                                 ProAmerican = o.ProAmerican,
                                 Birthright = o.Birthright,
                                 Id = o.Id
                             }
                         });

            var countryListDtos = await query.ToListAsync();

            return _countriesExcelExporter.ExportToFile(countryListDtos);
        }

        public virtual async Task Import(List<CountryImportDto> input)
        {
            var countries = ObjectMapper.Map<List<Country>>(input);

            foreach (var country in countries)
            {
                await _countryRepository.InsertAsync(country);
            }
        }
    }
}