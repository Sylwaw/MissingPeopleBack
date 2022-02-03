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
        private readonly IRepositoryBase<DangerOfLife> repositoryDangersOfLife;
        private readonly IRepositoryBase<PersonDetail> repositoryPersonDetail;
        private readonly ICityService cityService;
        private readonly IPictureService pictureService;
        private readonly IMapper mapper;

        public PersonService(IRepositoryBase<Person> repositoryPerson,
                             IMapper mapper,
                             IPictureService pictureService,
                             ICityService cityService,
                             IRepositoryBase<DangerOfLife> repositoryDangersOfLife,
                             IRepositoryBase<PersonDetail> repositoryPersonDetail)
        {
            this.repositoryPerson = repositoryPerson;
            this.pictureService = pictureService;
            this.mapper = mapper;
            this.cityService = cityService;
            this.repositoryDangersOfLife = repositoryDangersOfLife;
            this.repositoryPersonDetail = repositoryPersonDetail;
        }

        public async Task<DisplayPersonDetailDto> GetPersonByIdAsync(int id)
        {
            var entity = await repositoryPerson.GetByFunc(s => s.Id == id)
                .Include(s => s.DangerOfLife)
                .Include(s => s.Pictures)
                .Include(s => s.PersonDetail)
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
                //Detail = new PersonDetailDto(entity.PersonDetail),
                HeightFrom = entity.PersonDetail.HeightFrom,
                HeightTo = entity.PersonDetail.HeightFrom,
                WeightFrom = entity.PersonDetail.WeightFrom,
                WeightTo = entity.PersonDetail.WeightTo,
                OtherDetails = entity.PersonDetail.OtherDetails,
                ClothesDescription = entity.PersonDetail.ClothesDescription,
                TatoosDescription = entity.PersonDetail.TatoosDescription,
                ScarsDescription = entity.PersonDetail.ScarsDescription,
                DangerOfLife = entity.DangerOfLife.IsAtRisk,
                Description = entity.DangerOfLife.Description,
                DateOfDisappear = entity.DateOfDisappear,
                YearOfBirth = entity.YearOfBirth,
                Id = entity.Id,
                Pictures = entity.Pictures.Select(s => s.Name),
                
            };
            return person;
        }

        //public async Task<IEnumerable<DisplayPersonDto>> GetPersonsAsync(int page, int personPerPage)
        //{

        //    var entities = repositoryPerson.GetAll()
        //         .Include(s => s.DictCity)
        //         .Include(s => s.Pictures.Take(1))
        //         .Skip(page * personPerPage)
        //         .Take(personPerPage);

        //    var persons = await entities.ToListAsync();

        //    ICollection<DisplayPersonDto> models = new List<DisplayPersonDto>();

        //    foreach (var entity in persons)
        //    {
        //        var person = new DisplayPersonDto
        //        {
        //            Id = entity.Id,
        //            YearOfBirth = entity.YearOfBirth,
        //            City = entity.DictCity != null ? entity.DictCity.Name : "",
        //            Name = entity.Name,
        //            Surname = entity.Surname,
        //            //Picture = pictureService.GetPictureBase64ByName(entity.Pictures.FirstOrDefault().Name)
        //            Picture = entity.Pictures.FirstOrDefault().Name
        //        };

        //        models.Add(person);
        //    }

        //    return models;
        //}

        public async Task<IEnumerable<DisplayPersonDto>> GetPersonsAsync()
        {

            var entities = repositoryPerson.GetAll()
                 .Include(s => s.DictCity)
                 .Include(s => s.Pictures.Take(1))
                 .Include(s => s.DangerOfLife);

            var persons = await entities.ToListAsync();

            ICollection<DisplayPersonDto> models = new List<DisplayPersonDto>();

            foreach (var entity in persons)
            {
                var person = new DisplayPersonDto
                {
                    Id = entity.Id,
                    YearOfBirth = entity.YearOfBirth,
                    City = entity.DictCity != null ? entity.DictCity.Name : "",
                    Name = entity.Name,
                    Surname = entity.Surname,
                    //Picture = pictureService.GetPictureBase64ByName(entity.Pictures.FirstOrDefault().Name)
                    Picture = entity.Pictures.Count() != 0 ? entity.Pictures.FirstOrDefault().Name : "",
                    IsAtRisk = entity.DangerOfLife.IsAtRisk,
                    Description = entity.DangerOfLife.Description,
                    DecimalLatitude = entity.DictCity != null ? entity.DictCity.DecimalLatitude : 0,
                    DecimalLongitude = entity.DictCity != null ? entity.DictCity.DecimalLongitude : 0,
                    DateOfDisappear = entity.DateOfDisappear
                };

                models.Add(person);
            }

            return models;
        }

        public async Task<Person> UpdatePersonByIdAsync(UpdatePersonDto updatingPerson, int id)
        {
            var entity = await repositoryPerson.GetByFunc(s => s.Id == id)
                .Include(s => s.DangerOfLife)
                .Include(s => s.PersonDetail)
                .Include(s => s.DictCity)
                .FirstOrDefaultAsync();

            var city = await cityService.GetCityByName(updatingPerson.City);

            if (city != null)
            {
                entity.DictCityID = city.Id;
            }

            entity.DangerOfLife.IsAtRisk = updatingPerson.IsAtRisk;
            entity.PersonDetail.OtherDetails = updatingPerson.OtherDetails;
            entity.DangerOfLife.Description = updatingPerson.RiskDescription;

            await repositoryPerson.UpdateAsync(entity);
            return entity;


        }


        public async Task<Person> AddPerson(CreatePersonDto createPersonDto)
        {
            createPersonDto.IsAtRisk = false;
            createPersonDto.IsWaiting = true;
            var person =  new Person {
                Name = createPersonDto.Name,
                Surname = createPersonDto.Surname,
                SecondName = createPersonDto.SecondName,
                YearOfBirth = createPersonDto.YearOfBirth,
                DateOfDisappear = createPersonDto.DateOfDissapear,
                DictCityID = createPersonDto.DictCityID,
                DictEyeID = createPersonDto.DictEyeID,
                IsWaiting = createPersonDto.IsWaiting,
                PersonDetail = new()
                {
                    //Id = createPersonDto.PersonDetailId,
                    HeightFrom = createPersonDto.HeightFrom,
                    HeightTo = createPersonDto.HeightTo,
                    WeightFrom = createPersonDto.WeightFrom,
                    WeightTo = createPersonDto.WeightTo,
                    ClothesDescription = createPersonDto.ClothesDescription,
                    OtherDetails = createPersonDto.OtherDetails,
                    TatoosDescription = createPersonDto.TatoosDescription,
                    ScarsDescription = createPersonDto.ScarsDescription
                },
                DangerOfLife = new()
                {
                    IsAtRisk = createPersonDto.IsAtRisk,
                    Description = createPersonDto.Description
                }
            };

            

            //jak nie przypisujê rêcznie id to sa 0!!!!
            


            await repositoryPerson.CreateAsync(person);
            return person;
        }

        //mo¿na to zrobiæ w inny sposób - cascade delete fluent API, EF domyœlnie usuwa tabele, które s¹ w relacji 1:1
        public async Task DeletePerson(int personId)
        {
            var person = await repositoryPerson.GetByFunc(s => s.Id == personId).Include(s => s.DangerOfLife).FirstOrDefaultAsync();
            //var details = await repositoryPersonDetail.GetByIdAsync(person.PersonDetail.Id);

            await repositoryPerson.DeleteAsync(person);

        }

        
    }


}