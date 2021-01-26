using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities.Dictionaries
{
    public class DictDetailFeature : BaseEntity
    {
        public string Name { get; set; }

        [Required]
        public int DictFeatureId { get; set; }
        public DictDetailFeature DetailFeature { get; set; }
    }
}