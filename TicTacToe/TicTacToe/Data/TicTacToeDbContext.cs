using Microsoft.EntityFrameworkCore;
namespace TicTacToe.Data;
#nullable disable
public class TicTacToeDbContext : DbContext
{
    public DbSet<GameModel> Games { get; set; }
    public DbSet<MovesModel> Moves { get; set; }
    public DbSet<ScoresTableModel> ScoresTable { get; set; }
    public DbSet<TotalGamesVsComputerModel> TotalGamesVsComputer { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        if (baseDir.Contains("bin"))
        {
            int index = baseDir.IndexOf("bin");
            baseDir = baseDir.Substring(0, index);
        }
        options.UseSqlite($"Data Source={baseDir}Data\\Database\\tictactoe.db");
    }



}

