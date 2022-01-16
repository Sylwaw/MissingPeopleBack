using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPeople.Core.Interfaces.Peoples
{
    public interface IPersonDetailService 
    {
        public int AddDetails(PersonDetail personDetail);
        public PersonDetail GetPersonDetailByID(int id);
    }
}
