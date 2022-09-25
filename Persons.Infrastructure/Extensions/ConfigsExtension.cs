using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persons.Infrastructure.Configs;

namespace Persons.Infrastructure.Extensions
{
    public static class ConfigsExtension
    {
        public static IServiceCollection LoadConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            JwtConfig jwtConfig = new JwtConfig();
            jwtConfig.SecretKey = configuration.GetValue<string>("JwtConfig:SecretKey");
            jwtConfig.Issuer = configuration.GetValue<string>("JwtConfig:Issuer");
            jwtConfig.Audience = configuration.GetValue<string>("JwtConfig:Audience");
            services.AddSingleton(b => jwtConfig);
            return services;
        }
    }
}
