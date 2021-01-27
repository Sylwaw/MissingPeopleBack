using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MissingPeople.Core.Entities.Dictionaries;

namespace MissingPeople.Core.Entities.Peoples.Features
{
    public class Feature : BaseEntity
    {
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }

        [Required]
        public int DictFeatureId { get; set; }
        public DictFeature DictFeature { get; set; }

        public ICollection<DetailFeature> FeaturesDetails {get;set;}
    }
}