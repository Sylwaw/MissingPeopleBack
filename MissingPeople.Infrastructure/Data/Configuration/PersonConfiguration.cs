using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MissingPeople.Core.Entities.Peoples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingPeople.Infrastructure.Data.Configuration
{
    public class PersonConfiguration
    {
        public PersonConfiguration(EntityTypeBuilder<Person> builder)
        {
            builder.Property(s => s.Id).ValueGeneratedOnAdd().HasIdentityOptions(1274);
        }
    }
}
