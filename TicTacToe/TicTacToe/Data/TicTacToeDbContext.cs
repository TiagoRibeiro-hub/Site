using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace TicTacToe.Data;
#nullable disable
public class TicTacToeDbContext : DbContext
{
    public TicTacToeDbContext(DbContextOptions<TicTacToeDbContext> options) : base(options)
    {

    }
    public DbSet<GameModel> Games { get; set; }
    public DbSet<MovesModel> Moves { get; set; }
    public DbSet<ScoresTableModel> ScoresTable { get; set; }
    public DbSet<TotalGamesVsComputerModel> TotalGamesVsComputer { get; set; }


}

public class TicTacToeDbContextFactory : IDesignTimeDbContextFactory<TicTacToeDbContext>
{
    public TicTacToeDbContext CreateDbContext(string[] args)
    {
        //var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<TicTacToeDbContext>();
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        if (baseDir.Contains("bin"))
        {
            int index = baseDir.IndexOf("bin");
            baseDir = baseDir.Substring(0, index);
        }
        builder.UseSqlite($"Data Source={baseDir}Data\\Database\\tictactoe.db");
        return new TicTacToeDbContext(builder.Options);
    }
}

