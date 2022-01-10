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
        //gdzie to doda³eœ ten serwis?
    }
}