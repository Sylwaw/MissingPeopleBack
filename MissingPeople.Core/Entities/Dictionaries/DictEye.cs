
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MissingPeople.Core.Entities.Peoples;


namespace MissingPeople.Core.Entities.Dictionaries
{
    [Table("DictEyes")]
    public class DictEye:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }    
    }
}
