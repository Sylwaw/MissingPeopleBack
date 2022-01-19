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
        public int? HeightFrom { get; set; }
        public int? HeightTo { get; set; }
        public int? WeightFrom { get; set; }
        public int? WeightTo { get; set; }
        public string OtherDetails { get; set; }
        public string ClothesDescription { get; set; }
        public string TatoosDescription { get; set; }
        public string ScarsDescription { get; set; }
        public bool IsAtRisk { get; set; }
        public string Description { get; set; }
        public int DictCityID { get; set; }
        public int DangerOfLifeId { get; set; }
        public int PersonDetailId { get; set; }

        //public string Picture { get; set; }
    }
}
