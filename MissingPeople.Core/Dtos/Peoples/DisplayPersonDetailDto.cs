using System.Collections;
using System.Collections.Generic;

namespace MissingPeople.Core.Dtos.Peoples
{
    public class DisplayPersonDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        //public PersonDetailDto Detail { get; set; }
        public int? HeightFrom { get; set; }
        public int? HeightTo { get; set; }
        public int? WeightFrom { get; set; }
        public int? WeightTo { get; set; }
        public string OtherDetails { get; set; }
        public string ClothesDescription { get; set; }
        public string TatoosDescription { get; set; }
        public string ScarsDescription { get; set; }

        public bool DangerOfLife { get; set; }
        public string Description { get; set; }
        public System.DateTime? DateOfDisappear { get; set; }
        public int YearOfBirth { get; set; }
        public string Eyes { get; set; }
        public IEnumerable<string> Pictures { get; set; }
        

        public DisplayPersonDetailDto()
        {
            this.Pictures = new List<string>();
        }
    }
}