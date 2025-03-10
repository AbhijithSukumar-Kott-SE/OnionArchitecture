using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OnionArchitecture.Infrastructure.DBContext;
using OnionArchitecture.Infrastructure.Repositories;
using OnionArchitecture.Core.Interfaces;

namespace OnionArchitecture.Infrastructure
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register MongoDB context using the already registered IMongoClient
            services.AddSingleton<MongoDbContext>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                var databaseName = configuration["MongoDbSettings:DatabaseName"];
                return new MongoDbContext(client, databaseName!);
            });

            services.AddScoped<IBlogRepository, BlogRepository>();

            return services;  
        }
    }
}
