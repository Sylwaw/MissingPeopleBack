using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissingPeople.Core.Entities.Peoples
{
    [Table("DangersOfLife")]
    public class DangerOfLife:BaseEntity
    {
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public bool IsAtRisk { get; set; }
        public string Description { get; set; }

    }
}