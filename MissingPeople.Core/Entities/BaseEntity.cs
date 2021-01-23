using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}