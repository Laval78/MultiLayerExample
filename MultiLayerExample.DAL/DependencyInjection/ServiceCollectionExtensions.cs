using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiLayerExample.DAL.Data;
using MultiLayerExample.DAL.Repositories;
using MultiLayerExample.Domain.Interfaces.Repository;

namespace MultiLayerExample.DAL.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ExampleDbContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
