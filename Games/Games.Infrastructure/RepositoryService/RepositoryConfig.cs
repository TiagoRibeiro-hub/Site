using Games.Infrastructure.RepositoryService;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Infrastructure;
public static class RepositoryConfig
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IRepository, Repository>();
    }
}
