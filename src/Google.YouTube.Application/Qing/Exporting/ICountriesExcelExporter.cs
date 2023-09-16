using System.Collections.Generic;
using Google.YouTube.Qing.Dtos;
using Google.YouTube.Dto;

namespace Google.YouTube.Qing.Exporting
{
    public interface ICountriesExcelExporter
    {
        FileDto ExportToFile(List<GetCountryForViewDto> countries);
    }
}