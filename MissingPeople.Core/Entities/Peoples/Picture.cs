using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissingPeople.Core.Entities.Peoples
{
    [Table("Pictures")]
    public class Picture : BaseEntity
    {
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public string Name { get; set; }
    }
}