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

        //zwraca listê miast, ktorych nazwy zaczynaj¹ siê od wprowadzonej wartoœci
        [HttpGet("citiesByIncludeSource")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCitiesByIncludeSource(string value)
        {
            return new JsonResult(await cityService.GetCitiesByIncludeSourceAsync(value));
        }

        //zwraca id miasta po nazwie
        [HttpGet("cityByName")]
        public async Task<ActionResult<CityDto>> GetCityByName(string value)
        {
            return new JsonResult(await cityService.GetCityByName(value));
        }

        [HttpGet("cityById")]
        public async Task<ActionResult<CityDto>> GetCityById(int id)
        {
            return new JsonResult(await cityService.GetCityByID(id));
        }
    }
}