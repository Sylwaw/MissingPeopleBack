using Microsoft.Extensions.DependencyInjection;
using MissingPeople.Core.Interfaces;
using MissingPeople.Core.Interfaces.Dictionaries;
using MissingPeople.Core.Interfaces.Peoples;
using MissingPeople.Core.Interfaces.Repository;
using MissingPeople.Core.Services;
using MissingPeople.Core.Services.Dictionaries;
using MissingPeople.Core.Services.Peoples;
using MissingPeople.Infrastructure.Data.Repository;

namespace MissingPeople.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ServiceCollection(this IServiceCollection service) {
            service.AddTransient(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));
            service.AddScoped<IPersonService,PersonService>();
            service.AddScoped<IPictureService,PictureService>();
            service.AddScoped<ICityService, CityService>();
            service.AddScoped<IPersonDetailService, PersonDetailService>();
            service.AddScoped<IDangerOfLifeService, DangerOfLifeService>();
            
        }
    }
}