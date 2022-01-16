using MissingPeople.Core.Entities.Peoples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPeople.Core.Interfaces.Peoples
{
    public interface IDangerOfLifeService
    {
        public int AddDangerOfLife(DangerOfLife dangerOfLife);
        public DangerOfLife GetDangerOfLifeByID(int id);
    }
}
