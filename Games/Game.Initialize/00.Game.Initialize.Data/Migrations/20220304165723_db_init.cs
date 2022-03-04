using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _00.Game.Initialize.Data.Migrations
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
                    _GameId = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Player1_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Player2_Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    IsComputer = table.Column<bool>(type: "bit", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    StartFirst = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovesEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveNumber = table.Column<int>(type: "int", nullable: false),
                    DateTimeMove = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovesEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovesEntity_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovesEntity_GameId",
                table: "MovesEntity",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovesEntity");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
