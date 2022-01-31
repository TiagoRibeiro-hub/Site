using Microsoft.EntityFrameworkCore;

namespace TicTacToe.Data;
public class TicTacToeDbContext : DbContext
{
    public DbSet<GameModel> Games { get; set; }
    public DbSet<MovesModels> Moves { get; set; }
    public DbSet<ScoresTableModels> ScoresTable { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        if (baseDir.Contains("bin"))
        {
            int index = baseDir.IndexOf("bin");
            baseDir = baseDir.Substring(0, index);
        }
        options.UseSqlite($"Data Source={baseDir}Data\\tictactoe.db");
    }



}

