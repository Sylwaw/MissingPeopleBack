using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Core.Interfaces.Peoples;
using MissingPeople.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPeople.Core.Services.Peoples
{
    
    public class PersonDetailService : IPersonDetailService
    {
        private readonly IRepositoryBase<PersonDetail> repositoryPersonDetail;

        public int AddDetails(PersonDetail personDetail)
        {
            if(personDetail == null)
            {
                throw new Exception("Person details cannot be null");
            }

            repositoryPersonDetail.CreateAsync(personDetail);

            return personDetail.Id;
        }

        public PersonDetail GetPersonDetailByID(int id)
        {
            if(id <= 0)
            {
                throw new Exception("ID cannot be lower or equal to 0");
            }

            var entity = repositoryPersonDetail.GetByFunc(s => s.Id == id).FirstOrDefault();
            return entity;
        }
    }
}
