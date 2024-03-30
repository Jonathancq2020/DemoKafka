using DemoKafka.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace DemoKafka.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                    {
                        cfg.RegisterServicesFromAssembly(typeof(RegisterOrderUseCase).Assembly);
                    });
            return services;
        }
    }
}
