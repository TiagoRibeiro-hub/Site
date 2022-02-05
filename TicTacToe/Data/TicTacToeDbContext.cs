using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
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

    public DbSet<TotalGamesVsHumanModel> TotalGamesVsHuman { get; set; }
    public DbSet<TotalGamesVsComputerModel> TotalGamesVsComputer { get; set; }

    public DbSet<TotalGamesEasyModel> TotalGamesEasy { get; set; }
    public DbSet<TotalGamesIntermediateModel> TotalGamesIntermediate { get; set; }
    public DbSet<TotalGamesHardModel> TotalGamesHard { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Game
        modelBuilder.Entity<GameModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.Player1_Name).HasColumnType("nvarchar(50)").IsRequired();
            b.Property(x => x.Player2_Name).HasColumnType("nvarchar(50)").IsRequired();
            b.Property(x => x.IsComputer).HasColumnType("bit").IsRequired();
            b.Property(x => x.Difficulty).HasColumnType("nvarchar(20)").IsRequired(false);
            b.Property(x => x.StartFirst).HasColumnType("nvarchar(50)").IsRequired();
            b.Property(x => x.DateTimeStart).HasColumnType("datetime2").IsRequired();
            b.Property(x => x.DateTimeEnd).HasColumnType("datetime2").IsRequired();

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("Game");

        });

        // Moves
        modelBuilder.Entity<MovesModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.PlayerName).HasColumnType("nvarchar(50)").IsRequired();
            b.Property(x => x.Move).HasColumnType("int").IsRequired();
            b.Property(x => x.MoveNumber).HasColumnType("int").IsRequired();
            b.Property(x => x.DateTimeMove).HasColumnType("datetime2").IsRequired();

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("Moves");

            //Relations
            b.HasOne(x => x.Game).WithMany(x => x.Moves).HasForeignKey(x => x.GameId).OnDelete(DeleteBehavior.Cascade);

        });

        #region ScoresTable

        // ScoresTable
        modelBuilder.Entity<ScoresTableModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.Email).HasColumnType("nvarchar(50)").IsRequired();
            b.Property(x => x.PlayerName).HasColumnType("nvarchar(50)").IsRequired();


            //Keys
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.PlayerName);

            //Table Name
            b.ToTable("ScoresTable");

            //Relations
            b.HasOne(x => x.TotalGamesVsHuman).WithOne(x => x.ScoresTable).HasForeignKey<TotalGamesVsHumanModel>(x => x.ScoreTableId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.TotalGamesVsComputer).WithOne(x => x.ScoresTable).HasForeignKey<TotalGamesVsComputerModel>(x => x.ScoreTableId).OnDelete(DeleteBehavior.Cascade);

        });


        #region TotalGamesVsHuman

        // TotalGamesVsHuman
        modelBuilder.Entity<TotalGamesVsHumanModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.StartFirst).HasColumnType("int").IsRequired();
            b.Property(x => x.StartSecond).HasColumnType("int").IsRequired();
            b.Property(x => x.TotalGames).HasColumnType("int").IsRequired();
            b.Property(x => x.Victories).HasColumnType("int").IsRequired();
            b.Property(x => x.Losses).HasColumnType("int").IsRequired();
            b.Property(x => x.Ties).HasColumnType("int").IsRequired();

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("TotalGamesVsHuman");

        });

        #endregion

        #region TotalGameVsComputer

        // TotalGamesVsComputer
        modelBuilder.Entity<TotalGamesVsComputerModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("TotalGamesVsComputer");

            //Relations
            b.HasOne(x => x.TotalGamesEasy).WithOne(x => x.TotalGamesVsComputer).HasForeignKey<TotalGamesEasyModel>(x => x.TotalGamesVsComputerId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.TotalGamesIntermediate).WithOne(x => x.TotalGamesVsComputer).HasForeignKey<TotalGamesIntermediateModel>(x => x.TotalGamesVsComputerId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.TotalGamesHard).WithOne(x => x.TotalGamesVsComputer).HasForeignKey<TotalGamesHardModel>(x => x.TotalGamesVsComputerId).OnDelete(DeleteBehavior.Cascade);

        });

        // TotalGamesEasy
        modelBuilder.Entity<TotalGamesEasyModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.StartFirst).HasColumnType("int").IsRequired();
            b.Property(x => x.StartSecond).HasColumnType("int").IsRequired();
            b.Property(x => x.TotalGames).HasColumnType("int").IsRequired();
            b.Property(x => x.Victories).HasColumnType("int").IsRequired();
            b.Property(x => x.Losses).HasColumnType("int").IsRequired();
            b.Property(x => x.Ties).HasColumnType("int").IsRequired();

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("TotalGamesEasy");

        });

        // TotalGamesIntermediate
        modelBuilder.Entity<TotalGamesIntermediateModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.StartFirst).HasColumnType("int").IsRequired();
            b.Property(x => x.StartSecond).HasColumnType("int").IsRequired();
            b.Property(x => x.TotalGames).HasColumnType("int").IsRequired();
            b.Property(x => x.Victories).HasColumnType("int").IsRequired();
            b.Property(x => x.Losses).HasColumnType("int").IsRequired();
            b.Property(x => x.Ties).HasColumnType("int").IsRequired();

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("TotalGamesIntermediate");

        });

        // TotalGamesHard
        modelBuilder.Entity<TotalGamesHardModel>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.StartFirst).HasColumnType("int").IsRequired();
            b.Property(x => x.StartSecond).HasColumnType("int").IsRequired();
            b.Property(x => x.TotalGames).HasColumnType("int").IsRequired();
            b.Property(x => x.Victories).HasColumnType("int").IsRequired();
            b.Property(x => x.Losses).HasColumnType("int").IsRequired();
            b.Property(x => x.Ties).HasColumnType("int").IsRequired();

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("TotalGamesHard");

        });

        #endregion

        #endregion

        base.OnModelCreating(modelBuilder);
    }
}

public class TicTacToeDbContextFactory : IDesignTimeDbContextFactory<TicTacToeDbContext>
{
    public TicTacToeDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).AddJsonFile("appsettings.json").Build();

        var builder = new DbContextOptionsBuilder<TicTacToeDbContext>();

        builder.UseSqlServer(configuration.GetConnectionString("TicTacToeConnection"), config =>
        {
            config.MigrationsAssembly("Data");
        });

        return new TicTacToeDbContext(builder.Options);
    }
}

