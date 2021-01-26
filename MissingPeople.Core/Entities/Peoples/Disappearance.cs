using System;
using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities.Peoples
{
    public class Disappearance : BaseEntity
    {
        public DateTime DisapperanceFrom { get; set; }
        
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}