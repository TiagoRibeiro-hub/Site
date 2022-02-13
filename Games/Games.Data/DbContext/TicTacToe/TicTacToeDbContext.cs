namespace Games.Data;
#nullable disable
public class TicTacToeDbContext : DbContext
{
    public TicTacToeDbContext(DbContextOptions<TicTacToeDbContext> options) : base(options)
    {

    }
    public DbSet<GameEntity> Games { get; set; }
    public DbSet<MovesEntity> Moves { get; set; }

    public DbSet<ScoresTableEntity> ScoresTable { get; set; }

    public DbSet<TotalGamesVsHumanEntity> TotalGamesVsHuman { get; set; }
    public DbSet<TotalGamesVsComputerEntity> TotalGamesVsComputer { get; set; }

    public DbSet<TotalGamesEasyEntity> TotalGamesEasy { get; set; }
    public DbSet<TotalGamesIntermediateEntity> TotalGamesIntermediate { get; set; }
    public DbSet<TotalGamesHardEntity> TotalGamesHard { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.CreatingModelBuilder();
        base.OnModelCreating(modelBuilder);
    }
}
