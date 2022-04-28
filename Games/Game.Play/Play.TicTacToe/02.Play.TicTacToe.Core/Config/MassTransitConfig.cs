using _02.Play.TicTacToe.Core.Events;
using Data.Infrastructure.Config;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace _02.Play.TicTacToe.Core.Config;
public static class MassTransitConfig
{
    public static void AddMassTransitService(this IServiceCollection services)
    {
        services.AddMassTransit(config =>
        {
            config.AddDelayedMessageScheduler();
            config.SetKebabCaseEndpointNameFormatter();

            config.AddConsumer<InitializeGameConsumer>(typeof(InitializeGameConsumerDefenition))
                .Endpoint(e =>
                {
                    e.Name = "InitializeGame";
                    e.Temporary = false;
                    e.PrefetchCount = 20;
                });

            config.UsingRabbitMq((cxt, cfg) =>
            {
                cfg.Host("localhost", "/", h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                cfg.ConfigureEndpoints(cxt);

                cfg.UseDelayedMessageScheduler();
                cfg.UseMessageRetry(r =>
                {
                    r.Interval(3, TimeSpan.FromSeconds(5));
                });
            });
        });

        services.AddMassTransitHostOptConfig();
    }
}

