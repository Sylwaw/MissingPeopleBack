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
    public class PersonController : Controller
    {
        private readonly IPersonService personService;
        private readonly IPersonDetailService personDetailService;
        private readonly IDangerOfLifeService dangerOfLifeService;
        private const int PERSON_PER_PAGE = 10; // liczba wyswietlanych osob na stronie

        public PersonController(IPersonService personService, IPersonDetailService personDetailService, IDangerOfLifeService dangerOfLifeService)
        {
            this.personService = personService;
            this.dangerOfLifeService = dangerOfLifeService;
            this.personDetailService = personDetailService;
        }

        [HttpGet("peopleByID")]
        public async Task<ActionResult<DisplayPersonDetailDto>> GetPeopleByID(int id)
        {
            return new JsonResult(await personService.GetPersonByIdAsync(id)); 
        }

        [HttpGet("getAllPeople")]
        public async Task<ActionResult<DisplayPersonDto>> GetAllPeople([FromQuery] int page)
        {
            return new JsonResult(await personService.GetPersonsAsync(page, PERSON_PER_PAGE));
        }

        [HttpPut("updatePerson")]
        public async Task<ActionResult<UpdatePersonDto>> PutPeopleById(UpdatePersonDto updatePerson, int id)
        {
            var result = await personService.UpdatePersonByIdAsync(updatePerson, id);
            return Ok();
        }

        [HttpPost("createPerson")]
        public IActionResult PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dangerOfLife = dangerOfLifeService.GetDangerOfLifeByID(person.DangerOfLife.Id);
            if (dangerOfLife == null)
            {
                return NotFound("Cannot find dangers of life with provided id");
            }

            var personDetails = personDetailService.GetPersonDetailByID(person.PersonDetail.Id);
            if (personDetails == null)
            {
                return NotFound("Cannot find person details with provided id");
            }

            

            var newPersonID = personService.AddPerson(person, dangerOfLife, personDetails);

            return new JsonResult(newPersonID);

        }

        
    }
}
