using System;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Google.YouTube.Web.Areas.App.Models.Countries;
using Google.YouTube.Web.Controllers;
using Google.YouTube.Authorization;
using Google.YouTube.Qing;
using Google.YouTube.Qing.Dtos;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Google.YouTube.Web.Areas.App.Controllers
{
    [Area("App")]
    [AbpMvcAuthorize(AppPermissions.Pages_Countries)]
    public class CountriesController : YouTubeControllerBase
    {
        private readonly ICountriesAppService _countriesAppService;

        public CountriesController(ICountriesAppService countriesAppService)
        {
            _countriesAppService = countriesAppService;

        }

        public ActionResult Index()
        {
            var model = new CountriesViewModel
            {
                FilterText = ""
            };

            return View(model);
        }

        [AbpMvcAuthorize(AppPermissions.Pages_Countries_Create, AppPermissions.Pages_Countries_Edit)]
        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetCountryForEditOutput getCountryForEditOutput;

            if (id.HasValue)
            {
                getCountryForEditOutput = await _countriesAppService.GetCountryForEdit(new EntityDto { Id = (int)id });
            }
            else
            {
                getCountryForEditOutput = new GetCountryForEditOutput
                {
                    Country = new CreateOrEditCountryDto()
                };
            }

            var viewModel = new CreateOrEditCountryModalViewModel()
            {
                Country = getCountryForEditOutput.Country,

            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> ViewCountryModal(int id)
        {
            var getCountryForViewDto = await _countriesAppService.GetCountryForView(id);

            var model = new CountryViewModel()
            {
                Country = getCountryForViewDto.Country
            };

            return PartialView("_ViewCountryModal", model);
        }

        public async Task<IActionResult> Import(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                if (file.ContentType != "application/json")
                {
                    return BadRequest("Only JSON files are allowed.");
                }

                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    var jsonContent = await reader.ReadToEndAsync();
                    var data = JsonConvert.DeserializeObject<List<CountryJson>>(jsonContent);

                    var countries = new List<CountryImportDto>();
                    foreach (var item in data)
                    {
                        var country = new CountryImportDto
                        {
                            Name = item.Name.Common,
                            Region = item.Region,
                            SubRegion = item.Subregion,
                            English = item.Languages.Eng == "English",
                            Latitude = item.Latlng[0],
                            Longitude = item.Latlng[1],
                            Area = item.Area,
                            CallingCodes = item.CallingCodes[0],
                            Landlocked = item.Landlocked,
                            Capital = item.Capital[0],
                            Flag = item.Flag,
                            Independent = item.Independent
                        };
                        countries.Add(country);
                    }
                    await _countriesAppService.Import(countries);

                    return Ok("File uploaded successfully.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}