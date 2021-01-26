using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities.Peoples
{
    public class Picture : BaseEntity
    {
        [Key]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public string Name { get; set; }
    }
}