using _00.Infrastructure.Repository.Read;
using _00.Infrastructure.Repository.Write;
using Microsoft.Extensions.DependencyInjection;

namespace _00.Infrastructure.Repository;

public static class RepositoryServiceConfig
{
    public static void AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
    }
}