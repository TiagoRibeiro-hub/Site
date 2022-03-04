using Data.Infrastructure.Infrastructure.Repository.Read;
using Data.Infrastructure.Infrastructure.Repository.Write;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Infrastructure.Infrastructure.Repository;

public static class RepositoryServiceConfig
{
    public static void AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
    }
}