using Data.Infrastructure.Config;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace _02.Play.TicTacToe.Core.Events;
public static class MassTransitConfig
{
    public static void AddMassTransitService(this IServiceCollection services)
    {
        services.AddMassTransitServiceConfig();

        var busControl = Bus.Factory.CreateUsingRabbitMq(config =>
        {
            config.ReceiveEndpoint("InitializeGame", e =>
            {
                e.Consumer<InitializeGameConsumer>();
            });
        });

        busControl.Start();
    }
}

