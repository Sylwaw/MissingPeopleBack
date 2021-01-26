using AutoMapper;
using MissingPeople.Core.Dtos.Dictionaries.Cities;
using MissingPeople.Core.Entities.Dictionaries;

namespace MissingPeople.Core.Helpers.MapperProfile.Dictionaries
{
    public class DictCityProfile:Profile
    {
        public DictCityProfile()
        {
            CreateMap<DictCity,CityDto>();
        }
    }
}