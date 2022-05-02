using Core.Notifications;
using Domain.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace Application
{

    public static class ConfiguracaoServicos
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);
            services.AddSingleton<InMemoryDatabaseContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<NotificationContext>();

            return services;
        }
    }
}