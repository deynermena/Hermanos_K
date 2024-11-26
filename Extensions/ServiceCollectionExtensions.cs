using Microsoft.Extensions.DependencyInjection;
using HermanosK.Services;
using HermanosK.Repositories;
using HermanosK.Factories;
using HermanosK.Models;

namespace HermanosK.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Factories
            services.AddScoped<IEntityFactory<Feature>, FeatureFactory>();

            // Services
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IServiceService, ServiceService>();

            return services;
        }
    }
}