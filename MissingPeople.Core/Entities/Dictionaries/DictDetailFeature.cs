using System.ComponentModel.DataAnnotations;
using MissingPeople.Core.Entities.Peoples.Features;



namespace MissingPeople.Core.Entities.Dictionaries
{
    public class DictDetailFeature : BaseEntity
    {
        public string Name { get; set; }

        [Required]
        public int DictFeatureId { get; set; }
        public DetailFeature DetailFeature { get; set; }
        
    }
}