using Microsoft.Extensions.DependencyInjection;
using STANWEBAPI.Infrastructure.Security;

namespace STANWEBAPI.Infrastructure.ServiceCollectionExtensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddStanSiteAuthentication(
            this IServiceCollection services
        )
        {
            return services;
        }

        public static IServiceCollection AddPasswordHasher(
            this IServiceCollection services
        )
        {
            services.AddSingleton<IPasswordHasher, PassWordHasher>();
            return services;   
        }
    }
}