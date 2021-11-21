using System.ComponentModel.DataAnnotations;
using MissingPeople.Core.Entities.Dictionaries;

namespace MissingPeople.Core.Entities.Peoples.Features
{
    public class DetailFeature:BaseEntity
    {
        [Required]
        public int DictDetailFeatureId { get; set; }
        public DictDetailFeature DictDetailFeature { get; set; }
        public string Description { get; set; }

        public int FeatureID { get; set; }

        public Feature Feature { get; set; }
    }
}