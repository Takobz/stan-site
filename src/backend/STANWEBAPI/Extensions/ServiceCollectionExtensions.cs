using STANWEBAPI.Filters.Validation;

namespace STANWEBAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDTOValidatorFilters(
            this IServiceCollection services
        )
        {
            services.AddTransient<SignUpRequestValidationFilter>();
            return services;
        }
    }
}