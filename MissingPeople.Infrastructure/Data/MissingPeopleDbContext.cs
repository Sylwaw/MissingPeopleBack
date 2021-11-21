using Microsoft.EntityFrameworkCore;
using MissingPeople.Core.Entities.Dictionaries;
using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Core.Entities.Peoples.Features;


namespace MissingPeople.Infrastructure.Data
{
    public class MissingPeopleDbContext : DbContext
    {
        //domyœlny konstruktor
        public MissingPeopleDbContext(DbContextOptions<MissingPeopleDbContext> options) : base(options)
        {
        }

        //wyszczególnienie wszystkich tabel do utworzenia w bazie (nazwa - l. mnoga od nazwy modelu)
        public DbSet<DictCity> DictCities { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<DictDetailFeature> DictDetailFeatures { get; set; }
        public DbSet<DictFeature> DictFeatures { get; set; }
        public DbSet<DetailFeature> DetailFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<DangerOfLife> DangersOfLife { get; set; }
        public DbSet<LastLocation> LastLocations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonDetail> PeopleDetails { get; set; }
        public DbSet<DictProvince> DictProvinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("User ID=Sylwia; Password=sylwia123; Host=127.0.0.1; Port=5432; Database=MissingPeopleBase; Pooling=true;");
        }
    }
}