using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission13.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeamName = table.Column<string>(nullable: true),
                    CaptainId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Bowlers",
                columns: table => new
                {
                    BowlerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BowlerLastName = table.Column<string>(nullable: true),
                    BowlerFirstName = table.Column<string>(nullable: true),
                    BowlerMiddleInit = table.Column<string>(nullable: true),
                    BowlerAddress = table.Column<string>(nullable: true),
                    BowlerCity = table.Column<string>(nullable: true),
                    BowlerState = table.Column<string>(nullable: true),
                    BowlerZip = table.Column<string>(nullable: true),
                    BowlerPhoneNumber = table.Column<string>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowlers", x => x.BowlerId);
                    table.ForeignKey(
                        name: "FK_Bowlers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bowlers_TeamId",
                table: "Bowlers",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bowlers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
