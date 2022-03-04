using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Data._DbContext;
public static class RegisteredPlayersConfig
{
    public static void AddRegisteredPlayersDbContext(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        services.AddDbContext<RegisteredPlayersDbContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("RegisteredPlayersConnection"), config =>
            {
                config.MigrationsAssembly("00.Games.RegisterPlayer.Data");
            });
        });

        services.AddScoped<IDesignTimeDbContextFactory<RegisteredPlayersDbContext>, RegisteredPlayersDbContextFactory>();
    }
}
