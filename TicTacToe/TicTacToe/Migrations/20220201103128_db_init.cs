using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicTacToe.Migrations
{
    public partial class db_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdGame = table.Column<Guid>(type: "TEXT", nullable: false),
                    Player1_Name = table.Column<string>(type: "TEXT", nullable: true),
                    Player2_Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoresTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerName = table.Column<string>(type: "TEXT", nullable: true),
                    Victories = table.Column<int>(type: "INTEGER", nullable: false),
                    Losses = table.Column<int>(type: "INTEGER", nullable: false),
                    Ties = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalGames = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalGamesVsHuman = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoresTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerName = table.Column<string>(type: "TEXT", nullable: true),
                    Move = table.Column<int>(type: "INTEGER", nullable: false),
                    GameModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Games_GameModelId",
                        column: x => x.GameModelId,
                        principalTable: "Games",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TotalGamesVsComputer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalGames = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalGamesEasy = table.Column<string>(type: "TEXT", nullable: false),
                    TotalGamesIntermediate = table.Column<string>(type: "TEXT", nullable: false),
                    TotalGamesHard = table.Column<string>(type: "TEXT", nullable: false),
                    ScoresTableModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalGamesVsComputer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalGamesVsComputer_ScoresTable_ScoresTableModelId",
                        column: x => x.ScoresTableModelId,
                        principalTable: "ScoresTable",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameModelId",
                table: "Moves",
                column: "GameModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TotalGamesVsComputer_ScoresTableModelId",
                table: "TotalGamesVsComputer",
                column: "ScoresTableModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "TotalGamesVsComputer");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "ScoresTable");
        }
    }
}
