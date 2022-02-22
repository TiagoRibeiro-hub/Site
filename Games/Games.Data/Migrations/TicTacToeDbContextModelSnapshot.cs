﻿// <auto-generated />
using System;
using Games.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Games.Data.Migrations
{
    [DbContext(typeof(TicTacToeDbContext))]
    partial class TicTacToeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Games.Data.Data.GameEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Difficulty")
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsComputer")
                        .HasColumnType("bit");

                    b.Property<string>("Player1_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Player2_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StartFirst")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.MovesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTimeMove")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("MoveFrom")
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("MoveNumber")
                        .HasColumnType("int");

                    b.Property<string>("MoveTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Moves", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.ScoresTableEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PlayerName");

                    b.ToTable("ScoresTable", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesEasyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<int>("StartFirst")
                        .HasColumnType("int");

                    b.Property<int>("StartSecond")
                        .HasColumnType("int");

                    b.Property<int>("Ties")
                        .HasColumnType("int");

                    b.Property<int>("TotalGames")
                        .HasColumnType("int");

                    b.Property<int>("TotalGamesVsComputerId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TotalGamesVsComputerId")
                        .IsUnique();

                    b.ToTable("TotalGamesEasy", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesHardEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<int>("StartFirst")
                        .HasColumnType("int");

                    b.Property<int>("StartSecond")
                        .HasColumnType("int");

                    b.Property<int>("Ties")
                        .HasColumnType("int");

                    b.Property<int>("TotalGames")
                        .HasColumnType("int");

                    b.Property<int>("TotalGamesVsComputerId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TotalGamesVsComputerId")
                        .IsUnique();

                    b.ToTable("TotalGamesHard", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesIntermediateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<int>("StartFirst")
                        .HasColumnType("int");

                    b.Property<int>("StartSecond")
                        .HasColumnType("int");

                    b.Property<int>("Ties")
                        .HasColumnType("int");

                    b.Property<int>("TotalGames")
                        .HasColumnType("int");

                    b.Property<int>("TotalGamesVsComputerId")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TotalGamesVsComputerId")
                        .IsUnique();

                    b.ToTable("TotalGamesIntermediate", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesVsComputerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ScoreTableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScoreTableId")
                        .IsUnique();

                    b.ToTable("TotalGamesVsComputer", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesVsHumanEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<int>("ScoreTableId")
                        .HasColumnType("int");

                    b.Property<int>("StartFirst")
                        .HasColumnType("int");

                    b.Property<int>("StartSecond")
                        .HasColumnType("int");

                    b.Property<int>("Ties")
                        .HasColumnType("int");

                    b.Property<int>("TotalGames")
                        .HasColumnType("int");

                    b.Property<int>("Victories")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ScoreTableId")
                        .IsUnique();

                    b.ToTable("TotalGamesVsHuman", (string)null);
                });

            modelBuilder.Entity("Games.Data.Data.MovesEntity", b =>
                {
                    b.HasOne("Games.Data.Data.GameEntity", "Game")
                        .WithMany("Moves")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesEasyEntity", b =>
                {
                    b.HasOne("Games.Data.Data.TotalGamesVsComputerEntity", "TotalGamesVsComputer")
                        .WithOne("TotalGamesEasy")
                        .HasForeignKey("Games.Data.Data.TotalGamesEasyEntity", "TotalGamesVsComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TotalGamesVsComputer");
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesHardEntity", b =>
                {
                    b.HasOne("Games.Data.Data.TotalGamesVsComputerEntity", "TotalGamesVsComputer")
                        .WithOne("TotalGamesHard")
                        .HasForeignKey("Games.Data.Data.TotalGamesHardEntity", "TotalGamesVsComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TotalGamesVsComputer");
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesIntermediateEntity", b =>
                {
                    b.HasOne("Games.Data.Data.TotalGamesVsComputerEntity", "TotalGamesVsComputer")
                        .WithOne("TotalGamesIntermediate")
                        .HasForeignKey("Games.Data.Data.TotalGamesIntermediateEntity", "TotalGamesVsComputerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TotalGamesVsComputer");
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesVsComputerEntity", b =>
                {
                    b.HasOne("Games.Data.Data.ScoresTableEntity", "ScoresTable")
                        .WithOne("TotalGamesVsComputer")
                        .HasForeignKey("Games.Data.Data.TotalGamesVsComputerEntity", "ScoreTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScoresTable");
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesVsHumanEntity", b =>
                {
                    b.HasOne("Games.Data.Data.ScoresTableEntity", "ScoresTable")
                        .WithOne("TotalGamesVsHuman")
                        .HasForeignKey("Games.Data.Data.TotalGamesVsHumanEntity", "ScoreTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScoresTable");
                });

            modelBuilder.Entity("Games.Data.Data.GameEntity", b =>
                {
                    b.Navigation("Moves");
                });

            modelBuilder.Entity("Games.Data.Data.ScoresTableEntity", b =>
                {
                    b.Navigation("TotalGamesVsComputer");

                    b.Navigation("TotalGamesVsHuman");
                });

            modelBuilder.Entity("Games.Data.Data.TotalGamesVsComputerEntity", b =>
                {
                    b.Navigation("TotalGamesEasy");

                    b.Navigation("TotalGamesHard");

                    b.Navigation("TotalGamesIntermediate");
                });
#pragma warning restore 612, 618
        }
    }
}
