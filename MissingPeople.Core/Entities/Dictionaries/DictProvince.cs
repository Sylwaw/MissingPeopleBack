using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace MissingPeople.Core.Entities.Dictionaries
{
    public class DictProvince:BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DictCity> Cities { get; set; }
    }
}