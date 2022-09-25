using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Persons.Domain.Entities;
using Persons.Infrastructure.Contexts;
using Persons.Infrastructure.Seeds;

namespace Persons.Infrastructure.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedDataBase(this IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PersistenceContext>();
                
                if (context != null && !context.Set<User>().Any())
                {
                    context.Set<User>().AddRange(UsersSeed.GetUsers());
                    context.SaveChanges();
                }

                if (context != null && !context.Set<Scope>().Any())
                {
                    context.Set<Scope>().AddRange(ScopeSeed.GetScopes());
                    context.SaveChanges();
                }
            }
        }
    }
}
