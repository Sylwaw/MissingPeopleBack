using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Infrastructure.Data;
using MissingPeople.Core.Dtos.Dictionaries.Cities;
using MissingPeople.Core.Interfaces.Peoples;
using MissingPeople.Core.Dtos.Peoples;
using MissingPeople.Core.Extensions;

namespace MissingPeople.Api.Controllers.Dictionaries
{

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IPersonDetailService personDetailService;
        private readonly IDangerOfLifeService dangerOfLifeService;
        private const int PERSON_PER_
            = 1200; // liczba wyswietlanych osob na stronie

        public PersonController(IPersonService personService, IPersonDetailService personDetailService, IDangerOfLifeService dangerOfLifeService)
        {
            this.personService = personService;
            this.dangerOfLifeService = dangerOfLifeService;
            this.personDetailService = personDetailService;
        }

        [HttpGet("peopleByID/{id}")]
        public async Task<ActionResult<DisplayPersonDetailDto>> GetPeopleByID(int id)
        {
            return new JsonResult(await personService.GetPersonByIdAsync(id));
        }


        [HttpGet("getAllPeople")]
        public async Task<ActionResult<DisplayPersonDto>> GetAllPeople()
        {
            var result = new JsonResult(await personService.GetPersonsAsync());
            return result;
        }

        [HttpPut("updatePerson/{id}")]
        public async Task<ActionResult<UpdatePersonDto>> PutPeopleById([FromBody] UpdatePersonDto updatePerson, int id)
        {
            var result = await personService.UpdatePersonByIdAsync(updatePerson, id);
            return Ok();
        }

        [HttpDelete("deletePerson/{id}")]
        public async Task<IActionResult> DeletePeopleById(int id)
        {
            await personService.DeletePerson(id);
            return Accepted();
        }

        [HttpPost("createPerson")]
        public async Task<IActionResult> PostPerson([FromBody] CreatePersonDto createPersonDto)
        {
            if (ModelState.IsValid)
            {
                var person = await personService.AddPerson(createPersonDto);
                return new JsonResult(person.Id);
            }

            return Ok();
        }


    }
}
