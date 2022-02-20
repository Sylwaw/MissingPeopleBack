using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPeople.Core.Dtos.Peoples
{
    public class CreatePersonDto
    {
        [Required(ErrorMessage = "Imię jest wymagane")]
        [MinLength(3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Name { get; set; }
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [MinLength(3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        public string Surname { get; set; }
        [Range(1910, 2022)]
        public int YearOfBirth { get; set; }
        public System.DateTime DateOfDisappear { get; set; }
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
        public string DictCity { get; set; }
        public bool IsWaiting { get; set; }
        public string[] Pictures { get; set; }
    }
}
