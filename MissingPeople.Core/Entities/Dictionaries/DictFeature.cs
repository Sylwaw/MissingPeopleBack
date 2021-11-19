using System.Collections.Generic;
using MissingPeople.Core.Entities.Peoples.Features;

namespace MissingPeople.Core.Entities.Dictionaries
{
    public class DictFeature:BaseEntity
    {
        public string Name { get; set; }
        //public int FeatureID;
        public ICollection<DictDetailFeature> DictDetailFeatures { get; set; }
        public Feature Feature {get; set;}
    }
}