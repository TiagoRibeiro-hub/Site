using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _00.Games.RegisterPlayer.Data.Data._DbContext;

public class RegisteredPlayersDbContext : DbContext
{
    public RegisteredPlayersDbContext(DbContextOptions<RegisteredPlayersDbContext> options) : base(options)
    {

    }
    public DbSet<RegisteredPlayersEntity> RegisteredPlayers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisteredPlayersEntity>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.PlayerName).HasColumnType("nvarchar(50)").IsRequired();
            b.Property(x => x.PlayerEmail).HasColumnType("nvarchar(50)").IsRequired();

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("RegisteredPlayers");

        });
        base.OnModelCreating(modelBuilder);
    }
}