using Data.Infrastructure.Data._Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Infrastructure.Data._dbContextConfig;
public static class ModelBuilderCreating
{
    public static ModelBuilder CreatingRegisteredPlayersEntity(this ModelBuilder modelBuilder)
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
        return modelBuilder;
    }

    public static ModelBuilder CreatingGameEntity(this ModelBuilder modelBuilder)
    {
        // Game
        modelBuilder.Entity<GameEntity>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x._GameId).HasColumnType("nvarchar(150)").IsRequired();
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
        return modelBuilder;
    }
    public static ModelBuilder CreatingModelBuilder(this ModelBuilder modelBuilder)
    {
        // Game
        modelBuilder.CreatingGameEntity();

        // Moves
        modelBuilder.Entity<MovesEntity>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.PlayerName).HasColumnType("nvarchar(50)").IsRequired();
            b.Property(x => x.MoveTo).HasColumnType("nvarchar(15)").IsRequired();
            b.Property(x => x.MoveFrom).HasColumnType("nvarchar(15)").IsRequired(false);
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
        modelBuilder.Entity<ScoresTableEntity>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;
            b.Property(x => x.PlayerName).HasColumnType("nvarchar(50)").IsRequired();


            //Keys
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.PlayerName);

            //Table Name
            b.ToTable("ScoresTable");

            //Relations
            b.HasOne(x => x.TotalGamesVsHuman).WithOne(x => x.ScoresTable).HasForeignKey<TotalGamesVsHumanEntity>(x => x.ScoreTableId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.TotalGamesVsComputer).WithOne(x => x.ScoresTable).HasForeignKey<TotalGamesVsComputerEntity>(x => x.ScoreTableId).OnDelete(DeleteBehavior.Cascade);

        });


        #region TotalGamesVsHuman

        // TotalGamesVsHuman
        modelBuilder.Entity<TotalGamesVsHumanEntity>(b =>
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
        modelBuilder.Entity<TotalGamesVsComputerEntity>(b =>
        {
            //Columns
            b.Property(x => x.Id).HasColumnType("int").ValueGeneratedOnAdd().HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn); ;

            //Keys
            b.HasKey(x => x.Id);

            //Table Name
            b.ToTable("TotalGamesVsComputer");

            //Relations
            b.HasOne(x => x.TotalGamesEasy).WithOne(x => x.TotalGamesVsComputer).HasForeignKey<TotalGamesEasyEntity>(x => x.TotalGamesVsComputerId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.TotalGamesIntermediate).WithOne(x => x.TotalGamesVsComputer).HasForeignKey<TotalGamesIntermediateEntity>(x => x.TotalGamesVsComputerId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.TotalGamesHard).WithOne(x => x.TotalGamesVsComputer).HasForeignKey<TotalGamesHardEntity>(x => x.TotalGamesVsComputerId).OnDelete(DeleteBehavior.Cascade);

        });

        // TotalGamesEasy
        modelBuilder.Entity<TotalGamesEasyEntity>(b =>
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
        modelBuilder.Entity<TotalGamesIntermediateEntity>(b =>
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
        modelBuilder.Entity<TotalGamesHardEntity>(b =>
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

        return modelBuilder;
    }
}
