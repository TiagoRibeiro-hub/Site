using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Infrastructure.Config;

public static class MassTransitServicesConfig
{
    public static void AddMassTransitHostOptConfig(this IServiceCollection services)
    {
        services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    options.WaitUntilStarted = true;
                    options.StartTimeout = TimeSpan.FromSeconds(10);
                    options.StopTimeout = TimeSpan.FromSeconds(30);
                });
    }
}