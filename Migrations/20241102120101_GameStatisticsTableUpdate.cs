using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sports.MVC.Migrations
{
    /// <inheritdoc />
    public partial class GameStatisticsTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrancId",
                table: "GameStatistics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrancId",
                table: "GameStatistics",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
