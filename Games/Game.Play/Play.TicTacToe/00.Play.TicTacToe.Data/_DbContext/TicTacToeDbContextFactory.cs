using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace _00.Play.TicTacToe.Data._DbContext;

public class TicTacToeDbContextFactory : IDesignTimeDbContextFactory<TicTacToeDbContext>
{
    public TicTacToeDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<TicTacToeDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("TicTacToeConnection"), config =>
        {
            config.MigrationsAssembly("00.Play.TicTacToe.Data");
        });

        return new TicTacToeDbContext(builder.Options);
    }
}