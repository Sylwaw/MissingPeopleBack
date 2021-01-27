using System.Collections.Generic;
using System.Threading.Tasks;
using MissingPeople.Core.Dtos.Peoples;

namespace MissingPeople.Core.Interfaces.Peoples
{
    public interface IPersonService
    {
        Task<DisplayPersonDetailDto> GetPersonByIdAsync(int id);
        Task<IEnumerable<DisplayPersonDto>> GetPersonsAsync();
    }
}