using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MissingPeople.Core.Dtos.Dictionaries.Cities;
using MissingPeople.Core.Interfaces.Dictionaries;

namespace MissingPeople.Api.Controllers.Dictionaries
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController:Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        //zwraca list� miast, ktorych nazwy zaczynaj� si� od wprowadzonej warto�ci
        [HttpGet("citiesByIncludeSource")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCitiesByIncludeSource(string value)
        {
            return new JsonResult(await cityService.GetCitiesByIncludeSourceAsync(value));
        }

        //zwraca id miasta po nazwie
        [HttpGet("cityByName/{value}")]
        public async Task<ActionResult<CityDto>> GetCityByName(string value)
        {
            var city = value.ToLower();
            return new JsonResult(await cityService.GetCityByName(city));
        }

        [HttpGet("cityById")]
        public async Task<ActionResult<CityDto>> GetCityById(int id)
        {
            return new JsonResult(await cityService.GetCityByID(id));
        }

        [HttpGet("cityByNameAndProvince")]
        public async Task<ActionResult<CityDto>> GetCityByNameAndProvince(string province)
        {
            return new JsonResult(await cityService.GetCityByNameAndProvince(province));
        }

    }
}