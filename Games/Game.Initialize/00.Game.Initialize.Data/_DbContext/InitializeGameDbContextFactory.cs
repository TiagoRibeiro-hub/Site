using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace _00.Game.Initialize.Data._DbContext;

public class InitializeGameDbContextFactory : IDesignTimeDbContextFactory<InitializeGameDbContext>
{
    public InitializeGameDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<InitializeGameDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("InitializeGameConnection"), config =>
        {
            config.MigrationsAssembly("00.Game.Initialize.Data");
        });

        return new InitializeGameDbContext(builder.Options);
    }
}