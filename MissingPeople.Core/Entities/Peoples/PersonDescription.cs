using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities.Peoples
{
    public class PersonDescription:BaseEntity
    {
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string Description { get; set; }
    }
}