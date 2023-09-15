using System.Collections.Generic;
using Abp.Localization;
using Google.YouTube.Install.Dto;

namespace Google.YouTube.Web.Models.Install
{
    public class InstallViewModel
    {
        public List<ApplicationLanguage> Languages { get; set; }

        public AppSettingsJsonDto AppSettingsJson { get; set; }
    }
}
