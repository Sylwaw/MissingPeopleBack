using MissingPeople.Core.Entities.Peoples;

namespace MissingPeople.Core.Dtos.Peoples
{
    public class PersonDetailDto
    {
        public int HeightFrom { get; set; }
        public int HeightTo { get; set; }
        public int WeightFrom { get; set; }
        public int WeightTo { get; set; }
        public string OtherDetails { get; set; }
        

        public PersonDetailDto(PersonDetail personDetail)
        {
            HeightFrom = personDetail.HeightFrom;
            HeightTo = personDetail.HeightTo;
            WeightFrom = personDetail.WeightFrom;
            WeightTo = personDetail.WeightTo;
            OtherDetails = personDetail.OtherDetails;
        }
    }
}