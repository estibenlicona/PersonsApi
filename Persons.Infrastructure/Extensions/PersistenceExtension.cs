using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persons.Domain.Ports;
using Persons.Infrastructure.Adapters;

namespace Persons.Infrastructure.Extensions
{

    public static class PersistenceExtensions {
        public static IServiceCollection AddPersistence(this IServiceCollection svc) {
            svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));           
            return svc;
        }
    }
}