using Microsoft.Extensions.DependencyInjection;

namespace Repository;

public static class RepositoryServiceConfig
{
    public static void AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}