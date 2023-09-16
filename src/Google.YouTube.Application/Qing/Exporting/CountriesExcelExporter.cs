using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Google.YouTube.DataExporting.Excel.NPOI;
using Google.YouTube.Qing.Dtos;
using Google.YouTube.Dto;
using Google.YouTube.Storage;

namespace Google.YouTube.Qing.Exporting
{
    public class CountriesExcelExporter : NpoiExcelExporterBase, ICountriesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CountriesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetCountryForViewDto> countries)
        {
            return CreateExcelPackage(
                    "Countries.xlsx",
                    excelPackage =>
                    {

                        var sheet = excelPackage.CreateSheet(L("Countries"));

                        AddHeader(
                            sheet,
                        L("Name"),
                        L("Region"),
                        L("SubRegion"),
                        L("English"),
                        L("Latitude"),
                        L("Longitude"),
                        L("Area"),
                        L("CallingCodes"),
                        L("Landlocked"),
                        L("Capital"),
                        L("Flag"),
                        L("Independent"),
                        L("Organization"),
                        L("Visa"),
                        L("Extradition"),
                        L("Repatriate"),
                        L("WorkingVisa"),
                        L("ProAmerican"),
                        L("Birthright")
                            );

                        AddObjects(
                            sheet, countries,
                        _ => _.Country.Name,
                        _ => _.Country.Region,
                        _ => _.Country.SubRegion,
                        _ => _.Country.English,
                        _ => _.Country.Latitude,
                        _ => _.Country.Longitude,
                        _ => _.Country.Area,
                        _ => _.Country.CallingCodes,
                        _ => _.Country.Landlocked,
                        _ => _.Country.Capital,
                        _ => _.Country.Flag,
                        _ => _.Country.Independent,
                        _ => _.Country.Organization,
                        _ => _.Country.Visa,
                        _ => _.Country.Extradition,
                        _ => _.Country.Repatriate,
                        _ => _.Country.WorkingVisa,
                        _ => _.Country.ProAmerican,
                        _ => _.Country.Birthright
                            );

                    });

        }
    }
}