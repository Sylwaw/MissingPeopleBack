using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MissingPeople.Core.Entities.Peoples;

namespace MissingPeople.Core.Entities.Dictionaries
{
    [Table("DictCities")]
    public class DictCity:BaseEntity
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public double CordinateY { get; set; }
        public double CordinateX { get; set; }
        public double DecimalLatitude { get; set; }
        public double DecimalLongitude { get; set; }
        public int IdentifierTeryt { get; set; }
        public int ProvinceId { get; set; }
        public ICollection<Person> People { get; set; }

        [ForeignKey("ProvinceId")]
        public virtual DictProvince Provinces { get; set; }
    }
}