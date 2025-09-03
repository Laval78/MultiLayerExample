using Microsoft.Extensions.DependencyInjection;
using MultiLayerExample.BLL.Services;
using MultiLayerExample.DAL.DependencyInjection;
using MultiLayerExample.Domain.Interfaces.Services;

namespace MultiLayerExample.BLL.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services) 
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
