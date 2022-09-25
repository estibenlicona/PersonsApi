using Microsoft.Extensions.DependencyInjection;
using Persons.Domain.Ports;
using Persons.Infrastructure.Adapters;

namespace Persons.Infrastructure.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositorios(this IServiceCollection services)
        {
            services.AddTransient(typeof(IJWTRepository), typeof(JWTRepository));
            return services;
        }
    }
}
