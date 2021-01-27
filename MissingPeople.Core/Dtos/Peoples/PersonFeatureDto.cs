using System.Collections.Generic;

namespace MissingPeople.Core.Dtos.Peoples
{
    public class PersonFeatureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PersonFeatureDetailDto> PersonFeatureDetails { get; set; }

        public PersonFeatureDto()
        {
            this.PersonFeatureDetails = new List<PersonFeatureDetailDto>();
        }
    }
}