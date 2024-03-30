using DemoKafka.DomainServices.Interfaces.Repositories;
using DemoKafka.PersistenceEFCore.DataContexts;
using DemoKafka.PersistenceEFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoKafka.PersistenceEFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistenceEFCore(
            this IServiceCollection services,
            IConfiguration configuration,
            string connectionStringName)
        {
            services.AddDbContext<DemoKafkaContext>(option =>
                option.UseMySQL(
                    configuration.GetConnectionString(connectionStringName)));

            services.AddScoped<IRegisterOrderRepository, RegisterOrderRepository>();
            services.AddScoped<IRegisterNotificationMessageRepository, RegisterNotificationMessageRepository>();

            return services;
        }
    }
}
