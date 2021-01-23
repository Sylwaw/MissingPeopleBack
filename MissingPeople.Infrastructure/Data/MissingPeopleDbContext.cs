using Microsoft.EntityFrameworkCore;

namespace MissingPeople.Infrastructure.Data
{
    public class MissingPeopleDbContext:DbContext
    {
        public MissingPeopleDbContext(DbContextOptions<MissingPeopleDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseNpgsql("User ID=postgres;Password=ed74wq74;Host=127.0.0.1;Port=5432;Database=MissingPeopleDb;Pooling=true;");
        }
    }
}