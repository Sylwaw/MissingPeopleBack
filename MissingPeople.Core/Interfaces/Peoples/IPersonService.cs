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
        Task<Person> AddPerson(CreatePersonDto createPersonDto);
        Task DeletePerson(int personId);
    }

    
    
}