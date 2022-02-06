using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MissingPeople.Core.Dtos.Dictionaries.Cities;
using MissingPeople.Core.Entities.Dictionaries;
using MissingPeople.Core.Interfaces.Dictionaries;
using MissingPeople.Core.Interfaces.Repository;

namespace MissingPeople.Core.Services.Dictionaries
{
    public class CityService : ICityService
    {
        private readonly IRepositoryBase<DictCity> repository;
        private readonly IMapper mapper;

        public CityService(IRepositoryBase<DictCity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetCitiesByIncludeSourceAsync(string value)
        {
            var cities = repository.GetByFunc(s => s.Name.ToLower().StartsWith(value.ToLower()));

            return mapper.Map<IEnumerable<CityDto>>(await cities.ToListAsync());
        }

        public async Task<CityDto> GetCityByName(string nameCity)
        {
            var city = await repository.GetByFunc(s => s.Name.ToLower() == nameCity).FirstOrDefaultAsync();
            return mapper.Map<CityDto>(city);
        }

        public async Task<CityDto> GetCityByID(int id)
        {
            var city = await repository.GetByFunc(s => s.Id == id).FirstOrDefaultAsync();
            return mapper.Map<CityDto>(city);
        }
    //    public async Task<CityDto> GetCityByID(int id)
    //    {
    //        var entity = await repository.GetByFunc(s => s.Id == id).Include(s => s.Provinces).FirstOrDefaultAsync();

    //        var city = new CityDto
    //        {
    //            Id = entity.Id,
    //            Name = entity.Name,
    //            DecimalLatitude = entity.DecimalLatitude,
    //            DecimalLongitude = entity.DecimalLongitude,
    //            ProvinceName = entity.Provinces.Name,
    //};
    //        return mapper.Map<CityDto>(city);
    //    }

        public async Task<CityDto> GetCityByNameAndProvince(string provinceName)
        {
            var city = await repository.GetByFunc(s => s.Provinces.Name.ToLower() == provinceName).FirstOrDefaultAsync();

            return mapper.Map<CityDto>(city);
        }





    }
}