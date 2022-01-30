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
    public class DangerOfLifeService : IDangerOfLifeService
    {
        private readonly IRepositoryBase<DangerOfLife> repositoryDangerOfLife;
        public int AddDangerOfLife(DangerOfLife dangerOfLife)
        {

            if (dangerOfLife == null)
            {
                throw new Exception("Danger of life cannot be null");
            }

            repositoryDangerOfLife.CreateAsync(dangerOfLife);

            return dangerOfLife.Id;
        }

        public DangerOfLife GetDangerOfLifeByID(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID cannot be lower or equal to 0");
            }

            var entity = repositoryDangerOfLife.GetByFunc(s => s.Id == id).FirstOrDefault();
            return entity;
        }
    }

}
