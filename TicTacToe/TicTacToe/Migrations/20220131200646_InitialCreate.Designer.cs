﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToe.Data;

#nullable disable

namespace TicTacToe.Migrations
{
    [DbContext(typeof(TicTacToeDbContext))]
    [Migration("20220131200646_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("TicTacToe.Data.GameModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Player1_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Player2_Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TicTacToe.Data.MovesModels", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GameModelId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Move")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MoveNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayerName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GameModelId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("TicTacToe.Data.MovesModels", b =>
                {
                    b.HasOne("TicTacToe.Data.GameModel", null)
                        .WithMany("Moves")
                        .HasForeignKey("GameModelId");
                });

            modelBuilder.Entity("TicTacToe.Data.GameModel", b =>
                {
                    b.Navigation("Moves");
                });
#pragma warning restore 612, 618
        }
    }
}