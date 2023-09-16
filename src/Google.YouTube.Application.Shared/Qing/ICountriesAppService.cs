using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Google.YouTube.Qing.Dtos;
using Google.YouTube.Dto;
using System.Collections.Generic;

namespace Google.YouTube.Qing
{
    public interface ICountriesAppService : IApplicationService
    {
        Task<PagedResultDto<GetCountryForViewDto>> GetAll(GetAllCountriesInput input);

        Task<GetCountryForViewDto> GetCountryForView(int id);

        Task<GetCountryForEditOutput> GetCountryForEdit(EntityDto input);

        Task CreateOrEdit(CreateOrEditCountryDto input);

        Task Delete(EntityDto input);

        Task<FileDto> GetCountriesToExcel(GetAllCountriesForExcelInput input);

        Task Import(List<CountryImportDto> input);
    }
}