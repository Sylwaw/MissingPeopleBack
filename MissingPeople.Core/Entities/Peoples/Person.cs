using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MissingPeople.Core.Entities.Dictionaries;



namespace MissingPeople.Core.Entities.Peoples
{
    [Table("People")]
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string? SecondName { get; set; }
        public string Surname { get; set; }
        public int YearOfBirth { get; set; }
        public bool IsWaiting { get; set; }
        public DateTime? DateOfDisappear { get; set; }
        public int? DictEyeID { get; set; }
        public int? DictCityID { get; set; }
        public int PersonDetailID { get; set; }
        public PersonDetail Detail { get; set; }
        
        public DangerOfLife DangerOfLife { get; set; } 

        [ForeignKey("DictEyeID")]
        public DictEye DictEye { get; set; }

        [ForeignKey("DictCityID")]
        public DictCity? DictCity { get; set; }
        public ICollection<Picture> Pictures { get; set; }

        [ForeignKey("PersonDetailID")]
        public PersonDetail PersonDetail;
        
    }
}