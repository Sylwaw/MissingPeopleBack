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
using MissingPeople.Core.Extensions;
using static MissingPeople.Core.Dtos.Peoples.DisplayPersonDetailDto;
using MissingPeople.Core.Entities.Dictionaries;
using System;
using MissingPeople.Core.Interfaces.Dictionaries;

namespace MissingPeople.Core.Services.Peoples
{
    public class PersonService : IPersonService
    {
        
        private readonly IRepositoryBase<Person> repositoryPerson;
        private readonly ICityService cityService;
        private readonly IPictureService pictureService;
        private readonly IMapper mapper;

        public PersonService(IRepositoryBase<Person> repositoryPerson, IMapper mapper, IPictureService pictureService, ICityService cityService)
        {
            this.repositoryPerson = repositoryPerson;
            this.pictureService = pictureService;
            this.mapper = mapper;
            this.cityService = cityService;
        }

        public async Task<DisplayPersonDetailDto> GetPersonByIdAsync(int id)
        {
            var entity = await repositoryPerson.GetByFunc(s => s.Id == id)
                .Include(s => s.DangerOfLife)
                .Include(s => s.Pictures)
                .Include(s => s.Detail)
                .Include(s => s.DictCity)
                .Include(s => s.DictEye)
                .FirstOrDefaultAsync();

            var person = new DisplayPersonDetailDto
            { 
                //nie mo¿na zaci¹gn¹æ z pustego obiektu
                City = entity.DictCity != null ? entity.DictCity.Name : "",
                Eyes = entity.DictEye != null ? entity.DictEye.Name : "",
                Name = entity.Name,
                SecondName = entity.SecondName,
                Surname = entity.Surname,
                Detail = new PersonDetailDto(entity.Detail),
                DangerOfLife = entity.DangerOfLife.IsAtRisk,
                Id = entity.Id,
                Pictures = entity.Pictures.Select(s => pictureService.GetPictureBase64ByName(s.Name))    
            };
            return person;
        }

        public async Task<IEnumerable<DisplayPersonDto>> GetPersonsAsync(int page, int personPerPage)
        {
            
            var entities = repositoryPerson.GetAll()
                 .Include(s => s.DictCity)
                 .Include(s => s.Pictures.Take(1))
                 .Skip(page * personPerPage)
                 .Take(personPerPage);

            var persons = await entities.ToListAsync();

            ICollection<DisplayPersonDto> models = new List<DisplayPersonDto>();

            foreach (var entity in persons)
            {
                var person = new DisplayPersonDto
                {
                    Id = entity.Id,
                    City = entity.DictCity != null ? entity.DictCity.Name : "",
                    Name = entity.Name,
                    Surname = entity.Surname,
                    Picture = pictureService.GetPictureBase64ByName(entity.Pictures.FirstOrDefault().Name)
                };

                models.Add(person);
            }

            return models;
        }

        public async Task<Person> UpdatePersonByIdAsync(UpdatePersonDto updatingPerson, int id)
        {
            var entity = await repositoryPerson.GetByFunc(s => s.Id == id)
                .Include(s => s.DangerOfLife)
                .Include(s => s.Detail)
                .Include(s => s.DictCity)
                .FirstOrDefaultAsync();

            var city = await cityService.GetCityByName(updatingPerson.City);

            if(city !=null) {
                entity.DictCityID = city.Id;
            }
            
            entity.DangerOfLife.IsAtRisk = updatingPerson.IsAtRisk;
            entity.Detail.OtherDetails = updatingPerson.OtherDetails;
            entity.DangerOfLife.Description = updatingPerson.RiskDescription;

            await repositoryPerson.UpdateAsync(entity);
            return entity;


        }

        //dodaæ foty, miasto i oczy
        public int AddPerson(Person person, DangerOfLife dangerOfLife, PersonDetail personDetail)
        {
            if (person == null){
                throw new Exception("Person cannot be null");
            }
            if (dangerOfLife == null)
            {
                throw new Exception("Danger of life cannot be null");
            }
            if (personDetail == null)
            {
                throw new Exception("Person details cannot be null");
            }
            
            person.DangerOfLife = dangerOfLife;
            person.PersonDetail = personDetail;

            repositoryPerson.CreateAsync(person);
            return person.Id;
        }

        //mo¿na to zrobiæ w inny sposób - cascade delete fluent API
        public void DeletePerson(Person person, DangerOfLife dangerOfLife, PersonDetail personDetail)
        {
            if (person == null)
            {
                throw new Exception("Person cannot be null");
            }
            if (dangerOfLife == null)
            {
                throw new Exception("Danger of life cannot be null");
            }
            if (personDetail == null)
            {
                throw new Exception("Person details cannot be null");
            }

            repositoryPerson.DeleteAsync(person);
            //repositoryPerson.DeleteAsync(dangerOfLife);
            //repositoryPerson.DeleteAsync(personDetail);



        }














    }


}