using System.Collections.Generic;
using System.Threading.Tasks;
using MissingPeople.Core.Dtos.Dictionaries.Cities;

namespace MissingPeople.Core.Interfaces.Dictionaries
{
    public interface ICityService
    {
        /// <summary>
        /// Pobieranie miast na podstawie nazwy 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Task<IEnumerable<CityDto>> GetCitiesByIncludeSourceAsync(string value);
        Task<CityDto> GetCityByName(string nameCity);

        Task<CityDto> GetCityByID(int id);

        Task<CityDto> GetCityByNameAndProvince(string provinceName);
    }
}