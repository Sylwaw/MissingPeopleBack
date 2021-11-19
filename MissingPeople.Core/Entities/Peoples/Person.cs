using System.Collections.Generic;
using MissingPeople.Core.Entities.Peoples.Features;


namespace MissingPeople.Core.Entities.Peoples
{
    public class Person : BaseEntity
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public int YearOfBirth { get; set; }
        public System.DateTime DateOfDisappear { get; set; }
        public PersonDetail Detail { get; set; }
        public LastLocation LastLocation { get; set; }
        public DangerOfLife DangerOfLife { get; set; }
        public ICollection<Feature> Features { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}