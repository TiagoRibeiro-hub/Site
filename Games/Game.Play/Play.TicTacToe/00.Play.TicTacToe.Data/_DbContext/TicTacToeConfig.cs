using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace _00.Play.TicTacToe.Data._DbContext;
public static class TicTacToeConfig
{
    public static void AddTicTacToeDbContext(this IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        services.AddDbContext<TicTacToeDbContext>(config =>
        {
            config.UseSqlServer(configuration.GetConnectionString("TicTacToeConnection"), config =>
            {
                config.MigrationsAssembly("00.Play.TicTacToe.Data");
            });
        });

        services.AddScoped<IDesignTimeDbContextFactory<TicTacToeDbContext>, TicTacToeDbContextFactory>();
    }
}
