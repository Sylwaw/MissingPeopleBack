using System.Collections.Generic;

namespace MissingPeople.Core.Entities.Dictionaries
{
    public class DictFeature:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<DictDetailFeature> DictDetailFeatures { get; set; }
    }
}