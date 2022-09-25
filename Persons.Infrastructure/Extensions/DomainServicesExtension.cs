using Microsoft.Extensions.DependencyInjection;
using Persons.Domain.Services;

namespace Persons.Infrastructure.Extensions
{
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection svc)
        {
            var _services = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => {
                    return (assembly.FullName is null) ? false : assembly.FullName.Contains("Persons.Domain", StringComparison.InvariantCulture);
                })
                .SelectMany(s => s.GetTypes())
                .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));

            foreach (var _service in _services)
            {
                var sInterface = _service.GetInterfaces().FirstOrDefault(i => i.FullName is not null && i.FullName.Contains("Domain", StringComparison.InvariantCulture));
                if (sInterface != null)
                {
                    svc.AddTransient(sInterface, _service);
                }
                else
                {
                    svc.AddTransient(_service);
                }
            }

            return svc;
        }
    }
}
