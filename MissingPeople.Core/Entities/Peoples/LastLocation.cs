using System;
using System.ComponentModel.DataAnnotations;
using MissingPeople.Core.Entities.Dictionaries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissingPeople.Core.Entities.Peoples
{
    [Table("LastLocations")]
    public class LastLocation : BaseEntity
    {
        [Required]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public DictCity City { get; set; }

        public DateTime Modified { get; set; }
        public ICollection<Person> People { get; set; }
        
    }
}