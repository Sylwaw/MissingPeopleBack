using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissingPeople.Core.Dtos.Dictionaries.Cities;
using MissingPeople.Core.Interfaces.Dictionaries;

namespace MissingPeople.Api.Controllers.Dictionaries
{
    public class CityController:Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet("citiesByIncludeSource")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCitiesByIncludeSource(string value)
        {
            return new JsonResult(await cityService.GetCitiesByIncludeSourceAsync(value));
        }
    }
}