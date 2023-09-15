using System.Collections.Generic;
using Google.YouTube.Editions.Dto;

namespace Google.YouTube.Web.Areas.App.Models.Tenants
{
    public class TenantIndexViewModel
    {
        public List<SubscribableEditionComboboxItemDto> EditionItems { get; set; }
    }
}