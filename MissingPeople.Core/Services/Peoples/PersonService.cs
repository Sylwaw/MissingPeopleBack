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

        public async Task<DisplayPeopleDetailDto> GetPersonByIdAsync(int id)
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
                        .ThenInclude(s => s.DetailFeature)
                .FirstOrDefaultAsync();


            return null;
        }

        public async Task<IEnumerable<DisplayPeopleDto>> GetPersonsAsync()
        {
            var entities = await repositoryPerson.GetAll()
                .Include(s => s.LastLocation)
                    .ThenInclude(s => s.City)
                .Include(s => s.Pictures.Take(1))
                .ToListAsync();

            ICollection<DisplayPeopleDto> models = new List<DisplayPeopleDto>();

            foreach (var entity in entities)
            {
                var person = new DisplayPeopleDto
                {
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