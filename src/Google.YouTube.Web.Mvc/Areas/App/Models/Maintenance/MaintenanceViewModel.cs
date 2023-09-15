using System.Collections.Generic;
using Google.YouTube.Caching.Dto;

namespace Google.YouTube.Web.Areas.App.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}