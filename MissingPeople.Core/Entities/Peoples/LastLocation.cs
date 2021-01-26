using System;
using System.ComponentModel.DataAnnotations;
using MissingPeople.Core.Entities.Dictionaries;

namespace MissingPeople.Core.Entities.Peoples
{
    public class LastLocation : BaseEntity
    {
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public int CityId { get; set; }
        public DictCity City { get; set; }

        public DateTime Modified { get; set; }
    }
}