using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class db_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Player2_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsComputer = table.Column<bool>(type: "bit", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoresTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Victories = table.Column<int>(type: "int", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Ties = table.Column<int>(type: "int", nullable: false),
                    TotalGames = table.Column<int>(type: "int", nullable: false),
                    TotalGamesVsHuman = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoresTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Move = table.Column<int>(type: "int", nullable: false),
                    MoveNumber = table.Column<int>(type: "int", nullable: false),
                    DateTimeMove = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TotalGamesVsComputer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalGames = table.Column<int>(type: "int", nullable: false),
                    TotalGamesEasy = table.Column<int>(type: "int", nullable: false),
                    TotalGamesIntermediate = table.Column<int>(type: "int", nullable: false),
                    TotalGamesHard = table.Column<int>(type: "int", nullable: false),
                    ScoreTableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TotalGamesVsComputer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TotalGamesVsComputer_ScoresTable_ScoreTableId",
                        column: x => x.ScoreTableId,
                        principalTable: "ScoresTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameId",
                table: "Moves",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoresTable_PlayerName",
                table: "ScoresTable",
                column: "PlayerName");

            migrationBuilder.CreateIndex(
                name: "IX_TotalGamesVsComputer_ScoreTableId",
                table: "TotalGamesVsComputer",
                column: "ScoreTableId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "TotalGamesVsComputer");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "ScoresTable");
        }
    }
}
