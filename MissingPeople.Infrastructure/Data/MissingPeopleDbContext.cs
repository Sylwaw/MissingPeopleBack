using Microsoft.EntityFrameworkCore;
using MissingPeople.Core.Entities.Dictionaries;
using MissingPeople.Core.Entities.Peoples;
using MissingPeople.Infrastructure.Data.Configuration;

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
        public DbSet<DangerOfLife> DangersOfLife { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonDetail> PeopleDetails { get; set; }
        public DbSet<DictProvince> DictProvinces { get; set; }
        public DbSet<DictEye> DictEyes { get; set; }
       
      


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("User ID=Sylwia; Password=sylwia123; Host=127.0.0.1; Port=5432; Database=MissingPeople; Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PersonConfiguration(modelBuilder.Entity<Person>());
            modelBuilder.Entity<DangerOfLife>().Property(s => s.Id).ValueGeneratedOnAdd().HasIdentityOptions(1274);
            modelBuilder.Entity<PersonDetail>().Property(s => s.Id).ValueGeneratedOnAdd().HasIdentityOptions(1274);
            modelBuilder.Entity<Picture>().Property(s => s.Id).ValueGeneratedOnAdd().HasIdentityOptions(1274);
        }
    }
}