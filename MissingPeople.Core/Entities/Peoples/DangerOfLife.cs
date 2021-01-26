using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities.Peoples
{
    public class DangerOfLife:BaseEntity
    {
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public bool IsAtRisk { get; set; }
        public string Description { get; set; }
    }
}