using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sports.MVC.Migrations
{
    /// <inheritdoc />
    public partial class BranchTableUpdateColum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Teams_TeamId",
                table: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_Branches_TeamId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Branches");

            migrationBuilder.CreateTable(
                name: "BranchTeam",
                columns: table => new
                {
                    BranchesId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchTeam", x => new { x.BranchesId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_BranchTeam_Branches_BranchesId",
                        column: x => x.BranchesId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BranchTeam_TeamsId",
                table: "BranchTeam",
                column: "TeamsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchTeam");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Branches",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_TeamId",
                table: "Branches",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Teams_TeamId",
                table: "Branches",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
