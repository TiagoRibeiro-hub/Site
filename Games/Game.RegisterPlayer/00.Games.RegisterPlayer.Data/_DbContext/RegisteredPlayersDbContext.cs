using Data.Infrastructure.Data._dbContextConfig;
using Data.Infrastructure.Data._Entities;
using Microsoft.EntityFrameworkCore;


namespace Data._DbContext;
#nullable disable
public class RegisteredPlayersDbContext : DbContext
{
    public RegisteredPlayersDbContext(DbContextOptions<RegisteredPlayersDbContext> options) : base(options)
    {

    }
    public DbSet<RegisteredPlayersEntity> RegisteredPlayers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.CreatingRegisteredPlayersEntity();
        base.OnModelCreating(modelBuilder);
    }
}