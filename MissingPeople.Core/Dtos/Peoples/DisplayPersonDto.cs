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
    }
}