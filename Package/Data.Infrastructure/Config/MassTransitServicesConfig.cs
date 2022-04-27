using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Infrastructure.Config;

public static class MassTransitServicesConfig
{
    public static void AddMassTransitServiceConfig(this IServiceCollection services)
    {
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((cxt, cfg) =>
            {
                cfg.Host("localhost", "/", hostRMQ =>
                {
                    hostRMQ.Username("guest");
                    hostRMQ.Password("guest");
                });
                cfg.ConfigureEndpoints(cxt);
            });
        });
    }
}