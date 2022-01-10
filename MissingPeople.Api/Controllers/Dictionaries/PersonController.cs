﻿using System;
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
        private const int PERSON_PER_PAGE = 10; // liczba wyswietlanych osob na stronie

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
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


        //    private readonly MissingPeopleDbContext _context;

        //    public PeopleController(MissingPeopleDbContext context)
        //    {
        //        _context = context;
        //    }

        //    // GET: api/People
        //    [HttpGet]
        //    public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        //    {
        //        return await _context.People.ToListAsync();
        //    }

        //    // GET: api/People/5
        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<Person>> GetPerson(int id)
        //    {
        //        var person = await _context.People.FindAsync(id);

        //        if (person == null)
        //        {
        //            return NotFound();
        //        }

        //        return person;
        //    }

        //    // PUT: api/People/5
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> PutPerson(int id, Person person)
        //    {
        //        if (id != person.Id)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(person).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PersonExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }

        //    // POST: api/People
        //    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //    [HttpPost]
        //    public async Task<ActionResult<Person>> PostPerson(Person person)
        //    {
        //        _context.People.Add(person);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        //    }

        //    // DELETE: api/People/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeletePerson(int id)
        //    {
        //        var person = await _context.People.FindAsync(id);
        //        if (person == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.People.Remove(person);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool PersonExists(int id)
        //    {
        //        return _context.People.Any(e => e.Id == id);
        //    }
        //}
    }
}