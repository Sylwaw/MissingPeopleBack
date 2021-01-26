using System.ComponentModel.DataAnnotations;

namespace MissingPeople.Core.Entities.Peoples
{
    public class PersonDetail : BaseEntity
    {
        public int HeightFrom { get; set; }
        public int HeightTo { get; set; }
        public int WeightFrom { get; set; }
        public int WeightTo { get; set; }
        public ColorEye ColorEyes { get; set; }

        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }


        public enum ColorEye
        {

        }
    }
}