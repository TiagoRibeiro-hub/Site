using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Data._DbContext;

public class RegisteredPlayersDbContextFactory : IDesignTimeDbContextFactory<RegisteredPlayersDbContext>
{
    public RegisteredPlayersDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<RegisteredPlayersDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("RegisteredPlayersConnection"), config =>
        {
            config.MigrationsAssembly("00.Games.RegisterPlayer.Data");
        });

        return new RegisteredPlayersDbContext(builder.Options);
    }
}