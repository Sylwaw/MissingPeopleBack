namespace MissingPeople.Core.Dtos.Peoples
{
    public class DisplayPersonDto
    {
        public int Id { get; set; }
        public int YearOfBirth { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string? Picture { get; set; }
        public bool IsAtRisk { get; set; }
        public string Description { get; set; }
        public double DecimalLatitude { get; set; }
        public double DecimalLongitude { get; set; }

        public System.DateTime? DateOfDisappear {get; set;}
        public bool IsWaiting { get; set; }
    }
}