using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPeople.Core.Dtos.Peoples
{
    public class CreatePersonDto
    {

        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public int YearOfBirth { get; set; }
        public System.DateTime DateOfDissapear { get; set; }
        public int DictEyeID { get; set; }
        public PersonDetailDto PersonDetails { get; set; }
        public bool IsAtRisk { get; set; }
        public string Description { get; set; }
        public int DictCityID { get; set; }

        //public string Picture { get; set; }
    }
}
