using Microsoft.EntityFrameworkCore.Migrations;

namespace Kolokwium_nr2.Migrations
{
    public partial class AddedPlayer_TeamChampionship_TeamAndRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Championship_Team",
                columns: table => new
                {
                    IdChampionship = table.Column<int>(nullable: false),
                    IdTeam = table.Column<int>(nullable: false),
                    Score = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Championship_Team", x => x.IdChampionship);
                    table.ForeignKey(
                        name: "FK_Championship_Team_Championships_IdChampionship",
                        column: x => x.IdChampionship,
                        principalTable: "Championships",
                        principalColumn: "IdChampionship",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Championship_Team_Teams_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Team",
                columns: table => new
                {
                    IdTeam = table.Column<int>(nullable: false),
                    IdPlayer = table.Column<int>(nullable: false),
                    NumOnShirt = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Team", x => x.IdTeam);
                    table.ForeignKey(
                        name: "FK_Player_Team_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "IdPlayer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Team_Teams_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Teams",
                        principalColumn: "IdTeam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Championship_Team_IdTeam",
                table: "Championship_Team",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Team_IdPlayer",
                table: "Player_Team",
                column: "IdPlayer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Championship_Team");

            migrationBuilder.DropTable(
                name: "Player_Team");
        }
    }
}
