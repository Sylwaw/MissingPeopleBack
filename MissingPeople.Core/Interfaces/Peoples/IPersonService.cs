using System.Collections.Generic;
using System.Threading.Tasks;
using MissingPeople.Core.Dtos.Peoples;

namespace MissingPeople.Core.Interfaces.Peoples
{
    public interface IPersonService
    {
        Task<DisplayPeopleDetailDto> GetPersonByIdAsync(int id);
        Task<IEnumerable<DisplayPeopleDto>> GetPersonsAsync();
    }
}