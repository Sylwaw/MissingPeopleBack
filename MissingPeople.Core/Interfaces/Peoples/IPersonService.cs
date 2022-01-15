using System.Collections.Generic;
using System.Threading.Tasks;
using MissingPeople.Core.Dtos.Peoples;
using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Core.Extensions;



namespace MissingPeople.Core.Interfaces.Peoples
{
    public interface IPersonService
    {
        Task<DisplayPersonDetailDto> GetPersonByIdAsync(int id);
        Task<IEnumerable<DisplayPersonDto>> GetPersonsAsync(int page, int personPerPage);
        Task<Person> UpdatePersonByIdAsync(UpdatePersonDto updatedPerson, int id);
        int AddPerson(Person person, DangerOfLife dangerOfLife, PersonDetail personDetail);
        void DeletePerson(Person person, DangerOfLife dangerOfLife, PersonDetail personDetail);
    }

    //chodzi mi o to update
    // a co to tu z tym delete:D tzn? jakoos tak duzo przyjmuje parametrow LD
    //to addperson i dlete robie teraz wg tego tutoriala z udemy, a �le to jest? :D
    // nigdzie nie widzia�em zeby delete tyle parametrow przyjmowalo:D tylko jedno id:D ale ok:D moze je ok:D 
    //aaa kurde czekaj, musz� chyba zrobi� migracje jeszcze, bo zauwa�y�am �e nie mia�am relacji w jednym miejscu :D

    //ok
    
}