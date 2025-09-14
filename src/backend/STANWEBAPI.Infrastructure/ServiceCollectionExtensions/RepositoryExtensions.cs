using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using STANWEBAPI.Data.Interfaces;
using STANWEBAPI.Data.Options;
using STANWEBAPI.Infrastructure.Repositories;

namespace STANWEBAPI.Infrastructure.ServiceCollectionExtensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddEventStoreData(
            this IServiceCollection services,
            MongoDBOptions options)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddSingleton<IMongoClient>(sp =>
            {
                return new MongoClient(
                    options.ConnectionString
                );
            });

            return services;
        }
    }
}