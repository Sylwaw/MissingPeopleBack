using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissingPeople.Core.Entities.Peoples
{
    [Table("PersonDetails")]
    public class PersonDetail : BaseEntity
    {
        public int? HeightFrom { get; set; }
        public int? HeightTo { get; set; }
        public int? WeightFrom { get; set; }
        public int? WeightTo { get; set; }
        public string? ClothesDescription { get; set; }
        public string? OtherDetails { get; set; }
        public string? TatoosDescription { get; set; }
        public string? ScarsDescription { get; set; }

        [Required]
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }


    }
}