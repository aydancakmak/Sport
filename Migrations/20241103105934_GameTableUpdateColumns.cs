using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sports.MVC.Migrations
{
    /// <inheritdoc />
    public partial class GameTableUpdateColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Duration",
                table: "Games",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Games");
        }
    }
}
