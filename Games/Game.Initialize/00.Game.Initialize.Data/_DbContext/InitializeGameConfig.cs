using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace _00.Game.Initialize.Data._DbContext;
public static class InitializeGameConfig
{
    public static void AddInitializeGameDbContext(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        services.AddDbContext<InitializeGameDbContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("InitializeGameConnection"), config =>
            {
                config.MigrationsAssembly("00.Game.Initialize.Data");
            });
        });

        services.AddScoped<IDesignTimeDbContextFactory<InitializeGameDbContext>, InitializeGameDbContextFactory>();
    }
}
