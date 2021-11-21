
using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}