using DemoKafka.DomainServices.Interfaces.Services;
using DemoKafka.Services.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace DemoKafka.Services
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IEventProducer, EventProducer>();

            return services;
        }
    }
}
