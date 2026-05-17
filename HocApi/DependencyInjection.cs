using HocApi.Interfaces.Repository;
using HocApi.Interfaces.Service;
using HocApi.Repositories;
using HocApi.Services;

namespace HocApi
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();

            // Services
            services.AddScoped<IProductService, ProductService>();





            return services;
        }

    }
}
