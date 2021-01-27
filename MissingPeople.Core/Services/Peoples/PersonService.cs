using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MissingPeople.Core.Dtos.Peoples;
using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Core.Interfaces.Repository;
using MissingPeople.Core.Interfaces;
using MissingPeople.Core.Interfaces.Peoples;
using static MissingPeople.Core.Dtos.Peoples.DisplayPersonDetailDto;

namespace MissingPeople.Core.Services.Peoples
{
    public class PersonService : IPersonService
    {
        private readonly IRepositoryBase<Person> repositoryPerson;
        private readonly IPictureService pictureService;
        private readonly IMapper mapper;

        public PersonService(IRepositoryBase<Person> repositoryPerson, IMapper mapper, IPictureService pictureService)
        {
            this.repositoryPerson = repositoryPerson;
            this.pictureService = pictureService;
            this.mapper = mapper;
        }

        public async Task<DisplayPersonDetailDto> GetPersonByIdAsync(int id)
        {
            var entity = await repositoryPerson.GetByFunc(s => s.Id == id)
                .Include(s => s.DangerOfLife)
                .Include(s => s.Pictures)
                .Include(s => s.Description)
                .Include(s => s.Detail)
                .Include(s => s.LastLocation)
                    .ThenInclude(s => s.City)
                .Include(s => s.Disappearance)
                .Include(s => s.Features)
                    .ThenInclude(s => s.DictFeature)
                .Include(s => s.Features)
                    .ThenInclude(s => s.FeaturesDetails)
                        .ThenInclude(s => s.DictDetailFeature)
                .FirstOrDefaultAsync();

            var person = new DisplayPersonDetailDto
            {
                City = entity.LastLocation.City.Name,
                Name = entity.Name,
                SecondName = entity.SecondName,
                Surname = entity.Surname,
                Detail = new PersonDetailDto(entity.Detail),
                DangerOfLife = entity.DangerOfLife.IsAtRisk,
                Description = entity.Description.Description,
                Id = entity.Id,
                Pictures = entity.Pictures.Select(s => pictureService.GetPictureBase64ByName(s.Name))
            };

            foreach (var feature in entity.Features)
            {
                var personFeature = new PersonFeatureDto
                {
                    Id = feature.DictFeatureId,
                    Name = feature.DictFeature.Name
                };

                foreach (var featureDetail in feature.FeaturesDetails)
                {
                    var personFeatureDetail = new PersonFeatureDetailDto
                    {
                        Id = featureDetail.DictDetailFeatureId,
                        Name = featureDetail.DictDetailFeature.Name,
                        Description = featureDetail.Description
                    };
                    personFeature.PersonFeatureDetails.Add(personFeatureDetail);
                }


                person.PersonFeatures.Add(personFeature);
            }

            return person;
        }

        public async Task<IEnumerable<DisplayPersonDto>> GetPersonsAsync()
        {
            var entities = await repositoryPerson.GetAll()
                .Include(s => s.LastLocation)
                    .ThenInclude(s => s.City)
                .Include(s => s.Pictures.Take(1))
                .ToListAsync();

            ICollection<DisplayPersonDto> models = new List<DisplayPersonDto>();

            foreach (var entity in entities)
            {
                var person = new DisplayPersonDto
                {
                    Id = entity.Id,
                    City = entity.LastLocation.City.Name,
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Picture = pictureService.GetPictureBase64ByName(entity.Pictures.FirstOrDefault().Name)
                };

                models.Add(person);
            }

            return models;
        }


    }
}