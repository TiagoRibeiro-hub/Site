using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace _06.TicTacToe.Infrastructure.Data;

public class TicTacToeDbContextFactory : IDesignTimeDbContextFactory<TicTacToeDbContext>
{
    public TicTacToeDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<TicTacToeDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("TicTacToeConnection"), config =>
        {
            config.MigrationsAssembly("06.TicTacToe.Infrastructure");
        });

        return new TicTacToeDbContext(builder.Options);
    }
}