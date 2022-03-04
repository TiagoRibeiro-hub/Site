using Data.Infrastructure.Data._dbContextConfig;
using Data.Infrastructure.Data._Entities;
using Microsoft.EntityFrameworkCore;

namespace _00.Game.Initialize.Data._DbContext;
#nullable disable
public class InitializeGameDbContext : DbContext
{
    public InitializeGameDbContext(DbContextOptions<InitializeGameDbContext> options) : base(options)
    {

    }
    public DbSet<GameEntity> InitializeGames { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.CreatingGameEntity();
        base.OnModelCreating(modelBuilder);
    }
}