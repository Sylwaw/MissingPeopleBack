using Microsoft.Extensions.DependencyInjection;
using MissingPeople.Core.Interfaces.Repository;
using MissingPeople.Infrastructure.Data.Repository;

namespace MissingPeople.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ServiceCollection(this IServiceCollection service) {
            service.AddSingleton(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));
        }
    }
}