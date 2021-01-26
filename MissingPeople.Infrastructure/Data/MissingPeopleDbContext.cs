using Microsoft.EntityFrameworkCore;
using MissingPeople.Core.Entities.Dictionaries;
using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Core.Entities.Peoples.Features;

namespace MissingPeople.Infrastructure.Data
{
    public class MissingPeopleDbContext : DbContext
    {
        public MissingPeopleDbContext(DbContextOptions<MissingPeopleDbContext> options) : base(options)
        {
        }

        public DbSet<DictCity> DictCities { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<DictDetailFeature> DictDetailFeatures { get; set; }
        public DbSet<DictFeature> DictFeatures { get; set; }
        public DbSet<DetailFeature> DetailFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<DangerOfLife> DangersOfLife { get; set; }
        public DbSet<Disappearance> Disappearances { get; set; }
        public DbSet<LastLocation> LastLocations { get; set; }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<PersonDescription> PeopleDescriptions { get; set; }
        public DbSet<PersonDetail> PeopleDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("User ID=postgres;Password=ed74wq74;Host=127.0.0.1;Port=5432;Database=MissingPeopleDb;Pooling=true;");
        }
    }
}