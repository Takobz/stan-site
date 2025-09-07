using Microsoft.Extensions.DependencyInjection;

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
    }
}